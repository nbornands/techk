<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="techk.aspx.cs" Inherits="techk.techk" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Styles/animate.css" rel="stylesheet" />
    <link href="~/Styles/bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery-1.4.1.min.js"></script>
</head>
<body style="background-image:url('/Img/wallpaper.jpg'); background-attachment: fixed; background-repeat: no-repeat">
    <form id="form1" runat="server">

    <%--HEADER--%>
    <div id="header" class="sticky-top">
        <div class="container text-center bg-white shadow">
            <br />
                <img alt="" src="Img/logo.png" width="150px" />
                <br />
                <h4 class="text-danger">Actividad Trainee</h4>
            <br />
        </div>
        <div id="Div1" class="container shadow">
            <div id="Div2" class="row bg-danger">
                <div class="col-12 text-left">
                    <div class="btn-group">
                        <asp:Button ID="btInicio" runat="server" CssClass="btn btn-danger" Text="Inicio" OnClick="btInicio_Click"/>
                        <asp:Button ID="btAlumnos" runat="server" CssClass="btn btn-danger" Text="Alumnos" OnClick="btAlumnos_Click" />
                        <asp:Button ID="btEventos" runat="server" CssClass="btn btn-danger" Text="Eventos" OnClick="btEventos_Click" />
                        <asp:Button ID="btRegiones" runat="server" CssClass="btn btn-danger" Text="Regiones" OnClick="btRegiones_Click"/>
                    </div>
                </div>
                <br />
            </div>
        </div>
    </div>
    <br />

    <%--BODY--%>
    <div id="cuerpo" class="animated fadeIn">
         <%--INICIO--%>
        <div id="inicio"  class="container card shadow" runat="server" visible="true"> 
            <br />
            <div class="row">
                <div class="col-sm-12">
                    <h2 class="text-center">Inicio de Actividad Trainee</h2>
                    <h5 class="text-center text-dark">Seleccione cualquier opcion del menu</h5>
                </div>
            </div>
            <br />
        </div>

        <%--ALUMNOS--%>
        <div id="alumnos"  class="container card shadow" runat="server" visible="false"> 
            <br />
            <div class="row">
                <div class="col-md-9">
                <h4>Alumnos</h4>
                </div>
                <div class="col-md-3">
                    <asp:Button ID="btnOrdenarAlumnos" runat="server" CssClass="btn btn-danger btn-sm" Text="Por Edad - Asc" OnClick="btnOrdenarAlumnosBirth_Click" />&nbsp;
                    <asp:Button ID="btnOrdenarNotas" runat="server" CssClass="btn btn-danger btn-sm" Text="Por promedio - Asc" OnClick="btnOrdenarAlumnosAvrg_Click"  />
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-sm-12">
                    <center>
                        <asp:GridView ID="gvAlumnos" 
                            HeaderStyle-BackColor="LightGray" 
                            CssClass="table table-bordered table-sm"
                            AutoGenerateColumns="false"
                            runat="server">
                            <Columns>
                                <asp:BoundField DataField="name" HeaderText="Nombre" />
                                <asp:BoundField DataField="grades" HeaderText="Notas" />
                                <asp:BoundField DataField="avrg" HeaderText="Promedio" />
                                <asp:BoundField DataField="birth" HeaderText="Fecha de Nacimiento"/>
                            </Columns>
                        </asp:GridView>
                    </center>
                </div>
            </div>
            <br />
            <br />
        </div>

        <%--EVENTOS--%>
        <div id="eventos" class="container card shadow" runat="server" visible="false">
            <br />
               <div class="row">
                <div class="col-md-10">
                <h4>Eventos</h4>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnOrdenarFecha" runat="server" CssClass="btn btn-danger btn-sm" Text="Por Fech - Asc" OnClick="btnOrdenarFecha_Click" />
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-sm-12">
                    <center>
                        <asp:GridView ID="gvEventos" 
                            HeaderStyle-BackColor="LightGray" 
                            CssClass="table table-bordered table-sm"
                            AutoGenerateColumns="false"
                            runat="server">
                            <Columns>
                                <asp:BoundField DataField="evento" HeaderText="Nombre"/>
                                <asp:BoundField DataField="repeat" HeaderText="Frecuencia"/>
                                <asp:BoundField DataField="time" HeaderText="Fecha"/>
                            </Columns>
                        </asp:GridView>
                    </center>
                </div>
            </div>
            <br />
            <br />
        </div>
        
        <%--REGIONES--%>
        <div id="regiones" class="container card shadow" runat="server" visible="false">
            <br />
                <div class="row">
                <div class="col-md-10">
                <h4>Regiones</h4>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnOrdenarRegion" runat="server" CssClass="btn btn-danger btn-sm" Text="Por Número - Asc" OnClick="btnOrdenarRegion_Click"/>
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-sm-12">
                    <center>
                        <asp:GridView ID="gvRegiones" 
                            HeaderStyle-BackColor="LightGray"  
                            CssClass="table table-bordered table-sm" 
                            AutoGenerateColumns="false"
                            runat="server">
                            <Columns>
                                <asp:BoundField DataField="region" HeaderText="Nombre"/>
                                <asp:BoundField DataField="number" HeaderText="Número"/>
                            </Columns>
                        </asp:GridView>
                    </center>
                </div>
            </div>
        </div>
        <br />
        <br />
    </div>
    <br />

    <%--FOOTER--%>
    <div id="footer" class="container fixed-bottom text-center bg-dark" >
        <p class="text-white-50">Desarrollado por Nicolás Bornand - 2019</p>
    </div>
    <br />
    </form>
</body>
</html>
