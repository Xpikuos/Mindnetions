#!/usr/bin/python3
# -*- coding: utf-8 -*-

import os
from pocketsphinx import LiveSpeech, get_model_path

'''
- Proyecto: Bally 2.0
- Nombre del desarrollador: Diego de los Reyes Rodríguez (diegorys)
- Para: Xpikuos
- Version: 20.07.12.16.15.00
- Descripción: Transforma sonido en texto (TTS). Idioma español. Para instalarlo, previamente hay que instalar las siguientes dependencias:
    PocketSphinx: https://pypi.org/project/pocketsphinx/
    Idioma español: https://sourceforge.net/projects/cmusphinx/files/Acoustic%20and%20Language%20Models/Spanish/
- Licencia: Este trabajo está licenciado bajo la licencia de Atribución-NoComercialCompartirIgual 4.0 Internacional (CC BY-NC-SA 4.0)
    Para ver una copia de esta licencia, visita
    https://creativecommons.org/licenses/by-nc-sa/4.0/deed.es
'''


class Audicion():

    def actuar(self):
        ruta = get_model_path()
        frases = LiveSpeech(
            verbose=False,
            sampling_rate=16000,
            buffer_size=2048,
            no_search=False,
            full_utt=False,
            hmm=os.path.join(ruta, 'es-es'),
            lm=os.path.join(ruta, 'es-20k.lm.bin'),
            dict=os.path.join(ruta, 'es.dict')
        )
        for frase in frases:
            print(frase)


if __name__ == "__main__":
    audicion = Audicion()
    audicion.actuar()
