<%@ Page Title="Notas" Language="C#"  MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Notas.aspx.cs" Inherits="Notas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Nueva Nota</h4>
        <hr />
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="idFactura" CssClass="col-md-2 control-label">Id Factura de la cual Corresponde</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="idFactura" CssClass="form-control"  />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="idFactura"
                    CssClass="text-danger" ErrorMessage="Se requiere el Tipo de Nota." />
            </div>
        </div>   


         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="idtipo" CssClass="col-md-2 control-label" ID="idtipo">Tipo</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="ComboTipo" runat="server" CssClass="form-control">
                    <asp:ListItem>Credito</asp:ListItem>
                    <asp:ListItem>Debito</asp:ListItem>
                   
                </asp:DropDownList>
            </div>
        </div>
                <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="idNota" CssClass="col-md-2 control-label">Id Nota</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="idNota" CssClass="form-control"  />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="idNota"
                    CssClass="text-danger" ErrorMessage="Se requiere el Tipo de Nota." />
            </div>
        </div>   

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Monto" CssClass="col-md-2 control-label">Monto</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Monto" CssClass="form-control" OnTextChanged="Monto_TextChanged" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Monto"
                    CssClass="text-danger" ErrorMessage="Se requiere el Monto de la Nota" />
            </div>
        </div>   
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Fecha" CssClass="col-md-2 control-label">Fecha</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Fecha" CssClass="form-control" OnTextChanged="Fecha_TextChanged" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Fecha"
                    CssClass="text-danger" ErrorMessage="Se requiere Fecha de Nota" />
            </div>
        </div> 
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server"  Text="Registrar Nota" CssClass="btn btn-small btn-success" ID="btnRegistro" OnClick="Unnamed14_Click" OnClientClick="Registrar" />
            </div>
        </div>
      </div>
</asp:Content>