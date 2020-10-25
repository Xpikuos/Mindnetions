#!/usr/bin/env python3
'''
- Proyecto: Bally 2.0
- Nombre del desarrollador: "Fernando Jurado Cote"
- Para: Xpikuos
- Version: 25.10.20.10.20.25
- Descripción:  Recibe una fotografia a traves de mqtt y la analiza con Tensorflow Lite.
    Envia los resultados del analisis a la pi Zero de Bally
- https://creativecommons.org/licenses/by-nc-sa/4.0/deed.es
'''

import paho.mqtt.client as mqtt #sudo pip3 install paho-mqtt
import paho.mqtt.publish as publish
import base64
import os
import glob
import time
import cv2 #sudo pip3 install opencv-contrib-python==4.1.0.25
import numpy as np
from tensorflow.lite.python.interpreter import Interpreter
import json
from json import JSONEncoder

MQTT_BROKER = "192.168.0.13" #Ip de la raspberry pi 3
MQTT_PATH = "home/server"
MQTT_RESULTADOS = "home/results"

#Importante tener el directorio 'TFLite_model' con los archivos detect.tflite y labelmap.txt
MODEL_NAME = 'TFLite_model'
GRAPH_NAME = 'detect.tflite'
LABELMAP_NAME = 'labelmap.txt'
min_conf_threshold = 0.45 #Un umbral mas bajo da muchos falsos positivos

#Funcion para convertir el numpy en lista
class NumpyArrayEncoder(JSONEncoder):
    def default(self, obj):
        if isinstance(obj, np.ndarray):
            return obj.tolist()
        return JSONEncoder.default(self, obj)

    
# Esta aplicacion es el subscriber de MQTT 
# recibe un fotograma y lo analiza con TensorFlow Lite

CWD_PATH = os.getcwd()#Obtiene la ruta del directorio actual
# Ruta al archivo .tflite
PATH_TO_CKPT = os.path.join(CWD_PATH,MODEL_NAME,GRAPH_NAME)

# Ruta a las etiquetas
PATH_TO_LABELS = os.path.join(CWD_PATH,MODEL_NAME,LABELMAP_NAME)

# Carga las etiquetas
with open(PATH_TO_LABELS, 'r') as f:
    labels = [line.strip() for line in f.readlines()]

# Si la primera etiqueta es ??? , hay que eliminarla para evitar problemas
if labels[0] == '???':
    del(labels[0])
#cargamos el interprete de TensorFlow Lite
interpreter = Interpreter(model_path=PATH_TO_CKPT)

interpreter.allocate_tensors()

# Recoge los detalles del modelo
input_details = interpreter.get_input_details()
output_details = interpreter.get_output_details()
height = input_details[0]['shape'][1]
width = input_details[0]['shape'][2]

floating_model = (input_details[0]['dtype'] == np.float32)

input_mean = 127.5
input_std = 127.5

def on_connect(client, userdata, flags, rc):
    #print("Connected with result code "+str(rc)) #descomentar si se quiere confirmación en la consola
    client.subscribe(MQTT_PATH)
    #print('suscrito a ', MQTT_PATH) #descomentar si se quiere confirmacion en la consola

def on_message(client, userdata, msg):
    if (msg.payload == 'Q'):
        client.disconnect()
    else:
        #Recibe una imagen desde BALLY
        fotito = base64.b64decode(msg.payload) #Decodifica la imagen
        npimg = np.frombuffer(fotito, dtype=np.uint8)
        image = cv2.imdecode(npimg, 1)   
        
        image_rgb = cv2.cvtColor(image, cv2.COLOR_BGR2RGB)
        imH, imW, _ = image.shape 
        image_resized = cv2.resize(image_rgb, (width, height))
        input_data = np.expand_dims(image_resized, axis=0)
    
        if floating_model:
            input_data = (np.float32(input_data) - input_mean) / input_std

        # Detecta ejecutando el interprete
        interpreter.set_tensor(input_details[0]['index'],input_data)
        interpreter.invoke()

        # Busca los resultados
        boxes = interpreter.get_tensor(output_details[0]['index'])[0] #Coordenadas
        classes = interpreter.get_tensor(output_details[1]['index'])[0] # Indice de los objetos
        scores = interpreter.get_tensor(output_details[2]['index'])[0] # Confianza de los resultados
        
        resultados = np.array([])
      
        # For para buscar los objetos con confianza superior al umbral
        for i in range(len(scores)):
            if ((scores[i] > min_conf_threshold) and (scores[i] <= 1.0)):
                            
                # Obtiene las coordenadas de los objetos
                
                ymin = int(max(1,(boxes[i][0] * imH)))
                xmin = int(max(1,(boxes[i][1] * imW)))
                ymax = int(min(imH,(boxes[i][2] * imH)))
                xmax = int(min(imW,(boxes[i][3] * imW)))
                resultado = labels[int(classes[i])],scores[i],((xmax+xmin)/2 ),((ymax+ymin/2))
                #print(resultado) #Descomentar si se quiere ver los resultados en la consola de la pi3
                resultados = np.append(resultados,str(resultado))
                
        
        parabally = json.dumps(resultados,cls=NumpyArrayEncoder)#Convierte el numpy array a JSON
        client.publish(MQTT_RESULTADOS,parabally)


client = mqtt.Client('CARGA')
client.connect(MQTT_BROKER)

client.on_connect = on_connect
client.on_message = on_message



client.loop_forever() # Se mantiene en bucle esperando mas imagenes para procesar
