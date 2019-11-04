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
    class CargoDAO
    {
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
        public bool Insert(Objetos.Cargo cargo)
        {
            try
            {
                if (CheckCargo(cargo))
                {
                    MessageBox.Show("Cargo já existe", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    if (StartConnection())
                    {
                        if (cargo.Nome != "")
                        {
                            string sql = string.Format("Insert into Cargos(Nome) Values(\'{0}\')", cargo.Nome);
                            using (var comm = new SqlCommand(sql, connection))
                            {
                                comm.ExecuteNonQuery();
                                CloseConnection();
                                MessageBox.Show("Cargo inserido com sucesso", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Erro, preencha os campos obrigatórios em branco", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            CloseConnection();
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public bool Remove(Objetos.Cargo cargo)
        {
            try
            {
                
                DialogResult result =  MessageBox.Show("Tem certeza que deseja remover o cargo?", "REMOVER", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (StartConnection())
                    {
                        string sql = string.Format("Delete from Cargos where Nome = \'{0}\'", cargo.Nome);
                        using (var comm = new SqlCommand(sql, connection))
                        {
                            comm.ExecuteNonQuery();
                            CloseConnection();
                            MessageBox.Show("Sucesso ao remover o cargo", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                    }
                    return false;
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
        public bool Update(Objetos.Cargo cargo,string oldName)
        {
            try
            {
                if (CheckCargo(cargo) && cargo.Nome!=oldName)
                {
                    MessageBox.Show("Erro, cargo já existe", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    if (cargo.Nome != "")
                    {
                        if (StartConnection())
                        {
                            string sql = string.Format("Update Cargos set Nome = \'{0}\' Where Nome = \'{1}\'", cargo.Nome, oldName);
                            using (var comm = new SqlCommand(sql, connection))
                            {
                                comm.ExecuteNonQuery();
                                CloseConnection();
                                MessageBox.Show("Sucesso ao atualizar o cargo", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return true;
                            }
                        }
                        return false;
                    }
                    else
                    {
                        MessageBox.Show("Preencha todos os campos obrigatórios em branco", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetCargosTable()
        {
            DataTable aux = new DataTable();
            try
            {
                if(StartConnection())
                {
                    string sql = "Select * from Cargos";
                    using (var comm = new SqlCommand(sql,connection))
                    {
                        using (var adapter = new SqlDataAdapter(comm))
                        {
                            adapter.Fill(aux);
                            aux.Columns[0].ColumnName = "NOME";
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
        private SqlConnectionStringBuilder ConnInfo()
        {
            SqlConnectionStringBuilder aux = new SqlConnectionStringBuilder();
            aux.DataSource = "----";
            aux.InitialCatalog = "----";
            aux.UserID = "----";
            aux.Password = "----";
            return aux;
        }
        private void CloseConnection()
        {
            connection.Close();
            connection.Dispose();
            connection = null;
        }
        public void GetComboBoxItems(ComboBox comboBox)
        {
            using (DataTable aux = GetCargosTable())
            {
                for(int i = 0; i < aux.Rows.Count;i++)
                {
                    if (!comboBox.Items.Contains(aux.Rows[i][0]))
                    {
                        comboBox.Items.Add(aux.Rows[i][0]);
                    }
                }
            }
        }
        public bool CheckCargo(Objetos.Cargo cargo)
        {
            try
            {
                if (StartConnection())
                {
                    string sql = string.Format("Select * from Cargos where Nome = \'{0}\'", cargo.Nome);
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
    }
}
