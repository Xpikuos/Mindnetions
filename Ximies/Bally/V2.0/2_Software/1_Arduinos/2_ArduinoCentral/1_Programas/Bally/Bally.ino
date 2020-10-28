/* Proyecto: Bally 2.0
 * Nombre del desarrollador: "Leonardo Daniel Castro Carbajal"
 * Para: Xpikuos
 * Version: 20.09.20.11.33.52
 * Descripción: "Arduino Central" Controla movimientos cabeza, rotacion e inercia y recibe datos de los sensores de luz y sonido.
 */

#include "Sensores.h"

void setup() {
  Serial.begin(115200);
  pinMode(led_iluminacion, OUTPUT);
  pinMode(c_volante_inercia, OUTPUT);

  Serial.println("iniciado..");
  

}

void loop() {
  // put your main code here, to run repeatedly:
  byte pwm = getIntensidadLuminosa();
  iluminacion(pwm, false);
  Serial.print("iluminacion: ");
  Serial.println(pwm);
  delay(500);
}
