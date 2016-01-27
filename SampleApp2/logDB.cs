using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SampleApp2
{
    class LogDB
    {
        string MyConnectionString = DataBase.dbAddr;
        MySqlConnection conn;
        MySqlCommand cmd;

        public LogDB()
        {
            conn = new MySqlConnection(MyConnectionString);
        }

        public void createDataByDefault(string no_kendaraan, string waktu_masuk, string foto, string barcode)
        {
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO parkir_log (no_kendaraan,waktu_masuk,foto,barcode) VALUES(@no_kendaraan,@waktu_masuk,@foto,@barcode)";
                cmd.Parameters.AddWithValue("@no_kendaraan", no_kendaraan);
                cmd.Parameters.AddWithValue("@waktu_masuk", waktu_masuk);
                cmd.Parameters.AddWithValue("@foto", foto);
                cmd.Parameters.AddWithValue("@barcode", barcode);

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }


        public void createDataByRFID(string rfid, string waktu_masuk, string foto)
        {
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO parkir_log (rfid,waktu_masuk,foto) VALUES(@rfid,@waktu_masuk,@foto)";
                cmd.Parameters.AddWithValue("@rfid", rfid);
                cmd.Parameters.AddWithValue("@waktu_masuk", waktu_masuk);
                cmd.Parameters.AddWithValue("@foto", foto);

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public void updateById(string id, string waktu_keluar)
        {
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE  parkir_log SET waktu_keluar=@waktu_keluar, status=1 WHERE id=@id;";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@waktu_keluar", waktu_keluar);

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public void finish(string id)
        {
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE  parkir_log SET  status=2 WHERE id=@id;";
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Log> searchData()
        {
            List<Log> list = new List<Log>();
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM parkir_log";

                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Log sup = new Log(dataReader["id"].ToString(), dataReader["no_kendaraan"].ToString(), dataReader["waktu_masuk"].ToString(), dataReader["waktu_keluar"].ToString(), dataReader["foto"].ToString(), dataReader["barcode"].ToString(), dataReader["rfid"].ToString());
                    list.Add(sup);
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

            return list;
        }

        public List<Log> searchData(string key)
        {
            List<Log> list = new List<Log>();
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM parkir_log WHERE no_kendaraan LIKE @key";
                cmd.Parameters.AddWithValue("@key", "%" + key + "%");

                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Log sup = new Log(dataReader["id"].ToString(), dataReader["no_kendaraan"].ToString(), dataReader["waktu_masuk"].ToString(), dataReader["waktu_keluar"].ToString(), dataReader["foto"].ToString(), dataReader["barcode"].ToString(), dataReader["rfid"].ToString());
                    list.Add(sup);
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

            return list;
        }

        public Log searchDataById(string id)
        {
            Log sup = null;
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM parkir_log where barcode=@id";
                cmd.Parameters.AddWithValue("@id", id);

                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    sup = new Log(dataReader["id"].ToString(), dataReader["no_kendaraan"].ToString(), dataReader["waktu_masuk"].ToString(), Convert.ToString(dataReader["waktu_keluar"]), dataReader["foto"].ToString(), dataReader["barcode"].ToString(), dataReader["rfid"].ToString());
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

        public Log searchDataByRFID(string name)
        {
            Log sup = null;
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM parkir_log where rfid=@id";
                cmd.Parameters.AddWithValue("@id", name);

                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    sup = new Log(dataReader["id"].ToString(), dataReader["no_kendaraan"].ToString(), dataReader["waktu_masuk"].ToString(), dataReader["waktu_keluar"].ToString(), dataReader["foto"].ToString(), dataReader["barcode"].ToString(), dataReader["rfid"].ToString());
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
