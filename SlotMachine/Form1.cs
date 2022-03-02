using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlotMachine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Declaramos cada elemento
        public static int p1, p2, p3;

        //Declaramos el total, la apuesta y el saldo
        public static long saldo = 100;
        public static long total = 0;
        public static int apuesta = 5;


        private void Form1_Load(object sender, EventArgs e)
        {
            //Cargamos las 3 imágenes en la pictureBoxes
            pictureBox1.Image = Image.FromFile("1.png");
            pictureBox2.Image = Image.FromFile("2.png");
            pictureBox3.Image = Image.FromFile("3.png");
        }

        //Generamos números aleatorios
        public static class IntUtil
        {
            private static Random random;

            private static void Init()
            {
                if (random == null) random = new Random();
            }
            
            public static int Random(int min, int max)
            {
                Init();
                return random.Next(min, max);
            }
        }


        //Función del botón Girar
        private void button1_Click(object sender, EventArgs e)
        {
            if (saldo >= apuesta)
            {
                saldo = saldo - apuesta;
                label1.Text = "Saldo: " + saldo.ToString();

                //Sistema de generación de números
                for (var i = 0; i < 10; i++)
                {
                    p1 = IntUtil.Random(1, 4);
                    p2 = IntUtil.Random(1, 4);
                    p3 = IntUtil.Random(1, 4);
                }


                //Actualización de imágenes
                if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                pictureBox1.Image = Image.FromFile(p1.ToString() + ".png");

                if (pictureBox2.Image != null) pictureBox2.Image.Dispose();
                pictureBox2.Image = Image.FromFile(p2.ToString() + ".png");

                if (pictureBox3.Image != null) pictureBox3.Image.Dispose();
                pictureBox3.Image = Image.FromFile(p3.ToString() + ".png");

                total = 0;

                //Sacar resultados del juego
                //Comprobar 1,2 o 3
                if (p1 == 3) total = total = 5;
                if (p1 == 2 & p2 == 2) total = total + 10;
                if (p1 == 3 & p2 == 3) total = total + 10;
                if (p1 == 1 & p2 == 1 & p3 == 1) total = total + 20;
                if (p1 == 2 & p2 == 2 & p3 == 2) total = total + 30;
                if (p1 == 3 & p2 == 3 & p3 == 3) total = total + 50;

                //Actualización de saldo
                saldo = saldo + total;
                label3.Text = "Ganancia: " + total.ToString();
                label1.Text = "Saldo: " + saldo.ToString();

            }
        }

    }
}
