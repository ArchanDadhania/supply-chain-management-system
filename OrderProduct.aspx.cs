using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OrderProduct : System.Web.UI.Page
{
    DatabaseLayer objDb = new DatabaseLayer();
    ValidationFunctions objValidation = new ValidationFunctions();
    DataTable dt;
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
            btnDelete.Enabled = false;

            //fill list
            objDb.FillDropDownList(DdlProduct, "select ProductID, ProductName from ProductMaster order by ProductName", "ProductName", "ProductID");

            objDb.FillDropDownList(DdlWarehouse, "select WarehouseID, WarehouseName from WarehouseMaster order by WarehouseName", "WarehouseName", "WarehouseID");




            if  (Request.QueryString.Count <=0)
            {
                dt = new DataTable();
                dt.Columns.Add("Sr. No.");
                dt.Columns.Add("Product");
                dt.Columns.Add("Warehouse");
                dt.Columns.Add("Quantity");
                dt.Columns.Add("Price");
                dt.Columns.Add(" ");

                DataRow r1;
                r1 = dt.NewRow();
                dt.Rows.Add(r1);

                ViewState["dt"] = dt;
                grv1.DataSource = dt;
                grv1.DataBind();
            }

            if (Request.QueryString.Count > 0 && Request.QueryString["mode"] == "delete")
            {

                dt = (DataTable)Session["dt"];
                Response.Write(dt.Rows.Count);
                dt.Rows[int.Parse(Request.QueryString["id"]) - 1].Delete();

                int i = 0;
                for (i = 0; i <= dt.Rows.Count - 1;i++ )
                {
                    dt.Rows[i][0] = i + 1;
                }
                if (dt.Rows.Count <= 0)
                {
                    DataRow r1;
                    r1 = dt.NewRow();
                    dt.Rows.Add(r1);
                }

                ViewState["dt"] = dt;
                grv1.DataSource = dt;
                grv1.DataBind();
            }

            if (Request.QueryString.Count > 0 && Request.QueryString["mode"]=="edit")
            {
                TxtOrderID.Text = Convert.ToString(Request.QueryString["id"]);

                dt = new DataTable();
                dt.Columns.Add("Sr. No.");
                dt.Columns.Add("Product");
                dt.Columns.Add("Warehouse");
                dt.Columns.Add("Quantity");
                dt.Columns.Add("Price");
                dt.Columns.Add(" ");

                btnDelete.Enabled = true;
                DataSet dsOrd = new DataSet();
                dsOrd = objDb.GetDataset("select * from ordermaster,orderdetails,ProductMaster,WarehouseMaster where WarehouseID =  OrderWarehouseID and OrderProductId=ProductID and  orderid=OrderMasterId and orderid=" + Convert.ToString(Request.QueryString["id"]) + "", "orders");
                if (dsOrd != null)
                {
                    if (dsOrd.Tables["orders"].Rows.Count > 0)
                    {
                        int i = 0;
                        for (i = 0; i <= dsOrd.Tables["orders"].Rows.Count - 1; i++)
                        {
                            DataRow r = dsOrd.Tables["orders"].Rows[i];

                            DataRow r1;
                            r1 = dt.NewRow();

                            r1[0] = i + 1;
                            r1[1] = Convert.ToString(r["ProductID"]) + "-" + Convert.ToString(r["ProductName"]);
                            r1[2] = Convert.ToString(r["WarehouseID"]) + "-" + Convert.ToString(r["WarehouseName"]);
                            r1[3] = Convert.ToString(r["OrderQty"]);
                            r1[4] = Convert.ToString(r["OrderPrice"]);
                            dt.Rows.Add(r1);
                        }

                    }
                }

                ViewState["dt"] = dt;
                grv1.DataSource = dt;
                grv1.DataBind();
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
            //string strReqType = "";
            //string strCode = "";
            //string strName = "";
            //if (TxtCode.Text.Length > 0)
            //{
            //    strCode = " and WarehouseID = " + TxtCode.Text + " ";
            //}
            //if (TxtName.Text.Length > 0)
            //{
            //    strName = " and WarehouseName like '" + TxtName.Text + "%' ";
            //}

            //string str = "Select WarehouseID as [Warehouse Code], WarehouseName as [Warehouse Name], WarehouseCity as [City], WarehouseAddress as [Address], WarehouseID as [ ] from WarehouseMaster where WarehouseStokistID = " + Convert.ToString(Session["UserID"]) + strCode + strName + " order by WarehouseID ";
            //DataSet dsGrid = new DataSet();
            //dsGrid = objDb.GetDataset(str, "griddata");
            //ViewState["griddata"] = dsGrid;
            //grv1.DataSource = dsGrid;
            //grv1.DataBind();
        }
        catch (Exception ex) { lblmsg.Text = "Error : " + ex.Message.ToString(); }
    }

    protected void BtnAddProduct_Click(object sender, EventArgs e)
    {
        //validation
        if (DdlProduct.Text == "-1")
        {
            lblmsg.Text = "Select product"; return;
        }
        if (DdlWarehouse.Text == "--1")
        {
            lblmsg.Text = "Select warehouse"; return;
        }
        if (TxtQuantity.Text.Trim().Length <=0)
        {
            lblmsg.Text = "Enter quantity"; return;
        }
        if (objValidation.IsNumeric( TxtQuantity.Text)==false )
        {
            lblmsg.Text = "Enter quantity"; return;
        }
        //add in datatable and re-bind grid
        dt =(DataTable) ViewState["dt"];
        if (dt.Rows.Count == 1)
        {
            if (Convert.ToString( dt.Rows[0][0]) == "")
            {
                dt.Rows[0].Delete();
            }
        }
        
        DataRow r1;
        r1 = dt.NewRow();
        r1[0] = dt.Rows.Count + 1;
        r1[1] = DdlProduct.Text + "-" + objDb.ExecuteScaler("select ProductName from productmaster where productid=" + DdlProduct.Text);
        r1[2] = DdlWarehouse.Text + "-" + objDb.ExecuteScaler("select WarehouseName from WarehouseMaster where WarehouseID=" + DdlWarehouse.Text);
        r1[3] = TxtQuantity.Text ;
        r1[4] = objDb.ExecuteScaler("select Price from productmaster where productid=" + DdlProduct.Text);
        dt.Rows.Add(r1);

        ViewState["dt"] = dt;
        Session["dt"] = dt;
        grv1.DataSource = dt;
        grv1.DataBind();

        dt = (DataTable)ViewState["dt"];
        //Response.Write(dt.Rows.Count);

    }
    protected void btnreset0_Click(object sender, EventArgs e)
    {


        //Validate
        if (Request.QueryString.Count > 0)
        {
            //check for product already used


            //delete
            string strqr = "delete from  orderdetails where OrderDetailId=" + Convert.ToString(Request.QueryString["id"]);
            string ret = objDb.ExecuteInsertUpdate(strqr);

            strqr = "delete from  ordermaster where OrderID=" + Convert.ToString(Request.QueryString["id"]);
            ret = objDb.ExecuteInsertUpdate(strqr);

            if (ret == "" || ret == null || ret == "0")
            {
                lblmsg.Text = "Error : " + objDb.returnMsg; return;
            }
            this.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script language=\"javaScript\">" + "alert('Order deleted!');" + "window.location.href='ViewOrder.aspx';" + "<" + "/script>");


        }

    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        //validation
        if (DdlProduct.Text == "-1")
        {
            lblmsg.Text = "Select product"; return;
        }
        if (DdlWarehouse.Text == "--1")
        {
            lblmsg.Text = "Select warehouse"; return;
        }


        dt = (DataTable)ViewState["dt"];
        if (dt.Rows.Count <= 0)
        {
            lblmsg.Text = "No product details to save"; return;
        }

        if (Convert.ToString(dt.Rows[0][0])=="&nbsp;" || Convert.ToString(dt.Rows[0][0])=="" )
        {
            lblmsg.Text = "No product details to save"; return;
        }
        string strqr = "";
        string ret = "";
        string ordermasterid = "0";
        if (TxtOrderID.Text == "")
        {
            //save in order master

             ordermasterid= objDb.ExecuteScaler("select isnull(max(OrderID),0)+1 from ordermaster");

            strqr = "insert into ordermaster values(" + ordermasterid + ",getdate()," + Convert.ToString(Session["UserID"]) + ")";
            ret = objDb.ExecuteInsertUpdate(strqr);

        }
        else
        {
            ordermasterid = TxtOrderID.Text;
        }

        strqr = "delete from OrderDetails where OrderMasterId=" + ordermasterid ;
        ret = objDb.ExecuteInsertUpdate(strqr);


        int i = 0;
        for (i = 0; i <= dt.Rows.Count - 1; i++)
        {
            string temp1 = Convert.ToString(dt.Rows[i][1]);
            int p = temp1.IndexOf("-");
            string prodid = temp1.Substring(0, p);

            temp1 = Convert.ToString(dt.Rows[i][2]);
            p = temp1.IndexOf("-");
            string warehouseid = temp1.Substring(0, p);

            string orderdetailsid = objDb.ExecuteScaler("select isnull(max(OrderDetailId),0)+1 from OrderDetails");

            strqr = "insert into OrderDetails values(" + orderdetailsid + "," + ordermasterid + "," + prodid + "," + dt.Rows[i][3] + "," + dt.Rows[i][4] + "," + warehouseid + ",'Pending','Pending')";
            string ret1 = objDb.ExecuteInsertUpdate(strqr);

        }

        this.ClientScript.RegisterStartupScript(this.GetType(), "Alert", "<script language=\"javaScript\">" + "alert('Order saved successfully!');" + "window.location.href='ViewOrder.aspx';" + "<" + "/script>");

    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx");
    }
    protected void grv1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex >= 0)
        {
            if (Convert.ToString(e.Row.Cells[0].Text) != "&nbsp;")
            {
                ViewState["dt"] = dt;
                string s1 = "";
                s1 = "<a href='OrderProduct.aspx?mode=delete&id=" + e.Row.Cells[0].Text + "'>Delete Product</a>";
                e.Row.Cells[5].Text = s1;
            }
        }
    }
    protected void grv1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void DdlProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        //get product details
        if (DdlProduct.Text != "-1")
        {
            string str = "Select * from productmaster,ProductCategory,UserMaster where ProductCatId=CatID and ProductCompanyID=UserID and ProductID=" + DdlProduct.Text;
            DataSet dsP = new DataSet();
            dsP = objDb.GetDataset(str, "productmaster");
            if (dsP.Tables["productmaster"].Rows.Count > 0)
            {
                DataRow r;
                r = dsP.Tables["productmaster"].Rows[0];
                sp_product.InnerHtml = "Product Id : " + Convert.ToString(r["ProductID"]) + "</br>Product Category : " + Convert.ToString(r["CatName"]) + "</br>Company : " + Convert.ToString(r["DisplayName"]) + "</br>Price : " + Convert.ToString(r["price"]);
            }

        }
        else
        {
            sp_product.InnerHtml = "";
        }
    }
    protected void DdlWarehouse_SelectedIndexChanged(object sender, EventArgs e)
    {
        //get Warehouse details
        if (DdlWarehouse.Text != "-1")
        {
            string str = "Select * from WarehouseMaster,UserMaster where WarehouseStokistID=UserID and WarehouseID=" + DdlWarehouse.Text;
            DataSet dsW = new DataSet();
            dsW = objDb.GetDataset(str, "WarehouseMaster");
            if (dsW.Tables["WarehouseMaster"].Rows.Count > 0)
            {
                DataRow r;
                r = dsW.Tables["WarehouseMaster"].Rows[0];
                sp_warehouse.InnerHtml = "Warehouse Id : " + Convert.ToString(r["WarehouseID"]) + "</br>City : " + Convert.ToString(r["WarehouseCity"]) + "</br>Address : " + Convert.ToString(r["WarehouseAddress"]) ;
            }

        }
        else
        {
            sp_warehouse.InnerHtml = "";
        }
    }
}
