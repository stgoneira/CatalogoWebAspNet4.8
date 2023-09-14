using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ProductoEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }

        public int CategoriaId {  get; set; } = 0;

    }
}
