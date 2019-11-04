using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DentAnalyst.Repositório
{
    class ServiçoDAO
    {
        private SqlConnection connection;
        private bool StartConnection()
        {
            try
            {
                connection = new SqlConnection();
                connection.ConnectionString = ConnINFO().ConnectionString;
                connection.Open();
                return true;
            }
            catch
            {
                throw;
            }
        }
        private SqlConnectionStringBuilder ConnINFO()
        {
            SqlConnectionStringBuilder sql = new SqlConnectionStringBuilder();
            aux.DataSource = "----";
            aux.InitialCatalog = "----";
            aux.UserID = "----";
            aux.Password = "----";
            return sql;
        }
        public bool Insert(Objetos.Serviço servico)
        {
            try
            {
                if (CheckNome(servico))
                {
                    MessageBox.Show("Serviço já cadastrado","ERRO",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    if (StartConnection())
                    {
                        if (servico.Nome != "" && servico.Valor != "")
                        {
                            string sql = string.Format("Insert into Servicos(Nome,Valor) Values(\'{0}\',\'{1}\')", servico.Nome, servico.Valor);
                            using (var comm = new SqlCommand(sql, connection))
                            {
                                comm.ExecuteNonQuery();
                                CloseConnection();
                                MessageBox.Show("Serviço inserido com sucesso", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Preencha todos os campos em branco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Serviço não pôde ser inserido", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public bool Remove(Objetos.Serviço servico)
        {
            try
            {
                DialogResult result = MessageBox.Show("Tem certeza que deseja remover o serviço?", "REMOVER", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (StartConnection())
                    {
                        string sql = string.Format("delete from Servicos where Nome = \'{0}\'", servico.Nome);
                        using (var comm = new SqlCommand(sql, connection))
                        {
                            comm.ExecuteNonQuery();
                            CloseConnection();
                            MessageBox.Show("Seviço removido com sucesso", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Serviço não pôde ser removido", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
        public bool Update(Objetos.Serviço servico,string OldNome)
        {
            try
            {
                if (CheckNome(servico) && servico.Nome != OldNome)
                {
                    MessageBox.Show("Nome do serviço já cadastrado", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    if (servico.Nome != "")
                    {
                        if (StartConnection())
                        {
                            string sql = string.Format("Update Servicos set Nome = \'{0}\', Valor = \'{1}\' Where Nome = \'{2}\'", servico.Nome, servico.Valor, OldNome);
                            using (var comm = new SqlCommand(sql, connection))
                            {
                                comm.ExecuteNonQuery();
                                CloseConnection();
                                MessageBox.Show("Sucesso ao atualizar o serviço", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Erro ao atualizar o serviço", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Preencha todos os campos obrigatórios em branco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetServicosTable()
        {
            try
            {
                DataTable aux = new DataTable();
                if(StartConnection())
                {
                    string sql = "Select * from Servicos";
                    using (var comm = new SqlCommand(sql,connection))
                    {
                        using (var adapter = new SqlDataAdapter(comm))
                        {
                            adapter.Fill(aux);
                            aux.Columns[0].ColumnName = "NOME";
                            aux.Columns[1].ColumnName = "VALOR";
                        }
                    }
                }
                return aux;

            }
            catch
            {
                throw;
            }
        }
        public bool CheckNome(Objetos.Serviço servico)
        {
            try
            {
                if (StartConnection())
                {
                    string sql = string.Format("Select * from Servicos where Nome = \'{0}\'", servico.Nome);
                    using (var comm = new SqlCommand(sql, connection))
                    {
                        using (var reader = comm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return true;
                            }
                            connection.Close();
                            connection.Dispose();
                            connection = null;
                            return false;
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
        public void GetComboBoxItems(ComboBox comboBox)
        {
            using (DataTable aux = GetServicosTable())
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
        private void CloseConnection()
        {
            connection.Close();
            connection.Dispose();
            connection = null;
        }
    }
}

