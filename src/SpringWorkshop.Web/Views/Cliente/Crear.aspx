<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SpringWorkshop.Domain.Cliente>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Crear
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Crear Cliente</h2>

    <% using (Html.BeginForm()) {%>
        <%= Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Nombre) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Nombre) %>
                <%= Html.ValidationMessageFor(model => model.Nombre) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Direccion) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Direccion) %>
                <%= Html.ValidationMessageFor(model => model.Direccion) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Telefono) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Telefono) %>
                <%= Html.ValidationMessageFor(model => model.Telefono) %>
            </div>
            
            <p>
                <input type="submit" value="Crear" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%= Html.ActionLink("Regresar a la lista", "Index") %>
    </div>

</asp:Content>

