using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CP1_Proyecto1
{
    public class Final
    {
        public string nombre;
        public LinkedList<Estado> estados = new LinkedList<Estado>();

        public Final(string nombre,LinkedList<Estado> estados) {
            this.nombre = nombre;
            this.estados = estados;
        }
    }
}
