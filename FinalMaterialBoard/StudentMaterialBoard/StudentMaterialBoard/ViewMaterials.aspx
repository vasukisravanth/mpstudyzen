<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true"
    CodeBehind="ViewMaterials.aspx.cs" Inherits="StudentMaterialBoard.ViewMaterials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand">
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
                                            Text='<%# Eval("MaterialName") %>'></asp:Label>
                                        <div class="forum-sub-title">
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Description") %>'>.</asp:Label>
                                            Posted By:<asp:Label ID="Label3" runat="server" Text='<%# Eval("UserType") %>'></asp:Label>
                                            Upload Date:<asp:Label ID="Label4" runat="server" Text='<%# Eval("UploadDate") %>'></asp:Label>
                                        </div>
                                        <br />
                                        <div class="forum-sub-title">
                                            <asp:LinkButton ID="lnkRate" runat="server" class="btn btn-primary" CommandName="Rate"
                                                CommandArgument='<%# Eval("MMId") %>' OnClick="lnkRate_Click"><i class="glyphicon glyphicon-star-empty"></i>&nbsp Rate</asp:LinkButton>
                                            <asp:LinkButton ID="lnkDownload" runat="server" class="btn btn-warning" CommandArgument='<%# Eval("FilePath")+","+ Eval("MMId") %>'
                                                OnClick="lnkDownload_Click"><i class="glyphicon glyphicon-download-alt"></i>&nbsp Download</asp:LinkButton>
                                            <asp:LinkButton ID="lnkDiscussion" runat="server" class="btn btn-info" CommandArgument='<%# Eval("MMId") %>'
                                                OnClick="lnkDiscussion_Click"><i class="glyphicon glyphicon-list-alt"></i>&nbsp Discussion</asp:LinkButton>
                                            <asp:LinkButton ID="lnkSpam" runat="server" class="btn btn-danger" Enabled="false"
                                                CommandArgument='<%# Eval("MMId") %>' OnClick="lnkSpam_Click"><i class="glyphicon glyphicon-remove"></i>&nbsp Report Spam</asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="col-md-1 forum-info">
                                        <asp:Label ID="Label5" class="views-number" runat="server" Text='<%# Eval("ViewCount") %>'></asp:Label>
                                        <div>
                                            <small>Views</small>
                                        </div>
                                    </div>
                                    <div class="col-md-1 forum-info">
                                         <asp:Label ID="Label6" class="views-number" runat="server" Text='<%# Eval("RatePoint") %>'></asp:Label>
                                        <div>
                                            <small>Rating</small>
                                        </div>
                                    </div>
                                    <div class="col-md-1 forum-info">
                                       <asp:Label ID="Label7" class="views-number" runat="server" Text='<%# Eval("SpamCount") %>'></asp:Label>
                                        <div>
                                            <small>Spam Count</small>
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
                        Material Rating</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <asp:TextBox type="number" ID="txtRate" runat="server" class="rating" min="0" max="5"
                                step="0.5" data-glyphicon="false" data-star-captions="{}" data-default-caption="{rating} Stars"
                                data-size="lg"></asp:TextBox>
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
    <asp:HiddenField ID="hdfRatingValue" runat="server" />
    <script>
        $(document).ready(function () {
            $("#txtRate").on("rating.change", function (event, value, caption) {

                var ratingValue = $('#<%=hdfRatingValue.ClientID%>').val();
                ratingValue = value;
                alert(ratingValue);
            });
        });
    </script>
    <script type="text/javascript">
        function ShowPopup() {

            $("#exampleModal").modal("show");
        }
        function ShowMsg() {

            $("#divMsg").modal("show");
        }
    </script>
</asp:Content>
