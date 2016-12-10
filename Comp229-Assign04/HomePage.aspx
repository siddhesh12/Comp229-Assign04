<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Comp229_Assign04.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class = "container">
    
       <div class = "jumbotron">
          <h1>Welcome to Game Of Wrath!</h1>
          <p>An epic fantasy miniatures war game set in a stunning world. Beautiful miniatures, great art and fast rules!</p>
       </div>
       
    </div>

    <h3><u>Wrath Teams </u><span class="label label-default"></span></h3>
    <asp:DataList ID="DataListExample" runat="server" BackColor="White" BorderColor="#DEBA84"
        BorderStyle="None" BorderWidth="0px" CellPadding="50" CellSpacing="80" Font-Bold="True"
        Font-Names="Dotum" Font-Size="Small" RepeatColumns="2" RepeatDirection="Horizontal"
        Width="700px" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" OnSelectedIndexChanged="DataListExample_SelectedIndexChanged" ShowFooter="False" ShowHeader="False">
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" Font-Size="Large" ForeColor="White"
            HorizontalAlign="Center" VerticalAlign="Middle" />
        <ItemStyle BackColor="White" ForeColor="White" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Larger" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />
        <ItemTemplate>
            <table>
                <tr>
                    <td>
                        <asp:HyperLink runat="server" navigateUrl='<%#String.Format("~/Character.aspx?name={0}&faction={1}",Eval("name"),Eval("faction")) %>' >
                        <asp:Image ID="factionImg" runat="server" Height="200px" Width="250px" ImageUrl='<%# Eval("imageUrl") %>' />
                        <asp:Label ID="faction" 
                            runat="server" Text='<%# Eval("faction") %>' ForeColor="#000099" />
                        </asp:HyperLink></td></tr></table></ItemTemplate><SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
    </asp:DataList>
</asp:Content>
