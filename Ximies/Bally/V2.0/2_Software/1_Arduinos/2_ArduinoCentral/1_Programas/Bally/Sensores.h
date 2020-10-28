/* Proyecto: Bally 2.0
 * Nombre del desarrollador: "Leonardo Daniel Castro Carbajal"
 * Para: Xpikuos
 * Version: 20.09.20.11.33.52
 * Descripción: "Arduino Central" Controla movimientos cabeza, rotacion e inercia y recibe datos de los sensores de luz y sonido.
 */

//asignacion de pines
#define s_giro_cabeza               2
#define s_inclincacion_cabeza       4
#define s_traccion_esfera           9
#define c_volante_inercia           3
#define s_brazo_izquierdo           6
#define s_brazo_derecho             5
#define led_iluminacion             13

#define sensor_luz                  A0
#define sensor_sonido_izquierdo     A1
#define sensor_sonido_derecho       A2
#define sensor_sonido_trasero       A3

#define SPI_cs_izquierdo            D7
#define SPI_cs_derecho              D8
#define SPI_cs_raspberry            D10
#define SPI_clk                     D11
#define SPI_mosi                    D12
#define SPI_miso                    D3

#define I2C_clk                     A4
#define I2C_data                    A5



//valor devuelto de 0 (oscuridad total) a 255 (máxima iluminación)
byte getIntensidadLuminosa(); 

//valor devuelto de 0 (silencio total) a 255 (máxima intensidad sonora)
byte getIntensidadSonidoIzquierda(); 

//valor devuelto de 0 (silencio total) a 255 (máxima intensidad sonora)
byte getIntensidadSonidoDerecha(); 

//valor devuelto de 0 (silencio total) a 255 (máxima intensidad sonora)
byte getIntensidadSonidoTrasero(); 

//valor devuelto de 0 (contacto) a 255 (máxima distancia)
byte getDistancia(); 

//valor devuelto del sensor Apds 9960 codificado en 4 bits menos significativos:
//0:UP, 1:DOWN, 2:LEFT, 3:RIGHT
byte getGesto(); 

//valor RGB devuelto por referencia del sensor Apds 9960
void getColor(byte *r, byte *g, byte *b); 

//valor de 0 (stop) a 255 (máxima velocidad) si invertido=false
//valor de 255 (máxima velocidad) a 0(stop) si invertido=true
//genera una señal de PWM para controlar el servo que da tracción de la esfera
void traccionEsfera(byte valor, bool invertido); 

//valor de 0 (stop) a 255 (máxima velocidad) si invertido=false
//valor de 255 (máxima velocidad) a 0(stop) si invertido=true
//genera una señal de PWM para controlar el motor del volante de inercia para giros estáticos
void volanteDeInerciaParaGiroEstatico(byte valor, bool invertido); 

//valor de 0 (apagado) a 255 (máxima iluminación) si invertido=false
//valor de 255 (máxima iluminación) a 0(apagado) si invertido=true
//genera una señal de PWM para controlar el LED/FOCO de iluminación
void iluminacion(byte valor, bool invertido);
