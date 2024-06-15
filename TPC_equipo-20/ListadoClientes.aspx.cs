using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace TPC_equipo_20
{
    public partial class ListadoClientes : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["listaClientes"] != null)
            {
            dgvClientes.DataSource = Session["listaClientes"];
            dgvClientes.DataBind();
            }
        }
        
        protected void dgvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var id = dgvClientes.SelectedDataKey.Value.ToString();
                Response.Redirect("DetalleCliente.aspx?id=" + id);
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void dgvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dgvClientes.DataSource = Session["listaClientes"];
                dgvClientes.PageIndex = e.NewPageIndex;
                dgvClientes.DataBind();
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
                List<Cliente> lista = (List<Cliente>)Session["listaClientes"];
                List<Cliente> listaFiltrada = lista.FindAll(k => k.Nombre.ToLower().Contains(txtFiltro.Text.ToLower()) || k.Apellido.ToLower().Contains(txtFiltro.Text.ToLower()) || k.Email.ToLower().Contains(txtFiltro.Text.ToLower()) || k.Dni.ToLower().Contains(txtFiltro.Text.ToLower()));
                dgvClientes.DataSource = listaFiltrada;
                dgvClientes.DataBind();
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
                ClienteNegocio negocio = new ClienteNegocio();

                if (string.IsNullOrEmpty(txtFiltroAvanzado.Text))
                {
                    dgvClientes.DataSource = negocio.listar();
                }
                else
                {
                    dgvClientes.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString(), txtFiltroAvanzado.Text);
                }

                dgvClientes.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect("DetalleCliente.aspx");
        }
    }
}