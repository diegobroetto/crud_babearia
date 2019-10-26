using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AppBarber
{
    class dbConnection
    {
        private static string host = "localhost";
        private static string port = "3306";
        private static string user = "root";
        private static string db = "appbarber";
        private static string pass = "";
        MySqlConnection objcon = new MySqlConnection($"server={host}; port={port}; User id={user}; database={db}; password={pass}");

        public dbConnection()
        {
            try
            {
                objcon.Open();
            }
            catch(Exception e)
            {
                MessageBox.Show($"ERRO = {e}");
            }
        }

        public bool statusConexao()
        {
            if (objcon.State == ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool inserirUser(string nome, string user, string password)
        {
            try
            {
                MySqlCommand objInsere = new MySqlCommand("INSERT INTO usuarios (nome, user, senha) VALUES (@nome, @user, @senha)", objcon);
                objInsere.Parameters.Add("@nome", MySqlDbType.VarChar, 45).Value = nome;
                objInsere.Parameters.Add("@user", MySqlDbType.VarChar, 15).Value = user;
                objInsere.Parameters.Add("@senha", MySqlDbType.VarChar, 14).Value = password;

                objInsere.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show($"ERRO = {e}");
                return false;
            }
        }

        public DataTable getUsers()
        {
            MySqlCommand objSelect = new MySqlCommand("SELECT * FROM usuarios", objcon);
            MySqlDataReader reader = objSelect.ExecuteReader();

            DataTable data = new DataTable();
            data.Load(reader);
            return data;
        }

        public bool alteraUser(int id, string nome, string user, string senha)
        {
            try
            {

                MySqlCommand objAltera = new MySqlCommand($"UPDATE usuarios SET nome = @nome, user = @user, senha = @senha  WHERE idusuario = {Convert.ToInt32(id)}");
                objAltera.Parameters.Add("@nome", MySqlDbType.VarChar, 45).Value = nome;
                objAltera.Parameters.Add("@user", MySqlDbType.VarChar, 14).Value = user;
                objAltera.Parameters.Add("@senha", MySqlDbType.VarChar, 14).Value = senha;
                objAltera.ExecuteNonQuery();
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show($"ERRO {e}");
                return false;
            }
            
        }

        public bool validaLogin(string login, string senha)
        {
            try
            {

                MySqlCommand objLogin = new MySqlCommand("SELECT COUNT(user) AS result FROM usuarios WHERE user = @user AND senha = @senha", objcon);
                objLogin.Parameters.Add("@user", MySqlDbType.VarChar, 35).Value = login;
                objLogin.Parameters.Add("@senha", MySqlDbType.VarChar, 14).Value = senha;

                MySqlDataReader read = objLogin.ExecuteReader();
                read.Read();
                if (Convert.ToBoolean(read["result"]))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception er)
            {
                MessageBox.Show($"ERRO = {er} ");
                return false;
            }
        }
        
        public DataTable consultaUser(string coluna = null, string valor = null)
        {
            string query = "SELECT * FROM usuarios";

            if (coluna != null && valor != null)
            {
                query += $" WHERE {coluna.ToLower()} LIKE '%{valor.ToLower()}%'";
            }
            MySqlCommand objSelect = new MySqlCommand(query, objcon);
            MySqlDataReader reader = objSelect.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(reader);
            return data;

        }

        public void deletaUser(string id)
        {
            
            MySqlCommand objDelete = new MySqlCommand($"DELETE FROM usuarios WHERE idusuario = @id", objcon);
            objDelete.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(id);

            objDelete.ExecuteNonQuery();
        }

    }
}
