
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
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

        Camara c1 = new Camara(0, 2, (float)121.30, false, 'd', "Nisu", Image.FromFile("C:\\Users\\Cala\\source\\repos\\WindowsForm\\fotos\\cuerpo-de-la-c-mara-mirrorless-eos-r5-de-canon-producto-vista-frontal.jfif"));
        Camara c2 = new Camara(1, 4, (float)12.33, false, '2', "Nisu", Image.FromFile("C:\\Users\\Cala\\source\\repos\\WindowsForm\\fotos\\images (1).jfif"));
        Camara c3 = new Camara(2, 6, (float)12.320, false, 'a', "N1su", Image.FromFile("C:\\Users\\Cala\\source\\repos\\WindowsForm\\fotos\\images.jfif"));
        Camara c4 = new Camara(3, 8, (float)123.30, false, 'b', "Nisu", Image.FromFile("C:\\Users\\Cala\\source\\repos\\WindowsForm\\fotos\\cuerpo-de-la-c-mara-mirrorless-eos-r5-de-canon-producto-vista-frontal.jfif"));

        public Form1()
        {
            InitializeComponent();
            lista.Add(c1);
            lista.Add(c2);
            lista.Add(c3);
            lista.Add(c4);
            btnOk.Enabled = false;

            mostrarDatos(c1);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            retroceder();

        }

        private void Avanzar_Click(object sender, EventArgs e)
        {
            siguiente();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            txtProfesional.Text = aux.profesional.ToString();
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
            btnEliminar.Enabled = false;
            btnAvanzar.Enabled = false;
            btnNuevo.Enabled = false;
            btnRetroceder.Enabled = false;

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
            Camara aux = new Camara(index++, int.Parse(txtNumero.Text), float.Parse(txtPrecio.Text), false, char.Parse(txtCalidad.Text), txtMarca.Text, imagen);

            lista.Add(aux);

            mostrarDatos(aux);
            btnOk.Enabled = false;

            btnEliminar.Enabled = true;
            btnAvanzar.Enabled = true;
            btnNuevo.Enabled = true;
            btnRetroceder.Enabled = true;
        }

        private Image elegirArchivo()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Elige una foto";

            if (ofd.ShowDialog() == DialogResult.OK)
            {

                string path = ofd.FileName;
                Image imagen = Image.FromFile(path);
                return imagen;
            }
            else
            {
                return null;
            }

            ofd.Dispose();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileStream fileStream;

          //  fileStream.Write

        }
    }

}