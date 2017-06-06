using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_MVC_10.Service
{
    public interface ICrudCategoria<T>
    {
        List<T> readCatAll();
    }
}
