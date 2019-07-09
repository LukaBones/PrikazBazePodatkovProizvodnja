<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zgodovina.aspx.cs" Inherits="PrikazBazePodatkovProizvodnja.zgodovina"  EnableEventValidation="false" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" type="text/css" rel="stylesheet" />
     <script src="JavaScript.js" >
    </script>
</head>
<body>
    <div class="page-header">
      <img src="matech_logo_dodatne_variante_barvni_46x.png" class="img"/>
      <h1>PRETEKLA PROIZVODNJA</h1>
      <img src="matech_logo_dodatne_variante_barvni_46x.png"  class="img" />
    </div>
    <form id="form1" runat="server" class="form">
         <div class="div-text-box">
                <asp:Label ID="Label6" runat="server" Text="Koda:" CssClass="labels"></asp:Label>
                <asp:TextBox ID="TextBox6" runat="server" OnTextChanged="TextBox6_TextChanged" AutoPostBack="true" ></asp:TextBox>
            </div>

        <div class="div-datum-picer">
            <div class="div-text-box">
                <asp:Label ID="Label5" runat="server" Text="Datum od:" CssClass="labels"></asp:Label>
                <asp:TextBox ID="TextBox4" runat="server" TextMode="Date" BackColor="White" AutoPostBack="true" OnTextChanged="TextBox4_TextChanged"></asp:TextBox>
            </div>
            <div class="div-text-box">
                <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                <asp:TextBox ID="TextBox5" runat="server" TextMode="Date" BackColor="White" AutoPostBack="true" OnTextChanged="TextBox5_TextChanged" ></asp:TextBox>
            </div>
           

        </div>

         <div class="div-text-box">
                <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" >
                            <asp:ListItem Selected = "True" Value="1">GEN. STATUS</asp:ListItem>
                            <asp:ListItem Value="2">VTISKOVANJE</asp:ListItem>
                            <asp:ListItem Value="3">VIJAČENJE</asp:ListItem>
                            <asp:ListItem Value="4">TESNOST</asp:ListItem>
                            </asp:DropDownList>
          </div>
        <asp:HiddenField ID="radioButtonHistoryStatusValue" runat="server" value ="0"/>
        <div class="container">
          <div class="radio-tile-group">
            <div class="input-container-small">
              <input id="Radio4" runat="server" class="radio-button" type="radio" name="radioHistoryStatus" onclick="radioButtonHistoryStatusValueChanged(this);" value="0"/>
              <div class="radio-tile">
                <label for="walk" class="radio-tile-label">VSI</label>
                <asp:Label ID="Label8" runat="server" class="radio-tile-label" Text="Label"  Font-Size="25pt" Visible ="false"></asp:Label>
              </div>
            </div>

            <div class="input-container-small">
              <input id="Radio5" runat="server" class="radio-button" type="radio" name="radioHistoryStatus" onclick="radioButtonHistoryStatusValueChanged(this);"  value="1"/>
              <div class="radio-tile">
                <label for="bike" class="radio-tile-label">OK</label>
                <asp:Label ID="Label9" runat="server" class="radio-tile-label" Text="Label" Font-Size="25pt" ForeColor="#006600" Visible ="false"> </asp:Label>
              </div>
            </div>

            <div class="input-container-small">
              <input id="Radio6" runat="server" class="radio-button" type="radio" name="radioHistoryStatus"  onclick="radioButtonHistoryStatusValueChanged(this);"  value="2"/>
              <div class="radio-tile">
                <label id="driveId"for="drive" class="radio-tile-label">NOT OK</label>      
                <asp:Label ID="Label10" runat="server" class="radio-tile-label" Text="Label"  Font-Size="25pt" ForeColor="#CC0000" Visible ="false"> </asp:Label>
              </div>
            </div>

            <div id="divToHide" runat="server" class="input-container-small">
              <input id="Radio1" runat="server" class="radio-button" type="radio" name="radioHistoryStatus" onclick="radioButtonHistoryStatusValueChanged(this);"  value="4"/>
              <div class="radio-tile">
                <label id="drive"for="drive" class="radio-tile-label">IMPREGNACIJA</label>     
                <asp:Label ID="Label1" runat="server" class="radio-tile-label" Text="Label"  Font-Size="25pt" ForeColor="#CC0000" Visible ="false"> </asp:Label>
              </div>
            </div>

          </div>

             <div class="radio-tile-group-right">
             <div class="input-container">
              <div class="radio-tile-button">
                <asp:Button ID="Button5" runat="server" Text="Izpis" class="button-button" name="radioStatus" OnClick="Button1_Click" />
                <label id="izpis" for="drive" class="radio-tile-label">IZPIS</label>   
              </div>
            </div>
          

             
             <div class="input-container">
              <div class="radio-tile-button">
                <asp:Button ID="Button6" runat="server" Text="Izpis" class="button-button" name="radioStatus" OnClick="Button1_Click" />
                <label id="reset" for="drive" class="radio-tile-label">RESET</label>   
              </div>
            </div>
          

             
             <div class="input-container">
              <div class="radio-tile-button">
                <asp:Button ID="Button7" runat="server" Text="Izpis" class="button-button" name="radioStatus" OnClick="Button1_Click" />
                <label id="isce" for="drive" class="radio-tile-label">ISKANJE</label>   
              </div>
            </div>
          </div>

        </div>
         

         <div id="dIVscrolledGridView">
                    <asp:GridView ID="GridView1" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" SelectedRowStyle-CssClass="selectedrow" AllowPaging="True" PageSize="25" OnPageIndexChanging="datagrid_PageIndexChanging">
                    </asp:GridView>
         </div>
        
        
    </form>
    </body>
</html>

