/* Proyecto: Bally 2.0
 * Nombre del desarrollador: "Leonardo Daniel Castro Carbajal"
 * Para: Xpikuos
 * Version: 20.09.20.11.33.52
 * Descripción: "Arduino Central" Controla movimientos cabeza, rotacion e inercia y recibe datos de los sensores de luz y sonido.
 */

#include <Arduino.h>
#include "Sensores.h"



byte getIntensidadLuminosa(){// si el sensor da un valor invertido, entonces descomenta y comenta la otra funcion.
//return (1023 - analogRead(A0))/4; ////lee canal A0, el valor es de 10bits y se divide en 4 para convertirlo en 8 bits, retorna un valor 255-0.
return analogRead(sensor_luz)/4; //lee canal A0, el valor es de 10bits y se divide en 4 para convertirlo en 8 bits, retorna un valor 0-255.
}

byte getIntensidadSonidoIzquierda(){// si el sensor da un valor invertido, entonces descomenta y comenta la otra funcion.
//return (1023 - analogRead(sensor_sonido_izquierdo))/4; ////lee canal A0, el valor es de 10bits y se divide en 4 para convertirlo en 8 bits, retorna un valor 255-0.
return analogRead(sensor_sonido_izquierdo)/4; //lee canal A0, el valor es de 10bits y se divide en 4 para convertirlo en 8 bits, retorna un valor 0-255.
}

byte getIntensidadSonidoDerecha(){// si el sensor da un valor invertido, entonces descomenta y comenta la otra funcion.
//return (1023 - analogRead(sensor_sonido_derecho))/4; ////lee canal A0, el valor es de 10bits y se divide en 4 para convertirlo en 8 bits, retorna un valor 255-0.
return analogRead(sensor_sonido_derecho)/4; //lee canal A0, el valor es de 10bits y se divide en 4 para convertirlo en 8 bits, retorna un valor 0-255.
}

byte getIntensidadSonidoTrasero(){// si el sensor da un valor invertido, entonces descomenta y comenta la otra funcion.
//return (1023 - analogRead(sensor_sonido_trasero))/4; ////lee canal A0, el valor es de 10bits y se divide en 4 para convertirlo en 8 bits, retorna un valor 255-0.
return analogRead(sensor_sonido_trasero)/4; //lee canal A0, el valor es de 10bits y se divide en 4 para convertirlo en 8 bits, retorna un valor 0-255.
}

byte getDistancia(){
  
}

byte getGesto(){
   
}

void getColor(byte *r, byte *g, byte *b){
   
}

void traccionEsfera(byte valor, bool invertido){
   if(invertido){
    analogWrite(s_traccion_esfera, 255 - valor); //valores desde 255 - 0.
   } else{
    analogWrite(s_traccion_esfera, valor);    //valores desde 0 - 255.
   }
}

void volanteDeInerciaParaGiroEstatico(byte valor, bool invertido){
   if(invertido){
    analogWrite(c_volante_inercia, 255 - valor); //valores desde 255 - 0.
   } else{
    analogWrite(c_volante_inercia, valor);    //valores desde 0 - 255.
   }
   
}

void iluminacion(byte valor, bool invertido){
   if(invertido){
    analogWrite(led_iluminacion, 255 - valor); //valores desde 255 - 0.
   } else{
    analogWrite(led_iluminacion, valor);    //valores desde 0 - 255.
   }
  
}
