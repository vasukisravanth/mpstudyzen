<%@ Page Title="" Language="C#" MasterPageFile="~/Lecture.Master" AutoEventWireup="true" CodeBehind="LectureMaterialUpload.aspx.cs" Inherits="StudentMaterialBoard.LectureMaterialUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Material Upload</h3>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="">
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                
                                
                                <div class="form-group">
                                    <label>
                                            Select Subject</label>
                                        <asp:DropDownList ID="ddlSubject" runat="server" class="form-control">
                                        
                                        </asp:DropDownList>
                                        
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Subject" InitialValue="--Select--" ForeColor="Red" ValidationGroup="A" ControlToValidate="ddlSubject"></asp:RequiredFieldValidator>
                                </div>
                                
                                <div class="form-group">
                                     <label>
                                         Enter Material Name</label>
                                        <asp:TextBox ID="txtName" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Enter Name" ForeColor="Red" ValidationGroup="A" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                     <label>
                                         Enter Material Description</label>
                                        <asp:TextBox ID="txtDescription" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Description" ForeColor="Red" ValidationGroup="A" ControlToValidate="txtDescription"></asp:RequiredFieldValidator>
                                </div>
                                 <div class="form-group">
                                     <label>
                                         Select Material File</label>
                                       <asp:FileUpload ID="MaterialFile" class="form-control" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select File" ForeColor="Red" ValidationGroup="B" ControlToValidate="MaterialFile"></asp:RequiredFieldValidator>
                                </div>
                                <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label>
                                <div class="pull-right">
                                       <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="A"
                                            class="btn btn-primary btn-sm pull-right" style="padding:10px 20px;" 
                                            onclick="btnSave_Click" /> 
                                </div>
                                
                            </div>
                            <!-- /.col-lg-6 (nested) -->
                            <!-- /.col-lg-6 (nested) -->
                        </div>
                        <!-- /.row (nested) -->
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
    </div>
</asp:Content>
