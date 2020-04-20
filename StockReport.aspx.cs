using System;
using System.Data ;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StockReport : System.Web.UI.Page
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
            
            TxtProductCode.Text = "";

            DisplayGrid();
           
        }
        catch (Exception ex)
        {
            //lblmsg.Text = "Error : " + ex.Message.ToString();
        }
    }

    public void DisplayGrid()
    {
        try
        {
            string strReqType = "";
            string strCode = "";
            string strName = "";

            if (TxtProductCode.Text.Length > 0)
            {
                strName = " and productid  =" + TxtProductCode.Text + " ";
            }



            string str = "" +
                "select productid as [Prodcut ID], productname as [Product Name], DisplayName as [Product Company], " +
                "(select isnull(sum(OrderQty),0)  from OrderDetails where OrderProductId=productid ) as [Order Quantity], " +
                " (select isnull(sum(OrderQty),0)  from OrderDetails where OrderProductId=productid and OrderStatus='InStock') as [Receive Quantity], " +
                " (select isnull(sum(IssueQuantity),0)  from IssueStock where IssueProductID=productid) as [Issue Quantity], productid as [Available Quantity]" +
                " from productmaster,usermaster where UserID=ProductCompanyID " + strName ;
                
                ;
            DataSet dsGrid = new DataSet();
            dsGrid = objDb.GetDataset(str, "griddata");
            ViewState["griddata"] = dsGrid;
            grv1.DataSource = dsGrid;
            grv1.DataBind();

            lblmsg1.Text = dsGrid.Tables["griddata"].Rows.Count.ToString() + " Records found";
        }
        catch (Exception ex)
        { //lblmsg.Text = "Error : " + ex.Message.ToString(); 
        }
    }

   
    protected void btnreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Warehousemaster.aspx");
    }

    protected void grv1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex >= 0)
        {
            

            e.Row.Cells[6].Text =Convert.ToString( int.Parse(e.Row.Cells[4].Text) - int.Parse(e.Row.Cells[5].Text));
        }
    }

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        DisplayGrid();
         
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
