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
    public partial class Clientes : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClienteNegocio cliNeg = new ClienteNegocio();
                Session.Add("listaClientes", cliNeg.listar());
                dgvClientes.DataSource = Session["listaClientes"];
                dgvClientes.DataBind();
            }
        }

        protected void dgvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var id = dgvClientes.SelectedDataKey.Value.ToString();
                Response.Redirect("FormularioCliente.aspx?id=" + id, false);
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

        protected void txtFiltroCliente_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Cliente> lista = (List<Cliente>)Session["listaClientes"];
                List<Cliente> listaFiltrada = lista.FindAll(k => k.Nombre.ToLower().Contains(txtFiltroCliente.Text.ToLower()) || k.Apellido.ToLower().Contains(txtFiltroCliente.Text.ToLower()) || k.Email.ToLower().Contains(txtFiltroCliente.Text.ToLower()) || k.Dni.ToLower().Contains(txtFiltroCliente.Text.ToLower()));
                dgvClientes.DataSource = listaFiltrada;
                dgvClientes.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void chkFiltroAvanzadoCliente_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                FiltroAvanzado = chkFiltroAvanzadoCliente.Checked;
                txtFiltroCliente.Enabled = !FiltroAvanzado;
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

                if (string.IsNullOrEmpty(txtFiltroAvanzadoCliente.Text))
                {
                    dgvClientes.DataSource = negocio.listar();
                }
                else
                {
                    dgvClientes.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString(), txtFiltroAvanzadoCliente.Text);
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
            Response.Redirect("FormularioCliente.aspx");
        }

        protected void dgvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "nuevoIncidente")
                {
                    int rowNum = int.Parse(e.CommandArgument.ToString());
                    var id = dgvClientes.DataKeys[rowNum].Value.ToString();
                    Response.Redirect("FormularioIncidente.aspx?id=" + id, false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}