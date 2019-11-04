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
    public partial class AgendaADD : Form
    {
        Repositório.CargoDAO cargoDAO = new Repositório.CargoDAO();
        Repositório.ClientesDAO clientesDAO = new Repositório.ClientesDAO();
        Repositório.FuncionariosDAO funcionariosDAO = new Repositório.FuncionariosDAO();
        Repositório.ConsultasDAO consultasDAO = new Repositório.ConsultasDAO();
        Repositório.ServiçoDAO servicoDAO = new Repositório.ServiçoDAO();
        public AgendaADD()
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
        private void AgendaADD_Load(object sender, EventArgs e)
        {
            RefreshCB();
            CPF.Text = "Digite";
            label6.Text = "Nenhum CPF válido selecionado";
            Servico.Text = "Selecione";
            Dentista.Text = "Selecione";
            Data.Text = DateTime.Now.ToString();
        }
        private void RefreshCB()
        {
            clientesDAO.GetComboBoxItemsCPF(CPF);
            servicoDAO.GetComboBoxItems(Servico);
            funcionariosDAO.GetComboBoxItemsDentistas(Dentista);
        }
        private void CPF_SelectedIndexChanged(object sender, EventArgs e)
        {
                label6.Text = clientesDAO.GetNomeCliente(CPF.Text);
        }
        private void CloseBTTN_Click(object sender, EventArgs e)
        {
            View.UserControllers.AgendaControllers.openform = false;
            CPF.Text = "Digite";
            label6.Text = "Nenhum CPF válido selecionado";
            Servico.Text = "Selecione";
            Dentista.Text = "Selecione";
            UserControllers.AgendaControllers.addForm.Visible = false;
        }
        private void MinBTTN_Click(object sender, EventArgs e)
        {
            UserControllers.AgendaControllers.openform = true;
            UserControllers.AgendaControllers.addForm.Visible = false;
        }

        private void LIMPAR_Click(object sender, EventArgs e)
        {
            CPF.Text = "Digite";
            label6.Text = "Nenhum CPF válido selecionado";
            Servico.Text = "Selecione";
            Dentista.Text = "Selecione";
        }

        private void SALVAR_Click(object sender, EventArgs e)
        {
            try
            {
                if (CPF.Items.Contains(CPF.Text))
                {
                    if (Servico.Items.Contains(Servico.Text))
                    {
                        if (Dentista.Items.Contains(Dentista.Text))
                        {
                            if (CPF.Text != "" && label6.Text != "" && Dentista.Text != "" && Servico.Text != "" && Data.Text != "" &&
                                label6.Text != "Nenhum CPF válido selecionado" && Servico.Text != "Selecione" && Dentista.Text != "Selecione")
                            {
                                Objetos.Consulta consulta = new Objetos.Consulta();
                                consulta.Cliente = label6.Text;
                                consulta.CpfCliente = CPF.Text;
                                consulta.DataConsulta = Data.Text;
                                consulta.Dentista = Dentista.Text;
                                consulta.Servico = Servico.Text;
                                consultasDAO.Insert(consulta);
                            }
                            else
                            {
                                MessageBox.Show("Preencha todos os campos para agendar a consulta", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Dentista não cadastrado na base de dados");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Serviço não cadastrado na base de dados");
                    }
                }
                else
                {
                    MessageBox.Show("CPF não cadastrado na base de dados");
                }
            }
            catch
            {
                throw;
            }
        }
        private void CPF_TextUpdate(object sender, EventArgs e)
        {
            if (CPF.Items.Contains(CPF.Text))
            {
                label6.Text = clientesDAO.GetNomeCliente(CPF.Text);
            }
            else
            {
                label6.Text = "Nenhum CPF válido selecionado";
            }
        }
        private void AgendaADD_VisibleChanged_1(object sender, EventArgs e)
        {
            RefreshCB();
        }
    }
}
