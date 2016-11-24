using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class ClsCuenta
{
    private double FondoDolares;
    private double FondoPesos;
    private double DepBancario;//cantidad de dinero en la cuenta bancaria
    private string CuentaBancaria;
    private double ChequesCobrados;

   // private DateTime Fecha;


    public ClsCuenta() { }

    public ClsCuenta(double FD,double FP, double DB,string CB, double CC)
    {
        this.FondoDolares = FD;
        this.FondoPesos = FP;
        this.DepBancario = DB;
        this.CuentaBancaria = CB;
        this.ChequesCobrados = CC;

        //this.Fecha = fe;
    }
  
        
    public double SGFondosDolares
    {
        get { return FondoDolares; }
        set { FondoDolares = value; }
    }

    public string SGCuentaBanc {
    set { this.CuentaBancaria = value; }
    get { return CuentaBancaria; } }

    public double SGFondoPesos
    {
        get { return FondoPesos; }
        set { FondoPesos = value; }
    }
    public double SGDepBanc
    {
        get { return DepBancario; }
        set { DepBancario = value; }
    }
    public double SGCheqCobrados
    {
        get { return ChequesCobrados; }
        set { ChequesCobrados = value; }
    }

    public int TamCuenta {
    get { return  ((5 * 16)+16+SGCuentaBanc.Length*2); } }
}