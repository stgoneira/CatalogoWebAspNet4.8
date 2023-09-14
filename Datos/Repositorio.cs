using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Repositorio
    {
        private static List<CategoriaEntity> s_categorias = new List<CategoriaEntity>();
        public static List<CategoriaEntity> Categorias { get { return s_categorias; } }


        private static List<ProductoEntity> s_productos= new List<ProductoEntity>();
        public static List<ProductoEntity> Productos { get { return s_productos; } }

    }
}
