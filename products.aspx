<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="agrostorefrontend.ui.products"  MasterPageFile="~/Admin.Master"%>
<%@ MasterType VirtualPath="~/Admin.Master" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="col-lg-10 col-sm-10">

        <div class="row">
            <div class="box col-md-12">
                <div class="box-inner">
                    <div class="alert alert-info">Products</div>
                    <cc1:TabContainer ID="TabContainerProduct" runat="server" ScrollBars="Auto" ActiveTabIndex="0"  AutoPostBack="True" OnActiveTabChanged="TabContainerProduct_ActiveTabChanged">
                        <cc1:TabPanel runat="server" HeaderText="Fertilizers" TabIndex="0" ID="TabPanel1">
                            <ContentTemplate>
                                <div class="form-group has-success col-md-4">
                                    <asp:Label ID="Label2" runat="server" Text="Fertilizer name :" class="control-label"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FertilizerTextBox" Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" SetFocusOnError="True" ValidationGroup="MemberValidate"></asp:RequiredFieldValidator>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="FertilizerTextBox" runat="server" class="form-control"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="form-group has-success col-md-4">
                                    <asp:Label ID="Label1" runat="server" Text="Max quantity in KG per acre :" class="control-label"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="MaxQuantityTextBox" Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" SetFocusOnError="True" ValidationGroup="MemberValidate"></asp:RequiredFieldValidator>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="MaxQuantityTextBox" runat="server" class="form-control"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="form-group has-success col-md-4">
                                    <asp:Label ID="Label3" runat="server" Text="Unit price :" class="control-label"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="PriceTextBox" Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" SetFocusOnError="True" ValidationGroup="MemberValidate"></asp:RequiredFieldValidator>
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="PriceTextBox" runat="server" class="form-control" TextMode="Number"></asp:TextBox>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="form-group has-success col-md-4">
                                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                        <ContentTemplate>

                                            <asp:Button ID="CreateFertilizerButton" runat="server" BackColor="#0099FF" class="form-control" ForeColor="Black" OnClientClick="return Validate('MemberValidate');" Text="Submit" OnClick="CreateFertilizerButton_Click" />
                                            <asp:Label ID="FertilizerLabel" runat="server" class="control-label"></asp:Label>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="CreateFertilizerButton" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="row">
                                    <div class="box col-md-12">
                                        <div class="box-inner">
                                            <div class="alert alert-info">List of fertilizers</div>
                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                <ContentTemplate>
                                                    <asp:GridView ID="FertilizerGridView" runat="server" class="table table-striped table-bordered bootstrap-datatable datatable responsive" Font-Size="Small" CellPadding="4" ForeColor="Black" GridLines="None" AllowPaging="True" PageSize="5" OnPageIndexChanging="FertilizerGridView_PageIndexChanging">
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

                            
</ContentTemplate>

                        
</cc1:TabPanel>
                        <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Seeds" TabIndex="0">
                            <ContentTemplate>
                                <div class="form-group has-success col-md-4">
                                    <asp:Label ID="Label4" runat="server" Text="Seed name :" class="control-label"></asp:Label>


                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="SeedNameTextBox" Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" SetFocusOnError="True" ValidationGroup="SeedValidate"></asp:RequiredFieldValidator>


                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server"><ContentTemplate>
                                            <asp:TextBox ID="SeedNameTextBox" runat="server" class="form-control"></asp:TextBox>

                                        
</ContentTemplate>
</asp:UpdatePanel>


                                </div>
                                <div class="form-group has-success col-md-4">
                                    <asp:Label ID="Label5" runat="server" Text="Max quantity in KG per acre :" class="control-label"></asp:Label>


                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="SeedMaxQtyTextBox" Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" SetFocusOnError="True" ValidationGroup="SeedValidate"></asp:RequiredFieldValidator>


                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server"><ContentTemplate>
                                            <asp:TextBox ID="SeedMaxQtyTextBox" runat="server" class="form-control"></asp:TextBox>

                                        
</ContentTemplate>
</asp:UpdatePanel>


                                </div>
                                <div class="form-group has-success col-md-4">
                                    <asp:Label ID="Label6" runat="server" Text="Unit price :" class="control-label"></asp:Label>


                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="SeedUnitPriceTextBox" Display="Dynamic" ErrorMessage="*" ForeColor="#CC3300" SetFocusOnError="True" ValidationGroup="SeedValidate"></asp:RequiredFieldValidator>


                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server"><ContentTemplate>
                                            <asp:TextBox ID="SeedUnitPriceTextBox" runat="server" class="form-control" TextMode="Number"></asp:TextBox>

                                        
</ContentTemplate>
</asp:UpdatePanel>


                                </div>
                                <div class="form-group has-success col-md-4">
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server"><ContentTemplate>
                                            <asp:Label ID="Label7" runat="server" Text="Fertilizer type:" class="control-label">
                                            </asp:Label><asp:DropDownList ID="FertilizerDropDownList" runat="server" class="form-control">
                                            </asp:DropDownList>


                                        
</ContentTemplate>
</asp:UpdatePanel>



                                </div>
                                <div class="clearfix"></div>
                                <div class="form-group has-success col-md-4">
                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server"><ContentTemplate>

                                            <asp:Button ID="CreateSeedButton" runat="server" BackColor="#0099FF" class="form-control" ForeColor="Black" OnClientClick="return Validate('SeedValidate');" Text="Submit" OnClick="CreateSeedButton_Click" />
                                            <asp:Label ID="SeedLabel" runat="server" class="control-label"></asp:Label>

                                        
</ContentTemplate>
<Triggers>
<asp:PostBackTrigger ControlID="CreateSeedButton" />
</Triggers>
</asp:UpdatePanel>


                                </div>
                                <div class="row">
                                    <div class="box col-md-12">
                                        <div class="box-inner">
                                            <div class="alert alert-info">List of seeds</div>
                                            <asp:UpdatePanel ID="UpdatePanel9" runat="server"><ContentTemplate>
                                                    <asp:GridView ID="SeedGridView" runat="server" class="table table-striped table-bordered bootstrap-datatable datatable responsive" Font-Size="Small" CellPadding="4" ForeColor="Black" GridLines="None" AllowPaging="True" PageSize="5" OnPageIndexChanging="SeedGridView_PageIndexChanging">
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

                            
</ContentTemplate>

                        
</cc1:TabPanel>
                    </cc1:TabContainer>
                </div>
            </div>
        </div>

    </div>
</asp:Content>