using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CP1_Proyecto1
{
    public class Lexico
    {

        private LinkedList<Lexema> registro = new LinkedList<Lexema>();
        int errores=0;


        List<char> alfabeto = new List<char>(new char[]{ '_', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'Ñ', 'O', 'P', 'Q', 'R', 'S', 'T', 'V', 'U', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'ñ', 'o', 'p', 'q', 'r', 's', 't', 'v', 'u', 'w', 'x', 'y', 'z' });
        List<char> numeros = new List<char>(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', });
        List<char> espacios = new List<char>(new char[] { ' ', '\r', '\t', '\n', '\b', '\f' });

        
        List<char> simbolos = new List<char>(new char[] { '{', '}', ':', ';', ',', '[', ']', '/', '*', '"', '(', ')', '.', '=', '+', '-', '\'', '<', '>', '!', '%' });
        List<char> operadores = new List<char>(new char[] { '.', '|', '?', '*', '+' });

        int filaDato = 1;
        int columnaDato = 0;
        int auxiliar = 0;
        public LinkedList<Lexema> analizar(String cadena)
        {

            int inicioEstado = 0;
            int estadoPrincipal = 0;
            char cadenaConcatenar;
            String token = "";
            registro = new LinkedList<Lexema>();

            for (inicioEstado = 0; inicioEstado < cadena.Length; inicioEstado++)
            {
                cadenaConcatenar = cadena[inicioEstado];

                if (auxiliar == inicioEstado)
                {
                    columnaDato++;
                }

                if (auxiliar != inicioEstado)
                {
                    auxiliar = inicioEstado;
                }

                switch (estadoPrincipal)
                {
                    case 0:
                        switch (cadenaConcatenar)
                        {
                            case ' ':
                            case '\r':
                            case '\b':
                            case '\f':
                            case '\t':
                                estadoPrincipal = 0;
                                break;
                            case '\n':
                                filaDato++;
                                columnaDato = 0;
                                estadoPrincipal = 0;
                                break;

                            default:

                                if (alfabeto.Contains(cadenaConcatenar))
                                {
                                    token += cadenaConcatenar;
                                    estadoPrincipal = 2;

                                }
                                else if (simbolos.Contains(cadenaConcatenar))
                                {

                                    token += cadenaConcatenar;
                                    estadoPrincipal = 1;
                                }
                                else {
                                    token += cadenaConcatenar;
                                    estadoPrincipal = 6;
                                }

                                break;
                        }
                        break;

                    //-----------------------------ESTADO DE SIMBOLOS----------------------//
                    case 1:
                        if (token.Equals("-"))
                        {
                            if (cadenaConcatenar == '>')
                            {
                                token += cadenaConcatenar;
                                tokenValidos(token);
                                estadoPrincipal = 3;
                                token = "";

                            }
                            else
                            {
                                tokenValidos(token);
                                estadoPrincipal = 0;
                                token = "";
                                inicioEstado = inicioEstado - 1;
                            }

                        }
                        else if (token.Equals("%"))
                        {
                            if (cadenaConcatenar == '%')
                            {
                                token += cadenaConcatenar;
                                tokenValidos(token);
                                estadoPrincipal = 0;
                                token = "";

                            }
                            else
                            {
                                tokenValidos(token);
                                estadoPrincipal = 0;
                                token = "";
                                inicioEstado = inicioEstado - 1;
                            }

                        }
                        else if (token.Equals("/"))
                        {
                            if (cadenaConcatenar == '/')
                            {
                                token += cadenaConcatenar;
                                estadoPrincipal = 7;
                            }
                            else
                            {
                                tokenValidos(token);
                                estadoPrincipal = 0;
                                token = "";
                                inicioEstado = inicioEstado - 1;
                            }
                        }
                        else if (token.Equals("<"))
                        {
                            if (cadenaConcatenar == '!')
                            {
                                token += cadenaConcatenar;
                                estadoPrincipal = 9;

                            }
                            else
                            {
                                tokenValidos(token);
                                estadoPrincipal = 0;
                                token = "";
                                inicioEstado = inicioEstado - 1;
                            }
                        }
                        else if (token.Equals("\""))
                        {
                            estadoPrincipal = 4;
                            token = "";
                            token += cadenaConcatenar;
                            if (token.Equals("\""))
                            {
                                Lexema instancia = new Lexema("", "cadena", filaDato, columnaDato);
                                registro.AddLast(instancia);
                                token = "";
                                token += cadenaConcatenar;
                                tokenValidos(token);
                                token = "";
                                estadoPrincipal = 0;
                            }

                        }
                        else
                        {
                            tokenValidos(token);
                            token = "";
                            estadoPrincipal = 0;
                            inicioEstado = inicioEstado - 1;

                        }
                        break;

                    //-----------------------------ESTADO IDENTIFICADORES----------------------//
                    case 2:
                        if (espacios.Contains(cadenaConcatenar) || simbolos.Contains(cadenaConcatenar))
                        {
                            Lexema instancia;
                            if (token.Equals("CONJ"))
                            {
                                instancia = new Lexema(token, "Reservada CONJ", filaDato, columnaDato);
                            }
                            else
                            {
                                instancia = new Lexema(token, "Identificador", filaDato, columnaDato);
                            }

                            registro.AddLast(instancia);
                            token = "";
                            estadoPrincipal = 0;
                            inicioEstado = inicioEstado - 1;
                        }
                        else if (alfabeto.Contains(cadenaConcatenar) || numeros.Contains(cadenaConcatenar))
                        {
                            token += cadenaConcatenar;
                        }
                        else
                        {
                            token += cadenaConcatenar;
                            estadoPrincipal = 6;
                        }
                        break;

                    case 8:
                        if (operadores.Contains(cadenaConcatenar))
                        {
                            estadoPrincipal = 10;
                            inicioEstado--;
                        }
                        else
                        {
                            estadoPrincipal = 5;
                            inicioEstado--;
                        }

                        break;

                    //--------------------------ESPERA DE DEFINICION DE CONJUNTO------------//
                    case 3:
                        if (cadenaConcatenar != ' ')
                        {
                            estadoPrincipal = 8;
                            inicioEstado--;
                        }
                        break;

                    //-----------------------ESTADO CADENA...expresion?----------------------//
                    case 4:
                        if (cadenaConcatenar == '"' || cadenaConcatenar == '\n')
                        {
                            Lexema instancia = new Lexema(token, "cadena", filaDato, columnaDato);
                            registro.AddLast(instancia);
                            token = "";
                            estadoPrincipal = 0;

                        }
                        else
                        {
                            token += cadenaConcatenar;
                        }
                        break;

                    //-----------------------ESTADO DEFINICION CONJUNTOS---------------------//
                    case 5:
                        if (cadenaConcatenar == ';')
                        {
                            Lexema instancia = new Lexema(token, "conjunto", filaDato, columnaDato);
                            registro.AddLast(instancia);
                            token = "";
                            token += cadenaConcatenar;
                            tokenValidos(token);
                            token = "";
                            estadoPrincipal = 0;

                        }
                        else
                        {
                            token += cadenaConcatenar;
                        }
                        break;

                    //-----------------------------ESTADO COMENTARIO SIMPLE----------------------//
                    case 7:
                        if (cadenaConcatenar == '\n' || cadenaConcatenar == '\r')
                        {
                            Lexema instancia = new Lexema(token, "comentario simple", filaDato, columnaDato);
                            registro.AddLast(instancia);
                            token = "";
                            estadoPrincipal = 0;

                        }
                        else {
                            token += cadenaConcatenar;
                        }

                        break;

                    //-----------------------------ESTADO COMENTARIO BLOQUE----------------------//
                    case 9:
                        string substring = token.Substring(Math.Max(0, token.Length - 2));
                        if (substring.Equals("!>"))
                        {
                            Lexema instancia = new Lexema(token, "comentario bloque", filaDato, columnaDato);
                            registro.AddLast(instancia);
                            estadoPrincipal = 0;
                            token = "";
                            inicioEstado--;
                        }
                        else
                        {
                            token += cadenaConcatenar;
                        }
                        break;

                    //-----------------------------ESTADO DE ERROR----------------------//
                    case 6:

                        if (espacios.Contains(cadenaConcatenar) || cadenaConcatenar == ';')
                        {
                            errores++;
                            Lexema instancia = new Lexema(token, "error", filaDato, columnaDato);
                            registro.AddLast(instancia);
                            token = "";
                            estadoPrincipal = 0;
                            inicioEstado = inicioEstado - 1;
                        }
                        else {
                            token += cadenaConcatenar;
                        }
                        break;

                    //---------------------------EXPRESION REGULAR------------------------//
                    case 10:
                        if (cadenaConcatenar == ';')
                        {
                            Lexema instancia = new Lexema(token, "expresion", filaDato, columnaDato);
                            registro.AddLast(instancia);
                            token = "";
                            token += cadenaConcatenar;
                            tokenValidos(token);
                            token = "";
                            estadoPrincipal = 0;

                        }
                        else
                        {
                            token += cadenaConcatenar;
                        }

                        break;

                }

            }


            return registro;
        }

        
        public void tokenValidos(String entrada)
        {
            switch (entrada)
            {
                case "{":
                    Lexema instancia = new Lexema(entrada, "Llaves abrir", filaDato, columnaDato);
                    registro.AddLast(instancia);
                    break;
                case "}":
                    instancia = new Lexema(entrada, "Llaves cerrar", filaDato, columnaDato);
                    registro.AddLast(instancia);
                    break;
                case ":":
                    instancia = new Lexema(entrada, "Dos puntos", filaDato, columnaDato);
                    registro.AddLast(instancia);
                    break;
                case ";":
                    instancia = new Lexema(entrada, "Punto y coma", filaDato, columnaDato);
                    registro.AddLast(instancia);
                    break;
                case "->":
                    instancia = new Lexema(entrada, "Definicion", filaDato, columnaDato);
                    registro.AddLast(instancia);
                    break;
                case "%%":
                    instancia = new Lexema(entrada, "Doble porcentaje", filaDato, columnaDato);
                    registro.AddLast(instancia);
                    break;
                default:
                    instancia = new Lexema(entrada, "error", filaDato, columnaDato);
                    registro.AddLast(instancia);
                    errores++;
                    break;
            }

        }
        
        public int getErrores()
        {
            return errores;
        }


      

    }
    
}
