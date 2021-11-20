using System;

namespace JocPenjat
{
    class Program
    {
        static void Main(string[] args)
        {
            int continuarPartida = 1;
           while (continuarPartida == 1)
            {
                Console.WriteLine("Bienvenido al juego del ahorcado!\n" + "- ¿Como te llamas?");
            string nombre = Console.ReadLine();
            if (Jugador.CheckNombre(nombre))
            {             
                Jugador jugador1 = new Jugador(nombre);
                Console.WriteLine("Existen diferentes niveles de dificultad, indica con cual quieres jugar:\n" + "1- Fácil\n 2-Medio\n 3-Dificil\n 4-Partida para todos los publicos");
                int dificultad = Convert.ToInt32(Console.ReadLine());
                Partida.creaPartida(nombre, dificultad);
               Console.WriteLine("Volver a jugar otra partida? 1-Si 2-Exit");
               continuarPartida =Convert.ToInt32(Console.ReadLine());
                }
            }

        }
        }
    }

