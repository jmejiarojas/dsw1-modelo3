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
    public class ProductoDAO : ICrudDao<Producto>
    {
        public void create(Producto p)
        {
            SqlConnection cn = AccesoDB.getConnection();
            SqlCommand cmd = new SqlCommand("usp_Producto_Insertar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdProducto", p.IdProducto);
            cmd.Parameters.AddWithValue("@NombreProducto", p.NombreProducto);
            cmd.Parameters.AddWithValue("@IdProveedor", p.IdProveedor);
            cmd.Parameters.AddWithValue("@Idcategoria", p.IdCategoria);
            cmd.Parameters.AddWithValue("@umedida", p.umedida);
            cmd.Parameters.AddWithValue("@PrecioUnidad", p.Precio);
            cmd.Parameters.AddWithValue("@Stock", p.Stock);
            try
            {
                cn.Open();
                bool iresult = cmd.ExecuteNonQuery() == 1 ? true : false;
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void delete(Producto p)
        {
            SqlConnection cn = AccesoDB.getConnection();
            SqlCommand cmd = new SqlCommand("usp_Producto_Eliminar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdProducto", p.IdProducto);
            try
            {
                cn.Open();
                bool iresult = cmd.ExecuteNonQuery() == 1 ? true : false;
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public Producto findForId(int id)
        {
            Producto pro = null;
            SqlConnection cn = AccesoDB.getConnection();
            SqlCommand cmd = new SqlCommand("usp_Producto_Datos", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdProducto", id);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    pro = new Producto()
                    {
                        IdProducto = Convert.ToInt32(dr[0]),
                        NombreProducto = dr[1].ToString(),
                        IdProveedor = Convert.ToInt32(dr[2]),
                        IdCategoria = Convert.ToInt32(dr[3]),
                        umedida = dr[4].ToString(),
                        Precio = Convert.ToDecimal(dr[5]),
                        Stock = Convert.ToInt32(dr[6]),
                    };
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            { throw ex; }
            return pro;
        }

        public List<Producto> productoNombre(string nom)
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection cn = AccesoDB.getConnection();
            SqlCommand cmd = new SqlCommand("usp_Producto_Nombre", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@prod", nom);
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Producto pro = new Producto()
                    {
                        IdProducto = Convert.ToInt32(dr[0]),
                        NombreProducto = dr[1].ToString(),
                        IdProveedor = Convert.ToInt32(dr[2]),
                        IdCategoria = Convert.ToInt32(dr[3]),
                        umedida = dr[4].ToString(),
                        Precio = Convert.ToDecimal(dr[5]),
                        Stock = Convert.ToInt32(dr[6]),
                    };
                    lista.Add(pro);
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            { throw ex; }
            return lista;
        }

        public List<Producto> readAll()
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection cn = AccesoDB.getConnection();
            SqlCommand cmd = new SqlCommand("usp_Producto_Listar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Producto pro = new Producto()
                    {
                        IdProducto = Convert.ToInt32(dr[0]),
                        NombreProducto = dr[1].ToString(),
                        IdProveedor = Convert.ToInt32(dr[2]),
                        IdCategoria = Convert.ToInt32(dr[3]),
                        umedida = dr[4].ToString(),
                        Precio = Convert.ToDecimal(dr[5]),
                        Stock = Convert.ToInt32(dr[6]),
                    };
                    lista.Add(pro);
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

        public void update(Producto p)
        {
            SqlConnection cn = AccesoDB.getConnection();
            SqlCommand cmd = new SqlCommand("usp_Producto_Actualizar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdProducto", p.IdProducto);
            cmd.Parameters.AddWithValue("@NombreProducto", p.NombreProducto);
            cmd.Parameters.AddWithValue("@IdProveedor", p.IdProveedor);
            cmd.Parameters.AddWithValue("@Idcategoria", p.IdCategoria);
            cmd.Parameters.AddWithValue("@umedida", p.umedida);
            cmd.Parameters.AddWithValue("@PrecioUnidad", p.Precio);
            cmd.Parameters.AddWithValue("@Stock", p.Stock);
            try
            {
                cn.Open();
                bool iresult = cmd.ExecuteNonQuery() == 1 ? true : false;
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


    }
}