/*
 * Created by SharpDevelop.

 * Date: 9/11/2016
 * Time: 1:35 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ProyectoFinal
{
	public class clsFactura
	{
		
		private int idFactura;
		private DateTime fechaEmision;
    	private DateTime fechaCobro;
		private string tipo;
		private string modo;
        private int DniCliente;//es el dni del cliente
        private int IdNota;
        private int IdCheque;
		
		//CONSTRUCTOR
		
		
		
		public clsFactura(int idFact, DateTime fEmision, DateTime fCobro , string tip, string mod ,int cli , int not , int cheq)
		{
			this.IdFactura = idFact;
			this.FechaEmision = fEmision;
			this.FechaCobro = fCobro;
			this.Tipo = tip;
			this.Modo = mod;
			this.DniCliente= cli;
			this.IdNota = not ;
			this.IdCheque = cheq;
			
		}
		
		//PROPERTIES
		
		public int IdFactura{
			get{return idFactura;}
			set{idFactura=value;}
		}
		
		public DateTime FechaEmision{
			get{return fechaEmision;}
			set{fechaEmision=value;}
		}
		
		public DateTime FechaCobro{
			get{return fechaCobro;}
			set{fechaCobro=value;}
		}
		
		public string Tipo{
			get{return tipo;}
			set{tipo=value;}
		}
		
		public string Modo{
			get{return modo;}
			set{modo=value;}
		}
		
		public int Cliente{
        	get{return DniCliente;}
        	set{DniCliente=value;}
        }
		
		public int Nota{
        	get{return IdNota;}
        	set{IdNota=value;}
        }
		
		public int Cheque{
        	get{return IdCheque;}
        	set{IdCheque=value;}
        }
        public string FormatoFecha(DateTime fe)
        {
            return fe.ToString("dd/MM/yyyy");
        }
		
		public int Tamaño //tamaño del registro Persona
  		{
    		// Longitud en bytes de los atributos (un long = 8 bytes)
    		get { return (4 +FormatoFecha(FechaEmision).Length*2+FormatoFecha(fechaCobro).Length*2 + Tipo.Length*2 + Modo.Length*2 + 8 +8) ; }
  		}
		
	}
}
