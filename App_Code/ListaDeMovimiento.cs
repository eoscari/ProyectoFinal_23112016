using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using ProyectoFinal;
using iTextSharp.text;
using iTextSharp.text.pdf;

public class ListaDeMovimiento
{
    private FileStream fs, fst;
    private BinaryWriter bw, bwt;
    private BinaryReader br, brt;
    private int nregs;
    private int tamañoReg = 200;

    private String balancefinal = "BALANCE FINAL \n";
    private String repfacturaspropias = "REPORTES FACTURAS PROPIAS: \n";
    private String repfacturasrovp = " REPORTES FACTURAS PROPIAS: \n";
    private String intervalocobros = "PROMEDIO PARA DIAS DE COBRO : ";
    private String intervalopago = "PROMEDIO PARA DIAS DE PAGO : ";

    public ListaDeMovimiento(string fichero)
    {
        AbrirFichero(fichero);
    }
    public void AbrirFichero(string fi)
    {
        if (Directory.Exists(fi))
            throw new IOException(Path.GetFileName(fi) + " no es un fichero.");
        this.fs = new FileStream(fi, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        this.bw = new BinaryWriter(fs);
        this.br = new BinaryReader(fs);
        this.nregs = (int)Math.Ceiling((double)fs.Length / (double)this.tamañoReg);
    }
    public void CerrarFichero() { fs.Close(); bw.Close(); br.Close(); }


    public string FormatoFecha(DateTime dia)
    {
        return dia.ToString("dd/MM/yyyy");
    }

    public bool EscribirRegistro(int i, ClsMovimiento obj)
    {
        try
        {
            if (i >= 0 && i <= nregs)
            {
                if (obj.TamMovimiento + 4 > tamañoReg)
                {
                    Console.WriteLine("Tamaño de registro excedido.");
                    return false;
                }
                else
                {
                    bw.BaseStream.Seek(i * this.tamañoReg, SeekOrigin.Begin);
                    bw.Write(FormatoFecha(obj.SGFecha)); //campo que me guarda esta en formato dd/mm/aaaa y es un string 
                    bw.Write(obj.SGTipo);
                    bw.Write(obj.SGModoPago);
                    bw.Write(obj.SGMoneda);
                    bw.Write(obj.SGMonto);
                    bw.Write(obj.SGIdFac);
                    bw.Write(obj.SGRecurrente);
                    bw.Write(obj.SGFrecuenciaFac);
                    bw.Write(obj.SGPlazoEjec);
                    bw.Write(FormatoFecha(obj.SGFechaCobro));//guarda la fecha de cobro o de pago del movimiento
                    return true;
                }
            }
            else { return false; }
        }
        catch (IOException e) { CerrarFichero(); Console.WriteLine(e.Message); return false; }
    }

    public void AgregarRegistro(ClsMovimiento movimiento)
    {
        if (EscribirRegistro(this.nregs, movimiento))
            this.nregs++;
    }

    public int NumReg()
    {
        return this.nregs;
    }

    public ClsMovimiento LeerRegistro(int i)//lee registro mandandole la posicion en el fichero
    {
        try
        {
            if (i >= 0 && i <= NumReg())
            {
                br.BaseStream.Seek(i * this.tamañoReg, SeekOrigin.Begin);
                DateTime fecha = Convert.ToDateTime(br.ReadString());
                string tipo = br.ReadString();
                string ModoPago = br.ReadString();
                string mone = br.ReadString();
                double monto = br.ReadDouble();
                int idfactura = br.ReadInt32();
                bool recurren = br.ReadBoolean();
                byte frecuencia = br.ReadByte();
                byte plazo = br.ReadByte();
                DateTime FechaCoP = Convert.ToDateTime(br.ReadString());
                return (new ClsMovimiento(fecha,tipo,ModoPago,mone,monto,idfactura,recurren,frecuencia,plazo,FechaCoP));
            }
            else { return null; }
        }
        catch (IOException e) { CerrarFichero(); return null; }
    }


    //busca registro por el id de la factura devuelve la posicion en el fichero
    public int BuscarReg(int IDFac)
    {
        ClsMovimiento obj;
        int ide;
        int reg_i = 0;
        bool encontrado = false;
        try
        {
            if (IDFac < 0) { return -1; }
            else
            {
                while ((reg_i < nregs) && (!encontrado))
                {
                    obj = LeerRegistro(reg_i);
                    ide = obj.SGIdFac;
                    if (ide == IDFac)
                    {
                        encontrado = true;
                    }
                    else { reg_i++; }
                }

                if (encontrado)
                {
                    return reg_i;
                }
                else
                {
                    return -1;
                }
            }
        }
        catch (IOException e) { CerrarFichero(); Console.WriteLine("error:" + e.Message); return -1; }
    }

    public void RepFacturasPropiasP(DateTime ini, DateTime fin)
    //Reporte de facturas propias pendientes implica tambien el reporte de cobros adeudados
    {
        ClsMovimiento aux; int i, comp1, comp2;
        for (i = 0; i < nregs; i++)
        {
            aux = LeerRegistro(i); //en aux guarde mi objeto movimiento
            comp1 = DateTime.Compare(ini, aux.SGFecha);
            comp2 = DateTime.Compare(aux.SGFechaCobro, fin);
            if ((aux.SGTipo.Equals("Cobro")) && (comp1 < 0) && (comp2 < 0))
            {
                //La factura es propia, pendiente y entre las fechas dadas. mostrar.
                repfacturaspropias = "Id : " + aux.SGIdFac + "  Fecha Emision : " + aux.SGFecha + "    Fecha Cobro : " + aux.SGFechaCobro + "    Monto : " + aux.SGMonto + "    Moneda : " + aux.SGMoneda + "\n";

            }
        }
    }

    public void RepFacturasPropiasP()
    //Reporte de facturas propias pendientes implica tambien el reporte de cobros adeudados
    {
        ClsMovimiento aux;
        for (int i = 0; i < nregs; i++)
        {
            aux = LeerRegistro(i); //en aux guarde mi objeto movimiento
            if ((aux.SGTipo.Equals("Cobro")))
            {
                //La factura es propia, pendiente y entre las fechas dadas. mostrar.
                repfacturaspropias = "Id : " + aux.SGIdFac + "  Fecha Emision : " + aux.SGFecha + "    Fecha Cobro : " + aux.SGFechaCobro + "    Monto : " + aux.SGMonto + "    Moneda : " + aux.SGMoneda + "\n";

            }
        }
    }

    public void repFacturasProvP(DateTime ini, DateTime fin)
    //reporte de facturas de terceros pendientes implica tambien reportar pagos adeudados
    {
        ClsMovimiento aux; int i, comp1, comp2;
        for (i = 0; i < nregs; i++)
        {
            aux = LeerRegistro(i);
            comp1 = DateTime.Compare(ini, aux.SGFecha);
            comp2 = DateTime.Compare(aux.SGFechaCobro, fin);
            if ((aux.SGTipo.Equals("Pago")) && (comp1 < 0) && (comp2 < 0))
            {
                //La factura es propia, pendiente y entre las fechas dadas. mostrar.
                repfacturasrovp = "Id : " + aux.SGIdFac + "  Fecha Emision : " + aux.SGFecha + "    Fecha Cobro : " + aux.SGFechaCobro + "    Monto : " + aux.SGMonto + "    Moneda : " + aux.SGMoneda + "\n";

            }
        }
    }

    public void repFacturasProvP()
    //reporte de facturas de terceros pendientes implica tambien reportar pagos adeudados
    {
        ClsMovimiento aux;
        for (int i = 0; i < nregs; i++)
        {
            aux = LeerRegistro(i);
            if ((aux.SGTipo.Equals("Pago")))
            {
                //La factura es propia, pendiente y entre las fechas dadas. mostrar.
                repfacturasrovp = "Id : " + aux.SGIdFac + "  Fecha Emision : " + aux.SGFecha + "    Fecha Cobro : " + aux.SGFechaCobro + "    Monto : " + aux.SGMonto + "    Moneda : " + aux.SGMoneda + "\n";

            }
        }
    }

    public int intervaloCobros()
    {
        ClsMovimiento aux; int i, dias = 0, cant = 0;
        for (i = 0; i < nregs; i++)
        {
            aux = LeerRegistro(i);
            if (aux.SGTipo.Equals("Cobro"))
            {
                dias = dias + DateTime.Compare(aux.SGFechaCobro, aux.SGFecha); //el rdo es la cantidad de dias desde la emision al cobro
                cant++;
            }
        }
        if (cant != 0)
            return dias / cant;
        else //salida por defecto, no hay cargadas facturas propias
            return 0;
    }

    public int intervaloPagos()
    {
        ClsMovimiento aux; int i, dias = 0, cant = 0;
        for (i = 0; i < nregs; i++)
        {
            aux = LeerRegistro(i);
            if (aux.SGTipo.Equals("Pago"))
            {
                dias = dias + DateTime.Compare(aux.SGFechaCobro, aux.SGFecha); //el rdo es la cantidad de dias desde la emision al cobro
                cant++;
            }
        }
        if (cant != 0)
            return dias / cant;
        else //salida por defecto, no hay cargadas facturas a proveedores
            return 0;
    }

    public String REPORTE()
    {
        RepFacturasPropiasP();
        repFacturasProvP();

        return balancefinal + "" + intervalocobros + intervaloCobros() + intervalopago + intervaloPagos() + repfacturaspropias + repfacturasrovp;
    }

    public String REPORTE(DateTime ini, DateTime fin)
    {
        RepFacturasPropiasP(ini, fin);
        repFacturasProvP(ini, fin);

        return balancefinal + "" + intervalocobros + intervaloCobros() + intervalopago + intervaloPagos() + repfacturaspropias + repfacturasrovp;
    }

    public void crearPDF()
    {
        Document document = new Document();
        PdfWriter.GetInstance(document, new FileStream("devjoker.pdf", FileMode.OpenOrCreate));
        document.Open();

        String reporte = this.REPORTE();
        document.Add(new Paragraph(reporte));

        document.Close();
    }


}

