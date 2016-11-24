<%@ Page Title="Movimiento" Language="C#" AutoEventWireup="true" CodeFile="Movimientos.aspx.cs" Inherits="Movimientos" MasterPageFile="~/Site.master" %>
 <%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>

   
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <asp:ValidationSummary runat="server" CssClass="text-danger" />

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="idfecha" CssClass="col-md-2 control-label">Fecha</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="idfecha" CssClass="form-control" placeholder="Ingrese la fecha de Hoy"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="idfecha"
                    CssClass="text-danger" ErrorMessage="Se requiere la Fecha del movimiento" />
            </div>
        </div>   
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="idtipo" CssClass="col-md-2 control-label" ID="idtipo">Tipo</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="ComboTipo" runat="server" CssClass="form-control">
                    <asp:ListItem>Cobro</asp:ListItem>
                    <asp:ListItem>Pago</asp:ListItem>
                   
                </asp:DropDownList>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ModoPago" CssClass="col-md-2 control-label" ID="ModoPago">Modo de Pago</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="ComboPago" runat="server" CssClass="form-control">
                    <asp:ListItem>Efectivo</asp:ListItem>
                    <asp:ListItem>Transferencia Bancaria</asp:ListItem>
                    <asp:ListItem>Cheque</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Moneda" CssClass="col-md-2 control-label" ID="Moneda">Moneda</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="ComboMoneda" runat="server" CssClass="form-control">
                    <asp:ListItem>Peso Argentino</asp:ListItem>
                    <asp:ListItem>Dolar</asp:ListItem>
                    
                </asp:DropDownList>
            </div>
        </div>


        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Monto" CssClass="col-md-2 control-label">Monto</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Monto" CssClass="form-control"  />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Monto"
                    CssClass="text-danger" ErrorMessage="Se requiere el Monto de la Factura" />
            </div>
        </div>   
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Idfactura" CssClass="col-md-2 control-label">Id Factura</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Idfactura" CssClass="form-control"  />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Idfactura"
                    CssClass="text-danger" ErrorMessage="Se requiere id de factura" />
            </div>
        </div>   
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Tipo" CssClass="col-md-2 control-label" ID="Tipo">Tipo de Movimiento</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="ComboMovimiento" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ComboMovimiento_SelectedIndexChanged">
                    <asp:ListItem>Recurrente</asp:ListItem>
                    <asp:ListItem>Unico</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="frecfac" CssClass="col-md-2 control-label" ID="frecuencia">Frecuencia de Facturación</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="frecfac" CssClass="form-control"  />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="frecfac"
                    CssClass="text-danger" ErrorMessage="Se requiere la Frecuencia de Facturación" />
            </div>
        </div>   
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="plaEje" CssClass="col-md-2 control-label" ID="plazo">Plazo de Ejecución</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="plaEje" CssClass="form-control"  />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="plaEje"
                    CssClass="text-danger" ErrorMessage="Se requiere que ingrese Plazo de Ejecucion" />
            </div>
        </div> 

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="FechaCobro" CssClass="col-md-2 control-label">Fecha de Cobro</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="FechaCobro" CssClass="form-control"  />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="FechaCobro"
                    CssClass="text-danger" ErrorMessage="Se requiere la fecha de cobro" />
            </div>
        </div>   
        
         <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="AltaMovimiento" Text="Alta" CssClass="btn btn-default" />  
                            </div></div>
       
       </div>
</asp:Content>