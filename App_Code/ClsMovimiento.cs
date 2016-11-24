using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoFinal;

public class ClsMovimiento
{
    private DateTime Fecha;
    private string Tipo;// si es pago o cobro
    private string ModoDePago;//Efectivo, tRansferencia Bancaria o cheque
    private string Moneda;//si es moneda extranjera o peso argentino
    private double Monto;
    private int idFactura;
    private bool recurrente;//me indica si es un movimiento recurrente o no
    private byte FrecFac;//frecuencia de facturacion 
    private byte PlazoEjec; //cant de dias que seva a realizar el cobro o pago
    private DateTime FechaCoP;//es fecha de cobro o de pago
    //en consecuencia de un movimiento recurrente se genera una factura eventual correspondiente

    public ClsMovimiento(){}

    public ClsMovimiento(DateTime dia, string type, string mp, string mon, double monto, int IF,bool recu,byte ff,byte pe,DateTime FechaC)
    {
        this.Fecha = dia;
        this.Tipo = type;
        this.ModoDePago = mp;
        this.Moneda = mon;
        this.Monto = monto;
        this.idFactura = IF;
        this.recurrente = recu;
        this.FrecFac = ff;
        this.PlazoEjec = pe;
        this.FechaCoP = FechaC;
    }

    public DateTime SGFechaCobro {
    set { this.FechaCoP = value; }
    get { return FechaCoP; } }

    public DateTime SGFecha
    {
        set { this.Fecha = value; }
        get { return Fecha; }
    }
    public string SGTipo
    {
        set { this.Tipo = value;}
        get { return this.Tipo; }
    }
    public string SGModoPago
    {
        set { this.ModoDePago = value; }
        get { return ModoDePago; }
    }
    public string SGMoneda
    {
        set { this.Moneda = value; }
        get { return this.Moneda; }
    }
    public double SGMonto
    {
        set { this.Monto = value; }
        get { return Monto; }
    }
    public int SGIdFac
    {
        set { this.idFactura = value; }
        get { return idFactura; }
    }

    public string FormatoFecha(DateTime dia) {
        return dia.ToString("dd/MM/yyyy");
    }

    public byte SGFrecuenciaFac
    {
        set { this.FrecFac = value; }
        get { return FrecFac; }
    }

    public byte SGPlazoEjec
    {
        set { this.PlazoEjec = value; }
        get { return PlazoEjec; }
    }
    public bool SGRecurrente {
    set { this.recurrente = value; }
    get { return recurrente; } }

    public int TamMovimiento
    { 
        get { return (FormatoFecha(this.Fecha).Length*2+FormatoFecha(this.FechaCoP).Length*2+Tipo.Length*2+ModoDePago.Length*2+Moneda.Length*2+16+4+1+2); }
    }
}