<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="XMLSampleGen._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
      Bazaar Voice XML Product Feed Generation
    </h2>
   
    <div>
    <asp:Button ID="btnXmlGeneration" runat="server" Text="Genarate XML" 
            onclick="btnXmlGeneration_Click" />
    </div>
    <h3>
        <asp:Label ID="lblStatus" runat="server" Text="" Visible="false"></asp:Label></h3>
</asp:Content>
