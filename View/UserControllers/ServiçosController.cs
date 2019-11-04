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
    public partial class ServiçosController : UserControl
    {
        Repositório.ServiçoDAO servicoDAO = new Repositório.ServiçoDAO();
        public static bool openform = false;
        public static bool Up = false;
        public static Forms.SrvcADD addForm = new Forms.SrvcADD();
        public ServiçosController()
        {
            InitializeComponent();
        }
        private void RefreshGrid(object sender, EventArgs e)
        {
            dataGridView1.DataSource = servicoDAO.GetServicosTable();
        }

        private void ServiçosController_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = servicoDAO.GetServicosTable();
            addForm.VisibleChanged += RefreshGrid;
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
            if (ChangeATB())
            {
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
        }
        private bool ChangeATB()
        {
            try
            {
                Objetos.objAtb.atb0 = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                Objetos.objAtb.atb1 = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                return true;
            }
            catch
            {
                MessageBox.Show("Selecione uma celula para editar", "SELECIONAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Objetos.Serviço servico = new Objetos.Serviço();
                servico.Nome = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                servico.Valor = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                servicoDAO.Remove(servico);
                dataGridView1.DataSource = servicoDAO.GetServicosTable();
            }
            catch
            {
                MessageBox.Show("Selecione uma celula para remover", "SELECIONAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("NOME LIKE '{0}*'", textBox1.Text);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
