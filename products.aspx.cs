using agrostorefrontend.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace agrostorefrontend.ui
{
    public partial class products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                try
                {
                    APICall Api = new APICall();
                    DataTable dataFertilizers = new DataTable();
                    dataFertilizers = Api.ListSettings("ListAllFertilizers");
                    FertilizerGridView.DataSource = dataFertilizers;
                    FertilizerGridView.DataBind();

                    DataTable dataSeeds = new DataTable();
                    dataSeeds = Api.ListSettings("ListAllSeeds");
                    SeedGridView.DataSource = dataSeeds;
                    SeedGridView.DataBind();

                    FertilizerDropDownList.DataSource = dataFertilizers;
                    FertilizerDropDownList.DataValueField = "" + dataFertilizers.Columns[0].ToString() + "";
                    FertilizerDropDownList.DataTextField = "" + dataFertilizers.Columns[1].ToString() + "";
                    FertilizerDropDownList.DataBind();
                    FertilizerDropDownList.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "Select"));
                    TabContainerProduct.ActiveTabIndex = 0;
                    
                }
                catch(Exception)
                {

                }
            }
        }

        protected void CreateFertilizerButton_Click(object sender, EventArgs e)
        {
            APICall Api = new APICall();
            APICall.FertilizerRequest request = new APICall.FertilizerRequest();
            APICall.DbResponse response = new APICall.DbResponse();
            DataTable dataFertilizers = new DataTable();
            request.Name = FertilizerTextBox.Text;
            request.QuantityLimit = float.Parse(MaxQuantityTextBox.Text.Replace(".", ","));
            request.UnitPrice = float.Parse(PriceTextBox.Text.Replace(".", ","));
            response = Api.CreateFertilizer("CreateFertilizer", request);
            FertilizerLabel.Text = response.Message;
            if (response.Message != "SUCCESS")
            {
                FertilizerLabel.ForeColor = System.Drawing.Color.Red;
            }
            if (response.Message == "SUCCESS")
            {
                FertilizerLabel.ForeColor = System.Drawing.Color.Green;
            }
            dataFertilizers = Api.ListSettings("ListAllFertilizers");
            FertilizerGridView.DataSource = dataFertilizers;
            FertilizerGridView.DataBind();
        }

        protected void FertilizerGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            APICall Api = new APICall();
            DataTable dataFertilizers = new DataTable();
            dataFertilizers = Api.ListSettings("ListAllFertilizers");
            FertilizerGridView.DataSource = dataFertilizers;
            FertilizerGridView.PageIndex = e.NewPageIndex;
            FertilizerGridView.DataBind();
        }

        protected void CreateSeedButton_Click(object sender, EventArgs e)
        {
            APICall Api = new APICall();
            APICall.SeedRequest request = new APICall.SeedRequest();
            APICall.DbResponse response = new APICall.DbResponse();
            DataTable dataSeeds = new DataTable();
            request.Name = SeedNameTextBox.Text;
            request.QuantityLimit = float.Parse(SeedMaxQtyTextBox.Text.Replace(".", ","));
            request.FertilizerCode = FertilizerDropDownList.SelectedItem.Value.ToString();
            request.UnitPrice = float.Parse(SeedUnitPriceTextBox.Text.Replace(".", ","));
            response = Api.CreateSeed("CreateSeed", request);
            SeedLabel.Text = response.Message;
            if (response.Message != "SUCCESS")
            {
                SeedLabel.ForeColor = System.Drawing.Color.Red;
            }
            if (response.Message == "SUCCESS")
            {
                SeedLabel.ForeColor = System.Drawing.Color.Green;
            }
            dataSeeds = Api.ListSettings("ListAllSeeds");
            SeedGridView.DataSource = dataSeeds;
            SeedGridView.DataBind();
        }

        protected void SeedGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            APICall Api = new APICall();
            DataTable dataSeeds = new DataTable();
            dataSeeds = Api.ListSettings("ListAllSeeds");
            SeedGridView.DataSource = dataSeeds;
            SeedGridView.PageIndex = e.NewPageIndex;
            SeedGridView.DataBind();
        }

        protected void TabContainerProduct_ActiveTabChanged(object sender, EventArgs e)
        {
            if(TabContainerProduct.ActiveTabIndex==1)
            {
                APICall Api = new APICall();
                DataTable dataFertilizers = new DataTable();
                dataFertilizers = Api.ListSettings("ListAllFertilizers");
                FertilizerDropDownList.DataSource = dataFertilizers;
                FertilizerDropDownList.DataValueField = "" + dataFertilizers.Columns[0].ToString() + "";
                FertilizerDropDownList.DataTextField = "" + dataFertilizers.Columns[1].ToString() + "";
                FertilizerDropDownList.DataBind();
                FertilizerDropDownList.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "Select"));
            }
        }
    }
}