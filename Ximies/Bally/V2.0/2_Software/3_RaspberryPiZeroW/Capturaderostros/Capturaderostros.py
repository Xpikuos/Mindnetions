#!/usr/bin/python3
# -*- coding: utf-8 -*-

'''
- Proyecto: Bally 2.0
- Nombre del desarrollador: "Fernando Jurado Cote"
- Para: Xpikuos
- Version: 20.07.19.19.20.05
- Descripción: Captura video desde la cámara, y extrae imagenes del rostro con las distintas emociones para posterior entrenamiento
- https://creativecommons.org/licenses/by-nc-sa/4.0/deed.es
'''
import time
import numpy as np
import cv2 #sudo pip3 install opencv-contrib-python==4.1.0.25
import imutils
import argparse
import os

cv2.destroyAllWindows()

# Verificamos que se ha facilitado el argumento 'Nombre' de la 
# persona que le queremos 'presentar' a Bally
emociones = ["Alegre","Sorprendido","Triste","Enfadado"]
ap = argparse.ArgumentParser()
ap.add_argument("-n", "--nombre", required=True,
	help="Necesito el nombre de la persona para guardar los datos")
ap.add_argument("-m","--muestras",required=True,type=int,
    help="Especifica el numero de muestras de cada persona o expresion recomendado valor entre 40 y 300")
args = vars(ap.parse_args())
nombre = args["nombre"] #extraemos el nombre
muestras = args["muestras"]
if muestras < 300 and muestras > 40:
    print (muestras)
else:
    muestras = 40
path = './Data/'
pathpersona = path + nombre + '/'


if not os.path.exists(pathpersona): #creamos la carpeta con el nombre de la persona
    print('Carpeta creada: ',pathpersona)
    os.makedirs(pathpersona)


cap = cv2.VideoCapture(0)
time.sleep(0.5) #arrancamos la camara y le damos un respiro
#cargamos el clasificador haarcascade
faceClassif = cv2.CascadeClassifier(cv2.data.haarcascades+'haarcascade_frontalface_default.xml') 
nmuestras = 0
emocion = 0
_ = input ('Pon cara ' + emociones[emocion] + ' y pulsa enter...')
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
        rostro = cv2.normalize(rostro,None,0,255,cv2.NORM_MINMAX)
        cv2.imwrite(pathpersona + nombre + '-' + emociones[emocion] + '_{}.jpg'.format(nmuestras),rostro)
        nmuestras = nmuestras + 1
    #cv2.imshow('frame',frame)
    k =  cv2.waitKey(1)
    if k == 27 or nmuestras >= muestras:
        emocion = emocion+1
        if emocion <= 3:
            nmuestras = 0
            _ = input('Pon cara ' + emociones[emocion] + ' y pulsa enter...')
        else:
            break
cap.release()
cv2.destroyAllWindows()


