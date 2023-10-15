using MySql.Data.MySqlClient;
using SERVER.DatabaseManager;
using SERVER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SERVER.Controllers
{
    public class LoginController : BaseDatabaseManager
    {
        public string Salt(string Fnev)
        {
            string salt = "";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"SELECT * FROM felhasznalok WHERE fnev='{Fnev}'";
            try
            {
                MySqlConnection connection = BaseDatabaseManager.connection;
                connection.Open();
                cmd.Connection = connection;
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                salt = reader["SALT"].ToString();

            }
            catch (Exception ex)
            {
                salt = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return salt;
        }

        public static string GenerateSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] data = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }

        public string Login(Datazs loginData) 
        {
            string returnMessage = "";
            string salt = Salt(loginData.Fnev);
            string hash = GenerateSHA256(loginData.Jelszo + salt);

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"SELECT * FROM felhasznalok WHERE Fnev='{loginData.Fnev}'";

            try
            {
                MySqlConnection connection = BaseDatabaseManager.connection;
                connection.Open();
                cmd.Connection = connection;
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                string hash2 = reader["HASH"].ToString();

                if (hash2 == hash)
                {
                    returnMessage = "Sikeres bejelentkezés!";
                }
                else
                {
                    returnMessage = "Sikertelen bejelentkezés!";
                }
                
            }
            catch (Exception ex)
            {
                returnMessage = ex.Message;
            }
            finally 
            {
                connection.Close();
            }
            return returnMessage;
        }
    }
}