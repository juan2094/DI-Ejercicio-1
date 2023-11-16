
using DocumentFormat.OpenXml.Drawing.Charts;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class Form1 : Form
    {
        int index = 0;
        // FileStream cargar = File.OpenRead("Fichero.txt");
        int numero;
        float precio;
        Boolean profesional = false;
        char calidad;
        string marca;
        PictureBox pic;

        // Pic.ImageLocation =  null;

        List<Camara> lista = new List<Camara>();

        // Camara c1 = new Camara(0, 2, (float)121.30, false, 'd', "Nisu", Image.FromFile("C:\\Users\\Cala\\source\\repos\\WindowsForm\\fotos\\cuerpo-de-la-c-mara-mirrorless-eos-r5-de-canon-producto-vista-frontal.jfif"));
        /// Camara c2 = new Camara(1, 4, (float)12.33, false, '2', "Nisu", Image.FromFile("C:\\Users\\Cala\\source\\repos\\WindowsForm\\fotos\\images (1).jfif"));
        // Camara c3 = new Camara(2, 6, (float)12.320, false, 'a', "N1su", Image.FromFile("C:\\Users\\Cala\\source\\repos\\WindowsForm\\fotos\\images.jfif"));
        //Camara c4 = new Camara(3, 8, (float)123.30, false, 'b', "Nisu", Image.FromFile("C:\\Users\\Cala\\source\\repos\\WindowsForm\\fotos\\cuerpo-de-la-c-mara-mirrorless-eos-r5-de-canon-producto-vista-frontal.jfif"));

        public Form1()
        {
            InitializeComponent();
            //  lista.Add(c1);
            //  lista.Add(c2);
            //  lista.Add(c3);
            // lista.Add(c4);

            //DESACTIVAMOS EL BOTON NADA MAS INICIAR
            btnOk.Enabled = false;
            btnOk.Visible = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {

            retroceder();

        }

        private void Avanzar_Click(object sender, EventArgs e)
        {
            siguiente();
        }

        private void siguiente()
        {

            if (index == lista.Count)
            {
                btnAvanzar.Enabled = false;
            }

            btnRetroceder.Enabled = true;


            if (lista.Count - 1 > index)
            {

                index++;
                Camara aux = lista[index];
                mostrarDatos(aux);
            }

        }

        private void retroceder()
        {
            if (index == 0)
            {
                btnRetroceder.Enabled = false;
            }

            if (index > 0)
            {
                index--;
                Camara aux = lista[index];
                mostrarDatos(aux);
            }

            btnAvanzar.Enabled = true;


        }

        private void mostrarDatos(Camara aux)
        {


            txtCalidad.Text = aux.calidad.ToString();
            txtMarca.Text = aux.marca.ToString();
            txtNumero.Text = aux.numero.ToString();
            txtPrecio.Text = aux.precio.ToString();
            if (aux.profesional)
            {
                txtProfesional.Text = "Profesional";
            }
            else
            {
                txtProfesional.Text = "Aficionado";
            }
            afoto.Image = aux.foto;

        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (index > -1)
            {
                lista.RemoveAt(index);

                if (index != 0)
                {
                    index--;
                    Camara aux = lista[index];

                    mostrarDatos(aux);
                }
                else
                {
                    if (lista[index] != null)
                    {
                        Camara aux = lista[index];
                        mostrarDatos(aux);
                    }
                    vaciarCampos();

                }
            }
            else
                MessageBox.Show("No puedes eliminarlo");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            vaciarCampos();
            btnOk.Enabled = true;
            btnOk.Visible = true;
            btnEliminar.Enabled = false;
            btnAvanzar.Enabled = false;
            btnNuevo.Enabled = false;
            btnRetroceder.Enabled = false;
            //vaciamos todo y dejamos solo la opcion para añadir
        }

        private void vaciarCampos()
        {
            txtCalidad.Text = "";
            txtMarca.Text = "";
            txtNumero.Text = "";
            txtPrecio.Text = "";
            txtProfesional.Text = "";
            afoto.Image = null;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            Image imagen = elegirArchivo();
            Boolean profesional = false;

            if (txtCalidad.Text == "Si" || txtCalidad.Text == "si")
            {
                profesional = true;
            }
            //creamos el objeto que recoge los datos proporcionados
            Camara aux = new Camara(index++, int.Parse(txtNumero.Text), float.Parse(txtPrecio.Text), profesional, char.Parse(txtCalidad.Text), txtMarca.Text, imagen);
            //añadimos a la lista
            lista.Add(aux);

            mostrarDatos(aux);
            btnOk.Enabled = false;
            btnOk.Visible = false;
            btnEliminar.Enabled = true;
            btnAvanzar.Enabled = true;
            btnNuevo.Enabled = true;
            btnRetroceder.Enabled = true;
            //volvemos al estado anterior
        }

        private Image elegirArchivo()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Elige una foto";

            if (ofd.ShowDialog() == DialogResult.OK)
            {

                string path = ofd.FileName;
                Image imagen = Image.FromFile(path);
                ofd.Dispose();
                return imagen;
            }
            else
            {
                ofd.Dispose();
                return null;
            }


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //BUSCAMSO DONDE GUARDAR EL ARCHIVO
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowDialog();

            try
            {
                string rutaCompleta = Path.Combine(fd.SelectedPath, "archivo.dat");
                //RUTA COMPLETA CON UN NOMBRE YA DEFINIDO
                FileStream fw = new FileStream(rutaCompleta, FileMode.Create);
                //CREAMOS O SOBREESCRIBIMOS EL ARCHIVO
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fw, lista);
                //la serializamos
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { fd.Dispose(); }
        }


        private void Cargar(string rutaArchivo)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                //USAMOS UN BINARYFORMATTER PARA DESERIALIZAR OBJETOS
                using (FileStream fs = new FileStream(rutaArchivo, FileMode.OpenOrCreate))
                {
                    //SE GUARDA EN LA LISTA ANTERIORMENTE DECLARADA
                    lista = (List<Camara>)formatter.Deserialize(fs);
                }


            }
            catch (Exception ex)
            {
                //CONTROLAMOS LAS EXCEPCIONES
                MessageBox.Show($"Error al deserializar el archivo: {ex.Message}");

            }

            //INTENTOS ANTERIORES

            /*
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.ShowDialog();
            List<Camara>  aux = new List<Camara>();

            string[] archivos = Directory.GetFiles(fd.SelectedPath);
            //Camara aux1 = (Camara)sr.CurrentEncoding.GetString;

            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Crear un formateador binario
                BinaryFormatter formatter = new BinaryFormatter();

                // Crear un flujo de archivo para leer el objeto
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                {
                    // Deserializar la lista de cámaras desde el archivo
                    lista = (List<Camara>)formatter.Deserialize(fs);
                }

                // Aquí puedes hacer algo con la lista de cámaras cargadas
            }

            */
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.ShowDialog();

            Cargar(open.FileName);
            mostrarDatos(lista[0]);
        }
    }

}