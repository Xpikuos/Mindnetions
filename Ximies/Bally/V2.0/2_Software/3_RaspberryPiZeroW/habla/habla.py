#!/usr/bin/python3
# -*- coding: utf-8 -*-

import os
import sys
import soundfile as sf
import pyworld as pw
from pygame import mixer
import pygame

'''
- Proyecto: Bally 2.0
- Nombre del desarrollador: Diego de los Reyes Rodríguez (diegorys)
- Para: Xpikuos
- Version: 20.07.20.18.36.00
- Descripción: Transforma texto en sonido (TTS). Idioma español. Para instalarlo, previamente hay que instalar las siguientes dependencias:
    sudo apt install espeak
    sudo apt install mbrola mbrola-es1 mbrola-es2
    sudo pip3 install soundfile pyworld pygame
Puedes probarlo con:
python3 
- Licencia: Este trabajo está licenciado bajo la licencia de Atribución-NoComercialCompartirIgual 4.0 Internacional (CC BY-NC-SA 4.0)
    Para ver una copia de esta licencia, visita
    https://creativecommons.org/licenses/by-nc-sa/4.0/deed.es
'''

VOZ = "mb-es1"
ARCHIVO = "out.wav"
VELOCIDAD_DEL_DISCURSO = 0.6
GRAVEDAD = 0.8
ATENUACION_DEL_VOLUMEN = 1


class Habla():

    def actuar(self, text):
        command = 'espeak -v ' + VOZ + ' "' + text + '" -w ' + ARCHIVO
        os.system(command)
        x, fs = sf.read(ARCHIVO)
        f0, sp, ap = pw.wav2world(x, fs)
        yy = pw.synthesize(f0/GRAVEDAD, sp/ATENUACION_DEL_VOLUMEN, ap,
                           fs/VELOCIDAD_DEL_DISCURSO, pw.default_frame_period)
        sf.write(ARCHIVO, yy, fs)
        mixer.init()
        mixer.music.load(ARCHIVO)
        mixer.music.play()
        while mixer.music.get_busy():
            pygame.time.Clock().tick(10)
        mixer.quit()
        print("robot:$ " + text)


if __name__ == "__main__":
    habla = Habla()
    habla.actuar(sys.argv[1])
