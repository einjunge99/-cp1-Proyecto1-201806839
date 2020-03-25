using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CP1_Proyecto1
{
    public class Conjunto
    {
        public string nombre;
        public LinkedList<string> elementos;
        public Conjunto(string nombre, LinkedList<string> elementos)
        {
            this.nombre = nombre;
            this.elementos = elementos;
        }
    }
}
