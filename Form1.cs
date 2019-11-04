using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace DentAnalyst
{
    public partial class Form1 : Form
    {
        Repositório.ClientesDAO clientesDB = new Repositório.ClientesDAO();
        public Form1()
        {
            InitializeComponent();
        }

        private void CloseBTTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SizeBTTN_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                SizeBTTN.BackgroundImage = Properties.Resources.normalizar3;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                SizeBTTN.BackgroundImage = Properties.Resources.Maximizar2;
            }
        }

        private void MinBTTN_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void reLocaleY(int y)
        {
            if (y > pictureBox2.Location.Y)
            {
                for (int i = pictureBox2.Location.Y; i <= y; i += 10)
                {
                    BeginInvoke((MethodInvoker)delegate
                    {
                        Point p = new Point(0, i);
                        pictureBox2.Location = p;
                    });
                    Thread.Sleep(20);
                }
            }
            else if(y < pictureBox2.Location.Y)
            {
                for (int i = pictureBox2.Location.Y; i >= y; i -= 10)
                {
                    BeginInvoke((MethodInvoker)delegate ()
                    {
                        Point p = new Point(0, i);
                        pictureBox2.Location = p;
                    });
                    Thread.Sleep(20);
                }
            }
        }
        private void reLocale(int x)
        {
            if (x > pictureBox1.Location.X)
            {
                for (int i = pictureBox1.Location.X; i <= x; i += 20)
                {
                    BeginInvoke((MethodInvoker)delegate
                    {
                        Point p = new Point(i, 27);
                        pictureBox1.Location = p;
                    });
                    Thread.Sleep(20);
                }
            }
            else
            {
                for (int i = pictureBox1.Location.X; i >= x; i -= 20)
                {
                    BeginInvoke((MethodInvoker)delegate
                    {
                        Point p = new Point(i, 27);
                        pictureBox1.Location = p;
                    });
                    Thread.Sleep(20);
                }
            }

        }
        private void ts()
        {
            Thread t1 = new Thread(timeUp);
            t1.IsBackground = true;
            t1.Start();
        }
        private void timeUp()
        {
            while (true)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    label1.Text = DateTime.Now.ToString();
                });
                Thread.Sleep(1000);
            }
        }
        bool task = false;
        private void HomeBTTN_Click(object sender, EventArgs e)
        {
        }
        private void ClientesBTTN_Click(object sender, EventArgs e)
        {
            clientTable1.BringToFront();
            
            Task.Run(() => reLocale(ClientesBTTN.Location.X));
        }

        private void CargosBTTN_Click(object sender, EventArgs e)
        {
            cargosController1.BringToFront();
            Task.Run(() => reLocale(CargosBTTN.Location.X));
        }

        private void FuncionariosBTTN_Click(object sender, EventArgs e)
        {
            funcionariosController1.BringToFront();
            Task.Run(() => reLocale(FuncionariosBTTN.Location.X));
        }

        private void ServicoBTTN_Click(object sender, EventArgs e)
        {
            serviçosController1.BringToFront();
            Task.Run(() => reLocale(ServicoBTTN.Location.X));

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ts();
        }


        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Agenda_Click(object sender, EventArgs e)
        {
            agendaControllers1.BringToFront();
            Task.Run(() => reLocale(Agenda.Location.X));
        }

        private void agendaControllers1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
     
        }
        private bool mouseDown;
        private Point lastLocation;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
