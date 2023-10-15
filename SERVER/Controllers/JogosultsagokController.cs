using MySql.Data.MySqlClient;
using SERVER.DatabaseManager;
using SERVER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVER.Controllers
{
    public class JogosultsagokController : BaseDatabaseManager, ISQL
    {
        public List<Record> Select(string where)
        {
            List<Record> records = new List<Record>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            if (where != null)
            {
                if (where.Length > 0)
                {
                    cmd.CommandText = "SELECT * FROM jogosultsagok WHERE " + where + " ORDER BY nev";
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM jogosultsagok ORDER BY nev";
                }
                try
                {
                    MySqlConnection connection = BaseDatabaseManager.connection;
                    connection.Open();
                    cmd.Connection = connection;
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Jogosultsagok jogosultsag = new Jogosultsagok();
                        jogosultsag.Id = int.Parse(reader["id"].ToString());
                        jogosultsag.JogId = int.Parse(reader["JogId"].ToString());
                        jogosultsag.Nev = reader["Nev"].ToString();
                        records.Add(jogosultsag);
                    }
                }
                catch (Exception ex)
                {
                    Jogosultsagok jogosultsag = new Jogosultsagok();
                    jogosultsag.Id = -1;
                    jogosultsag.Nev = ex.Message;
                    records.Add(jogosultsag );
                    
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                Jogosultsagok jogosultsag = new Jogosultsagok();
                jogosultsag.Id = -1;
                jogosultsag.Nev = "Null értéket kaptam a where feltételben";
                records.Add(jogosultsag);
            }
            return records;
        }

        public string Insert(Record record)
        {
            if (record != null)
            {
                Jogosultsagok jogosultsag = record as Jogosultsagok;
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT INTO jogosultsagok (JogId,Nev) VALUES (@JogId,@Nev)";
                try
                {
                    cmd.Connection = BaseDatabaseManager.connection;
                    cmd.Parameters.Add(new MySqlParameter("@JogId", MySqlDbType.Int32)).Value = jogosultsag.JogId;
                    cmd.Parameters.Add(new MySqlParameter("@Nev", MySqlDbType.VarChar)).Value = jogosultsag.Nev;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    cmd.Connection.Close();
                }
                return "Felhasználó adatai sikeresen eltárolva.";
            }
            else
            {
                return "Null értéket kaptam a body-ban";
            }
        }

        public string Update(Record record)
        {
            if (record != null)
            {
                Jogosultsagok jogosultsag = record as Jogosultsagok;
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "UPDATE jogosultsagok SET JogId=@JogId, Nev=@Nev WHERE Id=@Id;";
                try
                {
                    cmd.Connection = BaseDatabaseManager.connection;
                    cmd.Parameters.Add(new MySqlParameter("@JogId", MySqlDbType.Int32)).Value = jogosultsag.JogId;
                    cmd.Parameters.Add(new MySqlParameter("@Nev", MySqlDbType.VarChar)).Value = jogosultsag.Nev;
                    cmd.Connection.Open();
                    int db = cmd.ExecuteNonQuery();
                    if (db == 0)
                    {
                        return "Nincs ilyen ID-val rendelkező jogosultság!";
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    cmd.Connection.Close();
                }
                return "Felhasználó adatainak a módosítása sikeresen megtörtént.";
            }
            else
            {
                return "Null értéket kaptam a body-ban";
            }
        }

        public string Delete(int? id)
        {
            if (id != null)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "DELETE FROM jogosultsagok WHERE Id=@Id;";
                try
                {
                    cmd.Connection = BaseDatabaseManager.connection;
                    cmd.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32)).Value = id;
                    cmd.Connection.Open();
                    int db = cmd.ExecuteNonQuery();
                    if (db == 0)
                    {
                        return "Nincs ilyen ID-val rendelkező felhasznaló!";
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
            else
            {
                return "Null értéket kaptam paraméterként";
            }
            return $"Sikeresen törölve a {id}-vel rendelkező rekord.";
        }
    }
}