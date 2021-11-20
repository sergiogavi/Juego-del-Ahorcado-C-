using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace JocPenjat
{
    class Partida
    {
        string nivelDificultad;

        public Partida() { }


        public static void creaPartida(string nombreJugador, int dificultad)
        {

            //Creación de ficheros y directorios basico para la ejecución y logica del juego
            string newFolder = "JocPenjat";
            string subFolderLogs = "Logs";
            string subFolderRanking = "Ranking";
            string subFolderDificultadPartidas = "DificultadPartidas";
            string path = System.IO.Path.Combine(
               Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
               newFolder
            );

            if (!System.IO.Directory.Exists(path))
            {
                try
                {
                   
                    System.IO.Directory.CreateDirectory(path);
                }
                catch (IOException ie)
                {
                    Console.WriteLine("IO Error: " + ie.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("General Error: " + e.Message);
                }
            }

            //Creación subFolder Logs
            string pathLogs = System.IO.Path.Combine(
              Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
              newFolder, subFolderLogs
           );

            if (!System.IO.Directory.Exists(pathLogs))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(pathLogs);
                }
                catch (IOException ie)
                {
                    Console.WriteLine("IO Error: " + ie.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("General Error: " + e.Message);
                }
            }


            //Creación subFolder Ranking
            string pathRanking = System.IO.Path.Combine(
              Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
              newFolder, subFolderRanking
           );

            if (!System.IO.Directory.Exists(pathRanking))
            {
                try
                {

                    System.IO.Directory.CreateDirectory(pathRanking);
                }
                catch (IOException ie)
                {
                    Console.WriteLine("IO Error: " + ie.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("General Error: " + e.Message);
                }
            }

            //Creación subFolder subFolderDificultadPartidas
            string pathDificultadPartida = System.IO.Path.Combine(
              Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
              newFolder, subFolderDificultadPartidas
           );

            if (!System.IO.Directory.Exists(pathDificultadPartida))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(pathDificultadPartida);
                }
                catch (IOException ie)
                {
                    Console.WriteLine("IO Error: " + ie.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("General Error: " + e.Message);
                }
            }


            //Trabajando en el directorio Logs con fichero de log de cada usuario
            
            Logger.Write(Path.Combine(pathLogs, nombreJugador+".txt"), nombreJugador);



            //Según la dificultad seleccionada irá a parar a un método u otro para la lógica del juego

            if (dificultad==1) {
                string dificultad1 = "facil";
                Console.WriteLine("Has seleccionado dificultad Fácil");
                Thread.Sleep(1000);
                Console.WriteLine("Creando sistema de ficheros...");
                Thread.Sleep(1000);
                Console.WriteLine("Creando partida...");
                Thread.Sleep(1000);
                PartidaFacil(pathDificultadPartida,nombreJugador, dificultad1);
            } else if (dificultad == 2)
            {
                string dificultad2 = "Media";
                Console.WriteLine("Has seleccionado dificultad Media");
                PartidaMedia(pathDificultadPartida, nombreJugador, dificultad2);
            } else if (dificultad == 3)
            {
                string dificultad3 = "Dificil";
                Console.WriteLine("Has seleccionado dificultad Dificil");
                PartidaDificil(pathDificultadPartida, nombreJugador, dificultad3);
            }
            else if (dificultad == 4)
            {
                string dificultad4 = "Para todos los publicos";
                Console.WriteLine("Has seleccionado dificultad Partida para todos los publicos");
                // PartidaTodosPublicos(pathDificultadPartida,,nombreJugador, dificultad4);
            }


        }


        public static void PartidaFacil(string path ,string nombreJugador, string dificultad)
        {
          
            string nombreArchivo = "facil.txt";
            String[] palabrasFacil = new String[] { "ojo", "sol", "año" ,"mes","dia","oso","pan","ron","uva","ego"};
            ArrayList wordsToRand = new ArrayList();
            ArrayList palabraEnJuego = new ArrayList();
            ArrayList palabraOculta = new ArrayList();
            //Uso de diccionarios para almacenar nombre y puntuacion de los usuarios
            Dictionary<string, int> PuntuacionUsarios = new Dictionary<string, int>();  
            int puntuacion = 0;
            int puntuacionPorNivel = 25;
            //Escritura de las palabras en el archivo de dificultad
            if (File.Exists(nombreArchivo)) { Console.WriteLine("EXISTE EL FICHERO"); }
                    foreach (string palabras in palabrasFacil)
                    {
                        Logger.EscribeDocumentoDificultad(Path.Combine(path, nombreArchivo), palabras);
                    }
                  string line;

            //Leemos el archivo
            try
            {
                //Se indica ruta y nombre de archivo
                StreamReader sr = new StreamReader(path+"/"+nombreArchivo);
                //Read the first line of text
                line = sr.ReadLine();
                
                while (line != null)
                {
                    line = sr.ReadLine();
                    wordsToRand.Add(line);
                }
                //cerramos el fichero
                sr.Close();  
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            //Generamos random para escoger una palabra aleatoria
            int digitos = 3;
            Random wordRand = new Random();
            int posWord=wordRand.Next(0, wordsToRand.Count);
            string wordToFind = (string)wordsToRand[posWord];
            Thread.Sleep(1000);
            Console.Clear();
   
            for(int i = 0; i < digitos; i++) { palabraOculta.Add("_"); }


            //variable intentos y de rondas
            int intentos = 3;
            int rondas = 3;
            Console.WriteLine(wordToFind);
          
            while (intentos >0 && rondas>0)
            {

                if (rondas == 0)
                {
                    PuntuacionUsarios.Add(nombreJugador, puntuacion);
                    Console.WriteLine("Partida finalizada.\n Has obtenido: " + puntuacion + " puntos."); break;
                }

                string ResultString = String.Join("",palabraOculta.ToArray());
               
                if (ResultString == wordToFind)
                {      
                    ResultString ="";
                    rondas--;
                    
                    puntuacion = puntuacion + 100+ puntuacionPorNivel;
                    Console.Clear();
                    //Puntuacion segun nivel palabras acertadas e intentos
                    if (intentos == 3) { puntuacion = puntuacion + 100; Console.WriteLine("Se han agregado 100 puntos a tu puntuación por resolverlo sin fallos."); }
                    if (intentos == 2) { puntuacion = puntuacion + 50; Console.WriteLine("Se han agregado 50 puntos a tu puntuación por resolverlo con 1 fallo."); }
                    if (intentos == 1) { puntuacion = puntuacion + 25; Console.WriteLine("Se han agregado 25 puntos a tu puntuación por resolverlo con 2 fallos."); }
                    Console.WriteLine("\nEnhorabuena has adivinado la palabra' " + wordToFind + " tu puntuación actual es: " + puntuacion);
                    Console.WriteLine("Ronda finalizada. Se restablecerá el número de intentos.\n Pasamos a la ronda: "+rondas);
                   
                    Thread.Sleep(8000);
                    Console.Clear();

                    intentos = 3;
                    posWord = wordRand.Next(0, wordsToRand.Count);
                    wordToFind = (string)wordsToRand[posWord];
                    palabraOculta.Clear();
                    for (int i = 0; i < digitos; i++)
                    {
                        palabraOculta.Add("_");
                    }
                }
                if (rondas == 0) {
                    PuntuacionUsarios.Add(nombreJugador, puntuacion);
                    Console.WriteLine("Partida finalizada.\n Has obtenido: "+puntuacion+" puntos."); break; }
                Console.WriteLine("\nIntroduce una letra e intenta adivinar la palabra...");
                char intento= Console.ReadKey().KeyChar;

              
                if (wordToFind.Contains(intento)) {

                   
                    for (int i=0;i<=wordToFind.Length-1;i++)
                    {
                        if (wordToFind[i] == intento)
                        {
                              palabraOculta[i] = intento;
                        }

                    }
                    Console.WriteLine("\nEnhorabuena la letra: '"+intento+"' aparece.");
                    Console.WriteLine("\nTe quedan: " + intentos + " en esta ronda.");
                }
                else {
                    intentos--; 
                    Console.WriteLine("\nTe quedan: "+intentos+" en esta ronda.");
                    //Metodo que dibujara el proceso del ahorcado de la partida
                    dibujoConsola.start(intentos);
                    if (intentos==0) { 
                        intentos = 3; rondas--;
                         Console.WriteLine("\n Ronda perdida. Vamos a la ronda: "+rondas+" la palabra era: "+wordToFind);
                         Thread.Sleep(3000);
                         Console.Clear();
                        posWord = wordRand.Next(0, wordsToRand.Count);
                         wordToFind = (string)wordsToRand[posWord];
                        palabraOculta.Clear();
                        for (int i = 0; i <= digitos; i++) {   
                            palabraOculta.Add("_");
                        }
                       
                    }
                }
      
               for(int i = 0; i < digitos; i++)
                {
                    Console.Write(palabraOculta[i]+" ");
                }
            }
            //Trabajando en el directorio xml de raking con fichero de ranking de cada dificultad
           // PuntuacionUsarios.Add(nombreJugador,puntuacion);
            string newFolder = "JocPenjat";
            string subFolderRanking = "Ranking";
            string pathRanking = System.IO.Path.Combine(
             Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
             newFolder, subFolderRanking
          );

            //Recogiendo las 10 mejores puntuaciones
            int j = 0;
            string maxGuid;
            int maxGuid2;
         


            //LINQ
            // maxGuid = PuntuacionUsarios.OrderByDescending(x => x.Value).FirstOrDefault().Key;
            // maxGuid2 = PuntuacionUsarios.OrderByDescending(x => x.Value).FirstOrDefault().Value;
         
            
            foreach (KeyValuePair<string, int> jugador in PuntuacionUsarios.OrderBy(key => key.Value))
            {
                string toPrintXml = jugador.Key;
                int toPrintXmlPoints = jugador.Value;
                Console.WriteLine("Key: {0}, Value: {1}", jugador.Key, jugador.Value);
                Logger.WriteRank(Path.Combine(pathRanking, dificultad + ".xml"), toPrintXml+" - "+toPrintXmlPoints);
            }

            //Logger.WriteRank(Path.Combine(pathRanking, dificultad + ".xml"), );

            //Logger.WriteRank(Path.Combine(pathRanking, dificultad + ".xml"), "</jugadores>");

        }



            public static void PartidaMedia(string path, string nombreJugador, string dificultad)
        {
            String[] palabrasMedia = new String[] { "pantalla", "monitor", "teclado" };


            foreach (string palabra in palabrasMedia)
            {
                Logger.EscribeDocumentoDificultad(Path.Combine(path, "media.txt"), palabra);
            }
        }

        public static void PartidaDificil(string path, string nombreJugador, string dificultad)
        {
            String[] palabrasDificil = new String[] { "desoxirribonucleico", "trabalenguas", "esternoclidomastoideo" };


            foreach (string palabra in palabrasDificil)
            {
                Logger.EscribeDocumentoDificultad(Path.Combine(path, "dificil.txt"), palabra);
            }
        }

        /*  public static void PartidaTodosPublicos(string path,string nombreJugador, string dificultad)
          {
              String[] palabrasTodosPublicos = new String[] { "sol", "pera", "luna" };


              foreach (string palabra in palabrasTodosPublicos)
              {
                  Logger.EscribeDocumentoDificultad(Path.Combine(path, "todosPublicos.txt"), palabra);
              }
          }*/

    }
}
