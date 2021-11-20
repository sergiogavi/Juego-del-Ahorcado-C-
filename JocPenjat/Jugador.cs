using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JocPenjat
{
    class Jugador
    {

         string nombreJugador;
        int puntuacion=0;
    
        public Jugador() { }

        public Jugador(string nombreJugador) {

            this.nombreJugador = nombreJugador;

        }


        public void setNombre(string nombre)
        {
            this.nombreJugador = nombre;
        }

        public string GetNombre()
        {
            return this.nombreJugador;
        }


        public void setPuntuacion(int puntuacion)
        {
            this.puntuacion = puntuacion;
        }

        public int GetPuntuacion()
        {
            return this.puntuacion;
        }


       



        public static bool CheckNombre(string nombre)
        {
            bool check=false;
            bool tieneEspacios = nombre.Any(c => char.IsSeparator(c));

            if (tieneEspacios) {
                Console.WriteLine("Por favor ingresa un nombre válido, sin espacios");
                check = false;
            }
            
            if (nombre == "")
            {
                Console.WriteLine("Por favor ingresa un nombre válido, el campo no puede dejarse en blanco");

                check = false;
            }
            if(!tieneEspacios && nombre !="") {
                Console.WriteLine("Nombre válido\n Bienvenido: " + nombre); 
                check = true;
            }
            return check;
        }

        public override string ToString()
        {
            return "El jugador: "+nombreJugador+" tiene una puntuación de: "+puntuacion.ToString();
        }

    }
}
