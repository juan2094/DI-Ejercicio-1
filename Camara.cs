using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

[Serializable]
internal class Camara
{
    public int Index { get; set; }
    public int Numero { get; set; }
    public float Precio { get; set; }
    public bool Profesional { get; set; }
    public char Calidad { get; set; }
    public string Marca { get; set; }
    private byte[] FotoBytes { get; set; }

    public Camara(int index, int numero, float precio, bool profesional, char calidad, string marca, Image foto)
    {
        this.Index = index;
        this.Numero = numero;
        this.Precio = precio;
        this.Calidad = calidad;
        this.Marca = marca;
        this.Profesional = profesional;
        SetFotoBytes(foto);
    }

    public Image GetFoto()
    {
        if (FotoBytes != null && FotoBytes.Length > 0)
        {
            return ByteArrayToImage(FotoBytes);
        }
        return null;
    }

    public byte[] GetFotoBytes()
    {
        return FotoBytes;
    }

    public void SetFotoBytes(Image foto)
    {
        if (foto != null)
        {
            FotoBytes = ImageToByteArray(foto);
        }
    }

    private byte[] ImageToByteArray(Image image)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            // Save the image as PNG format
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }
    }

    private Image ByteArrayToImage(byte[] byteArray)
    {
        if (byteArray == null)
        {
            return null;
        }

        using (MemoryStream ms = new MemoryStream(byteArray))
        {
            try
            {
                // Create the image from the data with PNG format
                return Image.FromStream(ms, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating image: {ex.Message}");
                return null;
            }
        }
    }
}

