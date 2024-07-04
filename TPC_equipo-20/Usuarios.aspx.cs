using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_equipo_20
{
    public partial class Usuarios : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                Session.Add("listaUsuarios", negocio.listar(true));
                dgvUsuarios.DataSource = Session["listaUsuarios"];
                dgvUsuarios.DataBind();
            }
        }

        protected void dgvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var id = dgvUsuarios.SelectedDataKey.Value.ToString();
                Response.Redirect("FormularioUsuario.aspx?id=" + id, false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void dgvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dgvUsuarios.DataSource = Session["listaUsuarios"];
                dgvUsuarios.PageIndex = e.NewPageIndex;
                dgvUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Usuario> lista = (List<Usuario>)Session["listaUsuarios"];
                List<Usuario> listaFiltrada = lista.FindAll(k => k.Nombre.ToLower().Contains(txtFiltro.Text.ToLower()) || k.Apellido.ToLower().Contains(txtFiltro.Text.ToLower()) || k.Nick.ToLower().Contains(txtFiltro.Text.ToLower()) || k.Dni.ToLower().Contains(txtFiltro.Text.ToLower()) || k.Telefono.ToLower().Contains(txtFiltro.Text.ToLower()) || k.Email.ToLower().Contains(txtFiltro.Text.ToLower()));
                dgvUsuarios.DataSource = listaFiltrada;
                dgvUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void chkFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                FiltroAvanzado = chkFiltroAvanzado.Checked;
                txtFiltro.Enabled = !FiltroAvanzado;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlCriterio.Items.Clear();
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Empieza con");
                ddlCriterio.Items.Add("Termina con");

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();

                if (chkFiltroAvanzado.Checked)
                {
                    if (string.IsNullOrEmpty(txtFiltroAvanzado.Text))
                {
                    dgvUsuarios.DataSource = negocio.listar(true);
                }
                else
                {
                    dgvUsuarios.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString(), txtFiltroAvanzado.Text);
                }
                }
                else
                {
                        List<Usuario> lista = (List<Usuario>)Session["listaUsuarios"];
                        List<Usuario> listaFiltrada = lista.FindAll(k => k.Nombre.ToLower().Contains(txtFiltro.Text.ToLower()) || k.Apellido.ToLower().Contains(txtFiltro.Text.ToLower()) || k.Nick.ToLower().Contains(txtFiltro.Text.ToLower()) || k.Dni.ToLower().Contains(txtFiltro.Text.ToLower()) || k.Telefono.ToLower().Contains(txtFiltro.Text.ToLower()) || k.Email.ToLower().Contains(txtFiltro.Text.ToLower()));
                        dgvUsuarios.DataSource = listaFiltrada;
                }
                dgvUsuarios.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void BtnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            try
            {
                txtFiltro.Text = "";
                txtFiltroAvanzado.Text = "";
                dgvUsuarios.DataSource = Session["listaUsuarios"];
                dgvUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtFiltroAvanzado_TextChanged(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                if (string.IsNullOrEmpty(txtFiltroAvanzado.Text))
                {
                    dgvUsuarios.DataSource = negocio.listar(true);
                }
                else
                {
                    dgvUsuarios.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString(), txtFiltroAvanzado.Text);
                }
                dgvUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}