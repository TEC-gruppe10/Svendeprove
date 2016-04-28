<%@ Page Title="" Language="C#" MasterPageFile="~/Hovedside.Master" AutoEventWireup="true" CodeBehind="Kunder.aspx.cs" Inherits="ServiceDesk.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-right: auto;margin-left:auto">
        <div style="width: 1000px">
            <div style="width: 200px; float: right;">
                <div style="width: inherit; background-color: blue;padding:20px;margin:10px">
                    Antal reparationer med medarbejder:<br />
                    Antal reparationer uden medarbejder:<br />
                </div>
                <div style="width: inherit; background-color: red;padding:20px;margin:10px">
                    hello2
                </div>
            </div>
            <div style="float: left; width:740px; background-color: orange;padding:20px;margin:10px">
                <asp:PlaceHolder ID = "PlaceHolder1" runat="server" /></asp:Placeholder>
            </div>
            
        </div>
    </div>
</asp:Content>
