using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Threading;

using System.Diagnostics;
using Font = iTextSharp.text.Font;

namespace _CP1_Proyecto1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
            panel1.AutoScroll = true;
            panel2.AutoScroll = true;
            panel3.AutoScroll = true;

            string nombre = "Pestaña " + contPestana.ToString();
            TabPage tp = new TabPage(nombre);
            RichTextBox rtb = new RichTextBox();
            rtb.Dock = DockStyle.Fill;

            tp.Controls.Add(rtb);
            tabControl1.TabPages.Add(tp);
            contPestana++;



        }
        //-----------------ELEMENTOS PERMITIDOS DENTRO DE LAS TABLAS----------//
        List<string> caracteres = new List<string>(new string[] { "_", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "Ñ", "O", "P", "Q", "R", "S", "T", "V", "U", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "ñ", "o", "p", "q", "r", "s", "t", "v", "u", "w", "x", "y", "z" });
        List<string> numeros = new List<string>(new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" });

        List<string> simbolos = new List<string>(new string[] { " ", ".", "|", "?", "*", "+", "{", "}", ":", ";", ",", "[", "]", "/", "*", "(", ")", ".", "=", "+", "-", "\"", "!", "%" });

        //-----------------------LECTOR DE ARCHIVOS--------------------------//
        OpenFileDialog lectorArchivo = new OpenFileDialog();

        //-----------------------CONTROL DE VENTANAS--------------------------//
        public static List<Directorio> registroDirectorio = new List<Directorio>();

        //-------------------CORRELATIVOS PARA PESTANAS----------------------//
        int contPestana = 1;
        int primImagen = 0;
        int movPrim = 0;

        int secImagen = 0;
        int movSec = 0;

        int tabla = 0;
        int movTabla = 0;


        string consola = "";


        LinkedList<Estado> transiciones;
        LinkedList<Conjunto> conjuntos = new LinkedList<Conjunto>();
        LinkedList<Final> expresionesFinal = new LinkedList<Final>();
        LinkedList<Lexema> lexemas = new LinkedList<Lexema>();
        string AFN(Nodo temp)
        {
            string concat = "";
            string tipo = "";
            concat += "digraph finite_state_machine {\n"
                    + "    rankdir=LR;\n"
                    + "    size=\"8,5\" \n";
            int aceptacion = temp.transiciones.Count() - 1;
            int cont = 0;
            foreach (var item in temp.transiciones)
            {

                if (cont == aceptacion)
                {
                    item.fin = true;
                    tipo = "doublecircle";
                }
                else
                {
                    tipo = "circle";
                }
                concat += "node [shape = " + tipo + ", label=\"S" + item.ID + "\", fontsize=12] S" + item.ID + "; \n";
                cont++;
            }

            foreach (var inside in temp.transiciones)
            {
                foreach (var item in inside.transiciones)
                {
                    concat += "S" + inside.ID + "->" + "S" + item.ID;
                    concat += " [ label = \"" + item.info + "\" ]; \n";

                }
            }
            concat += "}";
            return concat;
        }

        string AFD(LinkedList<Estado> temp)
        {
            string concat = "";
            string tipo = "";
            concat += "digraph finite_state_machine {\n"
                    + "    rankdir=LR;\n"
                    + "    size=\"8,5\" \n";

            foreach (var item in temp)
            {
                if (item.fin)
                {
                    tipo = "doublecircle";
                }
                else
                {
                    tipo = "circle";
                }

                concat += "node [shape = " + tipo + ", label=\"S" + item.ID + "\", fontsize=12] S" + item.ID + "; \n";

            }

            foreach (var inside in temp)
            {
                foreach (var item in inside.transiciones)
                {
                    concat += "S" + inside.ID + "->" + "S" + item.ID;
                    concat += " [ label = \"" + item.info + "\" ]; \n";

                }
            }

            concat += "}";
            return concat;
        }

        string tablaTransiciones(LinkedList<Estado> transiciones)
        {
            LinkedList<string> cabeceras = new LinkedList<string>();
            bool primero = true;
            foreach (var item in transiciones)
            {
                if (!primero)
                {
                    if (!cabeceras.Contains(item.info))
                    {
                        cabeceras.AddLast(item.info);
                    }
                }
                else
                {
                    primero = false;
                }
            }





            String concat = "";
            String encabezado = "";
            int cont = 0;

            foreach (var item in cabeceras)
            {
                if (item.Length == 1)
                {
                    if (numeros.Contains(item) || caracteres.Contains(item) || simbolos.Contains(item))
                    {
                        encabezado += "<td>" + item + "</td>";
                    }
                    else
                    {
                        encabezado += "<td> --- </td>";
                    }
                }
                else
                {
                    encabezado += "<td>" + item + "</td>";
                }

            }


            concat += "digraph{ tbl[ shape=plaintext label=<   <table border='0' cellborder='1' cellspacing='0'>\n"
                    + "        <tr>\n"
                    + "        <td>Estado</td>" + encabezado + "\n"
                    + "        </tr>";

            foreach (var item in transiciones)
            {
                concat += "<tr> <td> " + item.ID + "{";

                foreach (var trans in item.elementos)
                {
                    concat += trans +", ";
                }

                concat+= "}"+ "</td>";

                foreach (var inside in cabeceras)
                {
                    bool bandera = false;
                    string ID = "";
                    foreach (var insiderisimo in item.transiciones)
                    {
                        if (insiderisimo.info.Equals(inside)) {
                            bandera = true;
                            ID = insiderisimo.ID.ToString() ;
                        }
             
                    }
                    if (bandera)
                    {
                        concat += "<td> " + ID + "</td>";
                    }
                    else {
                        concat += "<td> </td>";
                    }

                }
                concat += "</tr> \n";
            }

            concat += "      </table>\n"
                    + "\n"
                    + "    >];\n"
                    + "\n"
                    + "}";

            return concat;

        }
        string rutaAbrir(int param, string nombre)
        {
            string rutaGeneradores = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            string carpeta = rutaGeneradores + "\\GRAFICAS";
            string ruta = carpeta + "\\" + nombre;
            if (param == 0)
            {
                ruta += ".png";
            }
            else
            {
                ruta += "("+param+")" + ".png";
            }
            return ruta;
        }
        private System.Drawing.Image GetCopyImage(string path)
        {
            using (System.Drawing.Image image = System.Drawing.Image.FromFile(path))
            {
                Bitmap bitmap = new Bitmap(image);
                return bitmap;
            }
        }

        void generarAFD(string grafica)
        {
            Graficador grafico = new Graficador();
            grafico.graficar(grafica, "primGrafica");
            pictureBox1.Image = GetCopyImage(rutaAbrir(primImagen, "primGrafica")); ;
            primImagen++;
            movPrim++;
        }
        void generarAFN(string grafica)
        {
            Graficador grafico = new Graficador();
            grafico.graficar(grafica, "secGrafica");
            pictureBox3.Image = GetCopyImage(rutaAbrir(secImagen, "secGrafica")); ;
            secImagen++;
            movSec++;
        }

        void generarTabla(string tabla)
        {

            Graficador grafico = new Graficador();
            grafico.graficar(tabla, "tabla");
            pictureBox2.Image = GetCopyImage(rutaAbrir(this.tabla, "tabla"));
            this.tabla++;
            movTabla++;
        }
        RichTextBox getTextBox()
        {

            RichTextBox rtb = null;
            TabPage tp = tabControl1.SelectedTab;

            if (tp != null)
            {
                rtb = tp.Controls[0] as RichTextBox;
            }
            return rtb;

        }

        Estado buscar(int ID)
        {
            foreach (var item in transiciones)
            {
                if (item.ID == ID)
                {
                    return item;
                }
            }
            return null;
        }

        LinkedList<string> buscarConjunto(string nombre)
        {

            foreach (var item in conjuntos)
            {
                if (item.nombre.Equals(nombre))
                {
                    return item.elementos;
                }
            }

            return null;
        }
        bool estadoMayor(Estado nodo)
        {
            foreach (var item in nodo.transiciones)
            {
                if (item.info.Length > 1&&!item.tipo.Equals("conjunto"))
                {
                    return true;
                }
            }

            return false;
        }




        bool global = false;

        bool mayor = false;
        string concat = "";
        int cont = 0;
        int contAux = 0;
        int pos = 0;
        int posAux = 0;
        bool retroceder = true;
        int iter = 0;
        int iterAux = 0;

        void reiniciar()
        {
            mayor = false;
            concat = "";
            retroceder = true;
            cont = 0;
            contAux = 0;
            iterAux = 0;
        }
        void reiniciarMas()
        {
            mayor = false;
            concat = "";
            cont = 0;
            contAux = 0;
            pos = 0;
            posAux = 0;
            retroceder = true;
            iter = 0;
            iterAux = 0;
        }
        int evaluar(Estado nodo, string terminal)
        {
            mayor = estadoMayor(nodo);
            iter = nodo.transiciones.Count();
            int actual = nodo.ID;
            foreach (var item in nodo.transiciones)
            {
                if (item.marcar)
                {

                    if (item.tipo.Equals("conjunto"))
                    {
                        LinkedList<string> temp = buscarConjunto(item.info);
                        if (temp.Contains(terminal))
                        {
                            actual = item.ID;
                            global = true;
                        }
                    }
                    else
                    {
                        if (item.info.Length == 1)
                        {
                            if (item.info.Equals(terminal))
                            {
                                actual = item.ID;
                                global = true;
                            }
                        }
                        else
                        {
                            if (retroceder)
                            {
                                posAux = pos;
                                cont = item.info.Length;
                                retroceder = false;
                            }
                            concat += terminal;
                            contAux++;
                            if (contAux == cont)
                            {
                                if (item.info.Equals(concat))
                                {
                                    actual = item.ID;
                                    global = true;

                                    reiniciar();
                                }
                                else
                                {
                                    item.marcar = false;
                                    iterAux++;

                                    concat = "";
                                    cont = 0;
                                    contAux = 0;

                                    if (iterAux < iter)
                                    {
                                        pos = posAux - 1;
                                        retroceder = true;
                                    }

                                }
                            }
                            break;

                        }

                    }
                }
            }
            return actual;
        }


        bool evaluarLexema(string cadena, LinkedList<Estado> expresion)
        {
            transiciones = expresion;
            int inicio = 0;
            bool aux = false;
            for (pos = 0; pos < cadena.Length; pos++)
            {
                string temp = "";
                temp += cadena[pos];
                inicio = evaluar(buscar(inicio), temp);

                //Si no corresponde a ninguna transición, ninguna de ellas es palabra y el mayor...creo que está de más XD
                if (!global && cont == 0 && !mayor)
                {
                    break;
                }
                else if (global)
                {
                    foreach (var inside in buscar(inicio).transiciones)
                    {
                        inside.marcar = true;
                    }
                }
                aux = global;
                global = false;
                temp = "";

                if (pos + 1 == cadena.Length)
                {
                    Estado verificar = buscar(inicio);
                    if (verificar.fin&&aux)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        void contadores()
        {
            primImagen = 0;
            movPrim = 0;
            secImagen = 0;
            movSec = 0;
            tabla = 0;
            movTabla = 0;

        }

        LinkedList<Estado> buscarFinal(string param)
        {
            foreach (var item in expresionesFinal)
            {
                if (item.nombre.Equals(param))
                {
                    return item.estados;
                }
            }
            return null;
        }
        void funcionamiento(string entrada)
        {

            Lexico analisisLexico = new Lexico();
            lexemas = analisisLexico.analizar(entrada);

            /*foreach (var item in lexemas)
            {
                  consola += item.tipo + " ----> " + item.info+"\n";

            }
            richTextBox1.Text = consola;
            */


            if (analisisLexico.getErrores() == 0)
            {
                Graficador grafico = new Graficador();
                grafico.eliminarArchivos();
                contadores();                   //Vuelve a colocar los contadores de imagenes en cero




                Arbol arbol = new Arbol();
                LinkedList<ExpresionRegular> expresiones;
                expresiones = arbol.analizar(lexemas);
                LinkedList<Lexema> evaluar = arbol.getEvaluar();
                conjuntos = arbol.getConjuntos();


                Thompson thompson = new Thompson();
                LinkedList<Nodo> listaThompson = new LinkedList<Nodo>();


                foreach (var item in expresiones)
                {
        
                    Nodo temp = thompson.AFN(item.nodo, item.cont);
                    generarAFN(AFN(temp));
                    listaThompson.AddLast(temp);
                }




                int cont = 0;
                foreach (var item in listaThompson)
                {
                    Subconjuntos subconjuntos = new Subconjuntos();
                    LinkedList<Estado> estados = subconjuntos.AFD(item.transiciones, expresiones.ElementAt(cont).terminales);
                    generarTabla(tablaTransiciones(estados));
                    generarAFD(AFD(estados));
                    Final temp = new Final(expresiones.ElementAt(cont).nombre, estados);
                    expresionesFinal.AddLast(temp);
                    cont++;
                }


                foreach (var item in evaluar)
                {
                    consola += item.evaluar + " -> " + item.info;
                    if (evaluarLexema(item.info, buscarFinal(item.evaluar)))
                    {
                        consola += "  Correcto! \r";
                        richTextBox1.Text = consola;
                    }
                    else
                    {
                        consola += "  Incorrecto... \r";
                        richTextBox1.Text = consola;
                    }
                }
                

                reiniciarMas();     //Reinicio variables utilizadas en la evaluación
                conjuntos.Clear();
                expresionesFinal.Clear();



            }
            else
            {
                generarPDF(lexemas);
                //MessageBox.Show("Entrada con errores", "Advertencia");
            }


        }

        private void CargarThomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*------------LISTADO DE PENDIENTES:
             *  1. Ver que puchis pasa que mueren las expresiones al meter mas
             *  2. Arreglar la tabla de transiciones,poner los que son estados de aceptacion
             *      y tambien que la transicion corresponda a su columna;
             *  3. Ver donde rayos mostrar los reportes XML
             *  4. y...Ya?
             */
            string cadenaTexto = "";

            if (getTextBox() == null)
            {

                MessageBox.Show("Cree una pestaña para comenzar", "Alerta");

            }
            else
            {
                cadenaTexto = getTextBox().Text;

                if (cadenaTexto.Equals(""))
                {
                    MessageBox.Show("Ingrese una entrada valida", "Cadena vacia");

                }
                else
                {

                    pictureBox1.Image = null;
                    pictureBox1.Update();
                    pictureBox2.Image = null;
                    pictureBox2.Update();
                    pictureBox3.Image = null;
                    pictureBox3.Update();
                    consola = "";
                    lexemas.Clear();
                    Graficador grafico = new Graficador();
                    grafico.eliminarArchivos();
                    Thread.Sleep(1000);
                    funcionamiento(cadenaTexto);
                }

            }




        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void NuevaPestañaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombre = "Pestaña " + contPestana.ToString();
            TabPage tp = new TabPage(nombre);
            RichTextBox rtb = new RichTextBox();
            rtb.Dock = DockStyle.Fill;

            tp.Controls.Add(rtb);
            tabControl1.TabPages.Add(tp);
            contPestana++;
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Prev1_Click(object sender, EventArgs e)
        {

            if (movPrim > 0)
            {
                movPrim--;
                pictureBox1.Image = GetCopyImage(rutaAbrir(movPrim, "primGrafica"));
            }


        }

        private void Next1_Click(object sender, EventArgs e)
        {

            if (movPrim + 1 < primImagen)
            {
                movPrim++;
                pictureBox1.Image = GetCopyImage(rutaAbrir(movPrim, "primGrafica"));
            }
        }

        private void Prev3_Click(object sender, EventArgs e)
        {
            if (movSec > 0)
            {
                movSec--;
                pictureBox3.Image = GetCopyImage(rutaAbrir(movSec, "secGrafica"));
            }

        }

        private void Next3_Click(object sender, EventArgs e)
        {
            if (movSec + 1 < secImagen)
            {
                movSec++;
                pictureBox3.Image = GetCopyImage(rutaAbrir(movSec, "secGrafica"));
            }

        }

        private void AbrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lectorArchivo.Filter = "ER|*.er";
            if (lectorArchivo.ShowDialog() == DialogResult.OK)
            {
                string ruta = lectorArchivo.FileName;

                string pagina = tabControl1.SelectedIndex.ToString();
                Directorio instancia = new Directorio(ruta, pagina);
                for (int i = 0; i < registroDirectorio.Count; i++)
                {
                    if (registroDirectorio[i].ventana.Equals(pagina))
                    {
                        registroDirectorio.RemoveAt(i);
                    }
                }

                registroDirectorio.Add(instancia);
                string fileContent = File.ReadAllText(ruta, Encoding.UTF8);
                getTextBox().Text = fileContent;

            }
        }

        private void GuardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pagina = tabControl1.SelectedIndex.ToString();

            bool documento = false;

            for (int i = 0; i < registroDirectorio.Count; i++)
            {
                if (registroDirectorio[i].ventana.Equals(pagina))
                {
                    getTextBox().SaveFile(registroDirectorio[i].ruta, RichTextBoxStreamType.PlainText);
                    documento = true;
                }
            }

            if (!documento)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.FileName = "archivoEntrada.er";
                save.Filter = "Archivos de texto (*.er)|*.er|Todos los archivos (*.*)|*.*";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    getTextBox().SaveFile(save.FileName, RichTextBoxStreamType.PlainText);

                    Directorio instancia = new Directorio(save.FileName, pagina);
                    registroDirectorio.Add(instancia);

                }
            }
        }

        string reporteErrores(LinkedList<Lexema> tokens)
        {
            string concat = "";
            concat += "<ListaErrores> \n";
            foreach (var item in tokens)
            {
                if (item.tipo.Equals("error"))
                {
                    string param = item.info;
                    if (item.info.Equals("<") || item.Equals(">"))
                    {
                        param = "---";
                    }
                    concat += "	<Error> \n";
                    concat += "             <Valor>" + param + "</Valor>\n";
                    concat += "             <Fila>" + item.fila + "</Fila>\n";
                    concat += "             <Columna>" + item.columna + "</Columna>\n";
                    concat += "	</Error> \n \n";
                }
            }
            concat += "</ListaErrores>";
            return concat;
        }
        string reporteTokens(LinkedList<Lexema> tokens)
        {
            string concat = "";
            concat += "<ListaTokens> \n";
            foreach (var item in tokens)
            {
              
                    string param = item.info;
                    if (item.info.Equals("<") || item.Equals(">"))
                    {
                        param = "";
                    }
                    concat += "	<Token> \n";
                    concat += "             <Nombre>" + item.tipo + "</Nombre> \n";
                    concat += "             <Valor>" + param + "</Valor>\n";
                    concat += "             <Fila>" + item.fila + "</Fila>\n";
                    concat += "             <Columna>" + item.columna + "</Columna>\n";
                    concat += "	</Token> \n \n";
            }
            concat += "</ListaTokens>";
            return concat;
        }

        public void generarPDF(LinkedList<Lexema> tokens)
        {

            Document doc = new Document();
            string rutaGeneradores = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            string carpeta = rutaGeneradores + "\\GRAFICAS";

            if (!Directory.Exists(carpeta))
            {
                Console.WriteLine("CREA CARPETA");
                Directory.CreateDirectory(carpeta);
            }

            try
            {

                PdfWriter.GetInstance(doc, new FileStream(rutaGeneradores + "\\GRAFICAS\\errores.pdf", FileMode.Create));
                doc.Open();

                Font fontTitulo = FontFactory.GetFont(iTextSharp.text.Font.FontFamily.HELVETICA.ToString(), 20, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                Paragraph titulo = new Paragraph("REPORTE ERRORES", fontTitulo);
                Paragraph espacio = new Paragraph("\n", fontTitulo);
                titulo.Alignment = Element.ALIGN_CENTER;
                doc.Add(titulo);
                doc.Add(espacio);

                PdfPTable table = new PdfPTable(4);

                table.AddCell("#");
                table.AddCell("Valor");
                table.AddCell("Fila");
                table.AddCell("Columna");

                int cont = 1;
                foreach (var item in tokens)
                {
                    if (item.tipo.Equals("error"))
                    {
                        table.AddCell(cont.ToString());
                        table.AddCell(item.info);
                        table.AddCell(item.fila.ToString());
                        table.AddCell(item.columna.ToString());
                        cont++;
                    }
                }


                doc.Add(table);
            }
            catch (Exception)
            {
                Console.WriteLine("PROBLEMAS?????????????");
            }
            finally

            {

                doc.Close();

            }


            DialogResult result = MessageBox.Show("Desea visualizar el reporte?", "Generador PDF", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                string ruta = carpeta + "\\errores.pdf";
                System.Diagnostics.Process.Start(ruta);
            }

            else if (result == DialogResult.Cancel)
            {
                MessageBox.Show("   Reporte guardado en el escritorio, \n                (carpeta GRAFICAS)", "Generador PDF");
            }




        }

        private void CargarTokensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string data = reporteTokens(lexemas);
            string inicio = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)+"\\GRAFICAS";
            File.WriteAllText(inicio + "\\" + "reporteTokens.xml", data);

            MessageBox.Show("   Reporte guardado en el escritorio, \n                (carpeta GRAFICAS)", "Generador XML");

        }

        private void Prev2_Click(object sender, EventArgs e)
        {
            if (movTabla > 0)
            {
                movTabla--;
                pictureBox2.Image = GetCopyImage(rutaAbrir(movTabla, "tabla"));
            }

        }

        private void Next2_Click(object sender, EventArgs e)
        {
            if (movTabla + 1 < this.tabla)
            {
                movTabla++;
                pictureBox2.Image = GetCopyImage(rutaAbrir(movTabla, "tabla"));
            }
        }

        private void GuardarErroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string data = reporteTokens(lexemas);
            string inicio = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\GRAFICAS";
            File.WriteAllText(inicio + "\\" + "reporteErrores.xml", data);

            MessageBox.Show("   Reporte guardado en el escritorio, \n                (carpeta GRAFICAS)", "Generador XML");
        }
    }

}

