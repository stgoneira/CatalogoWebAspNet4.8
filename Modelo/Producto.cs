using System;

namespace Modelo
{
    public class Producto
    {
        public Producto() { } 
        public Producto(int id, string nombre, int precio) {
            Id = id;
            Nombre = nombre;
            Precio = precio;
        } 

        public int Id { get; set; }
        public String Nombre { get; set; }
        public int Precio { get; set; }

        public Categoria Categoria { get; set; } = null;
    }
}
