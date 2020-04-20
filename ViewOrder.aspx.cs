using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewOrder : System.Web.UI.Page
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

            string str = "Select OrderID as [Order ID], OrderDate as [Order Date], OrderID  as [Quantity], OrderID  as [Price], OrderID  as [ ] from orderMaster where OrderDistributorID = " + Convert.ToString(Session["UserID"]) + " order by OrderID ";
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
        Response.Redirect("OrderProduct.aspx");
    }

    protected void grv1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex >= 0)
        {
            string s1 = "";

            s1 = "select sum(OrderQty), sum(OrderQty*OrderPrice) from OrderDetails where OrderMasterId =" + e.Row.Cells[0].Text;
            DataSet ds = new DataSet();
            ds = objDb.GetDataset(s1, "data");
            e.Row.Cells[2].Text = Convert.ToString(ds.Tables["data"].Rows[0][0]);
            e.Row.Cells[3].Text = Convert.ToString(ds.Tables["data"].Rows[0][1]);

            s1 = "<a href='OrderProduct.aspx?mode=edit&id=" + e.Row.Cells[0].Text + "'>Edit/View Order</a>";
            e.Row.Cells[4].Text = s1;
        }
    }

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        DisplayGrid();
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrderProduct.aspx");
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
