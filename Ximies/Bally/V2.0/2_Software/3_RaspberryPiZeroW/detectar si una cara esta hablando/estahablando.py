'''
- Proyecto: Bally 2.0
- Nombre del desarrollador: "Fernando Jurado Cote"
- Para: Xpikuos
- Version: 31.07.20.09.40.10
- Descripción: busca una persona y dice si está hablando basandose en el movimiento de los labios
- https://creativecommons.org/licenses/by-nc-sa/4.0/deed.es
'''
from imutils import face_utils # sudo pip3 install imutils
import numpy as np
import imutils
import dlib #sudo pip3 install dlib
import math
import cv2 #sudo pip3 install opencv-contrib-python==4.1.0.25

path = 'Data/' #donde tenemos el predictor de dlib 
#descargar de http://dlib.net/files/shape_predictor_68_face_landmarks.dat.bz2 y descomprimir 

#devuelve True o False si se estan moviendo o no los labios

def mueveloslabios (pnariz,bnariz,labiosup,labioinf):
	dactual = np.linalg.norm(pnariz-bnariz)
	dlabios = np.linalg.norm(labiosup-labioinf)
	ratio = (dactual+dlabios)/2 #para calcular si la cara se ha movido en el espacio
	#print('ratio= ',ratio, 'dlabios= ',dlabios, 'dlabios/ratio = ',(dlabios/ratio))
	#dividimos la distancia de los labios entre el ratio. probar a variar el valor del
	#umbral si da muchos falsos positivos
	if ((dlabios/ratio)>0.50):
		return True
	else:
		return False

fps = 5 #fps los ponemos a 5 para ahorrar recursos
temporizador = 0
milisegundos = int(fps/4) #calculamos cuantos frames son 250 ms
cap = cv2.VideoCapture(0)
cap.set(3,320)
cap.set(4,240)
cap.set(cv2.CAP_PROP_FPS, fps)
detector = cv2.CascadeClassifier(cv2.data.haarcascades+'haarcascade_frontalface_default.xml')
faceClassif = dlib.shape_predictor(path + 'shape_predictor_68_face_landmarks.dat')
while 1:
	ret,frame = cap.read()
	if ret == False: break
	if temporizador == milisegundos:
		temporizador = 0
		gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
		auxFrame = gray.copy()
		# detecta caras en la escala de grises
		#print('Buscando caras..')
		faces = detector.detectMultiScale(gray,1.3,3)
		for (x,y,w,h) in faces:
			#print('analizando caras')
			dlib_rect = dlib.rectangle(int(x), int(y), int(x + w), int(y + h))
			# busca en todas las caras que ha detectado en el frame
			forma = faceClassif(gray, dlib_rect)
			forma = face_utils.shape_to_np(forma)
			habla = mueveloslabios(forma[30],forma[33],forma[62],forma[66])
			if (habla):
				print('--------->   Está hablando')
	temporizador = temporizador + 1
		
	#cv2.imshow('frame',frame)
	k = cv2.waitKey(1)
	if k == 27:
		break

cap.release()
cv2.destroyAllWindows()


