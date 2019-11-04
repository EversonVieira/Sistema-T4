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
    class ClientesDAO
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
        public bool Insert(Objetos.Cliente cliente)
        {
            try
            {
                if (CheckCpf(cliente))
                {
                    MessageBox.Show("Erro, cpf já cadastrado", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (StartConnection())
                {
                    string sql = string.Format("Insert into Clientes(Cpf,Nome,Email,Telefone,datCad) VALUES (\'{0}\',\'{1}\',\'{2}\',\'{3}\',\'{4}\')",
                                                                               cliente.Cpf, cliente.Nome, cliente.Email, cliente.Telefone, cliente.DataCad);
                    if (cliente.Cpf != "" && cliente.Nome != "")
                    {
                        using (var comm = new SqlCommand(sql, connection))
                        {
                            comm.ExecuteNonQuery();
                            connection.Close();
                            connection.Dispose();
                            connection = null;
                        }
                        MessageBox.Show("Usuário inserido com sucesso", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Erro, preencha todos os campos obrigatórios em branco", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Usuário não pôde ser inserido", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
        public bool Remove(Objetos.Cliente cliente)
        {
            try
            {
                
                DialogResult result = MessageBox.Show("Tem certeza que deseja remover o cliente?", "REMOVER", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (StartConnection())
                    {
                        string sql = string.Format("delete from Clientes where Cpf = \'{0}\'", cliente.Cpf);
                        using (var comm = new SqlCommand(sql, connection))
                        {
                            comm.ExecuteNonQuery();
                            connection.Close();
                            connection.Dispose();
                            connection = null;
                            MessageBox.Show("Sucesso ao remover o cliente", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erro ao remover o cliente", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public bool Update(Objetos.Cliente cliente,string oldCpf)
        {
            try
            {
                if(CheckCpf(cliente) && cliente.Cpf!=oldCpf)
                {
                    MessageBox.Show("Cpf já cadastrado", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (StartConnection())
                {
                    if (cliente.Cpf != "" && cliente.Nome != "")
                    {
                        string sql = string.Format("Update Clientes set Cpf = \'{0}\', Nome = \'{1}\', Email = \'{2}\', Telefone = \'{3}\' Where Cpf = \'{4}\'",
                            cliente.Cpf, cliente.Nome, cliente.Email, cliente.Telefone, oldCpf);
                        using (var comm = new SqlCommand(sql, connection))
                        {
                            comm.ExecuteNonQuery();
                            CloseConnection();
                            MessageBox.Show("Sucesso ao atualizar o cliente", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erro, preencha todos os campos obrigatórios em branco", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Usuário não pôde ser inserido", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetClientesTable()
        {
            try
            {
                DataTable aux = new DataTable();
                if (StartConnection())
                {

                    string sql = "Select * from Clientes";
                    using (var comm = new SqlCommand(sql, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(comm);
                        adapter.Fill(aux);
                        aux.Columns[0].ColumnName = "CPF";
                        aux.Columns[1].ColumnName = "NOME";
                        aux.Columns[2].ColumnName = "E-MAIL";
                        aux.Columns[3].ColumnName = "TELEFONE";
                        aux.Columns[4].ColumnName = "DAT.CADASTRO";
                    }
                }
                return aux;
            }
            catch
            {
                throw;
            }
        }
        public bool CheckCpf(Objetos.Cliente cliente)
        {
            try
            {
                if (StartConnection())
                {
                    string sql = string.Format("Select * from Clientes where Cpf = \'{0}\'", cliente.Cpf);
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
        private void CloseConnection()
        {
            connection.Close();
            connection.Dispose();
            connection = null;
        }
        public void GetComboBoxItems(ComboBox comboBox)
        {
            using (DataTable aux = GetClientesTable())
            {
                for (int i = 0; i < aux.Rows.Count; i++)
                {
                    if (!comboBox.Items.Contains(aux.Rows[i][1]))
                    {
                        comboBox.Items.Add(aux.Rows[i][1]);
                    }
                }
            }
        }
        public void GetComboBoxItemsCPF(ComboBox comboBox)
        {
            using (DataTable aux = GetClientesTable())
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

        public string GetNomeCliente(string Cpf)
        {
            try
            {
                string aux = "";
                if(StartConnection())
                {
                    string sql = string.Format("Select * from Clientes Where Cpf = \'{0}\'", Cpf);
                    using (var comm = new SqlCommand(sql,connection))
                    {
                        var reader = comm.ExecuteReader();
                        while(reader.Read())
                        {
                            aux = reader[1].ToString();
                        }
                    }
                }
                return aux;
            }
            catch
            {
                MessageBox.Show("Erro, nenhum cliente Cadastrado com esse CPF");
                throw;
            }
        }
    }
}
