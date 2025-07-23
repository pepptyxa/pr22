using MySql.Data.MySqlClient;
using Mysqlx.Connection;
using SHOPPP_Cherkashneva.Data.Common;
using SHOPPP_Cherkashneva.Data.Interfaces;
using SHOPPP_Cherkashneva.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace SHOPPP_Cherkashneva.Data.DataBase
{
    public class BDItems : IItems
    {
        public ICategorys ICategorys = new DBCategorys();
        public IEnumerable<Items> AllItems
        {
            get
            {
                List<Items> allItems = new List<Items>();
                MySqlConnection connection = Connection.OpenConnection();
                MySqlDataReader dbItems = Connection.GetQuery("SELECT * FROM shop.Items ORDER BY `Name`;", connection);

                while (dbItems.Read())
                {
                    allItems.Add(new Items()
                    {
                        Id = dbItems.IsDBNull(0) ? -1 : dbItems.GetInt32(0),
                        Name = dbItems.IsDBNull(1) ? null : dbItems.GetString(1),
                        Description = dbItems.IsDBNull(2) ? null : dbItems.GetString(2),
                        Img = dbItems.IsDBNull(3) ? null : dbItems.GetString(3),
                        Price = dbItems.IsDBNull(4) ? 0 : dbItems.GetInt32(4),
                        Category = dbItems.IsDBNull(5) ? null : ICategorys.AllCategorys.Where(x => x.Id == dbItems.GetInt32(5)).First()
                    });
                }

                Connection.CloseConnection(connection);


                return allItems;
            }
        }

        public int Add(Items item)
        {
            MySqlConnection connection = Connection.OpenConnection();
            Connection.GetQuery($"INSERT INTO " +
                                    $"`Items` (" +
                                        $"`Name`, " +
                                        $"`Description`, " +
                                        $"`Img`, " +
                                        $"`Price`, " +
                                        $"`IdCategory`) " +
                                $"VALUES (" +
                                        $"'{item.Name}', " +
                                        $"'{item.Description}', " +
                                        $"'{item.Img}', " +
                                        $"{item.Price}, " +
                                        $"{item.Category.Id});", 
                                        connection);
            Connection.CloseConnection(connection);

            int idItem = -1;
            connection = Connection.OpenConnection();
            MySqlDataReader dbItem = Connection.GetQuery($"SELECT " +
                                                            $"`Id` " +
                                                         $"FROM " +
                                                            $"`Items` " +
                                                         $"WHERE "+
                                                            $"`Name`= '{item.Name}' AND "+
                                                            $"`Description`= '{item.Description}' AND "+
                                                            $"`Img`= '{item.Img}' AND "+
                                                            $"`Price`= {item.Price} AND "+
                                                            $"`IdCategory`= {item.Category.Id};", connection);
            if (dbItem.HasRows)
            {
                dbItem .Read();
                idItem = dbItem.GetInt32(0);
            }
            Connection.CloseConnection(connection);
            return idItem;
        }
    }
}
