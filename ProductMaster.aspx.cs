using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductMaster : System.Web.UI.Page
{
    DatabaseLayer objDb = new DatabaseLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        //
        try
        {
            if (Session["EmailID"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (IsPostBack == true)
            {
                return;
            }
            TxtCode.Text = "";
            TxtName.Text = "";

            DisplayGrid();
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Error : " + ex.Message.ToString();
        }
    }

    public void DisplayGrid()
    {
        try
        {
            string strReqType = "";
            string strCode = "";
            string strName = "";
            if (TxtCode.Text.Length > 0)
            {
                strCode = " and ProductID = " + TxtCode.Text + " ";
            }
            if (TxtName.Text.Length > 0)
            {
                strName = " and ProductName like '" + TxtName.Text + "%' ";
            }



            string str = "Select ProductID as [Product Code], ProductName as [Product Name], CatName as [Product Category], Price, ProductID as [ ] from ProductMaster, ProductCategory where ProductCatId = catID and ProductCompanyID = " + Convert.ToString(Session["UserID"]) + strCode + strName + " order by ProductID ";
            DataSet dsGrid = new DataSet();
            dsGrid = objDb.GetDataset(str, "griddata");
            ViewState["griddata"] = dsGrid;
            grv1.DataSource = dsGrid;
            grv1.DataBind();
        }
        catch (Exception ex) { lblmsg.Text = "Error : " + ex.Message.ToString(); }
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("productmaster.aspx");
    }

    protected void grv1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex >= 0)
        {
            string s1 = "";
            s1 = "<a href=ProductMasterViewEdit.aspx?id=" + e.Row.Cells[0].Text + ">Edit</a>";
            e.Row.Cells[4].Text = s1;
        }
    }

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        DisplayGrid();
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProductMasterViewEdit.aspx");
    }
    protected void grv1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataSet dsGrid = new DataSet();

        dsGrid = (DataSet)ViewState["griddata"];
        grv1.DataSource = dsGrid;
        grv1.DataBind();
        grv1.PageIndex = e.NewPageIndex;
    }
}
