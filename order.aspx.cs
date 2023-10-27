using agrostorefrontend.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace agrostorefrontend.WebForms
{
    public partial class order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                TabContainerOrder.ActiveTabIndex = 0;
                TabPanel2.Enabled = false;
                ItemsDropDownList.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "Select"));
                CreateOrderDetailsButton.Enabled = false;
                //Panel1.Visible = false;
            }
        }

        protected void ProductDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            APICall Api = new APICall();
            DataTable dataProduct = new DataTable();
           
            if (ProductDownList.SelectedIndex == 1)
            {
                dataProduct = Api.ListSettings("ListAllFertilizers");
                ItemsDropDownList.DataSource = dataProduct;
                ItemsDropDownList.DataValueField = "" + dataProduct.Columns[0].ToString() + "";
                ItemsDropDownList.DataTextField = "" + dataProduct.Columns[1].ToString() + "";
                ItemsDropDownList.DataBind();
                ItemsDropDownList.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "Select"));
            }
            else if (ProductDownList.SelectedIndex == 2)
            {

                dataProduct = Api.ListSettings("ListAllSeeds");
                ItemsDropDownList.DataSource = dataProduct;
                ItemsDropDownList.DataValueField = "" + dataProduct.Columns[0].ToString() + "";
                ItemsDropDownList.DataTextField = "" + dataProduct.Columns[1].ToString() + "";
                ItemsDropDownList.DataBind();
                ItemsDropDownList.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "Select"));
            }
            else

            {
                ItemsDropDownList.ClearSelection();
            }
        }

        protected void CreateOrderButton_Click(object sender, EventArgs e)
        {
            APICall Api = new APICall();
            DataTable dataOrder = new DataTable();
           
            APICall.OrderRequest order = new APICall.OrderRequest();
            APICall.DbResponse response = new APICall.DbResponse();
            order.FarmerName = FarmerNameTextBox.Text.ToUpper();
            order.FarmerPhone = FarmerPhoneTextBox.Text;
            response = Api.CreateOrder("CreateOrder", order);
            if (response.Code == "200")
            {
                TabContainerOrder.ActiveTabIndex = 1;
                DetailsLabel.Text = string.Empty;
                TabPanel2.Enabled = true;
               

                OrderDetailsGridView.DataSource = null;
                OrderDetailsGridView.DataBind();
                OrderGridView.SelectedIndex = -1;
                dataOrder = Api.ListSettings("GetOrder?PhoneNumber=" + FarmerPhoneTextBox.Text);
                OrderGridView.DataSource = dataOrder;
                OrderGridView.DataBind();
            }
            else
            {
                OrderLabel.ForeColor = System.Drawing.Color.Red;
                OrderLabel.Text = response.Message;
            }
        }

        protected void TabContainerOrder_ActiveTabChanged(object sender, EventArgs e)
        {
           
        }

        protected void OrderGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            APICall Api = new APICall();
            //Panel1.Enabled = false;
            DataTable dataOrderDetails = new DataTable();
            CreateOrderDetailsButton.Enabled = true;
            DetailsLabel.Text = string.Empty;
            dataOrderDetails = Api.ListSettings("GetOrderDetails?orderCode=" +OrderGridView.SelectedRow.Cells[2].Text);
            OrderDetailsGridView.DataSource = dataOrderDetails;
            OrderDetailsGridView.DataBind();
            
        }

        protected void CreateOrderDetailsButton_Click(object sender, EventArgs e)
        {
            double Total = 0;
            APICall Api = new APICall();
            APICall.OrderDetailsRequest details = new APICall.OrderDetailsRequest();
            APICall.DbResponse response = new APICall.DbResponse();
            DataTable dataOrderDetails = new DataTable();
            try
            {
                details.OrderCode = OrderGridView.SelectedRow.Cells[2].Text;
                details.ItemType = ProductDownList.SelectedItem.Text;
                details.CodeItem = ItemsDropDownList.SelectedItem.Value.ToString();
                details.LandSize = float.Parse(LandSizeTextBox.Text.Replace(".", ","));
                response = Api.CreateOrderDetails("CreateOrderDetails", details);
                dataOrderDetails = Api.ListSettings("GetOrderDetails?orderCode=" + OrderGridView.SelectedRow.Cells[2].Text);
                OrderDetailsGridView.DataSource = dataOrderDetails;
                OrderDetailsGridView.DataBind();
                if (response.Message != "SUCCESS")
                {
                    DetailsLabel.ForeColor = System.Drawing.Color.Red;
                }
                if (response.Message == "SUCCESS")
                {
                    DetailsLabel.ForeColor = System.Drawing.Color.Green;
                }
                foreach (GridViewRow row1 in OrderDetailsGridView.Rows)
                {

                    Total = Total + double.Parse(row1.Cells[8].Text);
                }

                OrderDetailsGridView.FooterRow.Cells[8].Text = Total.ToString("#,#");
            }
            catch(Exception)
            {
                LandSizeTextBox.Text = string.Empty;
            }
            finally
            {

            }

            DetailsLabel.Text = response.Message;
           
           

        }

        protected void OrderDetailsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }

        

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            APICall Api = new APICall();
            APICall.updateOrderRequest updatereq = new APICall.updateOrderRequest();
            APICall.DbResponse response = new APICall.DbResponse();
            updatereq.status = "SUBMITED";
            updatereq.OrderCode = OrderGridView.SelectedRow.Cells[2].Text;
            response = Api.Update_Order_Status("Update_Order_Status", updatereq);
            DataTable dataOrder = new DataTable();
            dataOrder = Api.ListSettings("GetOrder?PhoneNumber=" + FarmerPhoneTextBox.Text);
            OrderGridView.DataSource = dataOrder;
            OrderGridView.DataBind();
            OrderDetailsGridView.DataSource = null;
            OrderDetailsGridView.DataBind();
            LandSizeTextBox.Text = string.Empty;
            DetailsLabel.Text = string.Empty;
            CreateOrderDetailsButton.Enabled = false;
        }

        protected void OrderDetailsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            APICall Api = new APICall();
            APICall.DeleteOrderDetailRequest details = new APICall.DeleteOrderDetailRequest();
            APICall.DbResponse response = new APICall.DbResponse();
            details.Idrecord = int.Parse(OrderDetailsGridView.Rows[e.RowIndex].Cells[1].Text);
            details.OrderCode = OrderGridView.SelectedRow.Cells[2].Text;
            response = Api.Delete_OrderDetail("Delete_OrderDetail", details);
            DataTable dataOrderDetails = new DataTable();
            dataOrderDetails = Api.ListSettings("GetOrderDetails?orderCode=" + OrderGridView.SelectedRow.Cells[2].Text);
            OrderDetailsGridView.DataSource = dataOrderDetails;
            OrderDetailsGridView.DataBind();
        }

        protected void OrderGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            OrderGridView.SelectedIndex = -1;
            APICall Api = new APICall();
            DataTable dataOrder = new DataTable();
            dataOrder = Api.ListSettings("GetOrder?PhoneNumber=" + FarmerPhoneTextBox.Text);
            OrderGridView.DataSource = dataOrder;
            OrderGridView.PageIndex = e.NewPageIndex;
            OrderGridView.DataBind();
        }

        protected void OrderGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            APICall Api = new APICall();
            APICall.DeleteOrderDetailRequest details = new APICall.DeleteOrderDetailRequest();
            APICall.DbResponse response = new APICall.DbResponse();
            details.OrderCode = OrderGridView.Rows[e.RowIndex].Cells[2].Text;
            response = Api.DiscardOrder("DiscardOrder", details);
            DataTable dataOrder = new DataTable();
            dataOrder = Api.ListSettings("GetOrder?PhoneNumber=" + FarmerPhoneTextBox.Text);
            OrderGridView.DataSource = dataOrder;
            OrderGridView.DataBind();
        }
    }
}