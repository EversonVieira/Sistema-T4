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
    public partial class FuncADD : Form
    {
        Repositório.FuncionariosDAO funcionariosDAO = new Repositório.FuncionariosDAO();
        Repositório.CargoDAO cargo = new Repositório.CargoDAO();
        public FuncADD()
        {
            InitializeComponent();
        }

        private void FuncADD_VisibleChanged(object sender, EventArgs e)
        {
            cargo.GetComboBoxItems(Cargo);
            if (View.UserControllers.FuncionariosController.Up)
            {
                Cpf.Text = Objetos.objAtb.atb0;
                Nome.Text = Objetos.objAtb.atb1;
                Email.Text = Objetos.objAtb.atb2;
                Telefone.Text = Objetos.objAtb.atb3;
                Cargo.Text = Objetos.objAtb.atb4;
                Salario.Text = Objetos.objAtb.atb5;
                button1.Text = "ATUALIZAR";
            }
            else
            {
                button1.Text = "SALVAR";
            }
        }

        private void FuncADD_Load(object sender, EventArgs e)
        {
            cargo.GetComboBoxItems(Cargo);
            if (View.UserControllers.FuncionariosController.Up)
            {
                Cpf.Text = Objetos.objAtb.atb0;
                Nome.Text = Objetos.objAtb.atb1;
                Email.Text = Objetos.objAtb.atb2;
                Telefone.Text = Objetos.objAtb.atb3;
                Cargo.Text = Objetos.objAtb.atb4;
                Salario.Text = Objetos.objAtb.atb5;
                button1.Text = "ATUALIZAR";
            }
            else
            {
                button1.Text = "SALVAR";
            }
        }
        string oldS = "";
        private void Salario_TextChanged(object sender, EventArgs e)
        {
            string aux = "";
            for (int i = 0; i < Salario.Text.Length; i++)
            {
                if (Salario.Text[i].ToString() == 0.ToString())
                {
                    aux += 0;
                }
                else if (Salario.Text[i].ToString() == 1.ToString())
                {
                    aux += 1;
                }
                else if (Salario.Text[i].ToString() == 2.ToString())
                {
                    aux += 2;
                }
                else if (Salario.Text[i].ToString() == 3.ToString())
                {
                    aux += 3;
                }
                else if (Salario.Text[i].ToString() == 4.ToString())
                {
                    aux += 4;
                }
                else if (Salario.Text[i].ToString() == 5.ToString())
                {
                    aux += 5;
                }
                else if (Salario.Text[i].ToString() == 6.ToString())
                {
                    aux += 6;
                }
                else if (Salario.Text[i].ToString() == 7.ToString())
                {
                    aux += 7;
                }
                else if (Salario.Text[i].ToString() == 8.ToString())
                {
                    aux += 8;
                }
                else if (Salario.Text[i].ToString() == 9.ToString())
                {
                    aux += 9;
                }
                else if (Salario.Text[i].ToString() == ",")
                {
                    aux += ",";
                }
            }
            if (aux == "")
            {
                Salario.Text = oldS;
            }
            else
            {
                Salario.Text = aux;
            }
            oldS = aux;
        }

        private void MinBTTN_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void CloseBTTN_Click(object sender, EventArgs e)
        {
            View.UserControllers.FuncionariosController.Up = false;
            View.UserControllers.FuncionariosController.openform = false;
            Nome.Text = "";
            Cpf.Text = "";
            Email.Text = "";
            Telefone.Text = "";
            Salario.Text = "";
            Cargo.Text = "";
            View.UserControllers.FuncionariosController.addForm.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Nome.Text = "";
            Cpf.Text = "";
            Email.Text = "";
            Telefone.Text = "";
            Salario.Text = "";
            Cargo.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Objetos.Funcionario funcionario = new Objetos.Funcionario();
            funcionario.Nome = Nome.Text;
            funcionario.Cpf = Cpf.Text;
            funcionario.Email = Email.Text;
            funcionario.Telefone = Telefone.Text;
            funcionario.Salario = "R$ " + Salario.Text;
            funcionario.Cargo = Cargo.Text;
            if (View.UserControllers.FuncionariosController.Up)
            {
                funcionariosDAO.Update(funcionario, Objetos.objAtb.atb0);
            }
            else
            {
                funcionariosDAO.Insert(funcionario);

            }
            Nome.Text = "";
            Cpf.Text = "";
            Email.Text = "";
            Telefone.Text = "";
            Salario.Text = "";
            Cargo.Text = "";
        }

        private void Cargo_TextChanged(object sender, EventArgs e)
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
