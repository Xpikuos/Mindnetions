#!/usr/bin/python3
# -*- coding: utf-8 -*-

'''
- Proyecto: Bally 2.0
- Nombre del desarrollador: "Fernando Jurado Cote"
- Para: Xpikuos
- Version: 20.07.12.10.38.10
- Descripción: Captura video desde la cámara, y extrae imagenes del rostro para posterior entrenamiento
- https://creativecommons.org/licenses/by-nc-sa/4.0/deed.es
'''
import time
import numpy as np
import cv2 #sudo pip3 install opencv-contrib-python==4.1.0.25
import imutils
import argparse
import os


# Verificamos que se ha facilitado el argumento 'Nombre' de la 
# persona que le queremos 'presentar' a Bally
ap = argparse.ArgumentParser()
ap.add_argument("-n", "--nombre", required=True,
	help="Necesito el nombre de la persona para guardar los datos")
args = vars(ap.parse_args())
nombre = args["nombre"] #extraemos el nombre
path = '/home/pi/BALLY/Reconocimiento de rostros/Data/'
pathpersona = path + nombre + '/'

if not os.path.exists(pathpersona): #creamos la carpeta con el nombre de la persona
    print('Carpeta creada: ',pathpersona)
    os.makedirs(pathpersona)


cap = cv2.VideoCapture(0)
time.sleep(0.5) #arrancamos la camara y le damos un respiro
#cargamos el clasificador haarcascade
faceClassif = cv2.CascadeClassifier(cv2.data.haarcascades+'haarcascade_frontalface_default.xml') 
count = 0

while True:
    
    ret, frame = cap.read()
    if ret == False: break
    gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
    auxFrame = frame.copy()
    faces = faceClassif.detectMultiScale(gray,1.3,5)
    for (x,y,w,h) in faces:
        cv2.rectangle(frame, (x,y),(x+w,y+h),(0,255,0),2)
        rostro = auxFrame[y:y+h,x:x+w]
        rostro = cv2.resize(rostro,(150,150),interpolation=cv2.INTER_CUBIC)
        cv2.imwrite(pathpersona + nombre + '_{}.jpg'.format(count),rostro)
        count = count + 1
    #cv2.imshow('frame',frame)
    k =  cv2.waitKey(1)
    if k == 27 or count >= 300:
        break
cap.release()
cv2.destroyAllWindows()

