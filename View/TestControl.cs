using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentAnalyst.View
{
    public partial class TestControl : UserControl
    {
        Repositório.CargoDAO cargoDAO = new Repositório.CargoDAO();
        Repositório.ClientesDAO clientesDAO = new Repositório.ClientesDAO();
        Repositório.FuncionariosDAO funcionariosDAO = new Repositório.FuncionariosDAO();
        Repositório.ServiçoDAO servicoDAO = new Repositório.ServiçoDAO();
        public TestControl()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Objetos.Cliente cliente = new Objetos.Cliente();
            Objetos.Cargo cargo = new Objetos.Cargo();
            Objetos.Funcionario funcionario = new Objetos.Funcionario();
            Objetos.Serviço servico = new Objetos.Serviço();

            cliente.Cpf = "t3st3";
            cliente.Nome = "t3st3";
            cliente.Email = "t3st3";
            cliente.Telefone = "t3st3";
            cliente.DataCad = "t3st3";

            cargo.Nome = "t3st3";

            funcionario.Nome = "t3st3";
            funcionario.Cpf = "t3st3";
            funcionario.Email = "t3st3";
            funcionario.Telefone = "t3st3";
            funcionario.Cargo = "t3st3";
            funcionario.Salario = "t3ste";

            servico.Nome = "t3st3";
            servico.Valor = "t3st3";
            if (clientesDAO.Insert(cliente) && cargoDAO.Insert(cargo) && funcionariosDAO.Insert(funcionario) && servicoDAO.Insert(servico))
            {
                MessageBox.Show("INSERÇÃO OK");
            }
            else
            {
                MessageBox.Show("ERRO INSERÇÃO");
            }
            if (clientesDAO.Remove(cliente) && cargoDAO.Remove(cargo) && funcionariosDAO.Remove(funcionario) && servicoDAO.Remove(servico))
            {
                MessageBox.Show("REMOVE OK");
            }
            else
            {
                MessageBox.Show("ERRO REMOVE");
            }
        }
    }
}
