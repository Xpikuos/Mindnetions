'''
- Proyecto: Bally 2.0
- Nombre del desarrollador: "Fernando Jurado Cote"
- Para: Xpikuos
- Version: 25.10.20.10.20.25
- Descripción:  Hace una foto y la envia a la Pi 3 de la base de carga para que la analice.
    Se queda en un bucle esperando los resultados y cuando los recibe, los muestra y sale.
- https://creativecommons.org/licenses/by-nc-sa/4.0/deed.es
'''
import cv2 #sudo pip3 install opencv-contrib-python==4.1.0.25
import base64
import time
import numpy as np
import paho.mqtt.client as mqtt #sudo pip3 install paho-mqtt
import paho.mqtt.publish as publish
import paho.mqtt.subscribe as subscribe
import json
MQTT_BROKER = "192.168.0.13" #Direccion Ip de la Raspberry pi 3 de la base de carga
MQTT_PATH = "home/server"
MQTT_RESULTADOS = "home/results"
cap = cv2.VideoCapture(0)
# bajamos resolucion y frame rate a los usados 
cap.set(3,320)
cap.set(4,240)
cap.set(cv2.CAP_PROP_FPS, 5)
time.sleep(1)

ret,frame = cap.read()
clientsend = mqtt.Client('Camara')
clientsend.connect(MQTT_BROKER)


if ret == True:
    retframe, buffer = cv2.imencode('.jpg',frame)
    ba64 = base64.b64encode(buffer)
    clientsend.publish(MQTT_PATH,ba64)
    
cap.release()


def on_connect(client, userdata, rc):
    #print("Connectado "+str(rc)) #Descomentar si quieres mostrar resultado de la conexion
    client.subscribe(MQTT_RESULTADOS)
def on_message(client, userdata, msg):
    datos = json.loads(msg.payload)
    mensajes = np.array(datos)
    print(mensajes)
    client.disconnect() #Se desconecta automaticamente cuando recibe el resultado
    
#Creamos otro cliente de mqtt para recibir la descripción de la imagen
receptor = mqtt.Client('Receptor')
receptor.connect(MQTT_BROKER)
receptor.subscribe(MQTT_RESULTADOS)
receptor.on_connect = on_connect
receptor.on_message = on_message

receptor.loop_forever() #Se queda en bucle esperando el mensaje
