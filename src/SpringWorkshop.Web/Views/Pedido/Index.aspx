<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SpringWorkshop.Domain.Pedido>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Pedidos</h2>
    <table>
        <tr>
            <th>
                DireccionEnvio
            </th>
            <th>
                FechaPedido
            </th>
            <th>
                FechaEnvio
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%= Html.Encode(item.DireccionEnvio) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:d}", item.FechaPedido)) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:d}", item.FechaEnvio)) %>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <% using (Html.BeginForm("enviar","pedido"))
           {%>
        <input id="idCliente" name="idCliente" type="hidden" value="<%=Request.QueryString["idCliente"] %>" />
        <input type="submit" value="Enviar Pedidos" />
        <% } %>
    </p>
    <p>
        <%= Html.ActionLink("Regresar a la Lista de Clientes", "index","cliente") %>
    </p>
</asp:Content>
