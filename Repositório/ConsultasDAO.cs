using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace DentAnalyst.Repositório
{
    class ConsultasDAO
    {
        private SqlConnectionStringBuilder ConnInfo()
        {
            SqlConnectionStringBuilder aux = new SqlConnectionStringBuilder();
            aux.DataSource = "----";
            aux.InitialCatalog = "----";
            aux.UserID = "----";
            aux.Password = "----";
            return aux;
        }
        private SqlConnection connection;

        private bool StartConnection()
        {
            try
            {
                connection = new SqlConnection();
                connection.ConnectionString = ConnInfo().ConnectionString;
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Insert(Objetos.Consulta consulta)
        {
            try
            {
                if (!CheckConsulta(consulta))
                {
                    if (StartConnection())
                    {
                        string sql = string.Format("Insert into Consultas(Cliente,Dentista,Servico,Data,CpfCliente) Values(\'{0}\',\'{1}\',\'{2}\',\'{3}\',\'{4}\')",
                            consulta.Cliente, consulta.Dentista, consulta.Servico, consulta.DataConsulta, consulta.CpfCliente);
                        using (var comm = new SqlCommand(sql, connection))
                        {
                            comm.ExecuteNonQuery();
                            CloseConnection();
                            MessageBox.Show("Consulta agendada com sucesso", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erro, não foi possível agendar a consulta","ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Cliente já cadastrado para este dia", "Agendar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
        public bool Update(Objetos.Consulta consulta,string oldClient)
        {
            try
            {
                if (StartConnection())
                {
                    string sql = string.Format("Update Consultas set Cliente = \'{0}\', Dentista = \'{1}\', Servico = \'{2}\', Data = \'{3}\' where" +
                        "CpfCliente = \'{4}\'", consulta.Cliente, consulta.Dentista, consulta.Servico, consulta.DataConsulta, oldClient);
                    using (var comm = new SqlCommand(sql, connection))
                    {
                        comm.ExecuteNonQuery();
                        CloseConnection();
                        MessageBox.Show("Sucesso ao atualizar a consulta", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar a consulta", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
        public bool Remove(Objetos.Consulta consulta)
        {
            try
            {
                if(StartConnection())
                {
                    string sql = string.Format("Delete from Consultas where CpfCliente = \'{0}\' AND Data = \'{1}\' AND " +
                                                                           "Servico = \'{2}\' AND Dentista = \'{3}\'",
                                                                           consulta.CpfCliente,consulta.DataConsulta,
                                                                           consulta.Servico,consulta.Dentista);
                    using (var comm = new SqlCommand(sql,connection))
                    {
                        comm.ExecuteNonQuery();
                        CloseConnection();
                        MessageBox.Show("Sucesso ao remover a consulta", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("Erro ao remover a consulta", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetConsultasTable()
        {
            try
            {
                using (DataTable aux = new DataTable())
                {
                    if (StartConnection())
                    {
                        string sql = "Select * from Consultas";
                        using(var comm = new SqlCommand(sql,connection))
                        {
                            using(SqlDataAdapter adapter = new SqlDataAdapter(comm))
                            {
                                adapter.Fill(aux);
                                aux.Columns[0].ColumnName = "CLIENTE";
                                aux.Columns[1].ColumnName = "DENTISTA";
                                aux.Columns[2].ColumnName = "SERVIÇO";
                                aux.Columns[3].ColumnName = "DATA";
                                aux.Columns[4].ColumnName = "CPF_DO_CLIENTE";
                            }
                        }
                    }
                    return aux;
                }
            }
            catch
            {
                throw;
            }
        }
        private void CloseConnection()
        {
            connection.Close();
            connection.Dispose();
            connection = null;
        }
        public void GetComboBoxItems(ComboBox comboBox)
        {
            using (DataTable aux = GetConsultasTable())
            {
                for (int i = 0; i < aux.Rows.Count; i++)
                {
                    if (!comboBox.Items.Contains(aux.Rows[i][0]))
                    {
                        comboBox.Items.Add(aux.Rows[i][0]);
                    }
                }
            }
        }
        private bool CheckConsulta(Objetos.Consulta consulta)
        {
            try
            {
                if(StartConnection())
                {
                    string sql = string.Format("SELECT * FROM Consultas Where CpfCliente = \'{0}\' AND Data = \'{1}\'", consulta.CpfCliente, consulta.DataConsulta);
                    using(var comm = new SqlCommand(sql,connection))
                    {
                        SqlDataReader reader = comm.ExecuteReader();
                        while(reader.Read())
                        {
                            return true;
                        }
                        
                    }
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

    }
}
