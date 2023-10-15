using MySql.Data.MySqlClient;
using SERVER.DatabaseManager;
using SERVER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVER.Controllers
{
    public class FelhasznalokController:BaseDatabaseManager,ISQL
    {
        public List<Record> Select(string where)
        {
            List<Record> records = new List<Record>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType=System.Data.CommandType.Text;
            if (where != null)
            {
                if (where.Length > 0)
                {
                    cmd.CommandText = "SELECT * FROM felhasznalok WHERE "+where+" ORDER BY nev";
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM felhasznalok ORDER BY nev";
                }
                try
                {
                    MySqlConnection connection = BaseDatabaseManager.connection;
                    connection.Open();
                    cmd.Connection = connection;
                    MySqlDataReader reader =cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Felhasznalo felhasznalo = new Felhasznalo();
                        felhasznalo.Id = int.Parse(reader["id"].ToString());
                        felhasznalo.Fnev = reader["Fnev"].ToString();
                        felhasznalo.SALT = reader["SALT"].ToString();
                        felhasznalo.HASH = reader["HASH"].ToString();
                        felhasznalo.Nev = reader["Nev"].ToString();
                        felhasznalo.Jog = byte.Parse(reader["Jog"].ToString());
                        felhasznalo.Aktiv = bool.Parse(reader["Aktiv"].ToString().ToLower());
                        felhasznalo.Email = reader["Email"].ToString();
                        felhasznalo.FenykepUtvonal = reader["FenykepUtvonal"].ToString();
                        records.Add( felhasznalo );
                    }
                }
                catch (Exception ex)
                {
                    Felhasznalo felhasznalo = new Felhasznalo();
                    felhasznalo.Id = -1;
                    felhasznalo.Email = ex.Message;
                    records.Add(felhasznalo);
                }
                finally 
                { 
                    connection.Close(); 
                }
            }
            else
            {
                Felhasznalo felhasznalo = new Felhasznalo();
                felhasznalo.Id = -1;
                felhasznalo.Email = "Null értéket kapta a WHERE feltételben";
                records.Add(felhasznalo);
            }
            return records;
        }

        public string Insert(Record record)
        {
            if (record != null)
            {
                Felhasznalo felhasznalo = record as Felhasznalo;
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType=System.Data.CommandType.Text;
                cmd.CommandText = "INSERT INTO felhasznalok (Fnev,SALT,HASH,Nev,Jog,Aktiv,Email,FenykepUtvonal) VALUES (@Fnev,@SALT,@HASH,@Nev,@Jog,@Aktiv,@Email,@FenykepUtvonal)";
                try
                {
                    cmd.Connection = BaseDatabaseManager.connection;
                    cmd.Parameters.Add(new MySqlParameter("@Fnev",MySqlDbType.VarChar)).Value=felhasznalo.Fnev;
                    cmd.Parameters.Add(new MySqlParameter("@SALT", MySqlDbType.VarChar)).Value = felhasznalo.SALT;
                    cmd.Parameters.Add(new MySqlParameter("@HASH", MySqlDbType.VarChar)).Value = felhasznalo.HASH;
                    cmd.Parameters.Add(new MySqlParameter("@Nev", MySqlDbType.VarChar)).Value = felhasznalo.Nev;
                    cmd.Parameters.Add(new MySqlParameter("@Jog", MySqlDbType.Int32)).Value = felhasznalo.Jog;
                    cmd.Parameters.Add(new MySqlParameter("@Aktiv", MySqlDbType.Byte)).Value = felhasznalo.Aktiv;
                    cmd.Parameters.Add(new MySqlParameter("@Email", MySqlDbType.VarChar)).Value = felhasznalo.Email;
                    cmd.Parameters.Add(new MySqlParameter("@FenykepUtvonal", MySqlDbType.VarChar)).Value = felhasznalo.FenykepUtvonal;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch(Exception ex)
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
                Felhasznalo felhasznalo = record as Felhasznalo;
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "UPDATE felhasznalok SET Fnev=@Fnev,SALT=@SALT,HASH=@HASH,Nev=@Nev,Jog=@Jog,Aktiv=@Aktiv,Email=@Email,FenykepUtvonal=@FenykepUtvonal WHERE Id=@Id;";
                try
                {
                    cmd.Connection = BaseDatabaseManager.connection;
                    cmd.Parameters.Add(new MySqlParameter("@Id",MySqlDbType.Int32)).Value=felhasznalo.Id;
                    cmd.Parameters.Add(new MySqlParameter("@Fnev", MySqlDbType.VarChar)).Value = felhasznalo.Fnev;
                    cmd.Parameters.Add(new MySqlParameter("@SALT", MySqlDbType.VarChar)).Value = felhasznalo.SALT;
                    cmd.Parameters.Add(new MySqlParameter("@HASH", MySqlDbType.VarChar)).Value = felhasznalo.HASH;
                    cmd.Parameters.Add(new MySqlParameter("@Nev", MySqlDbType.VarChar)).Value = felhasznalo.Nev;
                    cmd.Parameters.Add(new MySqlParameter("@Jog", MySqlDbType.Int32)).Value = felhasznalo.Jog;
                    cmd.Parameters.Add(new MySqlParameter("@Aktiv", MySqlDbType.Byte)).Value = felhasznalo.Aktiv;
                    cmd.Parameters.Add(new MySqlParameter("@Email", MySqlDbType.VarChar)).Value = felhasznalo.Email;
                    cmd.Parameters.Add(new MySqlParameter("@FenykepUtvonal", MySqlDbType.VarChar)).Value = felhasznalo.FenykepUtvonal;
                    cmd.Connection.Open();
                    int db=cmd.ExecuteNonQuery();
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
                return "Felhasználó adatainak a módosítása sikeresen megtörtént.";
            }
            else
            {
                return "Null értéket kaptam a body-ban";
            }
        }

        public string Delete(int? id) 
        {
            if (id !=null)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "DELETE FROM felhasznalok WHERE Id=@Id;";
                try
                {
                    cmd.Connection = BaseDatabaseManager.connection;
                    cmd.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32)).Value = id;
                    cmd.Connection.Open();
                    int db=cmd.ExecuteNonQuery();
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