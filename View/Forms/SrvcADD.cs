using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentAnalyst.View.Forms
{
    public partial class SrvcADD : Form
    {
        Repositório.ServiçoDAO servicoDAO = new Repositório.ServiçoDAO();
        
        public SrvcADD()
        {
            InitializeComponent();
        }

        private void MinBTTN_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void CloseBTTN_Click(object sender, EventArgs e)
        {
            View.UserControllers.ServiçosController.openform = false;
            UserControllers.ServiçosController.Up = false;
            Nome.Text = "";
            Valor.Text = "";
            Hide();
        }

        private void SrvcADD_VisibleChanged(object sender, EventArgs e)
        {
            if(UserControllers.ServiçosController.Up)
            {
                Nome.Text = Objetos.objAtb.atb0;
                Valor.Text = Objetos.objAtb.atb1;
                button1.Text = "ATUALIZAR";
            }
            else
            {
                Nome.Text = "";
                Valor.Text = "";
                button1.Text = "SALVAR";
            }
        }

        private void SrvcADD_Load(object sender, EventArgs e)
        {
            if (UserControllers.ServiçosController.Up)
            {
                Nome.Text = Objetos.objAtb.atb0;
                Valor.Text = Objetos.objAtb.atb1;
                button1.Text = "ATUALIZAR";
            }
            else
            {
                Nome.Text = "";
                Valor.Text = "";
                button1.Text = "SALVAR";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Objetos.Serviço servico = new Objetos.Serviço();
            servico.Nome = Nome.Text;
            servico.Valor = "R$ " + Valor.Text;
            if(UserControllers.ServiçosController.Up)
            {
                servicoDAO.Update(servico, Objetos.objAtb.atb0);
            }
            else
            {
                servicoDAO.Insert(servico);
            }
            Nome.Text = "";
            Valor.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Nome.Text = "";
            Valor.Text = "";
        }
        string oldS = "";
        private void Valor_TextChanged(object sender, EventArgs e)
        {
            string aux = "";
            for (int i = 0; i < Valor.Text.Length; i++)
            {
                if (Valor.Text[i].ToString() == 0.ToString())
                {
                    aux += 0;
                }
                else if (Valor.Text[i].ToString() == 1.ToString())
                {
                    aux += 1;
                }
                else if (Valor.Text[i].ToString() == 2.ToString())
                {
                    aux += 2;
                }
                else if (Valor.Text[i].ToString() == 3.ToString())
                {
                    aux += 3;
                }
                else if (Valor.Text[i].ToString() == 4.ToString())
                {
                    aux += 4;
                }
                else if (Valor.Text[i].ToString() == 5.ToString())
                {
                    aux += 5;
                }
                else if (Valor.Text[i].ToString() == 6.ToString())
                {
                    aux += 6;
                }
                else if (Valor.Text[i].ToString() == 7.ToString())
                {
                    aux += 7;
                }
                else if (Valor.Text[i].ToString() == 8.ToString())
                {
                    aux += 8;
                }
                else if (Valor.Text[i].ToString() == 9.ToString())
                {
                    aux += 9;
                }
                else if (Valor.Text[i].ToString() == ",")
                {
                    aux += ",";
                }
            }
            if (aux == "")
            {
                Valor.Text = oldS;
            }
            else
            {
                Valor.Text = aux;
            }
            oldS = aux;
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
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
