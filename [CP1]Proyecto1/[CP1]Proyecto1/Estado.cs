using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CP1_Proyecto1
{
    public class Estado
    {
        public int ID;
        public string info;
        public string tipo = "";
        public Conjunto conjunto;
        public bool fin = false;
        public LinkedList<int> elementos = new LinkedList<int>();
        public LinkedList<int> mov;
        public LinkedList<Estado> transiciones=new LinkedList<Estado>();
        public bool marcar=false;

        public Estado(int ID, string info,LinkedList<int> mov) {
            this.ID = ID;
            this.info = info;
            this.mov = mov;

        }
    }
}
