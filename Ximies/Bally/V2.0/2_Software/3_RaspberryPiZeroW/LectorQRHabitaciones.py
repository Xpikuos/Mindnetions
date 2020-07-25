#!/usr/bin/python3
# -*- coding: utf-8 -*-

'''
- Proyecto: Bally 2.0
- Nombre del desarrollador: "Fernando Jurado Cote"
- Para: Xpikuos
- Version: 20.07.25.19.55.10
- Descripción: busca una pegatina verde con un QR y devuelve el contenido del codigo. 
  Sirve para que BALLY sepa de que habitacion sale y a cual entra
- https://creativecommons.org/licenses/by-nc-sa/4.0/deed.es
'''
#sudo pip3 install opencv-contrib-python==4.1.0.25
#sudo apt-get install libzbar-dev libzbar0 
#sudo pip3 install pyzbar
import pyzbar.pyzbar as pyzbar #libreria para leer qr que soporta python3
import numpy as np
import cv2
#cv2.destroyAllWindows()
cap = cv2.VideoCapture(0)
# bajamos resolucion y frame rate
cap.set(3,320)
cap.set(4,240)
cap.set(cv2.CAP_PROP_FPS, 5)
verdeBajo = np.array([37,25,25],np.uint8)
verdeAlto = np.array([70,255,255],np.uint8)
font = cv2.FONT_HERSHEY_SIMPLEX

def encontrar(mask,color,frame):
  contornos,jerarquia = cv2.findContours(mask, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)# buscamos los contornos 
  for c in contornos:
    area = cv2.contourArea(c)
    if area > 3000: #descartamos lo mas pequeño que este area
      M = cv2.moments(c)
      if (M["m00"]==0): M["m00"]=1
      x = int(M["m10"]/M["m00"])
      y = int(M['m01']/M['m00'])
      print('verde')
      lecturasQR = pyzbar.decode(frame)
      for resul in lecturasQR:
        print('Codigo con el texto', resul.data.decode("utf-8"), 'en X=',x,',    Y=',y)
      
      #este codigo es para pintar las coordenadas y la forma sobre el video,
      #  lo pongo comentado para ahorrar recursos
      '''
      nuevoContorno = cv2.convexHull(c)
      cv2.circle(frame,(x,y),7,(0,255,0),-1)
      cv2.putText(frame,'x{},y{}'.format(x,y),(x+10,y), font, 0.75,(0,255,0),1,cv2.LINE_AA)
      cv2.drawContours(frame, [nuevoContorno], 0, color, 3)
     ''' 


while True:
    ret,frame = cap.read()
    if ret == True:
        frameHSV = cv2.cvtColor(frame,cv2.COLOR_BGR2HSV)
        maskVerde = cv2.inRange(frameHSV,verdeBajo, verdeAlto)
        encontrar(maskVerde,(0,255,0),frame)

        #cv2.imshow('mascara',maskVerde)
        #cv2.imshow('Captura',frame)
        if cv2.waitKey(1) & 0xFF == ord('s'):
          break

cap.release()
cv2.destroyAllWindows()
