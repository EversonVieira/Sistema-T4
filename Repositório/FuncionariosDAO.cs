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
    class FuncionariosDAO
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
        public bool Insert(Objetos.Funcionario funcionario)
        {
            try
            {
                if (CheckCpf(funcionario))
                {
                    MessageBox.Show("Erro, funcionário já cadastrado", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    if (StartConnection())
                    {
                        if (funcionario.Nome != "" && funcionario.Cpf != "")
                        {
                            string sql = string.Format("Insert into Funcionarios(Cpf,Nome,Email,Telefone,Cargo,Salario) " +
                                "Values(\'{0}\',\'{1}\',\'{2}\',\'{3}\',\'{4}\',\'{5}\')",
                                funcionario.Cpf, funcionario.Nome, funcionario.Email, funcionario.Telefone, funcionario.Cargo, funcionario.Salario);
                            using (var comm = new SqlCommand(sql, connection))
                            {
                                comm.ExecuteNonQuery();
                                CloseConnection();
                                MessageBox.Show("Funcionário inserido com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Preencha todos os campos obrigatórios em branco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Funcionário não pôde ser inserido", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            catch
            {
                throw;
            }
        }
        public bool Remove(Objetos.Funcionario funcionario)
        {
            try
            {
                DialogResult result = MessageBox.Show("Tem certeza que deseja remover o funcionário?", "REMOVER", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (StartConnection())
                    {
                        string sql = string.Format("Delete from Funcionarios where Cpf = \'{0}\'", funcionario.Cpf);
                        using (var comm = new SqlCommand(sql, connection))
                        {
                            comm.ExecuteNonQuery();
                            CloseConnection();
                            MessageBox.Show("Sucesso ao remover o funcionário", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Funcionário não pôde ser removido", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public bool Update(Objetos.Funcionario funcionario, string OldCpf)
        {
            try
            {
                if (CheckCpf(funcionario) && funcionario.Cpf != OldCpf)
                {
                    MessageBox.Show("Erro, cpf já cadastrado", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (StartConnection())
                {
                    if (funcionario.Cpf != "" && funcionario.Nome != "")
                    {
                        string sql = string.Format("Update Funcionarios set Cpf = \'{5}\', Nome = \'{0}\', Email = \'{1}\', " +
                            "Telefone = \'{2}\', Cargo = \'{3}\', Salario = \'{4}\' Where Cpf = \'{6}\'",
                            funcionario.Nome, funcionario.Email, funcionario.Telefone, funcionario.Cargo, funcionario.Salario, funcionario.Cpf, OldCpf);
                        using (var comm = new SqlCommand(sql, connection))
                        {
                            comm.ExecuteNonQuery();
                            CloseConnection();
                            MessageBox.Show("Sucesso ao atualizar o funcionário", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Preencha todos os campos obrigatórios em branco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Funcionário não pôde ser atualizado", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetFuncionariosTable()
        {
            try
            {
                DataTable aux = new DataTable();
                if (StartConnection())
                {
                    string sql = "Select * from Funcionarios";
                    using (var comm = new SqlCommand(sql, connection))
                    {
                        using (var adapter = new SqlDataAdapter(comm))
                        {
                            adapter.Fill(aux);
                            aux.Columns[0].ColumnName = "CPF";
                            aux.Columns[1].ColumnName = "NOME";
                            aux.Columns[2].ColumnName = "E-MAIL";
                            aux.Columns[3].ColumnName = "TELEFONE";
                            aux.Columns[4].ColumnName = "CARGO";
                            aux.Columns[5].ColumnName = "SALÁRIO";
                            CloseConnection();
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
        private void CloseConnection()
        {
            connection.Close();
            connection.Dispose();
            connection = null;
        }
        public bool CheckCpf(Objetos.Funcionario funcionario)
        {
            try
            {
                if (StartConnection())
                {
                    string sql = string.Format("Select * from Funcionarios where Cpf = \'{0}\'", funcionario.Cpf);
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
            using (DataTable aux = GetFuncionariosTable())
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
        public DataTable GetDentistasTable()
        {
            try
            {
                DataTable aux = new DataTable();
                if (StartConnection())
                {
                    string sql = "Select * from Funcionarios Where Cargo = \'Dentista\'";
                    using (var comm = new SqlCommand(sql, connection))
                    {
                        using (var adapter = new SqlDataAdapter(comm))
                        {
                            adapter.Fill(aux);
                            aux.Columns[0].ColumnName = "CPF";
                            aux.Columns[1].ColumnName = "NOME";
                            aux.Columns[2].ColumnName = "E-MAIL";
                            aux.Columns[3].ColumnName = "TELEFONE";
                            aux.Columns[4].ColumnName = "CARGO";
                            aux.Columns[5].ColumnName = "SALÁRIO";
                            CloseConnection();
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
        public void GetComboBoxItemsDentistas(ComboBox box)
        {
            try
            {
                using (DataTable aux = GetDentistasTable())
                {
                    for (int i = 0; i < aux.Rows.Count; i++)
                    {
                        if (!box.Items.Contains(aux.Rows[i][1]))
                        {
                            box.Items.Add(aux.Rows[i][1]);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
