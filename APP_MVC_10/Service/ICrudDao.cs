using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_MVC_10.Service
{
    public interface ICrudDao<T>
    {
        void create(T p);
        void update(T p);
        void delete(T p);
        List<T> readAll();
        T findForId(int id);

        List<T> productoNombre(string nom);
    }
}
