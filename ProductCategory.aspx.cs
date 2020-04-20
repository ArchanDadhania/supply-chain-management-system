using System;
using System.Data ;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductCategory : System.Web.UI.Page
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
                strCode = " and CatID = " + TxtCode.Text + " ";
            }
            if (TxtName.Text.Length > 0)
            {
                strName = " and CatName like '" + TxtName.Text + "%' ";
            }



            string str = "Select CatID as [Category Code], CatName as [Product Category], CatActive as [Active Category], CatID as [ ] from productcategory where CatCompanyID = " + Convert.ToString(Session["UserID"]) + strCode + strName + " order by CatID ";
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
        Response.Redirect("productcategory.aspx");
    }

    protected void grv1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex >= 0)
        {
            string s1 = "";
            s1 = "<a href=ProductCategoryViewEdit.aspx?id=" + e.Row.Cells[0].Text + ">Edit</a>";
            e.Row.Cells[3].Text = s1;
        }
    }

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        DisplayGrid();
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        Response.Redirect  ("ProductCategoryViewEdit.aspx");
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
