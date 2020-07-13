#!/usr/bin/python3
# -*- coding: utf-8 -*-

import os
import sys

'''
- Proyecto: Bally 2.0
- Nombre del desarrollador: Diego de los Reyes Rodríguez (diegorys)
- Para: Xpikuos
- Version: 20.07.12.16.10.00
- Descripción: Transforma texto en sonido (TTS). Idioma español. Para instalarlo, previamente hay que instalar las siguientes dependencias:
    sudo apt install espeak
    sudo apt install mbrola mbrola-es1 mbrola-es2
- Licencia: Este trabajo está licenciado bajo la licencia de Atribución-NoComercialCompartirIgual 4.0 Internacional (CC BY-NC-SA 4.0)
    Para ver una copia de esta licencia, visita
    https://creativecommons.org/licenses/by-nc-sa/4.0/deed.es
'''


class Habla():

    def actuar(self, text):
        command = 'espeak -v mb-es1 -s 150 "' + text + '"'
        os.system(command)
        print("robot:$ " + text)


if __name__ == "__main__":
    habla = Habla()
    habla.actuar(sys.argv[1])
