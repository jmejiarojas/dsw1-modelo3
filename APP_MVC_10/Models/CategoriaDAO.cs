using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using APP_MVC_10.DataBase;
using APP_MVC_10.Entity;
using APP_MVC_10.Service;

namespace APP_MVC_10.Models
{
    public class CategoriaDAO : ICrudCategoria<Categoria>
    {
        public List<Categoria> readCatAll()
        {
            List<Categoria> lista = new List<Categoria>();
            SqlConnection cn = AccesoDB.getConnection();
            SqlCommand cmd = new SqlCommand("usp_Categoria_Listar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Categoria cat = new Categoria()
                    {
                        IdCategoria = Convert.ToInt32(dr[0]),
                        Descripcion = dr[1].ToString()
                    };
                    lista.Add(cat);
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lista;
        }
    }
}