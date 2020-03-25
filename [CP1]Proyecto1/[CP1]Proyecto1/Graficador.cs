using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CP1_Proyecto1
{
    class Graficador
    {
        //--------------ELEMENTOS PARA GRAFICA----------------------//
        string rutaGeneradores;
        StringBuilder grafo;
        public Graficador()
        {

            rutaGeneradores = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        }

        public void generarDot(string rdot, string rpng, string inicio)
        {


            File.WriteAllText(inicio + "\\" + rdot, grafo.ToString());
            var comandoDot = "dot -Tpng " + rdot + " -o " + rpng + " ";
            var comando = string.Format(comandoDot);
            var procStart = new System.Diagnostics.ProcessStartInfo("cmd", "/C " + comando);
            var proc = new System.Diagnostics.Process();
            proc.StartInfo = procStart;
            proc.StartInfo.WorkingDirectory = inicio;
            proc.Start();
            proc.WaitForExit();
     ;
        }

        public void graficar(string texto, string param)
        {
            string nombre = generarRuta(param);
            grafo = new StringBuilder();
            grafo.Append(texto);
            this.generarDot(nombre+".dot", nombre+".png", rutaGeneradores+"\\GRAFICAS");
        }



        public void eliminarArchivos() {

            string rutaGeneradores = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            string carpeta = rutaGeneradores + "\\GRAFICAS";

            string availableFileName = "";

            if (!Directory.Exists(carpeta))
            {
                Console.WriteLine("CREA CARPETA");
                Directory.CreateDirectory(carpeta);
            }

            int i = 1;
            string png = ".png";
            string dot = ".dot";
            LinkedList<string> nombres = new LinkedList<string>();
            nombres.AddLast("primGrafica");
            nombres.AddLast("secGrafica");
            nombres.AddLast("tabla");

            foreach (var item in nombres)
            {
                string fileName = item;
                availableFileName = fileName;
                while (File.Exists(carpeta + "\\" + availableFileName + png))
                {
                    File.Delete(carpeta+"\\"+ availableFileName + png);
                    File.Delete(carpeta + "\\" + availableFileName + dot);
                    availableFileName = fileName + "(" + i + ")";
                    i++;
                }
                i = 1;
            }
          
        }
        public string generarRuta(string nombre)
        {

            string rutaGeneradores = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            string carpeta = rutaGeneradores + "\\GRAFICAS";

            string availableFileName = "";

            if (!Directory.Exists(carpeta))
            {
                Console.WriteLine("CREA CARPETA");
                Directory.CreateDirectory(carpeta);
            }

            int i = 1;
            string fileExtension = ".png";
            availableFileName =nombre;
            while (File.Exists(carpeta + "\\" + availableFileName + fileExtension))
            {
                availableFileName =nombre + "(" + i + ")";
                i++;
            }


            return availableFileName;

        }




    }
}
