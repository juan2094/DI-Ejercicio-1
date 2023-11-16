using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsForm
{
    [Serializable]
    internal class Camara 
    {
        public int index {  get; set; }
        public int numero
        {
            get; set;
        }
        public float precio {  get; set; }
        public Boolean profesional {  get; set; }
        public char calidad { get; set; }
        public string marca { get; set; }
        public Image foto {  get; set; }
        public Camara(int indes,int numero,float precio,Boolean profesional,char calidad,string marca,Image foto) { 
            this.index = indes;
            this.numero = numero;
            this.precio = precio;
            this.calidad = calidad;
            this.marca = marca;
            this.profesional = profesional;
            this.foto = foto;
            //this.pic = pic;

        }




    }
}
