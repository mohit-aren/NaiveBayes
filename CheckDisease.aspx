<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckDisease.aspx.cs" Inherits="CheckDisease" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <LINK href="zengarden-sample.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="initial">
           <tr>
                <td class="initial" colspan="2" align="center">
                    <asp:Label ID="capSubj" runat="server" Width="557px"
                        Text="Check Disease" Font-Bold="True" 
                        ForeColor="#FF0066"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="initial" colspan="2" align="center">
                    <asp:Label ID="lblMessg" runat="server" Width="557px"
                        Text="" Font-Bold="True" 
                        ForeColor="#0066FF"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="capFile" runat="server" Text="File 1 of disease 1:"></asp:Label>
                </td>
                <td class="style1">
                    <asp:FileUpload ID="updFile" runat="server"></asp:FileUpload>
                </td>
            </tr>
           <tr>
                <td>
                    <asp:Label ID="capDis1" runat="server" Text="Name of Disease 1:"></asp:Label>
                </td>
               <td>
                   <asp:TextBox ID="txtDis1" runat="server"></asp:TextBox>
               </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Label ID="capFile1" runat="server" Text="File 2 of disease 2:"></asp:Label>
                </td>
                <td class="style1">
                    <asp:FileUpload ID="updFile2" runat="server"></asp:FileUpload>
                </td>
            </tr>
           <tr>
                <td>
                    <asp:Label ID="capDis2" runat="server" Text="Name of Disease 2:"></asp:Label>
                </td>
               <td>
                   <asp:TextBox ID="txtDis2" runat="server"></asp:TextBox>
               </td>
            </tr>

           <tr>
                <td>
                    <asp:Label ID="capSymp" runat="server" Text="New Symptom:"></asp:Label>
                </td>
               <td>
                   <asp:TextBox ID="txtSymp" runat="server" Width="397px"></asp:TextBox>
               </td>
            </tr>

           <tr>
                <td class="style1">
                    <asp:Label ID="capTestF" runat="server" Text="Test File :"></asp:Label>
                </td>
                <td class="style1">
                    <asp:FileUpload ID="updFile3" runat="server"></asp:FileUpload>
                </td>
            </tr>

            <tr>
               <td align="left" colspan="2">
                     <asp:Button ID="btnCheck" runat="server" Text="Check new Symptom" 
                         EnableTheming="True" onclick="btnCheck_Click" />
                      <asp:Button ID="btnSympFile" runat="server" Text="Check Symptom File" 
                         EnableTheming="True" onclick="btnSympFile_Click" />
                     
               </td>
            </tr>

            
        </table>
    </div>
    </form>
</body>
</html>
