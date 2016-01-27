using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SampleApp2
{
    class UserDB
    {
        string MyConnectionString = DataBase.dbAddr;
        MySqlConnection conn;
        MySqlCommand cmd;

        public UserDB()
        {
              conn = new MySqlConnection(MyConnectionString);

        }

        public User searchDataById(string id)
        {
            User sup = null;
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM user where id=@id";
                cmd.Parameters.AddWithValue("@id", id);

                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    sup = new User(dataReader["id"].ToString(), dataReader["no_rfid"].ToString(), dataReader["nama"].ToString());
                }
                dataReader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return sup;
        }

        public User searchDataByRFID(string name)
        {
            User sup = null;
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM user where no_rfid=@id";
                cmd.Parameters.AddWithValue("@id", name);

                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    sup = new User(dataReader["id"].ToString(), dataReader["no_rfid"].ToString(), dataReader["nama"].ToString());
                }
                dataReader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return sup;
        }
    }



}
