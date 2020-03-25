using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CP1_Proyecto1
{
    public class ExpresionRegular
    {
        public Nodo nodo;
        public String nombre;
        public int cont;
        public LinkedList<Nodo> terminales;
       // LinkedList<Siguientes> siguientes = new LinkedList<Siguientes>();
        //LinkedList<Transiciones> tabla = new LinkedList<Transiciones>();
        public ExpresionRegular(String nombre, LinkedList<Nodo> terminales)
        {
            this.nombre = nombre;
            this.terminales = terminales;
        }
    }
}
