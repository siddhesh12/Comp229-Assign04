<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Character.aspx.cs" Inherits="Comp229_Assign04.Character" %>

<%@ Import Namespace="Comp229_Assign04" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button type="button" class="btn btn-primary btn-md" ID="updateButton" runat="server" Text="Update" OnClick="updateButtonClicked" />
    <asp:Button type="button" class="btn btn-primary btn-md" runat="server" ID="cancelButton" OnClick="cancelButtonClicked" Text="Cancel" />
    <asp:Button type="button" class="btn btn-primary btn-md" runat="server" ID="email" OnClick="emailButtonClicked" Text="Email" Visible="false" />
    <%--<asp:Button type="button" class="btn btn-primary btn-md" runat="server" ID="cancelEmail" onclick="cancelEmailButton" Text="Cancel Email" Visible="false" />--%>

    <asp:TextBox ID="emailTextBox" runat="server" Visible="false" />

    <div class="row" role="main">
        <div class="col-xs-12 col-md-4">
            <asp:Image ID="factionImg" runat="server" Width="250px" class="img-rounded" alt="Cinque Terre" />
        </div>
        <div class="col-xs-12 col-md-8">
            <table class="table table-striped table-inverse">
                <tr>
                    <td>name: 
                             <asp:Label ID="name"
                                 runat="server" />
                        <asp:TextBox ID="nameTextField" runat="server" Visible="false" />
                    </td>
                </tr>
                <tr>
                    <td>faction: 
                             <asp:Label ID="faction"
                                 runat="server" />
                        <asp:TextBox ID="factionTextBox" runat="server" Visible="false" />

                    </td>
                </tr>
                <tr>
                    <td>rank: 
                             <asp:Label ID="rank"
                                 runat="server" />
                        <asp:TextBox ID="rankTextBox" runat="server" Visible="false" />

                    </td>
                </tr>
                <tr>
                    <td>base: 
                             <asp:Label ID="baseLabel"
                                 runat="server" />
                        <asp:TextBox ID="baseTextBox" runat="server" Visible="false" />

                    </td>
                </tr>
                <tr>
                    <td>size: 
                             <asp:Label ID="size"
                                 runat="server" />
                        <asp:TextBox ID="sizeTextBox" runat="server" Visible="false" />

                    </td>
                </tr>
                <tr>
                    <td>deploymentZone: 
                             <asp:Label ID="deploymentZone"
                                 runat="server" />
                        <asp:TextBox ID="deploymentZoneTextBox" runat="server" Visible="false" />

                    </td>
                </tr>
                <tr>
                    <td>mobility: 
                             <asp:Label ID="mobility"
                                 runat="server" />
                        <asp:TextBox ID="mobilityTextBox" runat="server" Visible="false" />

                    </td>
                </tr>
                <tr>
                    <td>resiliance: 
                             <asp:Label ID="resiliance"
                                 runat="server" />
                        <asp:TextBox ID="resilianceTextBox" runat="server" Visible="false" />

                    </td>
                </tr>
                <tr>
                    <td>wounds: 
                             <asp:Label ID="wounds"
                                 runat="server" />
                        <asp:TextBox ID="woundsTextBox" runat="server" Visible="false" />

                    </td>
                </tr>
            </table>
        </div>
    </div>

    <%--bottom array--%>
    <div class="row">
        <div class="col-xs-12 col-md-4">
            <table class="table table-sm">
                <thead>
                    <tr>
                        <th>Traits</th>
                    </tr>
                </thead>
                <asp:Repeater runat="server" ID="traitsList">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label Text='<%# Container.DataItem.ToString() %>'
                                    runat="server" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div class="col-xs-12 col-md-4">
            <table class="table table-sm">
                <thead>
                    <tr>
                        <th>Types</th>
                    </tr>
                </thead>
                <asp:Repeater runat="server" ID="TypesList">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label Text='<%# Container.DataItem.ToString() %>'
                                    runat="server" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div class="col-xs-12 col-md-4">
            <table class="table table-sm">
                <thead>
                    <tr>
                        <th>Defence Chart</th>
                    </tr>
                </thead>
                <asp:Repeater runat="server" ID="defenceChartList">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label Text='<%# Container.DataItem.ToString() %>'
                                    runat="server" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
        <div class="col-xs-12 col-md-4">
            <table class="table table-sm">
                <thead>
                    <tr>
                        <th>actions</th>

                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater runat="server" ID="actionsList">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    name: 
                                    <asp:Label Text='<%#Eval("name") %>' runat="server" />
                                </td>
                            </tr>

                            <tr>
                                <td>type: 
                                    <asp:Label Text='<%#Eval("type") %>' runat="server" />
                                </td>
                            </tr>

                            <tr>
                                <td>rating: 
                                    <asp:Label Text='<%#Eval("rating") %>' runat="server" />
                                </td>
                            </tr>

                            <tr>

                                <td>range:
                                    <asp:Label Text='<%#Eval("range") %>' runat="server" />
                                </td>
                            </tr>

                            <tr>

                                <td>description: 
                                    <asp:Label Text='<%#Eval("description") %>' runat="server" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <div class="col-xs-12 col-md-4">
            <table class="table table-sm">
                <thead>
                    <tr>
                        <th>Special abilities</th>
                    </tr>
                </thead>
                <asp:Repeater runat="server" ID="speciaAbilitiesList">
                    <ItemTemplate>
                        <tr>
                            <td>name: 
                              <asp:Label Text='<%#Eval("name") %>' runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>description: 
                              <asp:Label Text='<%#Eval("description") %>' runat="server" />
                            </td>
                        </tr>
                    </ItemTemplate>

                </asp:Repeater>
            </table>
        </div>
    </div>
</asp:Content>
