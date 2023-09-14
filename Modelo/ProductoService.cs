using Datos;
using System.Collections.Generic;
using System.Linq;

namespace Modelo
{
    public class ProductoService
    {
        public static void Crear(Producto producto)
        {
            var productoEntity = new ProductoEntity()
            {
                Id          = producto.Id,
                Nombre      = producto.Nombre,
                Precio      = producto.Precio,
                CategoriaId = producto?.Categoria?.Id ?? 0
            };            
            Repositorio.Productos.Add(productoEntity);
        }

        public static void Actualizar(Producto producto)
        {
            var productoEntity = Repositorio.Productos.Find(p =>  p.Id == producto.Id);
            productoEntity.CategoriaId = producto?.Categoria.Id ?? 0;
            productoEntity.Nombre = producto.Nombre;
            productoEntity.Precio = producto.Precio;            
        }

        public static List<Producto> TraerTodos()
        {
            return Repositorio.Productos.Select(p => Convertir(p)).ToList();
        }

        private static Producto Convertir(ProductoEntity entity)
        {
            var producto = new Producto(entity.Id, entity.Nombre, entity.Precio);
            producto.Categoria = CategoriaService.BuscarPorId(entity.CategoriaId);
            return producto;
        }

        public static List<Producto> Buscar(string termino)
        {
            if(!string.IsNullOrWhiteSpace(termino))
            {
                return Repositorio.Productos.FindAll(p => p.Nombre.Contains(termino)).Select(p => Convertir(p)).ToList();
            } else
            {
                return TraerTodos();
            }
            
        }

        public static Producto BuscarPorId(int id)
        {
            var productoEntity = Repositorio.Productos.Find(p => p.Id == id);
            return Convertir(productoEntity);
        }
    }
}
