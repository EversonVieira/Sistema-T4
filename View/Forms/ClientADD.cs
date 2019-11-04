using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DentAnalyst.View;

namespace DentAnalyst.View
{
    public partial class ClientADD : Form
    {
        Repositório.ClientesDAO clientesDAO = new Repositório.ClientesDAO();
        public ClientADD()
        {
            InitializeComponent();
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
        private void ClientADD_Load(object sender, EventArgs e)
        {
            if(View.ClientTable.Up)
            {
                Cpf.Text = Objetos.objAtb.atb0;
                Nome.Text = Objetos.objAtb.atb2;
                Email.Text = Objetos.objAtb.atb3;
                Telefone.Text = Objetos.objAtb.atb4;
                button1.Text = "ATUALIZAR";
            }
            else
            {
                button1.Text = "SALVAR";
            }
        }

        private void MinBTTN_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CloseBTTN_Click(object sender, EventArgs e)
        {
            Nome.Text = "";
            Cpf.Text = "";
            Email.Text = "";
            Telefone.Text = "";
            View.ClientTable.Up = false;
            this.Hide();
        }

        private void ClientADD_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        public void Button1_Click(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            try
            {
                
                Objetos.Cliente cliente = new Objetos.Cliente();
                cliente.Nome = Nome.Text;
                cliente.Cpf = Cpf.Text;
                cliente.Email = Email.Text;
                cliente.Telefone = Telefone.Text;
                cliente.DataCad = localDate.ToString();
                if (View.ClientTable.Up)
                {
                    clientesDAO.Update(cliente, Objetos.objAtb.atb0);
                }
                else
                {
                    clientesDAO.Insert(cliente);

                }
                Nome.Text = "";
                Cpf.Text = "";
                Email.Text = "";
                Telefone.Text = "";
            }
            catch(Exception)
            {
                throw;
            }

        }

        public void ClientADD_VisibleChanged(object sender, EventArgs e)
        {
            if (View.ClientTable.Up)
            {
                Cpf.Text = Objetos.objAtb.atb0;
                Nome.Text = Objetos.objAtb.atb1;
                Email.Text = Objetos.objAtb.atb2;
                Telefone.Text = Objetos.objAtb.atb3;
                button1.Text = "ATUALIZAR";
            }
            else
            {
                button1.Text = "SALVAR";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Email_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cpf_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Telefone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Nome_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

    }
}
