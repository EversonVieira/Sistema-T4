using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentAnalyst.View.UserControllers
{
    public partial class FuncionariosController : UserControl
    {
        public static View.Forms.FuncADD addForm = new Forms.FuncADD();
        Repositório.CargoDAO cargoDAO = new Repositório.CargoDAO();
        public static bool openform = false;
        public static bool Up = false;
        Repositório.FuncionariosDAO funcionariosDAO = new Repositório.FuncionariosDAO();
        public FuncionariosController()
        {
            InitializeComponent();
        }
        private void FuncionariosController_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = funcionariosDAO.GetFuncionariosTable();
            addForm.VisibleChanged += RefreshGrid;
        }
        private void RefreshGrid(object sender, EventArgs e)
        {
            dataGridView1.DataSource = funcionariosDAO.GetFuncionariosTable();
        }

        private void AddBTTN_Click(object sender, EventArgs e)
        {
            Up = false;
            if (!openform)
            {
                openform = true;
                addForm.ShowDialog();
            }
            else
            {
                addForm.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Up = true;
            if (changeATB())
            {
                MessageBox.Show(openform.ToString());
                if (!openform)
                {
                    addForm.ShowDialog();
                    openform = true;
                }
                else
                {
                    addForm.Visible = true;
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
                Objetos.objAtb.atb4 = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                Objetos.objAtb.atb5 = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                return true;
            }
            catch
            {
                MessageBox.Show("Selecione um item para editar", "SELECIONAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Up = true;
            changeATB();
            if (!openform)
            {
                addForm.ShowDialog();
                openform = true;
            }
            else
            {
                addForm.Visible = true;
                openform = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Objetos.Funcionario funcionario = new Objetos.Funcionario();
                funcionario.Cpf = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                funcionariosDAO.Remove(funcionario);
                dataGridView1.DataSource = funcionariosDAO.GetFuncionariosTable();
            }
            catch
            {
                MessageBox.Show("Selecione um item para remover", "SELECIONAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("CPF LIKE '{0}*' OR NOME LIKE '{0}*' OR " +
              "[E-MAIL] LIKE '{0}*' OR TELEFONE LIKE '{0}*' OR  [CARGO] LIKE '{0}*' OR  [SALÁRIO] LIKE '{0}*'", textBox1.Text);
        }
    }

}
