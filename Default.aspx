<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Cash Flow</h1>
        <p class="lead">En economía y finanzas es la denominación de flujo de caja o flujo de fondos o de efectivo; el cash flow implica los flujos de entradas y de salidas de caja o efectivo, 
            en un determinado período y por tanto constituye un indicador más que concreto de la liquidez que ostenta nuestra Empresa.
 Podemos conocer el estado de cuenta, cuánto efectivo queda en la misma luego de los gastos, pago de capital y de intereses.

Cabe destacar, que el cash flow es un estado contable que presenta información sobre todos los movimientos de efectivo y sus equivalentes.

        </p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Primer Paso</h2>
            <p>
                Lo primero que debes hacer es Inicializar tu Capital, osea crear tu Cuenta. Vas al Menu Superior en la Opcion "Cuenta"->Mi Cuenta
                llenas los campos requeridos y Aceptar.
            </p>
            <p>
                <a class="btn btn-default" href="#">Ir Directo a Mi Cuenta.. &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Segundo Paso</h2>
            <p>
                Una vez creado el capital vas a hacer Movimientos Altas, Bajas y Modificaciones.Aqui se hace el movimiento de caja en si.
                Vas al Menu Superior en la opcion "Ingresos"->Movimientos.
            </p>
            <p>
                <a class="btn btn-default" href="Movimientos">Ir Directo a Movimientos &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Tercer Paso</h2>
            <p>
                
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>
</asp:Content>
