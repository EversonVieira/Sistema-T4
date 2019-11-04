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
    public partial class CargosController : UserControl
    {
        public static bool openform = false;
        public static bool Up = false;
        Repositório.CargoDAO cargoDAO = new Repositório.CargoDAO();
        public static Forms.CargoADDcs addForm = new Forms.CargoADDcs();
        public CargosController()
        {
            InitializeComponent();
        }
        private void CargosController_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cargoDAO.GetCargosTable();
            addForm.VisibleChanged += RefreshGrid;
        }
        private void RefreshGrid(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cargoDAO.GetCargosTable();
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
        private bool changeATB()
        {
            try
            {
                Objetos.objAtb.atb0 = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                return true;
            }
            catch
            {
                MessageBox.Show("Selecione um item para atualizar", "SELECIONAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Up = true;
            if (changeATB())
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Objetos.Cargo cargo = new Objetos.Cargo();
                cargo.Nome = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                cargoDAO.Remove(cargo);
                dataGridView1.DataSource = cargoDAO.GetCargosTable();
            }
            catch
            {
                MessageBox.Show("Selecione um item para remover", "SELECIONAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("NOME LIKE '{0}*'", textBox1.Text);
        }

    }
}
