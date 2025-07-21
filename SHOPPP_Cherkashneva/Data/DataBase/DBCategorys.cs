﻿using MySql.Data.MySqlClient;
using SHOPPP_Cherkashneva.Data.Common;
using SHOPPP_Cherkashneva.Data.Interfaces;
using SHOPPP_Cherkashneva.Data.Models;
using System.Collections;
using System.Collections.Generic;

namespace SHOPPP_Cherkashneva.Data.DataBase
{
    public class DBCategorys : ICategorys
    {
       public IEnumerable<Categorys> AllCategorys
        {
            get
            {
                List<Categorys> allCategorys = new List<Categorys>();
                MySqlConnection connection = Connection.OpenConnection();
                MySqlDataReader dbCategorys = Connection.GetQuery("SELECT * FROM shop.Categorys ORDER BY `Name`;", connection);

                while (dbCategorys.Read())
                {
                    allCategorys.Add(new Categorys()
                    {
                        Id = dbCategorys.IsDBNull(0) ? -1 : dbCategorys.GetInt32(0),
                        Name = dbCategorys.IsDBNull(1) ? null : dbCategorys.GetString(1),
                        Description = dbCategorys.IsDBNull(2) ? null : dbCategorys.GetString(2)
                    });
                }

                Connection.CloseConnection(connection);


                return allCategorys;
            }
        }
    }
}
