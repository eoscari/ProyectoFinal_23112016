using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Movimientos : System.Web.UI.Page
{
    ListaDeMovimiento move;
    bool recurrente;
    byte FrecFacturacion, Plazo;

    protected void Page_Load(object sender, EventArgs e)
    {
        move = new ListaDeMovimiento(Server.MapPath(@"~/Archivos/Movimientos.bin"));
        move.CerrarFichero();
    }

    protected void AltaMovimiento(object sender, EventArgs e)
    {
        try
        {
            move.AbrirFichero(Server.MapPath(@"~/Archivos/Movimientos.bin"));
            DateTime fecha = DateTime.Parse(idfecha.Text);
            string tipo = ComboTipo.Text;
            string modo = ComboPago.Text;
            string moneda = ComboMoneda.Text;
            double monto =double.Parse(Monto.Text);
            int idfac = int.Parse(Idfactura.Text);
           
            int combo = ComboMovimiento.Items.IndexOf(ComboMovimiento.Items.FindByValue(ComboMovimiento.Text));
            if (combo == 0) { recurrente = true;
                FrecFacturacion = byte.Parse(frecfac.Text);
                Plazo = byte.Parse(plaEje.Text);
            } else { recurrente = false;
                FrecFacturacion = 0;
                Plazo = 0;
            }
            DateTime fecha1 = DateTime.Parse(FechaCobro.Text);
            ClsMovimiento obj = new ClsMovimiento(fecha,tipo,modo,moneda,monto,idfac,recurrente,FrecFacturacion,Plazo,fecha1);
            move.AgregarRegistro(obj);
            //numeroReg = lista.NumReg();
            move.CerrarFichero();
        }
        catch (IOException er) { move.CerrarFichero(); }
    }

    protected void ComboMovimiento_SelectedIndexChanged(object sender, EventArgs e)
    {
        int combo = ComboMovimiento.Items.IndexOf(ComboMovimiento.Items.FindByValue(ComboMovimiento.Text));
        if (combo == 0)
        {
            recurrente = true;
            frecfac.Enabled = true;
            frecfac.Visible = true;
            frecuencia.Visible = true;
            plazo.Visible = true;
            plaEje.Enabled = true;
            plaEje.Visible = true;
        }
        else
        {
            recurrente = false;
            frecfac.Enabled = false;
            frecfac.Visible = false;
            frecuencia.Visible = false;
            plazo.Visible = false;
            plaEje.Enabled = false;
            plaEje.Visible = false;
            
        }
    }
}