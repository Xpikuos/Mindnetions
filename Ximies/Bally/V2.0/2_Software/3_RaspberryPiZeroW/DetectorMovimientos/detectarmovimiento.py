'''
- Proyecto: Bally 2.0
- Nombre del desarrollador: "Fernando Jurado Cote"
- Para: Xpikuos
- Version: 16.08.20.21.44.10
- Descripción: resta los fotogramas impares para detectar movimientos
- https://creativecommons.org/licenses/by-nc-sa/4.0/deed.es
'''
import cv2 #sudo pip3 install opencv-contrib-python==4.1.0.25
fps = 5
contador = 0
cap = cv2.VideoCapture(0)
cap.set(3,320)
cap.set(4,240)
cap.set(cv2.CAP_PROP_FPS, fps)


def buscar(mask):
  contornos,jerarquia = cv2.findContours(mask, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)# buscamos los contornos 
  for c in contornos:
    area = cv2.contourArea(c)
    #print(area)
    if area > 70 and area < 100: #descartamos lo mas pequeño que este area y falsos positivos
      M = cv2.moments(c)
      if (M["m00"]==0): M["m00"]=1
      x = int(M["m10"]/M["m00"])
      y = int(M['m01']/M['m00'])
      print('El objeto en movimiento está en X=',x,',    Y=',y)#muestra las coordenadas

while 1:
    ret,frame = cap.read()
    if ret == False:
            break
    if contador == 0:
        contador = contador + 1
        img1 = frame
    else:
        resta = cv2.subtract(img1,frame)
        contador = 0
        mascara = cv2.cvtColor(resta,cv2.COLOR_BGR2GRAY)
        buscar(mascara)
        #cv2.imshow('resta',resta)
    k = cv2.waitKey(1)
    if k == 27:
        break


