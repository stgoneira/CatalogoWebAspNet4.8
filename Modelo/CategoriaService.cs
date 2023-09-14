using Datos;
using System.Collections.Generic;
using System.Linq;

namespace Modelo
{
    public class CategoriaService
    {
        public static void Crear(Categoria categoria)
        {
            var categoriaEntity = new CategoriaEntity()
            {
                Id      = categoria.Id,
                Nombre  = categoria.Nombre,                
            };
            Repositorio.Categorias.Add(categoriaEntity);
        }

        public static void Actualizar(Categoria categoria)
        {
            var categoriaEntity = Repositorio.Categorias.Find(c => c.Id == categoria.Id);
            categoriaEntity.Nombre = categoria.Nombre;            
        }

        public static List<Categoria> TraerTodas()
        {
            return Repositorio.Categorias.Select(c => Convertir(c)).ToList();
        }

        private static Categoria Convertir(CategoriaEntity entity)
        {
            return new Categoria(entity.Id, entity.Nombre);
        }

        public static List<Categoria> Buscar(string termino)
        {
            if( string.IsNullOrWhiteSpace(termino) )
            {
                return TraerTodas();
            }
            return Repositorio.Categorias.FindAll(c => c.Nombre.Contains(termino)).Select(c => Convertir(c)).ToList();
        }

        public static Categoria BuscarPorId(int id)
        {
            return Convertir( Repositorio.Categorias.Find(c => c.Id == id) );
        }
    }
}
