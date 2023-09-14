using Modelo;
using System;
using System.Collections.Generic;

namespace CatalogoWeb
{
    public partial class ProductosPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if( !IsPostBack )
            {
                CargarDatosDePrueba();
            }
        }

        private void CargarDatosDePrueba()
        {
            ProductoService.Crear(new Producto(1, "Uno", 1000));
            ProductoService.Crear(new Producto(2, "Dos", 2000));
            ProductoService.Crear(new Producto(3, "Tres", 3000));
        }
        public List<Categoria> GetCategorias()
        {
            return CategoriaService.TraerTodas();
        }

        public List<Producto> GetProductos()
        {
            string busqueda = TextBoxBusqueda?.Text ?? "";
            return ProductoService.Buscar(busqueda);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var indice      = GridView1.SelectedIndex;
            var idStr       = GridView1.Rows[indice].Cells[0].Text;
            var id          = Convert.ToInt32(idStr);
            var producto    = ProductoService.BuscarPorId(id);

            ValoresFormulario(producto);

            ButtonGuardar.Text = "Editar";
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            GridView1.DataSourceID = null;
            GridView1.DataSource = GetProductos();
            GridView1.DataBind();
        }

        private void ValoresFormulario(Producto producto = null)
        {
            TextBoxId.Text      = producto?.Id.ToString() ?? "";
            TextBoxNombre.Text  = producto?.Nombre ?? "";
            TextBoxPrecio.Text  = producto?.Precio.ToString() ?? "";
            DropDownCategoria.SelectedValue = producto?.Categoria?.Id.ToString();
        }

        private Producto CrearProductoDesdeFormulario()
        {
            var id      = Convert.ToInt32( TextBoxId.Text );
            var nombre  = TextBoxNombre.Text;
            var precio  = Convert.ToInt32(TextBoxPrecio.Text);
            var categoriaId = Convert.ToInt32( DropDownCategoria.SelectedValue );
            var categoria = CategoriaService.BuscarPorId(categoriaId);
            var producto = new Producto(id, nombre, precio);
            producto.Categoria = categoria;
            return producto;
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            var producto = CrearProductoDesdeFormulario();

            if( ButtonGuardar.Text == "Editar" )
            {
                // editar 
                ProductoService.Actualizar(producto);
            } else
            {
                // crear 
                ProductoService.Crear(producto);
            }

            GridView1.DataBind();
        }

        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            ValoresFormulario(null);
            ButtonGuardar.Text = "Crear";
        }
    }
}