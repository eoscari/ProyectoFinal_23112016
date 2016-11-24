using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoFinal;

public partial class Facturas : System.Web.UI.Page
{
    private ListaFactura lista;
    private ListaClientes listaClientes;
    string combonombre = "";
    int buscapos;
    int idcli;
    clsCliente cli;

    protected void Page_Load(object sender, EventArgs e)
    {
        lista = new ListaFactura(Server.MapPath(@"~/Archivos/Facturas.bin"));
        listaClientes = new ListaClientes(Server.MapPath(@"~/Archivos/Clientes.bin"));
        if (!(IsPostBack))
        {
            for (int j = 0; j < listaClientes.NumReg(); j++)
            {
                cli = listaClientes.LeerRegistro(j);
                combonombre = cli.Dni + " - " + cli.Apellido + " " + cli.Nombre;
                ComboCliente.Items.Add(combonombre);
            }
        }
        lista.CerrarFichero();
        listaClientes.CerrarFichero();
    }

    protected void ComboCliente_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ComboFactura_SelectedIndexChanged(object sender, EventArgs e)
    {
        int combo = ComboFactura.Items.IndexOf(ComboFactura.Items.FindByValue(ComboFactura.Text));
        if (combo == 0)
        {
            ErrorMessage.Text = "Ingrese un tipo de factura correcto...";
        }
        else
        if (combo == 1)
        {
            ErrorMessage.Text = "";
            Numero.Enabled = false;
        }
        else
        {
            ErrorMessage.Text = "";
            Numero.Enabled = true;
        }
    }

    protected void Unnamed14_Click(object sender, EventArgs e)
    {
        ErrorMessage.Text = "";
        lista.abrirFichero(Server.MapPath(@"~/Archivos/facturas.bin"));
        if (ComboFactura.Items.IndexOf(ComboFactura.Items.FindByValue(ComboFactura.Text)).Equals(0))
        {
            ErrorMessage.Text = "Ingrese un tipo de factura correcto...";
        }
        else
            if (FechaEmi.Text != "" && FechaCobro.Text != "")
        {
            clsFactura obj = new clsFactura(1, Convert.ToDateTime(FechaEmi.Text), Convert.ToDateTime(FechaCobro.Text), "Propia", "Hola", 1, 1, 1);
            lista.agregarRegistro(obj);
            Notas.Text = Convert.ToString(lista.Registro);
            lista.CerrarFichero();
            SuccessMessage.Text = "Guardado con éxito...";
            ErrorMessage.Text = "";
        }
        else
        {
            //ErrorMessage.Text = "Ingrese una Fecha de Emisión o Fecha de cobro válida...";
        }
        //}
    }
}