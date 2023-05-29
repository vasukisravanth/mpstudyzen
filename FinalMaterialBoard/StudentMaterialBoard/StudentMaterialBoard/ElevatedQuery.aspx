<%@ Page Title="" Language="C#" MasterPageFile="~/Lecture.Master" AutoEventWireup="true"
    CodeBehind="ElevatedQuery.aspx.cs" Inherits="StudentMaterialBoard.ElevatedQuery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server" Style="width: 100%">
        <ItemTemplate>
            <table class="nav-justified">
                <tr>
                    <td>
                        <div class="ibox-content forum-container">
                            <div class="forum-title">
                                <div class="pull-right forum-desc">
                                    <%--<small>Total posts: </small>--%>
                                </div>
                                <%--<h3>
                                    General subjects</h3>--%>
                            </div>
                            <div class="forum-item active">
                                <div class="row">
                                    <div class="col-md-9">
                                        <div class="forum-icon">
                                            <i class="fa fa-shield"></i>
                                        </div>
                                        <asp:Label ID="Label2" Style="font-size: 20px;" class="forum-item-title" runat="server"
                                            Text='<%# Eval("PostQuery") %>'></asp:Label>
                                        <div class="forum-sub-title">
                                            Posted By:<asp:Label ID="Label3" runat="server" Text='<%# Eval("UserType") %>'></asp:Label>
                                            Posted Date:<asp:Label ID="Label4" runat="server" Text='<%# Eval("PostDate") %>'></asp:Label>
                                        </div>
                                        <br />
                                        <div class="forum-sub-title">
                                            <asp:LinkButton ID="lnkReply" runat="server" class="btn btn-primary" CommandArgument='<%# Eval("MQId") %>'
                                                OnClick="lnkReply_Click"><i class="glyphicon glyphicon-comment"></i>&nbsp Post Reply</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
        aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">
                        Elevated Material Reply</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <label>
                                    Enter Reply</label>
                                <asp:TextBox ID="txtReply" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>
                                    Select File</label>
                                <asp:FileUpload ID="MaterialFile" class="form-control" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">
                        Close</button>
                    <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="Save changes"
                        OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="divMsg" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
        aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="H1">
                        Message</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">
                        Close</button>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function ShowPopup() {

            $("#exampleModal").modal("show");
        }
        function ShowMsg() {

            $("#divMsg").modal("show");
        }
    </script>
</asp:Content>
