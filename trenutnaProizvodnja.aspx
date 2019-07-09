<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="trenutnaProizvodnja.aspx.cs" Inherits="PrikazBazePodatkovProizvodnja.trenutnaProizvodnja"  EnableEventValidation="false"%>

<!DOCTYPE html>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" type="text/css" rel="stylesheet" />
     <script src="JavaScript.js" >
    </script>
</head>
<body>
    <form id="form1" method="post" runat="server">
    <div class="page-header">
      <img src="matech_logo_dodatne_variante_barvni_46x.png" class="img" />
      <h1>TRENUTNA PROIZVODNJA</h1>
      <img src="matech_logo_dodatne_variante_barvni_46x.png"  class="img" />
    </div>
        <asp:HiddenField ID="radioButtonTimeValue" runat="server" value ="1"/>
         <div class="container">
          <div class="radio-tile-group">
            <div class="input-container">
              <input id="walk" runat="server" class="radio-button" type="radio" name="radioTime" onclick="handleClickRadioButtonTime(this);" value="1" checked="checked"/>
              <div class="radio-tile">
                <label for="walk" class="radio-tile-label">ZADNJIH 1000</label>
              </div>
            </div>

            <div class="input-container">
              <input id="bike" runat="server" class="radio-button" type="radio" name="radioTime" onclick="handleClickRadioButtonTime(this);"  value="2"/>
              <div class="radio-tile">
                <label for="bike" class="radio-tile-label">DANES</label>
              </div>
            </div>

            <div class="input-container">
              <input id="drive" runat="server" class="radio-button" type="radio" name="radioTime" onclick="handleClickRadioButtonTime(this);"  value="3"/>
              <div class="radio-tile">
                <label for="drive" class="radio-tile-label">IZMENA</label>
              </div>
            </div>
          </div>
        </div>
        
        <asp:HiddenField ID="radioButtonStatusValue" runat="server" Value ="1" />
        <div class="container">
          <div class="radio-tile-group">
            <div class="input-container-small">
              <input id="Radio4" runat="server" class="radio-button" type="radio" name="radioStatus" onclick="handleClickRadioButtonTime(this);" value="1"  checked="checked"/>
              <div class="radio-tile">
                <label for="walk" class="radio-tile-label">VSI</label>
                <asp:Label ID="Label2" runat="server" class="radio-tile-label" Text="Label"  Font-Size="25pt"></asp:Label>
              </div>
            </div>

            <div class="input-container-small">
              <input id="Radio5" runat="server" class="radio-button" type="radio" name="radioStatus" onclick="handleClickRadioButtonTime(this);"  value="2"/>
              <div class="radio-tile">
                <label for="bike" class="radio-tile-label">OK</label>
                <asp:Label ID="Label3" runat="server" class="radio-tile-label" Text="Label" Font-Size="25pt" ForeColor="#006600"> </asp:Label>
              </div>
            </div>

            <div class="input-container-small">
              <input id="Radio6" runat="server" class="radio-button" type="radio" name="radioStatus" onclick="handleClickRadioButtonTime(this);"  value="3"/>
              <div class="radio-tile">
                <label id="driveId"for="drive" class="radio-tile-label">NOT OK</label>      
                <asp:Label ID="Label4" runat="server" class="radio-tile-label" Text="Label"  Font-Size="25pt" ForeColor="#CC0000"> </asp:Label>
              </div>
            </div>
          </div>
            
            <div class="radio-tile-group-right">
             <div class="input-container">
              <div class="radio-tile-button">
                <asp:Button ID="Button1" runat="server" Text="Izpis" class="button-button" name="radioStatus" OnClick="Button1_Click" />
                <label id="izpis" for="drive" class="radio-tile-label">IZPIS</label>   
              </div>
            </div>
          </div>
                
        </div>


         <div id="dIVscrolledGridView">
                    <asp:GridView ID="datagrid" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" SelectedRowStyle-CssClass="selectedrow" AllowPaging="True" PageSize="25" OnPageIndexChanging="datagrid_PageIndexChanging" OnRowDataBound="datagrid_RowDataBound1">
                    </asp:GridView>
         </div>
     </form>
</body>
    
</html>
