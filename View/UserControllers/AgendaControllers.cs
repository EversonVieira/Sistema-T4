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
    public partial class AgendaControllers : UserControl
    {
        public static View.Forms.AgendaADD addForm = new Forms.AgendaADD();
        public static bool openform = false;
        public static bool up = false;
        Repositório.ConsultasDAO consultasDAO = new Repositório.ConsultasDAO();
        public AgendaControllers()
        {
            InitializeComponent();
        }

        private void AddBTTN_Click(object sender, EventArgs e)
        {
            up = false;
            if(!openform)
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
            up = true;
            if (!openform)
            {
                openform = true;
                addForm.ShowDialog();
            }
            else
            {
                addForm.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Objetos.Consulta consulta = new Objetos.Consulta();
                consulta.CpfCliente = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                consulta.DataConsulta = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                consulta.Servico = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                consulta.Dentista = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                consultasDAO.Remove(consulta);
                RefreshGrid(sender, e);
            }
            catch
            {
                MessageBox.Show("Erro, selecione um item para remover", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AgendaControllers_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = consultasDAO.GetConsultasTable();
            addForm.VisibleChanged += RefreshGrid;
        }
        private void RefreshGrid(object sender, EventArgs e)
        {
            dataGridView1.DataSource = consultasDAO.GetConsultasTable();
            this.Show();
            this.Visible = true;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("CLIENTE LIKE '{0}*' OR " +
                                                                                          "DENTISTA LIKE '{0}*' OR " +
                                                                                          "[SERVIÇO] LIKE '{0}*' OR " +
                                                                                          "DATA LIKE '{0}*' OR " +
                                                                                          "CPF_DO_CLIENTE LIKE '{0}*'",
                textBox1.Text);
        }
    }
}
