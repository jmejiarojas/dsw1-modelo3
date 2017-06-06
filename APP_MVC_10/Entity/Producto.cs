using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP_MVC_10.Entity
{
    public class Producto
    {
        // propiedades
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int IdProveedor { get; set; }
        public int IdCategoria { get; set; }
        public string umedida { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}