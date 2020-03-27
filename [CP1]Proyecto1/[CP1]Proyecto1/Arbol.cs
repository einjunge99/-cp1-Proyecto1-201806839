using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CP1_Proyecto1
{
    class Arbol
    {
        List<string> binarios = new List<string>() { ".", "|" };
        LinkedList<ExpresionRegular> expresiones = new LinkedList<ExpresionRegular>();
        LinkedList<Conjunto> conjuntos = new LinkedList<Conjunto>();
        LinkedList<Lexema> evaluar = new LinkedList<Lexema>();


        public LinkedList<ExpresionRegular> analizar(LinkedList<Lexema> lexico)
        {
            
            string identificador="";
            foreach (var item in lexico)
            {
           

                if (item.tipo.Equals("Identificador"))
                {
                    identificador = item.info;
                }
                else if (item.tipo.Equals("conjunto"))
                {
                    conjunto(item, identificador);
                }
                else if (item.tipo.Equals("expresion"))
                {

                    //----------------Desecho de caracteres incesesarios de la expresión regular, clasificación y construcción del objeto nodo--------------//

                    LinkedList<Nodo> aux = new LinkedList<Nodo>();
                    LinkedList<Nodo> terminales = new LinkedList<Nodo>();
                    int current = 0;
                    string expresion = "";
                    string concat = "";
                    int ID = 0;
                    int tempCont = 0;

                    expresion = item.info;
                    int i = 0;
                    for (i = 0; i < expresion.Length; i++)
                    {

                        switch (current)
                        {
                            case 0:
                                switch (expresion[i])
                                {
                                    case ' ':
                                        current = 0;
                                        break;
                                    case '"':
                                        current = 1;
                                        break;
                                    case '{':
                                        current = 2;
                                        break;
            
                                    default:
                                        concat += expresion[i];
                                        Nodo nodo = new Nodo(ID, concat, "operador");
                                        nodo.tipoAux = "operador";
                                        aux.AddLast(nodo);
                                        concat = "";
                                        ID++;
                                        break;
                                }
                                break;
                            case 1:
                                if (expresion[i] == '"')
                                {
                            
                                    Nodo nodo = new Nodo(ID, concat, "cadena");
                                    nodo.tipoAux = "cadena";
                            
                                    if (true)
                                    {
                                        LinkedList<Nodo> listaNodo = new LinkedList<Nodo>();
                                        Nodo inicio = new Nodo(tempCont); tempCont++;
                                        Nodo fin = new Nodo(tempCont); tempCont++; fin.info = nodo.info;

                                        inicio.transiciones.AddLast(fin);
                                        listaNodo.AddLast(inicio);
                                        listaNodo.AddLast(fin);
                                        nodo.transiciones = listaNodo;
                                    }
                                    bool bandera = false;
                                    foreach (var inside in terminales)
                                    {
                                        if (inside.info.Equals(nodo.info)) {
                                            bandera = true;
                                            break;
                                        }
                                    }
                                    if (!bandera) {
                                        terminales.AddLast(nodo);
                                    }
                                    aux.AddLast(nodo);
                                    concat = "";
                                    current = 0;
                                    ID++;
                                }
                                else
                                {
                                    concat += expresion[i];
                  
                                }
                                break;
                            case 2:
                                if (expresion[i] == '}')
                                {
                                    Nodo nodo = new Nodo(ID, concat, "conjunto");
                                    nodo.tipoAux = "conjunto";

                                    if (true)
                                    {
                                        LinkedList<Nodo> listaNodo = new LinkedList<Nodo>();
                                        Nodo inicio = new Nodo(tempCont); tempCont++;
                                        Nodo fin = new Nodo(tempCont); tempCont++; fin.info = nodo.info;
                                        inicio.transiciones.AddLast(fin);
                                        listaNodo.AddLast(inicio);
                                        listaNodo.AddLast(fin);
                                        nodo.transiciones = listaNodo;
                                    }

                                    bool bandera = false;
                                    foreach (var inside in terminales)
                                    {
                                        if (inside.info.Equals(nodo.info))
                                        {
                                            bandera = true;
                                            break;
                                        }
                                    }
                                    if (!bandera)
                                    {
                                        terminales.AddLast(nodo);
                                    }



                                    aux.AddLast(nodo);
                                    concat = "";
                                    current = 0;
                                    ID++;
                                }
                                else
                                {
                                    concat += expresion[i];
                                }
                                break;
                       

                        }

                    }


                    //----------------Jerarquía del arbol de acuerdo a la naturaleza del operador(binario o unario)-----------------//

                    int pos = 0;
                    int cont = 0;
                    current = 0;
                    string tipo;


                    for (int j = 0; j < aux.Count; j++)
                    {
                        tipo = aux.ElementAt(j).tipo;
                        int size = aux.Count;
                        switch (current)
                        {
                            case 0:
                                if (tipo.Equals("operador"))
                                {
                                    if (binarios.Contains(aux.ElementAt(j).info))
                                    {
                                        current = 1;
                                    }
                                    else
                                    {
                                        current = 2;
                                    }
                                    pos = j;
                                }
                                break;
                            case 1:
                                if (!tipo.Equals("operador"))
                                {
                                    cont++;
                                    if (cont == 2)
                                    {
                                        aux.ElementAt(pos).izquierda = aux.ElementAt(pos + 1);
                                        aux.ElementAt(pos).derecha = aux.ElementAt(pos + 2);
                                        aux.ElementAt(pos).tipoAux = aux.ElementAt(pos).tipo;
                                        aux.ElementAt(pos).tipo = "operando";


                                        aux.RemoveAt(pos + 1);
                                        aux.RemoveAt(pos + 1);


                                        cont = 0;
                                        current = 0;
                                        j = -1;

                                    }
                                }
                                else
                                {
                                    cont = 0;
                                    current = 0;
                                    j--;
                                }

                                break;
                            case 2:
                                if (!tipo.Equals("operador"))
                                {
                                    cont++;
                                    if (cont == 1)
                                    {
                                        aux.ElementAt(pos).izquierda = aux.ElementAt(pos + 1);
                                        aux.ElementAt(pos).tipoAux = aux.ElementAt(pos).tipo;
                                        aux.ElementAt(pos).tipo = "operando";


                                        aux.RemoveAt(pos + 1);



                                        cont = 0;
                                        current = 0;
                                        j = -1;
                                    }
                                }
                                else
                                {
                                    cont = 0;
                                    current = 0;
                                    j--;
                                }

                                break;



                        }
                    }
                    ExpresionRegular instancia = new ExpresionRegular(identificador, terminales);
                    instancia.nodo = aux.First();
                    instancia.cont = tempCont;
                    expresiones.AddLast(instancia);




                }
                else if (item.tipo.Equals("cadena")) {
                    item.evaluar = identificador;
                    evaluar.AddLast(item);
                }

            }

            return expresiones;
        }


        public void conjunto(Lexema lexema, string nombre)
        {
            LinkedList<string> elementos = new LinkedList<string>();
            if (!lexema.info.Equals("todo"))
            {
                int actual = 0;

                string split = lexema.info;
                int prim = split[0];

                string temp = "";
                temp += split[0];
                elementos.AddLast(temp);
                temp = "";

                for (int i = 1; i < split.Length; i++)
                {
                    char estado = split[i];
                    switch (actual)
                    {
                        case 0:
                            switch (estado)
                            {
                                case ',':
                                    actual = 2;
                                    break;
                                case '~':
                                    actual = 1;
                                    break;
                            }
                            break;
                        case 1:
                            elementos.Clear();
                            int sec = split[i];
                            for (int k = prim; k < sec + 1; k++)
                            {
                                temp += (char)k;
                                elementos.AddLast(temp);
                                temp = "";
                            }
                            break;
                        case 2:
                            temp += split[i];
                            elementos.AddLast(temp);
                            temp = "";
                            actual = 0;
                            break;


                    }
                }
                Conjunto conjunto = new Conjunto(nombre, elementos);
                conjuntos.AddLast(conjunto);

            }
            else {
                Conjunto conjunto = new Conjunto(nombre, elementos);
                conjuntos.AddLast(conjunto);
            }
        }
        public LinkedList<Conjunto> getConjuntos() {
            return conjuntos;
        }
        public LinkedList<Lexema> getEvaluar() {
            return evaluar;
        }

    }
}
