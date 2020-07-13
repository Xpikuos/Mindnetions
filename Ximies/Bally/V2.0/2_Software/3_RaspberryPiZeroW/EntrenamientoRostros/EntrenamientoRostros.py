#!/usr/bin/python3
# -*- coding: utf-8 -*-

'''
- Proyecto: Bally 2.0
- Nombre del desarrollador: "Fernando Jurado Cote"
- Para: Xpikuos
- Version: 20.07.12.11.30.07
- Descripción: Entrena segun las personas de las que ha obtenido rostros y guarda los resultados
- https://creativecommons.org/licenses/by-nc-sa/4.0/deed.es
'''
import time
import numpy as np
import cv2 #sudo pip3 install opencv-contrib-python==4.1.0.25
import imutils
import os

path = '/home/pi/BALLY/Reconocimiento de rostros/Data/' #ruta donde están las imagenes a procesar

peopleList = os.listdir(path) #obtenemos la lista de personas y mostramos sus nombres
print('Lista de personas: ', peopleList)
#creamos los arrays para almacenar las etiquetas (nombre de la persona) 
# Y la información sobre las caras 
labels = []
facesData = []
label = 0

for nameDir in peopleList:
	personPath = path + '/' + nameDir
	print('Leyendo las imágenes')

	for fileName in os.listdir(personPath):
		print('Rostros: ', nameDir  + '/' + fileName)
		labels.append(label)
		facesData.append(cv2.imread(personPath+'/'+fileName,0))
		#image = cv2.imread(personPath+'/'+fileName,0)
		#cv2.imshow('image',image)
		#cv2.waitKey(10)
	label = label + 1
# He optado por LBPHFaceRecognizer por ser mas rapido en cargar y en reconocer los datos
#face_recognizer = cv2.face.EigenFaceRecognizer_create()
#face_recognizer = cv2.face.FisherFaceRecognizer_create()
face_recognizer = cv2.face.LBPHFaceRecognizer_create()

print("Entrenando...")
face_recognizer.train(facesData, np.array(labels))

# Almacenando el modelo obtenido
#face_recognizer.write('modeloEigenFace.xml')
#face_recognizer.write('modeloFisherFace.xml')
face_recognizer.write('modeloLBPHFace.xml')
print("Modelo almacenado...")
