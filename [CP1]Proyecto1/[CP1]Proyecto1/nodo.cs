using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CP1_Proyecto1
{
    public class Nodo
    {
        public int ID;
        public string info;
        public string tipo;
        public string tipoAux;
        public Nodo izquierda;
        public Nodo derecha;


        public Nodo(int ID, string info, string tipo) {
            this.ID = ID;
            this.info = info;
            this.tipo = tipo;
        }   //Constructor para nodo de arbol

        //-----------------THOMPSON------------------//


        public bool fin = false;
        public bool inicio = false;
        public bool marcar = false;
        public LinkedList<Nodo> transiciones = new LinkedList<Nodo>();

        public Nodo(int ID)
        {
            this.ID = ID;
        }      //Constructor para nodo de estructura

        public Nodo(Nodo o)
        {
            this.ID = o.ID;
            this.info = o.info;
        }      //Constructor para copia de nodo, ya que esta cosa se pasa por referencia y no por valor 

   
    }



}

