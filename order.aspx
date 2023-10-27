<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="agrostorefrontend.WebForms.order"   MasterPageFile="~/User.Master"%>
<%@ MasterType VirtualPath="~/User.Master" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="col-lg-10 col-sm-10">

        <div class="row">
            <div class="box col-md-12">
                <div class="box-inner">
                    <div class="alert alert-info">New order details</div>
                    <cc1:TabContainer ID="TabContainerOrder" runat="server" ScrollBars="Auto" ActiveTabIndex="1" OnActiveTabChanged="TabContainerOrder_ActiveTabChanged" >
                        <cc1:TabPanel runat="server" HeaderText="Order" TabIndex="0" ID="TabPanel1">
                            <ContentTemplate>
                                <div class="form-group has-success col-md-4">
                                    <asp:Label ID="Label2" runat="server" Text="Farmer name :" class="control-label"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FarmerNameTextBox" Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" SetFocusOnError="True" ValidationGroup="MemberValidate"></asp:RequiredFieldValidator>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="FarmerNameTextBox" runat="server" class="form-control"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>
                                <div class="form-group has-success col-md-4">
                                    <asp:Label ID="Label1" runat="server" Text="Farmer phone :" class="control-label"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FarmerPhoneTextBox" Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" SetFocusOnError="True" ValidationGroup="MemberValidate"></asp:RequiredFieldValidator>

                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="FarmerPhoneTextBox" runat="server" class="form-control"></asp:TextBox>


                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>
                                <div class="form-group has-success col-md-4">
                                    <asp:Label ID="Label5" runat="server" class="control-label"></asp:Label>
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" class="form-control" Visible="False"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group has-success col-md-4">
                                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="CreateOrderButton" runat="server" BackColor="#0099FF" class="form-control" ForeColor="Black" OnClientClick="return Validate('MemberValidate');" Text="Proceed" OnClick="CreateOrderButton_Click" /><asp:Label ID="OrderLabel" runat="server" class="control-label"></asp:Label>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="CreateOrderButton" />
                                        </Triggers>
                                    </asp:UpdatePanel>

                                </div>

                            </ContentTemplate>


                        </cc1:TabPanel>
                        <cc1:TabPanel ID="TabPanel2" runat="server" TabIndex="1" HeaderText="Order details">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="box col-md-12">
                                        <div class="box-inner">
                                            <div class="alert alert-info">Order</div>
                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="OrderGridView" runat="server" class="table table-striped table-bordered bootstrap-datatable datatable responsive" Font-Size="Small" CellPadding="4" ForeColor="Black" GridLines="None" OnSelectedIndexChanged="OrderGridView_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="OrderGridView_PageIndexChanging" PageSize="5" OnRowDeleting="OrderGridView_RowDeleting">
                                                        <Columns>
                                                            <asp:CommandField ButtonType="Button" HeaderText="Select to add details" ShowSelectButton="True" />
                                                            <asp:CommandField ButtonType="Button" DeleteText="Discard" HeaderText="Discard" ShowDeleteButton="True" />
                                                        </Columns>
                                                        <EditRowStyle BackColor="#2461BF" />
                                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="#0066FF" />
                                                        <HeaderStyle Wrap="False" BackColor="#507CD1" Font-Bold="True" ForeColor="Black" />
                                                        <PagerStyle BackColor="#2461BF" ForeColor="Black" HorizontalAlign="Center" />
                                                        <RowStyle Wrap="False" BackColor="#EFF3FB" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group has-success col-md-4">
                                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="Label9" runat="server" Text="Product type:" class="control-label">
                                            </asp:Label><asp:DropDownList ID="ProductDownList" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ProductDownList_SelectedIndexChanged">
                                                <asp:ListItem Value="0">- Select -</asp:ListItem>
                                                <asp:ListItem>Fertilizer</asp:ListItem>
                                                <asp:ListItem Value="Seed"></asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="form-group has-success col-md-4">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="Label3" runat="server" Text="Item type:" class="control-label">
                                            </asp:Label><asp:DropDownList ID="ItemsDropDownList" runat="server" class="form-control"></asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="form-group has-success col-md-4">
                                    <asp:Label ID="Label4" runat="server" Text="Land size in Acres:" class="control-label"></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="LandSizeTextBox" Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" SetFocusOnError="True" ValidationGroup="DetailsValidate"></asp:RequiredFieldValidator><asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="LandSizeTextBox" runat="server" class="form-control"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="form-group has-success col-md-4">
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="CreateOrderDetailsButton" runat="server" BackColor="#0099FF" class="form-control" ForeColor="Black" OnClientClick="return Validate('DetailsValidate');" Text="Add item" OnClick="CreateOrderDetailsButton_Click" /><asp:Label ID="DetailsLabel" runat="server" class="control-label"></asp:Label>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="CreateOrderDetailsButton" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="row">
                                    <div class="box col-md-12">
                                        <div class="box-inner">
                                            <div class="alert alert-info">Order details</div>
                                            <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="OrderDetailsGridView" runat="server" class="table table-striped table-bordered bootstrap-datatable datatable responsive" Font-Size="Small" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDataBound="OrderDetailsGridView_RowDataBound" ShowFooter="True" OnRowDeleting="OrderDetailsGridView_RowDeleting">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Remove detail" ShowHeader="False">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="RemoveRecordButton" runat="server" CausesValidation="False" OnClientClick="return confirm('Do you real want to remove?')" CommandName="Delete" Text="Remove" />
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:Button ID="SubmitButton" runat="server" BackColor="#0099FF" class="form-control" ForeColor="Black" Text="Submit your order" OnClick="SubmitButton_Click" OnClientClick="return confirm('Do you real want to submit?')" /><asp:Label ID="SubmitOrderLabel" runat="server" class="control-label"></asp:Label>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EditRowStyle BackColor="#2461BF" />
                                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="Black" />
                                                        <HeaderStyle Wrap="False" BackColor="#507CD1" Font-Bold="True" ForeColor="Black" />
                                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                        <RowStyle Wrap="False" BackColor="#EFF3FB" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>

                            </ContentTemplate>


                        </cc1:TabPanel>
                    </cc1:TabContainer>
                </div>
            </div>
        </div>

    </div>
</asp:Content>