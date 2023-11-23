
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

        //DECLARACION
        int index = 0;
        int numero;
        float precio;
        Boolean profesional = false;
        char calidad;
        string marca;
        PictureBox pic;

        

        List<Camara> lista = new List<Camara>();

        
        public Form1()
        {
            //INICIAMOS LOS CAMPOS Y DESACTIVAMOS BTN_OK
            InitializeComponent();
            btnOk.Enabled = false;
            btnOk.Visible = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //LLAMADA A METODO
            retroceder();

        }

        private void Avanzar_Click(object sender, EventArgs e)
        {
            //LLAMADA A METODO
            siguiente();
        }

        private void siguiente()
        {
            //CONTROLAMOS SEGÚN EL ÍNDICE ESTÁTICO LA POSICIÓN DE LA LISTA QUE MOSTRAMOS
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
            txtCalidad.Text = aux.Calidad.ToString();
            txtMarca.Text = aux.Marca.ToString();
            txtNumero.Text = aux.Numero.ToString();
            txtPrecio.Text = aux.Precio.ToString();
            //mostramos los datos y compr
            if (aux.Profesional)
            {
                txtProfesional.Text = "Profesional";
            }
            else
            {
                txtProfesional.Text = "Aficionado";
            }

            Image imagen = aux.GetFoto();
            afoto.Image = imagen;
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            //nada
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (index > -1)
            {
                //eliminamos de la lista y controlando los errores 
                lista.RemoveAt(index);

                if (index != 0)
                {
                    index--;
                    Camara aux = lista[index];

                    mostrarDatos(aux);
                }
                else
                {
                    if (index== 0)
                    {
                        Camara aux = lista[index];
                        mostrarDatos(aux);
                    }
                    else
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
            bool profesional = (txtCalidad.Text.Equals("Si", StringComparison.OrdinalIgnoreCase));

            // Creamos el objeto que recoge los datos proporcionados
            Camara aux = new Camara(index++, int.Parse(txtNumero.Text), float.Parse(txtPrecio.Text), profesional, char.Parse(txtCalidad.Text), txtMarca.Text, imagen);

            // Añadimos a la lista
            lista.Add(aux);

            mostrarDatos(aux);

            // Volvemos al estado anterior
            btnOk.Enabled = false;
            btnOk.Visible = false;
            btnEliminar.Enabled = true;
            btnAvanzar.Enabled = true;
            btnNuevo.Enabled = true;
            btnRetroceder.Enabled = true;
        }

        private Image elegirArchivo()
        {
            //abrimos la ventana para elegir foto
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

            Guardar("databank.data");

        }


        private void Guardar(string rutaArchivo)
        {
            try
            {
                //con un binaryWriter sobreescribimos el archivo
                using (BinaryWriter bw = new BinaryWriter(File.Open(rutaArchivo, FileMode.Create)))
                {
                    foreach (Camara a in lista)
                    {
                        bw.Write(a.Calidad);
                        bw.Write(a.Marca);
                        bw.Write(a.Profesional);
                        //escribimos los datos y pasamos la foto al array de  bytes
                        byte[] fotoBytes = a.GetFotoBytes();
                        //guardamos el tamaño del array antes de la foto
                        bw.Write(fotoBytes.Length);
                        bw.Write(fotoBytes);
                        //se guarda el array
                        bw.Write(a.Index);
                        bw.Write(a.Numero);
                        bw.Write(a.Precio);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cargar(string rutaArchivo)
        {
            lista = CargarLista(rutaArchivo);
        }

        private List<Camara> CargarLista(string rutaArchivo)
        {
            List<Camara> listaCamaras = new List<Camara>();

            try
            {
                using (BinaryReader br = new BinaryReader(File.Open(rutaArchivo, FileMode.Open)))
                {
                    while (br.BaseStream.Position < br.BaseStream.Length)
                    {
                        char calidad = br.ReadChar();
                        string marca = br.ReadString();
                        bool profesional = br.ReadBoolean();
                        int fotoLength = br.ReadInt32();
                        //ahora le podemos pasar el tamaño de la foto
                        byte[] fotoBytes = br.ReadBytes(fotoLength);
                        int index = br.ReadInt32();
                        int numero = br.ReadInt32();
                        float precio = br.ReadSingle();

                        Camara camara = new Camara(index, numero, precio, profesional, calidad, marca, null);
                        //añadimos la foto a posterior con el metodo que gemos creado
                        camara.SetFotoBytes(byteArrayToImage(fotoBytes));
                        listaCamaras.Add(camara);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listaCamaras;
        }



       

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

           // open.ShowDialog();
            if (open.ShowDialog() == DialogResult.OK) { 
                //si seleccionamos el archivo lo cargamos
            Cargar(open.FileName);
            }else
            //si no, cargamos estas por defecto
            if (lista.Count==0)
            {
                Camara c1 = new Camara(0, 2, (float)121.30, false, 'd', "Nisu", ( Image.FromFile("C:\\Users\\Cala\\source\\repos\\WindowsForm\\fotos\\cuerpo-de-la-c-mara-mirrorless-eos-r5-de-canon-producto-vista-frontal.jfif")));
                Camara c2 = new Camara(1, 4, (float)12.33, false, '2', "Nisu", (Image.FromFile("C:\\Users\\Cala\\source\\repos\\WindowsForm\\fotos\\images (1).jfif")));
                Camara c3 = new Camara(2, 6, (float)12.320, false, 'a', "N1su", (Image.FromFile("C:\\Users\\Cala\\source\\repos\\WindowsForm\\fotos\\images.jfif")));
                Camara c4 = new Camara(3, 8, (float)123.30, false, 'b', "Nisu", (Image.FromFile("C:\\Users\\Cala\\source\\repos\\WindowsForm\\fotos\\cuerpo-de-la-c-mara-mirrorless-eos-r5-de-canon-producto-vista-frontal.jfif")));
                lista.Add(c1);
                lista.Add(c2);
                lista.Add(c3);
                lista.Add(c4);
               
            }

            
            // mostrarDatos(lista[0]);
        }
    }

}