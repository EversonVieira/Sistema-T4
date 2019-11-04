using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace DentAnalyst.View
{
    public partial class ClientTable : UserControl
    {
        Repositório.ClientesDAO clientesDAO = new Repositório.ClientesDAO();
        public static bool openform = false;
        public static ClientADD clientADD = new ClientADD();
        public static bool Up = false;
        public ClientTable()
        {
            InitializeComponent();
        }
        private void ClientTable_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clientesDAO.GetClientesTable();
            clientADD.VisibleChanged += RefreshGrid;
        }

        private void RefreshGrid(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clientesDAO.GetClientesTable();
        }


        private void AddBTTN_Click_1(object sender, EventArgs e)
        {
            Up = false;
            if (!openform)
            {
                clientADD.ShowDialog();
            }
            else
            {
                clientADD.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Objetos.Cliente cliente = new Objetos.Cliente();
                cliente.Cpf = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                clientesDAO.Remove(cliente);
                dataGridView1.DataSource = clientesDAO.GetClientesTable();
            }
            catch
            {
                MessageBox.Show("Selecione um item para remover", "Selecionar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("CPF LIKE '{0}*' OR NOME LIKE '{0}*' OR " +
              "[E-MAIL] LIKE '{0}*' OR TELEFONE LIKE '{0}*' OR  [DAT.CADASTRO] LIKE '{0}*'", textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Up = true;
            if (changeATB())
            {
                if (!openform)
                {
                    clientADD.ShowDialog();
                }
                else
                {
                    clientADD.Visible = true;
                }
            }
        }
        private bool changeATB()
        {
            try
            {
                Objetos.objAtb.atb0 = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                Objetos.objAtb.atb1 = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                Objetos.objAtb.atb2 = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                Objetos.objAtb.atb3 = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                return true;
            }
            catch
            {
                MessageBox.Show("Selecione um item para atualizar","SELECIONAR",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Up = true;
            changeATB();
            if (!openform)
            {
                clientADD.Show();
                openform = true;
            }
            else
            {
                clientADD.Visible = true;
                openform = true;
            }
        }
    }
}
