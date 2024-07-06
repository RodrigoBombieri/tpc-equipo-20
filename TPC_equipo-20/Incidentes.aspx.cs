using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using System.Runtime.InteropServices.ComTypes;
namespace TPC_equipo_20
{
    public partial class Incidentes : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IncidenteNegocio negocio = new IncidenteNegocio();
                if (Seguridad.EsTelefonista(Session["usuario"]))
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    Session.Add("listadoIncidentes", negocio.listar(true, usuario.Id.ToString()));
                    dgvIncidentes.Columns.Add(new CommandField { ShowSelectButton = true, ControlStyle = { CssClass = "btn btn-info" }, SelectText = "Ver", HeaderText = "Ver" });
                }
                else
                {
                    Session.Add("listadoIncidentes", negocio.listar(true));
                    BoundField usuarioAsignadoField = new BoundField();
                    usuarioAsignadoField.DataField = "UsuarioAsignado.Nombre";
                    usuarioAsignadoField.HeaderText = "Usuario asignado";
                    dgvIncidentes.Columns.Add(usuarioAsignadoField);
                    dgvIncidentes.Columns.Add(new CommandField { ShowSelectButton = true, ControlStyle = { CssClass = "btn btn-info" }, SelectText = "Ver", HeaderText = "Ver" });

                }
                dgvIncidentes.DataSource = Session["listadoIncidentes"];
                dgvIncidentes.DataBind();
            }
        }

        protected void dgvIncidentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var id = dgvIncidentes.SelectedDataKey.Value.ToString();
                Response.Redirect("GestionIncidente.aspx?id=" + id, false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void dgvIncidentes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dgvIncidentes.DataSource = Session["listadoIncidentes"];
                dgvIncidentes.PageIndex = e.NewPageIndex;
                dgvIncidentes.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioIncidente.aspx");
        }
        protected void chkFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtFiltro.Enabled = !chkFiltroAvanzado.Checked;
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
                List<Incidente> lista = (List<Incidente>)Session["listadoIncidentes"];
                List<Incidente> listaFiltrada = lista.FindAll(k => k.Tipo.Nombre.ToLower().Contains(txtFiltro.Text.ToLower()) || k.Prioridad.Nombre.ToLower().Contains(txtFiltro.Text.ToLower()) || k.Estado.Nombre.ToLower().Contains(txtFiltro.Text.ToLower()));
                dgvIncidentes.DataSource = listaFiltrada;
                dgvIncidentes.DataBind();
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
                if (ddlCampo.SelectedItem.ToString() == "Precio")
                {
                    ddlCriterio.Items.Add("Mayor a");
                    ddlCriterio.Items.Add("Menor a");
                    ddlCriterio.Items.Add("Igual a");
                }
                else
                {
                    ddlCriterio.Items.Add("Contiene");
                    ddlCriterio.Items.Add("Empieza con");
                    ddlCriterio.Items.Add("Termina con");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        private bool validarFiltro()
        {
            return false;
        }
        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                txtFiltro.Text = "";
                txtFiltroAvanzado.Text = "";
                dgvIncidentes.DataSource = Session["listadoIncidentes"];
                dgvIncidentes.DataBind();
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
                IncidenteNegocio negocio = new IncidenteNegocio();

                if (chkFiltroAvanzado.Checked)
                {
                    if (string.IsNullOrEmpty(txtFiltroAvanzado.Text))
                    {
                        dgvIncidentes.DataSource = negocio.listar(true);
                    }
                    else
                    {
                        dgvIncidentes.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(),
                        ddlCriterio.SelectedItem.ToString(), txtFiltroAvanzado.Text);
                    }
                }
                else
                {
                    List<Incidente> lista = (List<Incidente>)Session["listadoIncidentes"];
                    List<Incidente> listaFiltrada = lista.FindAll(k => k.Tipo.Nombre.ToLower().Contains(txtFiltro.Text.ToLower()) || k.Prioridad.Nombre.ToLower().Contains(txtFiltro.Text.ToLower()) || k.Estado.Nombre.ToLower().Contains(txtFiltro.Text.ToLower()));
                    dgvIncidentes.DataSource = listaFiltrada;
                }
                dgvIncidentes.DataBind();
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
                /* IncidenteNegocio negocio = new IncidenteNegocio();
                 if (string.IsNullOrEmpty(txtFiltroAvanzado.Text))
                 {
                     dgvIncidentes.DataSource = negocio.listar(true);
                 }
                 else
                 {
                     dgvIncidentes.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(),
                     ddlCriterio.SelectedItem.ToString(), txtFiltroAvanzado.Text);
                 }
                 dgvIncidentes.DataBind();*/
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void dgvIncidentes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Obtener el objeto asociado a la fila actual
                Incidente aux = (Incidente)e.Row.DataItem;
                DateTime ahora = DateTime.Now;
                TimeSpan dateDifference = aux.FechaVencimiento - ahora;
                Label lblVencimiento = (Label)e.Row.FindControl("lblVencimiento");
                lblVencimiento.Text = string.Format("{0:dd-MM-yyyy HH:mm}", aux.FechaVencimiento);
                string nombreEstado = HttpUtility.HtmlDecode(e.Row.Cells[4].Text);
                aux.Estado.Nombre = nombreEstado;
                // Obtener la diferencia en días
                int differenceInDays = dateDifference.Days;
                if (differenceInDays <= 2 && differenceInDays >= 0 && aux.Estado.Nombre != "Cerrado")
                {
                    lblVencimiento.Text += " <i class='fa fa-exclamation-circle icon-danger'></i>";
                }
                else if (differenceInDays >= 3 && differenceInDays <=5 && aux.Estado.Nombre != "Cerrado")
                {
                    lblVencimiento.Text += " <i class='fa fa-exclamation-triangle icon-warning'></i>";
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Obtener el objeto asociado a la fila actual
                Incidente aux = (Incidente)e.Row.DataItem;
                if (aux.Prioridad.Nombre == "Alta")
                    e.Row.Cells[1].BackColor = System.Drawing.Color.Red;
                else if (aux.Prioridad.Nombre == "Media")
                    e.Row.Cells[1].BackColor = System.Drawing.Color.Yellow;
                else if (aux.Prioridad.Nombre == "Baja")
                    e.Row.Cells[1].BackColor = System.Drawing.Color.LightGreen;
                else
                    e.Row.Cells[1].BackColor = System.Drawing.Color.Magenta;
            }
        }
    }
}