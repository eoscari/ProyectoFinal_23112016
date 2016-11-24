<%@ Page Title="Mi Cuenta" Language="C#" AutoEventWireup="true" CodeFile="MiCuenta.aspx.cs" Inherits="MiCuenta" MasterPageFile="~/Site.master" %>

 <%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                 <hr />
                <div class="form-horizontal">
         
                  <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="FondoDolar" CssClass="col-md-2 control-label">Fondo en Dolar</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="FondoDolar" CssClass="form-control" PlaceHolder="Si no Tiene Fondo Ingrese 0" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="FondoDolar"
                                CssClass="text-danger" ErrorMessage="Ingrese fondo de Dolar." />
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="FondoPeso" CssClass="col-md-2 control-label">Fondo en Pesos</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="FondoPeso" CssClass="form-control" PlaceHolder="Si no tiene fondo ingrese 0"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="FondoPeso"
                                CssClass="text-danger" ErrorMessage="Ingrese un fondo." />
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="NroCuenta" CssClass="col-md-2 control-label">Nro de Cuenta</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="NroCuenta" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="NroCuenta"
                                CssClass="text-danger" ErrorMessage="Ingrese el Numero de cuenta." />
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Cuenta" CssClass="col-md-2 control-label">Cantidad de Dinero en la Cuenta</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Cuenta" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Cuenta"
                                CssClass="text-danger" ErrorMessage="The user name field is required." />
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="ChequesCo" CssClass="col-md-2 control-label">Cheques Cobrados</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="ChequesCo" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ChequesCo"
                                CssClass="text-danger" ErrorMessage="Ingrese valores." />
                        </div>
                    </div>

                    
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="Alta" Text="Alta" CssClass="btn btn-default" />
                          
                            
                        </div>
                    </div>
                </div>
              
            </section>
        </div>
    </div>
       
</asp:Content>

