<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="AplicacionSIPA1.Vistas.Empleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <div class="container">
  
   
    <div class="text-center" >
        <h3 >Ingreso de usuario</h3>

    </div>
        <div class="row">
        <div class="col-lg-6  ">
            <div class="row">

            <div class=" col-lg-6">
                <asp:Label ID="lblEmpleado" runat="server" >Empleado</asp:Label>
                <asp:DropDownList ID="ddlEmpleados" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
            </div>
            <div class=" col-lg-6">
                <asp:Label ID="Label1" runat="server" >Usuario:</asp:Label>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" Width="100%" placeholder="Usuario"  ></asp:TextBox>
                
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6">
                    <asp:Label ID="Label2" runat="server" >Contraseña:</asp:Label>
                    <asp:TextBox ID="txtContrasenia" runat="server" CssClass="form-control" TextMode="Password" placeholder="Contraseña" Width="100%"></asp:TextBox>

                </div>
                <div class="col-lg-6">
                    <asp:Label ID="Label3" runat="server" >Validar Contraseña:</asp:Label>
                    <asp:TextBox ID="txtVcontrasenia" runat="server" CssClass="form-control" TextMode="Password" placeholder=" Validar Contraseña" Width="100%"></asp:TextBox>

                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <br />
                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" OnClick="btnGuardar_Click" Text="Guardar" Width="100%" />
                </div>
            </div>
              <div class="row">
                <div class="col-lg-12">
                    <br />
                   <asp:Label ID="lblSuccess" runat="server" CssClass="alert alert-success" Visible="false" Width="100%"></asp:Label>
                   <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger" Visible="false" Width="100%"></asp:Label>
                </div>
            </div>

 
        </div>

             <div class=" col-lg-6">
                 <br />
            <asp:GridView runat="server" ID="gvEmpleado" Width="100%" >

                 <Columns>
                                               <asp:CommandField ButtonType="Image" SelectImageUrl="~/Content/css/img/icon/formas-y-simbolos.png" ShowSelectButton="True">
                                               <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                               <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                               </asp:CommandField>
                     </Columns>

            </asp:GridView>

        </div>
	</div>
       

</div>




</asp:Content>
