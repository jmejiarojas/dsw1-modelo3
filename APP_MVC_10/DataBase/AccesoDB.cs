using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace APP_MVC_10.DataBase
{
    public class AccesoDB
    {
        public static SqlConnection getConnection()
        {
            SqlConnection cnx = new SqlConnection(
              ConfigurationManager.ConnectionStrings["Negocios"].ConnectionString);
            return cnx;
        }
    }
}