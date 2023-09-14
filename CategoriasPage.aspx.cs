using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogoWeb
{
    public partial class CategoriasPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosDePrueba();
            }
        }

        private void CargarDatosDePrueba()
        {
            CategoriaService.Crear(new Categoria(0, "Sin Categoría"));
            CategoriaService.Crear(new Categoria(1, "Oficina"));
            CategoriaService.Crear(new Categoria(2, "Deportes"));
            CategoriaService.Crear(new Categoria(3, "Regalos"));
        }

        public List<Categoria> GetCategorias()
        {
            string busqueda = TextBoxBusqueda?.Text ?? "";
            return CategoriaService.Buscar(busqueda);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var indice  = GridView1.SelectedIndex;
            var idStr   = GridView1.Rows[indice].Cells[0].Text;
            var id      = Convert.ToInt32(idStr);
            var categoria = CategoriaService.BuscarPorId(id);

            ValoresFormulario(categoria);

            ButtonGuardar.Text = "Editar";
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            GridView1.DataSourceID = null;
            GridView1.DataSource = GetCategorias();
            GridView1.DataBind();
        }

        private void ValoresFormulario(Categoria categoria = null)
        {
            TextBoxId.Text = categoria?.Id.ToString() ?? "";
            TextBoxNombre.Text = categoria?.Nombre ?? "";            
        }

        private Categoria CrearCategoriaDesdeFormulario()
        {
            var id = Convert.ToInt32(TextBoxId.Text);
            var nombre = TextBoxNombre.Text;            
            return new Categoria(id, nombre);
        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            var categoria = CrearCategoriaDesdeFormulario();

            if (ButtonGuardar.Text == "Editar")
            {
                // editar 
                CategoriaService.Actualizar(categoria);
            }
            else
            {
                // crear 
                CategoriaService.Crear(categoria);
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