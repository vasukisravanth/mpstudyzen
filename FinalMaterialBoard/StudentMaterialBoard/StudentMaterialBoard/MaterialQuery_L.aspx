<%@ Page Title="" Language="C#" MasterPageFile="~/Lecture.Master" AutoEventWireup="true" CodeBehind="MaterialQuery_L.aspx.cs" Inherits="StudentMaterialBoard.MaterialQuery_L" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header">
                    Material Discussion</h3>
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
                                <div class="pull-right">
                                    <asp:Button ID="btnPostQuery" runat="server" Text="Post Query" class="btn btn-primary btn-sm pull-right"
                                        Style="padding: 10px 20px;" OnClick="btnPostQuery_Click" />
                                </div>
                                <asp:DataList ID="DataList1" runat="server">
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
                                                                <div class="col-md-12">
                                                                    <div class="forum-icon">
                                                                        <i class="fa fa-shield"></i>
                                                                    </div>
                                                                    <asp:Label ID="Label2" Style="font-size: 20px;" class="forum-item-title" runat="server"
                                                                        Text='<%# Eval("PostQuery") %>'></asp:Label>
                                                                    <div class="forum-sub-title">
                                                                        Posted By:<asp:Label ID="Label3" runat="server" Text='<%# Eval("UserType") %>'></asp:Label>
                                                                        Upload Date:<asp:Label ID="Label4" runat="server" Text='<%# Eval("PostDate") %>'></asp:Label>
                                                                    </div>
                                                                    <br />
                                                                    <div class="forum-sub-title">
                                                                        <asp:LinkButton ID="lnkViewReply" runat="server" class="btn btn-primary" CommandArgument='<%# Eval("MQId") %>'
                                                                            OnClick="lnkViewReply_Click"><i class="glyphicon glyphicon-comment"></i>&nbsp View Reply</asp:LinkButton>
                                                                        <asp:LinkButton ID="lnkPostReply" runat="server" class="btn btn-warning" CommandArgument='<%# Eval("MQId") %>'
                                                                            OnClick="lnkPostReply_Click"><i class="glyphicon glyphicon-list-alt"></i>&nbsp Post Reply</asp:LinkButton>
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
                                <asp:Panel ID="Panel1" runat="server">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <h3 class="page-header">
                                                Material Reply</h3>
                                        </div>
                                        <!-- /.col-lg-12 -->
                                    </div>
                                    <asp:DataList ID="DataList2" runat="server" Style="width: 100%">
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
                                                                            Text='<%# Eval("ReplyQuery") %>'></asp:Label>
                                                                        <div class="forum-sub-title">
                                                                            Posted By:<asp:Label ID="Label3" runat="server" Text='<%# Eval("UserType") %>'></asp:Label>
                                                                            Reply Date:<asp:Label ID="Label4" runat="server" Text='<%# Eval("ReplyDate") %>'></asp:Label>
                                                                        </div>
                                                                        <br />
                                                                        <div class="forum-sub-title">
                                                                            <asp:LinkButton ID="lnkDownload" runat="server" class="btn btn-warning" CommandArgument='<%# Eval("FilePath")+","+ Eval("MQRId") %>'
                                                                                OnClick="lnkDownload_Click"><i class="glyphicon glyphicon-download-alt"></i>&nbsp Download</asp:LinkButton>
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
                                </asp:Panel>
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
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
        aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">
                        Post Material Query</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="form-group">
                                <label>
                                    Enter Material Query</label>
                                <asp:TextBox ID="txtQuery" runat="server" class="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Enter Query"
                                    ForeColor="Red" ValidationGroup="A" ControlToValidate="txtQuery"></asp:RequiredFieldValidator>
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
    <div class="modal fade" id="postquery" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
        aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="H2">
                        Post Material Reply</h5>
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
                    <asp:Button ID="btnPostReply" runat="server" class="btn btn-primary" Text="Post Reply"
                        OnClick="btnPostReply_Click" />
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
        function PostPopup() {

            $("#postquery").modal("show");
        }
        function ShowMsg() {

            $("#divMsg").modal("show");
        }
    </script>
</asp:Content>
