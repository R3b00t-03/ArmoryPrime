using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System.Reflection;

namespace Armory.lib
{
    public class DBInterface
    {
        SqlConnection _con;

        public DBInterface(string server, string database)
        {
            string connection_string = "Data Source=" + server + ";Initial Catalog=" + database + ";Trusted_Connection=Yes";
            _con = new SqlConnection(connection_string);
            _con.Open();
        }

        public List<models.Inventory> GetInventoryData()
        {
            try
            {
                string query = "SELECT * FROM Inventar;";
                SqlCommand command = new SqlCommand(query, _con);
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    List<models.Inventory> result = new List<models.Inventory>();
                    while (reader.Read())
                    {
                        models.Inventory invItm = new models.Inventory();
                        invItm.Id = reader.GetInt32(0);
                        invItm.Artikel = reader.GetString(1);
                        invItm.Bestand = reader.GetInt32(2);
                        invItm.Mindestbestand = reader.GetInt32(3);
                        result.Add(invItm);
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public void update_stock(models.Inventory invItem, int new_stock)
        {
            string query = $"UPDATE Inventar SET Bestand = {new_stock} WHERE ID = {invItem.Id};";
            SqlCommand command = new SqlCommand(query, _con);
            try
            {
                int updated_rows = command.ExecuteNonQuery();
                Debug.WriteLine($"INFO: Updated {updated_rows} rows!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void update_min_stock(models.Inventory invItem, int new_min_stock)
        {
            string query = $"UPDATE Inventar SET Bestand = {new_min_stock} WHERE ID = {invItem.Id};";
            SqlCommand command = new SqlCommand(query, _con);
            try
            {
                int updated_rows = command.ExecuteNonQuery();
                Debug.WriteLine($"INFO: Updated {updated_rows} rows!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        ~DBInterface()
        {
            _con.Close();
        }
    }
}
