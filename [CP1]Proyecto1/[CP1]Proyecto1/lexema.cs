using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CP1_Proyecto1
{
    public class Lexema
    {
        
        public string tipo;
        public string info;
        public int columna;
        public int fila;

        //----------Inidica si el lexema contiene un conjunto
        public Conjunto conjunto;
        public string evaluar;
    
        public Lexema(string info,string tipo,int columna, int fila) {
            this.fila = fila;
            this.columna = columna;
            this.tipo = tipo;
            this.info = info;
        }
    }
}
