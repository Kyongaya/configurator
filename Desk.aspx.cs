using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Net.Mail;
using System.Net.Mime;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.Script.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public partial class configurator2_Desk : System.Web.UI.Page
{
    // Configurator Type 2 is for medical cart
    int ConfiguratorTypeId = 2;
    // Add Dictionary for for selected items 
    Dictionary<string, int> ProductGroups = new Dictionary<string, int>();
    string internalWeb = AFCconfiguration.InternalSiteName;
    string value1 = "";
    bool IsMedicalCart = true;
    string PoleCartPath = @"~\configurator\medicalcart\";
    string PdfPath = "~/PDF-configurator/";
    //  public string strConn;
    private static readonly string strConn = ConfigurationManager.ConnectionStrings["AFC"].ConnectionString;
    SqlConnection conn = new SqlConnection(strConn);
    SqlCommand cmd = new SqlCommand();
    string address = AFCconfiguration.SiteName;
    // string imgSmall = "imgSmall/";
    string imgSmall = "imgSmall/";
    string imgMedium = "imgMedium/";
    string imgURL = String.Empty;
    string strimgDeskLeg = String.Empty;
    int intColorOption = 0;
    string strTableShapeChoice = String.Empty;
    DataTable dt = new DataTable();
    DataTable dtt = new DataTable();
    productParts pr = new productParts();
   
    //  productPartsDB sdb = new productPartsDB();
    configDB sdb = new configDB();
    string courseNumber1 = "";
    string courseName1 = "";
    DataTable Cart;
    DataView CartView;
    List<conMain> imgList;
    int intNum = 0;
    int intSelect = 0;
    //string address = AFCconfiguration.SiteName;
    string strSelect = String.Empty;
    private bool isEditMode = false;
    protected bool IsEditMode
    {
        get { return isEditMode; }
        set { this.isEditMode = value; }
    }
    public string gridRowCount = string.Empty;
    int intAdd1 = 1;
    int selectBase = 0;
    string imgCall = String.Empty;
    int check = 0;
    int shelfView = 0;
    DataTable d3 = new DataTable();
    int intDeskType = 0;
    int intIdOptionCategory = 0;
    int intDeskGroup = 0;
    DataTable dt2 = new DataTable();
   
    int intDeskType1 = 0;
    int intSubCategory = 0;
    string strMaterial = String.Empty;

    private void HideSelection()
    {       
        deskbutton();
     
       // changeCabinetFrameColor();
        changeKeyboardColor();
      //  changeTopShelfMoldingColor();

        changeDeskFooterBottomMoldingColor();

    }


    //private void changeDeskMoldingColor()
    //{
    //    if (rdoDeskColor.SelectedIndex != -1)
    //    {
    //        //if (rdoDeskTopCabinetType.SelectedIndex != -1)
    //        //{

    //        int intIdOption = 0;
    //        int intIdOptionCategory = 10;
    //        int intIdBaseColor = 0;


    //        if ((rdoMoldingColor.SelectedIndex != -1) && (rdoDeskColor.SelectedIndex != -1))
    //        {

    //            //int intIdOption = 0;
    //            //int intIdOptionCategory = 17;
    //            //int intIdBaseColor = 0;
    //            //int intColorGroup = 0;

    //            if (ViewState["selectMoldingColor"] != null)
    //            {
    //                int intKeyboard = Convert.ToInt32(rdoDeskColor.SelectedValue);
    //                if (intKeyboard == 1 || intKeyboard == 2 || intKeyboard == 3)
    //                {
    //                   imgMoldingColor.Visible = false;

    //                }
    //                else
    //                {
    //                    intIdBaseColor = Convert.ToInt32(ViewState["selectMoldingColor"]);
    //                    intColorGroup = Convert.ToInt32(ViewState["keyboardSelect"]);
    //                    //  lblDeskCaster.Text = "what is  ViewState[deskmetal] option " + intIdBaseColor.ToString();
    //                    DataTable dt = sdb.getOptionColorMatchGroup(intIdBaseColor, intIdOptionCategory, intColorGroup);
    //                    // DataTable dt = sdb.getOptionColorMatchSelect(intIdBaseColor, intIdOptionCategory, 1);
    //                    if (dt.Rows.Count > 0)
    //                    {
    //                        foreach (DataRow dr in dt.Rows)
    //                        {
    //                            intIdOption = Convert.ToInt32(dr["idOption"]);
    //                            // intIdOptionGroup = Convert.ToInt32(dr["Expr1"]);
    //                            //  ViewState["test"] = intIdOptionGroup.ToString();
    //                            imgURL = dr["imgURLPng"].ToString();
    //                            imgMoldingColor.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
    //                            imgMoldingColor.Visible = true;

    //                        }
    //                    }
    //                }
    //            }
    //            else
    //            {
    //                imgMoldingColor.Visible = false;

    //            }
    //        }
    //        else
    //        {
    //            imgMoldingColor.Visible = false;

    //        }
    //    }

    //}

    private void changeCabinetFrameColor()
    {
        //if ((rdoDeskColor.SelectedIndex != -1) && (rdoDeskLeg.SelectedIndex != -1) && (rdoMoldingColor.SelectedIndex != -1) && (rdoCabinet.SelectedIndex != -1) && (rdoCaster.SelectedIndex != -1))
        if (rdoCabinet.SelectedIndex != -1)
        {
            //if (rdoDeskTopCabinetType.SelectedIndex != -1)
            //{

            int intIdOption = 0;
            int intIdOptionCategory = 10;
            int intIdBaseColor = 0;


            if (ViewState["DeskLegSelect"] != null)
            {
                int intImageCabinet = Convert.ToInt32(rdoCabinet.SelectedValue);
                if (intImageCabinet == 1)
                {
                    imgDeskCabinetFrameColor.Visible = false;

                }
              
                else
                {
                    intIdBaseColor = Convert.ToInt32(ViewState["DeskLegSelect"]);
                    //  lblDeskCaster.Text = "what is  ViewState[deskmetal] option " + intIdBaseColor.ToString();
                    DataTable dt = sdb.getOptionColorMatch(intIdBaseColor, intIdOptionCategory);
                    // DataTable dt = sdb.getOptionColorMatchSelect(intIdBaseColor, intIdOptionCategory, 1);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            intIdOption = Convert.ToInt32(dr["idOption"]);
                            // intIdOptionGroup = Convert.ToInt32(dr["Expr1"]);
                            //  ViewState["test"] = intIdOptionGroup.ToString();
                            imgURL = dr["imgURLPng"].ToString();
                            imgDeskCabinetFrameColor.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
                            imgDeskCabinetFrameColor.Visible = true;

                        }
                    }
                }
            }
            else
            { imgDeskCabinetFrameColor.Visible = false; }
        }


    }
    private void changeKeyboardColor()
    {
        if ((rdoMoldingColor.SelectedIndex != -1) && (rdoKeyboard.SelectedIndex != -1))
        {

            int intIdOption = 0;
            int intIdOptionCategory = 17;
            int intIdBaseColor = 0;
            int intColorGroup = 0;

            if (ViewState["selectMoldingColor"] != null)
            {
                int intKeyboard = Convert.ToInt32(rdoKeyboard.SelectedValue);
                if (intKeyboard == 1 || intKeyboard == 2 || intKeyboard == 3)
                {
                    imgKeyboardMolding.Visible = false;

                }
                else
                {
                    intIdBaseColor = Convert.ToInt32(ViewState["selectMoldingColor"]);
                    intColorGroup = Convert.ToInt32(ViewState["keyboardSelect"]);
                    //  lblDeskCaster.Text = "what is  ViewState[deskmetal] option " + intIdBaseColor.ToString();
                    DataTable dt = sdb.getOptionColorMatchGroup(intIdBaseColor, intIdOptionCategory, intColorGroup);
                    // DataTable dt = sdb.getOptionColorMatchSelect(intIdBaseColor, intIdOptionCategory, 1);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            intIdOption = Convert.ToInt32(dr["idOption"]);
                            // intIdOptionGroup = Convert.ToInt32(dr["Expr1"]);
                            //  ViewState["test"] = intIdOptionGroup.ToString();
                            imgURL = dr["imgURLPng"].ToString();
                            imgKeyboardMolding.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
                            imgKeyboardMolding.Visible = true;

                        }
                    }
                }
            }
            else
            {
                imgKeyboardMolding.Visible = false;
            }
        }
        else
        {
            imgKeyboardMolding.Visible = false;
        }
    }

    private void changeTopShelfMoldingColor()
    {
        if ((rdoDeskColor.SelectedIndex != -1) && (rdoDeskLeg.SelectedIndex != -1) && (rdoMoldingColor.SelectedIndex != -1) && (rdoCaster.SelectedIndex != -1) && (rdoCabinet.SelectedIndex != -1))
        {

            int intIdOption = 0;
            int intIdOptionCategory = 18;
            int intIdBaseColor = 0;
            int intColorGroup = 0;

            if (ViewState["selectMoldingColor"] != null)
            {
                int intKeyboard = Convert.ToInt32(rdoCabinet.SelectedValue);
                if (intKeyboard == 1 || intKeyboard == 2)
                {
                    imgTopShelfMoldingColor.Visible = false;

                }
                else
                {
                    intIdBaseColor = Convert.ToInt32(ViewState["selectMoldingColor"]);
                    intColorGroup = Convert.ToInt32(ViewState["cabinetSelect"]);
                    //  lblDeskCaster.Text = "what is  ViewState[deskmetal] option " + intIdBaseColor.ToString();
                    DataTable dt = sdb.getOptionColorMatchGroup(intIdBaseColor, intIdOptionCategory, intColorGroup);
                    // DataTable dt = sdb.getOptionColorMatchSelect(intIdBaseColor, intIdOptionCategory, 1);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            intIdOption = Convert.ToInt32(dr["idOption"]);
                            // intIdOptionGroup = Convert.ToInt32(dr["Expr1"]);
                            //  ViewState["test"] = intIdOptionGroup.ToString();
                            imgURL = dr["imgURLPng"].ToString();
                            imgTopShelfMoldingColor.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
                            imgTopShelfMoldingColor.Visible = true;

                        }
                    }
                }
            }

        }
        else
        {
            imgTopShelfMoldingColor.Visible = false;
        }

    }

    private void changeDeskFooterBottomMoldingColor()
    {
        if ((rdoMoldingColor.SelectedIndex != -1) && (rdoDeskBottomPanel.SelectedIndex != -1))
        {

            int intIdOption = 0;
            int intIdOptionCategory = 19;
            int intIdBaseColor = 0;
            int intColorGroup = 0;

            if (ViewState["selectMoldingColor"] != null)
            {
                int intKeyboard = Convert.ToInt32(rdoDeskBottomPanel.SelectedValue);
              
                    intIdBaseColor = Convert.ToInt32(ViewState["selectMoldingColor"]);
                    intColorGroup = Convert.ToInt32(ViewState["DeskBottomSelect"]);
                    //  lblDeskCaster.Text = "what is  ViewState[deskmetal] option " + intIdBaseColor.ToString();
                    DataTable dt = sdb.getOptionColorMatchGroup(intIdBaseColor, intIdOptionCategory, intColorGroup);
                    // DataTable dt = sdb.getOptionColorMatchSelect(intIdBaseColor, intIdOptionCategory, 1);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            intIdOption = Convert.ToInt32(dr["idOption"]);
                            // intIdOptionGroup = Convert.ToInt32(dr["Expr1"]);
                            //  ViewState["test"] = intIdOptionGroup.ToString();
                            imgURL = dr["imgURLPng"].ToString();
                            imgDeskBottomMoldingColor.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
                            imgDeskBottomMoldingColor.Visible = true;

                        }
                    }
                
            }

        }
        else
        {
            imgDeskBottomMoldingColor.Visible = false;
        }

    }


    public void getDeskSize()
    {
        int intOptionGroup = 0;
        DataTable dt = sdb.getIdOptionGroup(4);
        List<int> listOptionGroup = new List<int>();
        ArrayList list = new ArrayList();
        foreach (DataRow dataRow in dt.Rows)
        {           
            productParts item = new productParts();

            item.ImgSmall = String.Format("<p class=\"imgthumb\"><img src='imgSmall/{0}' width=\"100px\" /></p>" + "<div class=\"standing-desk-description\"><p>{1}</p><p>idoption: {2}</p></div>", dataRow["imgSmall"].ToString(), dataRow["material"].ToString(), dataRow["idOption"].ToString());
            item.ProductValue = Convert.ToInt32(dataRow["productValue"]);
            item.Material = Convert.ToString(dataRow["Material"]);
            list.Add(item);
        }
          
            rdoDeskSize.DataSource = list;
            rdoDeskSize.DataTextField = "imgSmall";
            rdoDeskSize.DataValueField = "ProductValue";
            rdoDeskSize.DataBind();
                
    }

    private void deskbutton()
    {
        if (ViewState["DeskButton"] != null)
        {
           // int intDeskGroup = 5;
            int idOptionC = Convert.ToInt32(ViewState["DeskButton"]);
            if (idOptionC > 0)
            {
                DataTable dt2 = sdb.getIdOptionGroup(idOptionC);
                if (dt2.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt2.Rows)
                    {
                        imgURL = dr["imgURLPng"].ToString();
                        imgDeskButton.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
                        imgDeskButton.Visible = true;
                    }
                }
            }
        }

    }


    private void getCasterExtra()
    {

        if (rdoDeskBottomPanel.SelectedIndex != -1)
        {

            int intIdOption = 0;
            int intIdOptionCategory = 20;
            int intIdBaseColor = 0;
            int intColorGroup = 0;

            if (ViewState["DeskBottomSelect"] != null)
            {
                int intKeyboard = Convert.ToInt32(rdoDeskBottomPanel.SelectedValue);

                intIdBaseColor = Convert.ToInt32(ViewState["SelectCasterExtra"]);

                //  lblDeskCaster.Text = "what is  ViewState[deskmetal] option " + intIdBaseColor.ToString();
                intColorGroup = Convert.ToInt32(ViewState["DeskBottomSelect"]);
                DataTable dt = sdb.getOptionColorMatchGroup(intIdBaseColor, intIdOptionCategory, intColorGroup);
                //  DataTable dt = sdb.getOptionColorMatch(intIdBaseColor, intIdOptionCategory);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        intIdOption = Convert.ToInt32(dr["idOption"]);
                        // intIdOptionGroup = Convert.ToInt32(dr["Expr1"]);
                        //  ViewState["test"] = intIdOptionGroup.ToString();
                        imgURL = dr["imgURLPng"].ToString();
                        imgCasterExra.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
                        imgCasterExra.Visible = true;

                    }
                }

            }



        }
    }

            //if (ViewState["CasterExtra"] != null)
            //{
            //    // int intDeskGroup = 5;
            //    int idOptionC = Convert.ToInt32(ViewState["CasterExtra"]);
            //    if (idOptionC > 0)
            //    {
            //        DataTable dt2 = sdb.getIdOptionGroup(idOptionC);
            //        if (dt2.Rows.Count > 0)
            //        {
            //            foreach (DataRow dr in dt2.Rows)
            //            {
            //                imgURL = dr["imgURLPng"].ToString();
            //                imgCasterExra.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
            //                imgCasterExra.Visible = true;
            //            }
            //        }
            //    }
            //}

       // }


    public void getDeskColor()
    {       
        if (ViewState["DeskSize"] != null)
        {
            intDeskGroup = Convert.ToInt32(ViewState["DeskSize"]);  
          //  lblDeskColor.Text = intDeskGroup.ToString();
            DataTable dt = sdb.getIdOptionGroup(intDeskGroup);        
            List<int> listOptionGroup = new List<int>();
            ArrayList list = new ArrayList();              
            foreach (DataRow dataRow in dt.Rows)
            {             
                productParts item = new productParts();

                item.ImgSmall = String.Format("<p class=\"imgthumb\"><img src='imgSmall/{0}'  width=\"100px\"  /></p>" + "<div class=\"standing-desk-description\"><p>{1}</p><p>idoption: {2}</p></div>", dataRow["imgSmall"].ToString(), dataRow["material"].ToString(), dataRow["idOption"].ToString());
                item.ProductValue = Convert.ToInt32(dataRow["productValue"]);
                item.Material = Convert.ToString(dataRow["Material"]);
                list.Add(item);
            }
            rdoDeskColor.DataSource = list;
            rdoDeskColor.DataTextField = "imgSmall";
            rdoDeskColor.DataValueField = "ProductValue";
            rdoDeskColor.DataBind();
            lblDeskColor.Text = "2. Desk Color";
            lblDeskColor.Attributes.Add("class", "stepSegement");
            this.deskColor.Attributes.Add("class", "color-container1");
        }

    }


    public void getDeskLeg()
    {
        intIdOptionCategory = 2;
      //  int intDeskType1 = 65;
      
        if (ViewState["DeskLeg"] != null)
        {
            int intOptionGroup = Convert.ToInt32(ViewState["DeskLeg"]);

            DataTable dt = sdb.getIdOptionGroup(intOptionGroup);
            List<int> listOptionGroup = new List<int>();
            ArrayList list = new ArrayList();
            // ArrayList list2 = new ArrayList();                 
            foreach (DataRow dataRow in dt.Rows)
            {
                //int IntOptionGroup = Convert.ToInt32(dataRow["idOptionGroup"]);
                productParts item = new productParts();
                item.ImgSmall = String.Format("<p class=\"imgthumb\"><img src='imgSmall/{0}'  width=\"100px\"  /></p>" + "<div class=\"standing-desk-description\"><p>{1}</p><p>idoption: {2}</p></div>", dataRow["imgSmall"].ToString(), dataRow["material"].ToString(), dataRow["idOption"].ToString());
                item.ProductValue = Convert.ToInt32(dataRow["productValue"]);
                item.Material = Convert.ToString(dataRow["Material"]);
                list.Add(item);

            }

            rdoDeskLeg.DataSource = list;
            rdoDeskLeg.DataTextField = "imgSmall";
            rdoDeskLeg.DataValueField = "ProductValue";
            rdoDeskLeg.DataBind();
            // rdoDeskLeg.SelectedIndex = 0;
            lblDeskLeg.Text = "3. Desk Leg";
            lblDeskLeg.Attributes.Add("class", "stepSegement");
            this.deskLeg.Attributes.Add("class", "color-container1");
        }

    }

    
  



    public void getCaster()
    {
        intIdOptionCategory = 3;
        int intIdBaseColor = 0;

        if (ViewState["DeskLegSelect"] != null)
        {
           // intDeskGroup = Convert.ToInt32(ViewState["Caster"]);
            //  lblDeskColor.Text = intDeskGroup.ToString();
            //DataTable dt = sdb.getIdOptionGroup(intDeskGroup);

            intIdBaseColor = Convert.ToInt32(ViewState["DeskLegSelect"]);
           // lblDeskCaster.Text = "what is  ViewState[deskmetal] option " + intIdBaseColor.ToString();
            DataTable dt = sdb.getOptionColorMatch(intIdBaseColor, intIdOptionCategory);
            List<int> listOptionGroup = new List<int>();
            ArrayList list = new ArrayList();
            foreach (DataRow dataRow in dt.Rows)
            {
                productParts item = new productParts();

                item.ImgSmall = String.Format("<p class=\"imgthumb\"><img src='imgSmall/{0}'  width=\"100px\"  /></p>" + "<div class=\"standing-desk-description\"><p>{1}</p><p>idoption: {2}</p></div>", dataRow["imgSmall"].ToString(), dataRow["material"].ToString(), dataRow["idOption"].ToString());
                item.ProductValue = Convert.ToInt32(dataRow["productValue"]);
                item.Material = Convert.ToString(dataRow["Material"]);
                list.Add(item);
            }
            rdoCaster.DataSource = list;
            rdoCaster.DataTextField = "imgSmall";
            rdoCaster.DataValueField = "ProductValue";
            rdoCaster.DataBind();
            lblDeskCaster.Text = "5.Foot Type";
            lblDeskCaster.Attributes.Add("class", "stepSegement");
            this.deskCaster.Attributes.Add("class", "color-container1");
        }

    }


    public void getMoldingColor()
    {

        int intIdProduct = 0;
        int intOptionGroup = 0;

        if (ViewState["MoldingColor"] != null)
        {
            intIdProduct = Convert.ToInt32(ViewState["MoldingColor"]);
            // lblMoldingColorList.Text = "<br/> what is MoldingColor option " + intIdProduct.ToString();
            DataTable dt = sdb.getIdOptionGroup(intIdProduct);

            List<int> listOptionGroup = new List<int>();
            ArrayList list = new ArrayList();
            foreach (DataRow dataRow in dt.Rows)
            {
                productParts item = new productParts();
                item.ImgSmall = String.Format("<p class=\"imgthumb\"><img src='imgSmall/{0}' width=\"70px\" /></p>" + "<div class=\"standing-desk-description\"><p>{1}</p><p>{2}</p></div>", dataRow["imgSmall"].ToString(), dataRow["material"].ToString(), dataRow["idOption"].ToString());
                item.ProductValue = Convert.ToInt32(dataRow["productvalue"]);
                item.Material = Convert.ToString(dataRow["Material"]);
                list.Add(item);
            }

            rdoMoldingColor.DataSource = list;
            rdoMoldingColor.DataTextField = "imgSmall";
            rdoMoldingColor.DataValueField = "ProductValue";
            rdoMoldingColor.DataBind();
            lblMoldingColor.Text = "4. Molding Color";
            lblMoldingColor.Attributes.Add("class", "stepSegement");
            this.moldingColor.Attributes.Add("class", "color-container1");
        }


    }





    public void getKeyboard()
    {
        intIdOptionCategory = 6;
        int intIdBaseColor = 0;

        if (ViewState["deskcolorSelect"] != null)
        {
            // intDeskGroup = Convert.ToInt32(ViewState["Caster"]);
            //  lblDeskColor.Text = intDeskGroup.ToString();
            //DataTable dt = sdb.getIdOptionGroup(intDeskGroup);

            intIdBaseColor = Convert.ToInt32(ViewState["deskcolorSelect"]);
            // lblDeskCaster.Text = "what is  ViewState[deskmetal] option " + intIdBaseColor.ToString();
            DataTable dt = sdb.getOptionColorMatch(intIdBaseColor, intIdOptionCategory);
            List<int> listOptionGroup = new List<int>();
            ArrayList list = new ArrayList();
            foreach (DataRow dataRow in dt.Rows)
            {
                productParts item = new productParts();

                item.ImgSmall = String.Format("<p class=\"imgthumb\"><img src='imgSmall/{0}'  width=\"100px\"  /></p>" + "<div class=\"standing-desk-description\"><p>{1}</p><p>idoption: {2}</p></div>", dataRow["imgSmall"].ToString(), dataRow["material"].ToString(), dataRow["idOption"].ToString());
                item.ProductValue = Convert.ToInt32(dataRow["productValue"]);
                item.Material = Convert.ToString(dataRow["Material"]);
                list.Add(item);
            }
            rdoKeyboard.DataSource = list;
            rdoKeyboard.DataTextField = "imgSmall";
            rdoKeyboard.DataValueField = "ProductValue";
            rdoKeyboard.DataBind();
            lblKeyboardTray.Text = "6. Keyboard Tray";
            lblKeyboardTray.Attributes.Add("class", "stepSegement");
            this.keyboardTray.Attributes.Add("class", "color-container1");          
        }

    }


    public void getMonitorArm()
    {
        if (ViewState["MonitorArm"] != null)
        {
            intDeskGroup = Convert.ToInt32(ViewState["MonitorArm"]);
            //  lblDeskColor.Text = intDeskGroup.ToString();
            DataTable dt = sdb.getIdOptionGroup(intDeskGroup);
            List<int> listOptionGroup = new List<int>();
            ArrayList list = new ArrayList();
            foreach (DataRow dataRow in dt.Rows)
            {
                productParts item = new productParts();

               // item.ImgSmall = String.Format("<img src='imgSmall/{0}'  width=\"100px\"  />" + "<div class=\"standing-desk-description\"><p>{1}</p><p>idoption: {2}</p></div>", dataRow["imgSmall"].ToString(), dataRow["material"].ToString(), dataRow["idOption"].ToString());
                item.ImgSmall = String.Format("<p class=\"imgthumb\"><img src='imgSmall/{0}'  width=\"100px\"  /></p>" + "<div class=\"standing-desk-description\"><p>{1}</p><p>idoption: {2}</p><p>idoptionGroup: {3}</p></div>", dataRow["imgSmall"].ToString(), dataRow["material"].ToString(), dataRow["idOption"].ToString(), dataRow["idOptionGroup"].ToString());

                item.ProductValue = Convert.ToInt32(dataRow["productValue"]);
                item.Material = Convert.ToString(dataRow["Material"]);
                list.Add(item);
            }
            rdoMonitorArm.DataSource = list;
            rdoMonitorArm.DataTextField = "imgSmall";
            rdoMonitorArm.DataValueField = "ProductValue";
            rdoMonitorArm.DataBind();
            lblMonitorArm.Text = "7. Monitor Arm";
            lblMonitorArm.Attributes.Add("class", "stepSegement");
            this.monitorArm.Attributes.Add("class", "color-container1");
        }

    }


    public void getMonitorTypeSub()
    {
        if (ViewState["MonitorArmSelect"] != null)
        {
            intSubCategory = Convert.ToInt32(ViewState["MonitorArmSelect"]);
            //  lblDeskColor.Text = intDeskGroup.ToString();
            DataTable dtt = sdb.getIdOptionGroupSub(intSubCategory);
            int subGroup = 0;
            if (dtt.Rows.Count > 0)
            {
                subGroup = Convert.ToInt32(dtt.Rows[0]["idOptionGroup"]);
            }
            //    intDeskType = Convert.ToInt32(ViewState["desktype"]);
            DataTable dt = sdb.getIdOptionGroup(subGroup);
            //lblDeskColorRadio.Text = "desktype1 " + intDeskType1.ToString();



            List<int> listOptionGroup = new List<int>();
            ArrayList list = new ArrayList();
            foreach (DataRow dataRow in dt.Rows)
            {
                productParts item = new productParts();

                item.ImgSmall = String.Format("<p class=\"imgthumb\"><img src='imgSmall/{0}'  width=\"100px\"  /></p>" + "<div class=\"standing-desk-description\"><p>{1}</p><p>idoption: {2}</p></div>", dataRow["imgSmall"].ToString(), dataRow["material"].ToString(), dataRow["idOption"].ToString());
                item.ProductValue = Convert.ToInt32(dataRow["productValue"]);
                item.Material = Convert.ToString(dataRow["Material"]);
                list.Add(item);
               
            }
            rdoMonitorTypeSub.DataSource = list;
            rdoMonitorTypeSub.DataTextField = "imgSmall";
            rdoMonitorTypeSub.DataValueField = "ProductValue";
            rdoMonitorTypeSub.DataBind();
          
          // monitorArmSub.Attributes.Add("class", "sub-monitor-container");
            monitorArmSub.Attributes.Add("class", "color-container1 sub-monitor-container");
        }

    }
    

    public void getCabinet()
    {
        intIdOptionCategory = 7;
        int intIdBaseColor = 0;

        if (ViewState["deskcolorSelect"] != null)
        {
            // intDeskGroup = Convert.ToInt32(ViewState["Caster"]);
            //  lblDeskColor.Text = intDeskGroup.ToString();
            //DataTable dt = sdb.getIdOptionGroup(intDeskGroup);

            intIdBaseColor = Convert.ToInt32(ViewState["deskcolorSelect"]);
            // lblDeskCaster.Text = "what is  ViewState[deskmetal] option " + intIdBaseColor.ToString();
            DataTable dt = sdb.getOptionColorMatch(intIdBaseColor, intIdOptionCategory);
            List<int> listOptionGroup = new List<int>();
            ArrayList list = new ArrayList();
            foreach (DataRow dataRow in dt.Rows)
            {
                productParts item = new productParts();

                item.ImgSmall = String.Format("<p class=\"imgthumb\"><img src='imgSmall/{0}'  width=\"100px\"  /></p>" + "<div class=\"standing-desk-description\"><p>{1}</p><p>idoption: {2}</p></div>", dataRow["imgSmall"].ToString(), dataRow["material"].ToString(), dataRow["idOption"].ToString());
                item.ProductValue = Convert.ToInt32(dataRow["productValue"]);
                item.Material = Convert.ToString(dataRow["Material"]);
                list.Add(item);
            }
            rdoCabinet.DataSource = list;
            rdoCabinet.DataTextField = "imgSmall";
            rdoCabinet.DataValueField = "ProductValue";
            rdoCabinet.DataBind();
            lblTopCabinet.Text = "8. Cabinet";
            lblTopCabinet.Attributes.Add("class", "stepSegement");
            this.topCabinet.Attributes.Add("class", "color-container1");
        }

    }

   

    public void getDeskBottomPanel()
    {
        intIdOptionCategory = 9;
        int intIdBaseColor = 0;

        if (ViewState["deskcolorSelect"] != null)
        {
            // intDeskGroup = Convert.ToInt32(ViewState["Caster"]);
            //  lblDeskColor.Text = intDeskGroup.ToString();
            //DataTable dt = sdb.getIdOptionGroup(intDeskGroup);

            intIdBaseColor = Convert.ToInt32(ViewState["deskcolorSelect"]);
            // lblDeskCaster.Text = "what is  ViewState[deskmetal] option " + intIdBaseColor.ToString();
            DataTable dt = sdb.getOptionColorMatch(intIdBaseColor, intIdOptionCategory);
            List<int> listOptionGroup = new List<int>();
            ArrayList list = new ArrayList();
            foreach (DataRow dataRow in dt.Rows)
            {
                productParts item = new productParts();

                item.ImgSmall = String.Format("<p class=\"imgthumb\"><img src='imgSmall/{0}'  width=\"100px\"  /></p>" + "<div class=\"standing-desk-description\"><p>{1}</p><p>idoption: {2}</p></div>", dataRow["imgSmall"].ToString(), dataRow["material"].ToString(), dataRow["idOption"].ToString());
                item.ProductValue = Convert.ToInt32(dataRow["productValue"]);
                item.Material = Convert.ToString(dataRow["Material"]);
                list.Add(item);
            }
            rdoDeskBottomPanel.DataSource = list;
            rdoDeskBottomPanel.DataTextField = "imgSmall";
            rdoDeskBottomPanel.DataValueField = "ProductValue";
            rdoDeskBottomPanel.DataBind();
            lblDeskBottomPanel.Text = "9. Desk Bottom Panel";
            lblDeskBottomPanel.Attributes.Add("class", "stepSegement");
            this.deskBottomPanel.Attributes.Add("class", "color-container1");
        }

    }


    public void getCpuHolder()
    {
        intIdOptionCategory = 11;
        int intIdBaseColor = 0;

        if (ViewState["CpuHolder"] != null)
        {
            intDeskGroup = Convert.ToInt32(ViewState["CpuHolder"]);
            //  lblDeskColor.Text = intDeskGroup.ToString();
            DataTable dt = sdb.getIdOptionGroup(intDeskGroup);
            List<int> listOptionGroup = new List<int>();
            ArrayList list = new ArrayList();
            foreach (DataRow dataRow in dt.Rows)
            {
                productParts item = new productParts();

                item.ImgSmall = String.Format("<p class=\"imgthumb\"><img src='imgSmall/{0}'  width=\"100px\"  /></p>" + "<div class=\"standing-desk-description\"><p>{1}</p><p>idoption: {2}</p><p>idoptionGroup: {3}</p></div>", dataRow["imgSmall"].ToString(), dataRow["material"].ToString(), dataRow["idOption"].ToString(), dataRow["idOptionGroup"].ToString());
                item.ProductValue = Convert.ToInt32(dataRow["productValue"]);
                item.Material = Convert.ToString(dataRow["Material"]);
                list.Add(item);
            }
            rdoCpuHolder.DataSource = list;
            rdoCpuHolder.DataTextField = "imgSmall";
            rdoCpuHolder.DataValueField = "ProductValue";
            rdoCpuHolder.DataBind();

            lblCpuHolder.Text = "10. CPU Holder";
            lblCpuHolder.Attributes.Add("class", "stepSegement");
            this.cpuHolder.Attributes.Add("class", "color-container1");
        }

    }

    public void getPhoneArm()
    {
        intIdOptionCategory = 12;
        int intIdBaseColor = 0;

        if (ViewState["PhoneArm"] != null)
        {
            intDeskGroup = Convert.ToInt32(ViewState["PhoneArm"]);
            //  lblDeskColor.Text = intDeskGroup.ToString();
            DataTable dt = sdb.getIdOptionGroup(intDeskGroup);
            List<int> listOptionGroup = new List<int>();
            ArrayList list = new ArrayList();
            foreach (DataRow dataRow in dt.Rows)
            {
                productParts item = new productParts();

                item.ImgSmall = String.Format("<p class=\"imgthumb\"><img src='imgSmall/{0}'  width=\"100px\"  /></p>" + "<div class=\"standing-desk-description\"><p>{1}</p><p>idoption: {2}</p><p>idoptionGroup: {3}</p></div>", dataRow["imgSmall"].ToString(), dataRow["material"].ToString(), dataRow["idOption"].ToString(), dataRow["idOptionGroup"].ToString());
                item.ProductValue = Convert.ToInt32(dataRow["productValue"]);
                item.Material = Convert.ToString(dataRow["Material"]);
                list.Add(item);
            }
            chkPhoneArm.DataSource = list;
            chkPhoneArm.DataTextField = "imgSmall";
            chkPhoneArm.DataValueField = "ProductValue";
            chkPhoneArm.DataBind();
        }

    }


    public void getTaskLight()
    {
        intIdOptionCategory = 13;
        int intIdBaseColor = 0;

        if (ViewState["TaskLight"] != null)
        {
            intDeskGroup = Convert.ToInt32(ViewState["TaskLight"]);
            //  lblDeskColor.Text = intDeskGroup.ToString();
            DataTable dt = sdb.getIdOptionGroup(intDeskGroup);
            List<int> listOptionGroup = new List<int>();
            ArrayList list = new ArrayList();
            foreach (DataRow dataRow in dt.Rows)
            {
                productParts item = new productParts();

                item.ImgSmall = String.Format("<p class=\"imgthumb\"><img src='imgSmall/{0}'  width=\"100px\"  /></p>" + "<div class=\"standing-desk-description\"><p>{1}</p><p>idoption: {2}</p><p>idoptionGroup: {3}</p></div>", dataRow["imgSmall"].ToString(), dataRow["material"].ToString(), dataRow["idOption"].ToString(), dataRow["idOptionGroup"].ToString());
                item.ProductValue = Convert.ToInt32(dataRow["productValue"]);
                item.Material = Convert.ToString(dataRow["Material"]);
                list.Add(item);
            }
            chkTaskLight.DataSource = list;
            chkTaskLight.DataTextField = "imgSmall";
            chkTaskLight.DataValueField = "ProductValue";
            chkTaskLight.DataBind();
        }

    }


    public void getUSBhub()
    {
        intIdOptionCategory = 14;
        int intIdBaseColor = 0;

        if (ViewState["USBhub"] != null)
        {
            intDeskGroup = Convert.ToInt32(ViewState["USBhub"]);
            //  lblDeskColor.Text = intDeskGroup.ToString();
            DataTable dt = sdb.getIdOptionGroup(intDeskGroup);
            List<int> listOptionGroup = new List<int>();
            ArrayList list = new ArrayList();
            foreach (DataRow dataRow in dt.Rows)
            {
                productParts item = new productParts();

                item.ImgSmall = String.Format("<p class=\"imgthumb\"><img src='imgSmall/{0}'  width=\"100px\"  /></p>" + "<div class=\"standing-desk-description\"><p>{1}</p><p>idoption: {2}</p><p>idoptionGroup: {3}</p></div>", dataRow["imgSmall"].ToString(), dataRow["material"].ToString(), dataRow["idOption"].ToString(), dataRow["idOptionGroup"].ToString());
                item.ProductValue = Convert.ToInt32(dataRow["productValue"]);
                item.Material = Convert.ToString(dataRow["Material"]);
                list.Add(item);
            }
            chkUSBhub.DataSource = list;
            chkUSBhub.DataTextField = "imgSmall";
            chkUSBhub.DataValueField = "ProductValue";
            chkUSBhub.DataBind();
        }

    }
    public void getCupHolder()
    {
        intIdOptionCategory = 15;
        int intIdBaseColor = 0;

        if (ViewState["CupHolder"] != null)
        {
            intDeskGroup = Convert.ToInt32(ViewState["CupHolder"]);
            //  lblDeskColor.Text = intDeskGroup.ToString();
            DataTable dt = sdb.getIdOptionGroup(intDeskGroup);
            List<int> listOptionGroup = new List<int>();
            ArrayList list = new ArrayList();
            foreach (DataRow dataRow in dt.Rows)
            {
                productParts item = new productParts();

                item.ImgSmall = String.Format("<p class=\"imgthumb\"><img src='imgSmall/{0}'  width=\"100px\"  /></p>" + "<div class=\"standing-desk-description\"><p>{1}</p><p>idoption: {2}</p><p>idoptionGroup: {3}</p></div>", dataRow["imgSmall"].ToString(), dataRow["material"].ToString(), dataRow["idOption"].ToString(), dataRow["idOptionGroup"].ToString());
                item.ProductValue = Convert.ToInt32(dataRow["productValue"]);
                item.Material = Convert.ToString(dataRow["Material"]);
                list.Add(item);
            }
            chkCupHolder.DataSource = list;
            chkCupHolder.DataTextField = "imgSmall";
            chkCupHolder.DataValueField = "ProductValue";
            chkCupHolder.DataBind();
        }

    }

    public void getChkWireManagement()
    {
        intIdOptionCategory = 21;
        int intIdBaseColor = 0;

        if (ViewState["Wiremanagement"] != null)
        {
            intDeskGroup = Convert.ToInt32(ViewState["Wiremanagement"]);
            //  lblDeskColor.Text = intDeskGroup.ToString();
            DataTable dt = sdb.getIdOptionGroup(intDeskGroup);
            List<int> listOptionGroup = new List<int>();
            ArrayList list = new ArrayList();
            foreach (DataRow dataRow in dt.Rows)
            {
                productParts item = new productParts();

                item.ImgSmall = String.Format("<p class=\"imgthumb\"><img src='imgSmall/{0}'  width=\"100px\"  /></p>" + "<div class=\"standing-desk-description\"><p>{1}</p><p>idoption: {2}</p><p>idoptionGroup: {3}</p></div>", dataRow["imgSmall"].ToString(), dataRow["material"].ToString(), dataRow["idOption"].ToString(), dataRow["idOptionGroup"].ToString());
                item.ProductValue = Convert.ToInt32(dataRow["productValue"]);
                item.Material = Convert.ToString(dataRow["Material"]);
                list.Add(item);
            }
            chkWireManagement.DataSource = list;
            chkWireManagement.DataTextField = "imgSmall";
            chkWireManagement.DataValueField = "ProductValue";
            chkWireManagement.DataBind();
        }

    }

    

    protected void Page_PreRender(object sender, EventArgs e)
    {
       // HideSelection();


    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
        //  Start Find Out Browser
        System.Web.HttpBrowserCapabilities browser = Request.Browser;
        string name = browser.Browser;
        float version = (float)(browser.MajorVersion + browser.MinorVersion);
        if (name == "InternetExplorer" && version < 9)
        {
            // show message, 
            string message = "alert('You are not using IE . You are use any other browser for best performance!')";
            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            return;

        }
      
        if (!IsPostBack)
        {
            Bind();


            if (Session["SelectPrice"] == null)
            {
                Cart = new DataTable();
                Cart.Columns.Add(new DataColumn("Material", typeof(string)));
                Cart.Columns.Add(new DataColumn("Description", typeof(string)));
                Cart.Columns.Add(new DataColumn("Selling_Price", typeof(string)));
                Cart.Columns.Add(new DataColumn("SKU", typeof(int)));
                Session["SelectPrice"] = Cart;

            }
            else
            {
                Cart = (DataTable)Session["SelectPrice"];
                CartView = new DataView(Cart);
                GridView1.DataSource = CartView;
                GridView1.DataBind();
               
            }




        }
        //if ((address.Contains("localhost") || address.Contains("tstation-dev1") || address.Contains(internalWeb)))
        //{
        //    dvCreatepdf.Visible = true;
        //}
        //else
        //{
        //    dvCreatepdf.Visible = false;
        //}
        //pnlOtherElectronicLeg.Visible = true;

        //if (string.IsNullOrEmpty(txtQuantity.Text.Trim()))
        //{
        //    txtQuantity.Text = "1";
        //}


    }


    public void Bind()
    {       
        getDeskSize();
        DataTable dt = sdb.getIdOptionGroup(intDeskGroup);
        DataView dv = new DataView(dt);
        GridView1.DataSource = dv;
        GridView1.DataBind();

    }




    DataSet getOptions(string strGroup, int intSelect)
    {
        string strOption = "select * from config_desk where productgroup = @productgroup and productvalue=@productvalue order by productvalue";

        SqlCommand cmd = new SqlCommand(strOption, conn);
        cmd.Parameters.AddWithValue("@productgroup", strGroup);
        cmd.Parameters.AddWithValue("@productvalue", intSelect);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet dsOptions = new DataSet();
        conn.Open();

        da.Fill(dsOptions, "listOption");
        conn.Close();

        return dsOptions;
    }


   
   

    /*=================================For Email Send===============*/
    static string emailpdfName = string.Empty;
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static void UploadImageForEmail(string imageData)
    {
        string NewstrData = imageData.Replace("data:image/png;base64,", String.Empty);
        Guid guid = Guid.NewGuid();
        emailpdfName = guid.ToString() + ".png";
        try
        {
            //string fileNameWitPath = HttpContext.Current.Server.MapPath(@"\configurator\medicalcart\imgOrder\medicalcart.png");
            string fileNameWitPath = HttpContext.Current.Server.MapPath(@"\configurator\medicalcart\imgOrder\" + emailpdfName);
            using (FileStream fs = new FileStream(fileNameWitPath, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    byte[] data = Convert.FromBase64String(NewstrData);
                    bw.Write(data);
                    bw.Close();
                }

            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
    }

    public string GeneratePDF(string OrderImgPathName, string OrderId, int Id, bool IsMedicalCart)
    {
        string filename = string.Empty;
        StringBuilder stbrPdf = new StringBuilder();
        DataSet ds = Session["PoleCart"] as DataSet;
        //string strProductName = getproductName(ds);

        string strpath = string.Empty;
        string pdfName = string.Empty;
        try
        {
            strpath = "imgOrder/" + Path.GetFileName(OrderImgPathName);
            string srtimageName = Server.MapPath(strpath);

            filename = "PDF_Polecart/" + OrderId + ".pdf";
            if (!Directory.Exists(Server.MapPath("~/PDF-configurator")))
            {
                Directory.CreateDirectory(Server.MapPath("~/PDF-configurator"));
            }
            filename = "~/PDF-configurator/" + OrderId + ".pdf";
            pdfName = OrderId + ".pdf";

            // UpdatePDFName(filename, Id);

            //Create document
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            //Create PDF Table
            iTextSharp.text.pdf.PdfPTable tableLayout = new iTextSharp.text.pdf.PdfPTable(4);
            //Create a PDF file in specific path
            iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(Server.MapPath(filename), FileMode.Create));
            //Open the PDF document
            doc.Open();
            ViewState["pdfName"] = pdfName;
            //Add Content to PDF
            if (Session["PoleCart"] != null)
            {
                string title = "Product Description of Medical cart";
                doc.Add(GeneratePdf.Add_Content_To_PDF(tableLayout, OrderImgPathName, PoleCartPath, pdfName, IsMedicalCart, ConfiguratorTypeId, title));
            }

            // Closing the document
            doc.Close();
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
            ClientScript.RegisterClientScriptBlock(this.GetType(), "key", "swal('" + msg + "');", true);
        }
        return filename;
    }

   
   
 
    
    protected void rdoMoldingColor_SelectedIndexChanged1(object sender, EventArgs e)
    {
        
        if (rdoMoldingColor.SelectedIndex != -1)
        {

            int intSelect = Convert.ToInt32(rdoMoldingColor.SelectedValue);
            int intIdOption = 0;
            int intIdProduct = 0;
            int intIdOptionGroup = 0;

            imgKeyboard.Visible = false;
            imgKeyboardMolding.Visible = false;
            rdoKeyboard.SelectedIndex = -1;
           
            rdoCabinet.SelectedIndex = -1;
            imgCabinet.Visible = false;
            imgDeskCabinetFrameColor.Visible = false;
            imgTopShelfMoldingColor.Visible = false;

            imgDeskBottomMoldingColor.Visible = false;
            imgDeskBottomPanel.Visible = false;
            rdoDeskBottomPanel.SelectedIndex = -1;

            if (ViewState["MoldingColor"] != null)
            {
                intIdOptionGroup = Convert.ToInt32(ViewState["MoldingColor"]);
                // lblMoldingColorList.Text = " ViewState[MoldingColor] " + intIdProduct.ToString();
                DataTable dt = sdb.getIdOptionGroupSelect(intIdOptionGroup, intSelect);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        intIdOption = Convert.ToInt32(dr["idOption"]);
                        ViewState["selectMoldingColor"] = intIdOption.ToString();
                        intIdOptionGroup = Convert.ToInt32(dr["Expr1"]);

                        imgURL = dr["imgURLPng"].ToString();
                        imgMoldingColor.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
                        ViewState["deskmoldingcolortext"] = dr["Material"].ToString();
                        imgMoldingColor.Visible = true;

                    }
                }
            }

           
        }
    }
 
    protected void rdoDeskButton_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoDeskButton.SelectedIndex != -1)
        {
            int intSelect = Convert.ToInt32(rdoDeskButton.SelectedValue);
            int intIdOption = 0;
            int intIdProduct = 0;
            int intIdOptionGroup = 0;

            if (ViewState["DeskButton"] != null)
            {
                intIdProduct = Convert.ToInt32(ViewState["DeskButton"]);
                // lblKeyboardTypeSub.Text = " ViewState[monitortypesub] " + intIdProduct.ToString();
                DataTable dt = sdb.getIdOptionGroupSelect(intIdProduct, intSelect);
                //if (intSelect == 2)
                //{

                //}

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        intIdOption = Convert.ToInt32(dr["idOption"]);
                        intIdOptionGroup = Convert.ToInt32(dr["Expr1"]);
                        //  ViewState["MetalKeyboardType"] = intIdOptionGroup.ToString();
                        imgURL = dr["imgURLPng"].ToString();
                        imgDeskButton.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
                        imgDeskButton.Visible = true;

                    }
                }
            //    lblMonitorTypeSubDetail.Text = "ViewState[monitortypesub]    " + intIdOption.ToString();
                //"intIdOption " + intIdOptionGroup.ToString() + "select" + intSelect.ToString() +
                //" image name" + imgMonitorTypeSub.ImageUrl.ToString();

            }
            HideSelection();

        }

    }

    protected void rdoCasterExtra_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoCasterExtra.SelectedIndex != -1)
        {
            int intSelect = Convert.ToInt32(rdoCasterExtra.SelectedValue);
            int intIdOption = 0;
            int intIdProduct = 0;
            int intIdOptionGroup = 0;

            if (ViewState["CasterExtra"] != null)
            {
                intIdProduct = Convert.ToInt32(ViewState["CasterExtra"]);
                // lblKeyboardTypeSub.Text = " ViewState[monitortypesub] " + intIdProduct.ToString();
                DataTable dt = sdb.getIdOptionGroupSelect(intIdProduct, intSelect);
                //if (intSelect == 2)
                //{

                //}

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        intIdOption = Convert.ToInt32(dr["idOption"]);
                        intIdOptionGroup = Convert.ToInt32(dr["Expr1"]);
                        //  ViewState["MetalKeyboardType"] = intIdOptionGroup.ToString();
                        imgURL = dr["imgURLPng"].ToString();
                        imgCasterExra.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
                        imgCasterExra.Visible = true;

                    }
                }
                //    lblMonitorTypeSubDetail.Text = "ViewState[monitortypesub]    " + intIdOption.ToString();
                //"intIdOption " + intIdOptionGroup.ToString() + "select" + intSelect.ToString() +
                //" image name" + imgMonitorTypeSub.ImageUrl.ToString();

            }
            HideSelection();

        }

    }

    protected void rdoDeskColor_SelectedIndexChanged(object sender, EventArgs e)
    {      
        int intIdOption = 0;
        int intIdOptionGroup = 0;
        int intColorOptionSelect = 0;
        if (rdoDeskColor.SelectedIndex != -1 ) 
        {
            int intSelect = Convert.ToInt32(rdoDeskColor.SelectedValue);
            if (ViewState["DeskSize"] != null)
            {
                intColorOptionSelect = Convert.ToInt32(ViewState["DeskSize"]);
               // lblDeskColorDetail.Text = intColorOptionSelect.ToString();
                DataTable dt = sdb.getIdOptionGroupSelect(intColorOptionSelect, intSelect);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        intIdOption = Convert.ToInt32(dr["idOption"]);
                        ViewState["deskcolorSelect"] = intIdOption.ToString();
                        ViewState["desktopcolortext"] = dr["Material"].ToString();
                        intIdOptionGroup = Convert.ToInt32(dr["Expr1"]);
                        ViewState["MoldingType"] = intIdOptionGroup.ToString();
                        imgURL = dr["imgURLPng"].ToString();
                        imgDeskColor.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
                        imgDeskColor.Visible = true;                      

                    }
                }
                //  HideSelection();
              
                getDeskLeg();
                getMoldingColor();
             
                //getKeyboard();
            
                //imgCabinet.Visible = false;
                //imgDeskBottomPanel.Visible = false;
                //imgDeskBottomMoldingColor.Visible = false;
                //imgKeyboard.Visible = false;
                //imgKeyboardMolding.Visible = false;
                //imgMoldingColor.Visible = false;
                //imgTopShelfMoldingColor.Visible = false;
                //imgDeskCabinetFrameColor.Visible = false;


          
                imgDeskLeg.Visible = false;
                imgCaster.Visible = false;
                imgMoldingColor.Visible = false;
                imgDeskButton.Visible = false;
                imgCabinet.Visible = false;
                imgKeyboard.Visible = false;
                imgDeskBottomPanel.Visible = false;
                imgMonitorArm.Visible = false;
                imgDeskCabinetFrameColor.Visible = false;
                imgCpuHolder.Visible = false;
                imgPhoneArm.Visible = false;
                imgTaskLight.Visible = false;
                imgUSBhub.Visible = false;
                imgCupHolder.Visible = false;
                imgMonitorArmSub.Visible = false;
                imgKeyboardMolding.Visible = false;
                imgTopShelfMoldingColor.Visible = false;
                imgDeskBottomMoldingColor.Visible = false;
                imgCasterExra.Visible = false;
                imgWiremanagement.Visible = false;

            }
        }
       
    


    }
    
    protected void rdoDeskSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoDeskSize.SelectedIndex != -1)
        {
            int intidOptionGroup = 0;
            int intidOptionGroupFrame = 0;
            int intidOptionGroupMoldingColor = 0;
            int intidOptionGroupButton = 0;
            //int intidOptonGroupKeyboardType = 0;
            int intidCasterType = 0;
            int intidKeyboard = 0;
            int intidCabinetType = 0;
            int intidCabinetFrame = 0;
            int intidMonitorArm = 0;
            int intidCpuHolder = 0;
            int intidPhoneArm = 0;
            int intidTaskLight = 0;
            int intidDeskLamp = 0;
            int intidCupHolder = 0;
            int intidKeyboardTypeSub = 0;
            int intCasterExra = 0;
            int intSelect = Convert.ToInt32(rdoDeskSize.SelectedValue);

            int intIdOption = 0;
            int intidWiremanagement = 0;
            //int intIdOptionGroup = 0;
            //int intColorOptionSelect = 0;

            //  DataTable dt = sdb.getIdOptionGroupSelect(4, intSelect);
            DataTable dt = sdb.displayOptions1Select(intSelect);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    //intIdOption = Convert.ToInt32(dr["idOption"]);                  
                    //ViewState["desksizetext"] = dr["Material"].ToString();
                    intidOptionGroup = Convert.ToInt32(dr["idOptionGroup"]);
                    ViewState["DeskSize"] = intidOptionGroup.ToString();
                    intidOptionGroupFrame = Convert.ToInt32(dr["idOptionGroupFrame"]);
                    ViewState["DeskLeg"] = intidOptionGroupFrame.ToString();
                    //   lblDeskSize.Text = "    ViewState[DeskSize] " + intidOptionGroup.ToString();

                    if (dr["idOptionGroupMoldingColor"] != DBNull.Value)
                    {
                        intidOptionGroupMoldingColor = Convert.ToInt32(dr["idOptionGroupMoldingColor"]);
                        ViewState["MoldingColor"] = intidOptionGroupMoldingColor.ToString();
                    }
                    else
                    {
                        intidOptionGroupMoldingColor = 0;
                    }
                    if (dr["idOptionGroupButton"] != DBNull.Value)
                    {
                        intidOptionGroupButton = Convert.ToInt32(dr["idOptionGroupButton"]);
                        ViewState["DeskButton"] = intidOptionGroupButton.ToString();
                    }
                    else
                    {
                        intidOptionGroupButton = 0;

                    }
                 
                    if (dr["idCasterType"] != DBNull.Value)
                    {
                        intidCasterType = Convert.ToInt32(dr["idCasterType"]);
                        ViewState["Caster"] = intidCasterType.ToString();
                    }
                    else
                    {
                        intidCasterType = 0;
                    }
                    if (dr["idKeyboardType"] != DBNull.Value)
                    {
                        intidKeyboard = Convert.ToInt32(dr["idKeyboardType"]);
                        ViewState["Keyboard"] = intidKeyboard.ToString();
                    }
                    else
                    {
                        intidKeyboard = 0;
                    }
                    if (dr["idCabinetType"] != DBNull.Value)
                    {
                        intidCabinetType = Convert.ToInt32(dr["idCabinetType"]);
                        ViewState["Cabinet"] = intidCabinetType.ToString();
                    }
                    else
                    {
                        intidCabinetType = 0;
                    }
                    if (dr["idCabinetFrame"] != DBNull.Value)
                    {
                        intidCabinetFrame = Convert.ToInt32(dr["idCabinetFrame"]);
                        ViewState["CabinetFrame"] = intidCabinetFrame.ToString();
                    }
                    else
                    {
                        intidCabinetFrame = 0;
                    }

                    
                    if (dr["idMonitorArm"] != DBNull.Value)
                    {
                        intidMonitorArm = Convert.ToInt32(dr["idMonitorArm"]);
                        ViewState["MonitorArm"] = intidMonitorArm.ToString();
                    }
                    else
                    {
                        intidMonitorArm = 0;
                    }

                    if (dr["idCpuHolder"] != DBNull.Value)
                    {
                        intidCpuHolder = Convert.ToInt32(dr["idCpuHolder"]);
                        ViewState["CpuHolder"] = intidCpuHolder.ToString();
                    }
                    else
                    {
                        intidCpuHolder = 0;
                    }

                    if (dr["idPhoneArm"] != DBNull.Value)
                    {
                        intidPhoneArm = Convert.ToInt32(dr["idPhoneArm"]);
                        ViewState["PhoneArm"] = intidPhoneArm.ToString();
                    }
                    else
                    {
                        intidPhoneArm = 0;
                    }

                    if (dr["idTaskLight"] != DBNull.Value)
                    {
                        intidTaskLight = Convert.ToInt32(dr["idTaskLight"]);
                        ViewState["TaskLight"] = intidTaskLight.ToString();
                    }
                    else
                    {
                        intidCpuHolder = 0;
                    }

                    if (dr["idUSBhub"] != DBNull.Value)
                    {
                        intidDeskLamp = Convert.ToInt32(dr["idUSBhub"]);
                        ViewState["USBhub"] = intidDeskLamp.ToString();
                    }
                    else
                    {
                        intidPhoneArm = 0;
                    }
                    if (dr["idCupHolder"] != DBNull.Value)
                    {
                        intidCupHolder = Convert.ToInt32(dr["idCupHolder"]);
                        ViewState["CupHolder"] = intidCupHolder.ToString();
                    }
                    else
                    {
                        intidCupHolder = 0;
                    }

                    if (dr["idWiremanagement"] != DBNull.Value)
                    {
                        intidWiremanagement = Convert.ToInt32(dr["idWiremanagement"]);
                        ViewState["Wiremanagement"] = intidWiremanagement.ToString();
                    }
                    else
                    {
                        intidWiremanagement = 0;
                    }



                }

            }
            getDeskColor();
            getDeskLeg();   
            getCpuHolder();
         
            imgDeskColor.Visible = false;
            imgDeskLeg.Visible = false;
            imgCaster.Visible = false;
            imgMoldingColor.Visible = false;
            imgDeskButton.Visible = false;
            imgCabinet.Visible = false;
            imgKeyboard.Visible = false;
            imgKeyboardMolding.Visible = false;
            imgDeskBottomPanel.Visible = false;
            imgMonitorArm.Visible = false;
            imgDeskCabinetFrameColor.Visible = false;
            imgCpuHolder.Visible = false;
            imgPhoneArm.Visible = false;
            imgTaskLight.Visible = false;
            imgUSBhub.Visible = false;
            imgCupHolder.Visible = false;
            imgMonitorArmSub.Visible = false;
         
            imgTopShelfMoldingColor.Visible = false;
            imgDeskBottomMoldingColor.Visible = false;
            imgCasterExra.Visible = false;
            imgWiremanagement.Visible = false;


        }
        }


    protected void rdoCaster_SelectedIndexChanged(object sender, EventArgs e)
    {      
        if (rdoCaster.SelectedIndex != -1)
        {
            int intIdOptionCategory = 3;
            int intIdBaseColor = 0;
            int intIdOption = 0;
            int intSelect = 0;
            int intIdOptionGroup = 0;

            intSelect = Convert.ToInt32(rdoCaster.SelectedValue);
          
            if (ViewState["DeskLegSelect"] != null)
            {
                // intDeskGroup = Convert.ToInt32(ViewState["Caster"]);
                //  lblDeskColor.Text = intDeskGroup.ToString();
                //DataTable dt = sdb.getIdOptionGroup(intDeskGroup);

                intIdBaseColor = Convert.ToInt32(ViewState["DeskLegSelect"]);
                // lblDeskCaster.Text = "what is  ViewState[deskmetal] option " + intIdBaseColor.ToString();
                DataTable dt = sdb.getOptionColorMatchSelect(intIdBaseColor, intIdOptionCategory, intSelect);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        intIdOption = Convert.ToInt32(dr["idOption"]);
                        ViewState["SelectCasterExtra"] = intIdOption.ToString();
                        //    ViewState["desklegcolortext"] = dr["Material"].ToString();
                      //  intIdOptionGroup = Convert.ToInt32(dr["Expr1"]);
                        //   ViewState["Caster"] = intIdOptionGroup.ToString();
                        imgURL = dr["imgURLPng"].ToString();
                        imgCaster.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
                        imgCaster.Visible = true;
                        imgCasterExra.Visible = false;
                    }
                }
                getKeyboard();
            }

          
        }

        }


   
   

    protected void rdoCabinet_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (rdoCaster.SelectedIndex != -1)
        // if ((rdoCabinet.SelectedIndex != -1) && (rdoDeskLeg.SelectedIndex != -1) && (rdoCaster.SelectedIndex != -1))
        if (rdoCabinet.SelectedIndex != -1)
        {
            int intIdOptionCategory = 7;
            int intIdBaseColor = 0;
            int intIdOption = 0;
            int intSelect = 0;
            int intIdOptionGroup = 0;

            intSelect = Convert.ToInt32(rdoCabinet.SelectedValue);
            int intSelectIndex = Convert.ToInt32(rdoCabinet.SelectedIndex);
            if (intSelectIndex == 1 || intSelectIndex == 2)
            {
                imgTopShelfMoldingColor.Visible = false;

            }
            else
            {

                imgTopShelfMoldingColor.Visible = true;
            }
            if (ViewState["deskcolorSelect"] != null)
            {
                // intDeskGroup = Convert.ToInt32(ViewState["Caster"]);
                //  lblDeskColor.Text = intDeskGroup.ToString();
                //DataTable dt = sdb.getIdOptionGroup(intDeskGroup);

                intIdBaseColor = Convert.ToInt32(ViewState["deskcolorSelect"]);
                // lblDeskCaster.Text = "what is  ViewState[deskmetal] option " + intIdBaseColor.ToString();
                DataTable dt = sdb.getOptionColorMatchSelect(intIdBaseColor, intIdOptionCategory, intSelect);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        intIdOption = Convert.ToInt32(dr["idOption"]);
                        ViewState["cabinetSelect"] = intIdOption.ToString();
                        //    ViewState["desklegcolortext"] = dr["Material"].ToString();
                        //  intIdOptionGroup = Convert.ToInt32(dr["Expr1"]);
                        //   ViewState["Caster"] = intIdOptionGroup.ToString();
                        imgURL = dr["imgURLPng"].ToString();
                        imgCabinet.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
                        imgCabinet.Visible = true;
                        imgDeskCabinetFrameColor.Visible = true;
                    }
                    HideSelection();

                }

            }



            //int intIdOption = 0;
            //int intIdOptionCategory = 18;
            //int intIdBaseColor = 0;
            int intColorGroup = 0;

            if (ViewState["selectMoldingColor"] != null)
            {
                int intKeyboard = Convert.ToInt32(rdoCabinet.SelectedValue);
                if (intKeyboard == 1 || intKeyboard == 2)
                {
                    imgTopShelfMoldingColor.Visible = false;

                }
                else
                {
                    intIdBaseColor = Convert.ToInt32(ViewState["selectMoldingColor"]);
                    intColorGroup = Convert.ToInt32(ViewState["cabinetSelect"]);
                    //  lblDeskCaster.Text = "what is  ViewState[deskmetal] option " + intIdBaseColor.ToString();
                    DataTable dt = sdb.getOptionColorMatchGroup(intIdBaseColor, 18, intColorGroup);
                    // DataTable dt = sdb.getOptionColorMatchSelect(intIdBaseColor, intIdOptionCategory, 1);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            intIdOption = Convert.ToInt32(dr["idOption"]);
                            // intIdOptionGroup = Convert.ToInt32(dr["Expr1"]);
                            //  ViewState["test"] = intIdOptionGroup.ToString();
                            imgURL = dr["imgURLPng"].ToString();
                            imgTopShelfMoldingColor.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
                            imgTopShelfMoldingColor.Visible = true;

                        }
                    }
                }
            }




        }
        else
        {

            imgCabinet.Visible = false;


        }


        if (rdoCabinet.SelectedIndex != -1)
        {
            //if (rdoDeskTopCabinetType.SelectedIndex != -1)
            //{

            int intIdOption = 0;
            int intIdOptionCategory = 10;
            int intIdBaseColor = 0;


            if (ViewState["DeskLegSelect"] != null)
            {
                int intImageCabinet = Convert.ToInt32(rdoCabinet.SelectedValue);
                if (intImageCabinet == 1)
                {
                    imgDeskCabinetFrameColor.Visible = false;

                }

                else
                {
                    intIdBaseColor = Convert.ToInt32(ViewState["DeskLegSelect"]);
                    //  lblDeskCaster.Text = "what is  ViewState[deskmetal] option " + intIdBaseColor.ToString();
                    DataTable dt = sdb.getOptionColorMatch(intIdBaseColor, intIdOptionCategory);
                    // DataTable dt = sdb.getOptionColorMatchSelect(intIdBaseColor, intIdOptionCategory, 1);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            intIdOption = Convert.ToInt32(dr["idOption"]);
                            // intIdOptionGroup = Convert.ToInt32(dr["Expr1"]);
                            //  ViewState["test"] = intIdOptionGroup.ToString();
                            imgURL = dr["imgURLPng"].ToString();
                            imgDeskCabinetFrameColor.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
                            imgDeskCabinetFrameColor.Visible = true;

                        }
                    }
                }
            }
            else
            { imgDeskCabinetFrameColor.Visible = false; }
        }


    }


    protected void rdoKeyboard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoKeyboard.SelectedIndex != -1)
        {
            int intIdOptionCategory = 6;
            int intIdBaseColor = 0;
            int intIdOption = 0;
            int intSelect = 0;
            int intIdOptionGroup = 0;

            intSelect = Convert.ToInt32(rdoKeyboard.SelectedValue);

            rdoDeskBottomPanel.SelectedIndex = -1;
            imgDeskBottomMoldingColor.Visible = false;
            imgDeskBottomPanel.Visible = false;
           

            if (ViewState["deskcolorSelect"] != null)
            {
                // intDeskGroup = Convert.ToInt32(ViewState["Caster"]);
                //  lblDeskColor.Text = intDeskGroup.ToString();
                //DataTable dt = sdb.getIdOptionGroup(intDeskGroup);

                intIdBaseColor = Convert.ToInt32(ViewState["deskcolorSelect"]);
                // lblDeskCaster.Text = "what is  ViewState[deskmetal] option " + intIdBaseColor.ToString();
                DataTable dt = sdb.getOptionColorMatchSelect(intIdBaseColor, intIdOptionCategory, intSelect);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        intIdOption = Convert.ToInt32(dr["idOption"]);
                        ViewState["keyboardSelect"] = intIdOption.ToString();
                        //    ViewState["desklegcolortext"] = dr["Material"].ToString();
                        //  intIdOptionGroup = Convert.ToInt32(dr["Expr1"]);
                        //   ViewState["Caster"] = intIdOptionGroup.ToString();
                        imgURL = dr["imgURLPng"].ToString();
                        imgKeyboard.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
                        imgKeyboard.Visible = true;
                    }
                    getMonitorArm();
                    getCabinet();
                    getDeskBottomPanel();
                    HideSelection();
                }

            }

        }
    }
    protected void rdoMonitorArm_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (rdoMonitorArm.SelectedIndex != -1)
        {
            //int intIdOptionCategory = 6;
            int intIdBaseColor = 0;
            int intIdOption = 0;
            int intSelect = 0;
            int intIdOptionGroup = 0;

            intSelect = Convert.ToInt32(rdoMonitorArm.SelectedValue);

            //if (ViewState["deskcolorSelect"] != null)
            //{
            //    // intDeskGroup = Convert.ToInt32(ViewState["Caster"]);
            //    //  lblDeskColor.Text = intDeskGroup.ToString();
            //    //DataTable dt = sdb.getIdOptionGroup(intDeskGroup);

            //    intIdBaseColor = Convert.ToInt32(ViewState["deskcolorSelect"]);
            //    // lblDeskCaster.Text = "what is  ViewState[deskmetal] option " + intIdBaseColor.ToString();
            //    DataTable dt = sdb.getOptionColorMatchSelect(intIdBaseColor, intIdOptionCategory, intSelect);

            //    if (dt.Rows.Count > 0)
            //    {
            //        foreach (DataRow dr in dt.Rows)
            //        {
            //            intIdOption = Convert.ToInt32(dr["idOption"]);
            //            //  ViewState["deskcolor"] = intIdOption.ToString();
            //            //    ViewState["desklegcolortext"] = dr["Material"].ToString();
            //            //  intIdOptionGroup = Convert.ToInt32(dr["Expr1"]);
            //            //   ViewState["Caster"] = intIdOptionGroup.ToString();
            //            imgURL = dr["imgURLPng"].ToString();
            //            imgMonitorArm.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
            //            imgMonitorArm.Visible = true;
            //        }
            //    }

            //}
            if (ViewState["MonitorArm"] != null)
            {
                intDeskGroup = Convert.ToInt32(ViewState["MonitorArm"]);
                //  lblDeskColor.Text = intDeskGroup.ToString();
                DataTable dt = sdb.getIdOptionGroupSelect(intDeskGroup, intSelect);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        intIdOption = Convert.ToInt32(dr["idOption"]);
                        ViewState["MonitorArmSelect"] = intIdOption;
                        //  ViewState["deskcolor"] = intIdOption.ToString();
                        //    ViewState["desklegcolortext"] = dr["Material"].ToString();
                        //  intIdOptionGroup = Convert.ToInt32(dr["Expr1"]);
                        //   ViewState["Caster"] = intIdOptionGroup.ToString();
                        imgURL = dr["imgURLPng"].ToString();
                        imgMonitorArm.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
                        imgMonitorArm.Visible = true;
                    }
                }

                getMonitorTypeSub();
              
            }

        }

    }

    protected void rdoMonitorTypeSub_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoMonitorTypeSub.SelectedIndex != -1)
        {
            int intSelect = Convert.ToInt32(rdoMonitorTypeSub.SelectedValue);
            int intIdOption = 0;
            int intIdProduct = 0;
            int intIdOptionGroup = 0;
            int intIdOptionCategory = 16;

            if (ViewState["MonitorArmSelect"] != null)
            {
                intDeskGroup = Convert.ToInt32(ViewState["MonitorArmSelect"]);
             
                DataTable dt = sdb.getOptionColorMatchSelect(intDeskGroup, intIdOptionCategory, intSelect);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        intIdOption = Convert.ToInt32(dr["idOption"]);
                        // ViewState["deskcolor"] = intIdOption.ToString();
                        //ViewState["DeskLegSelect"] = intIdOption.ToString();
                        //ViewState["desklegcolortext"] = dr["Material"].ToString();
                        //intIdOptionGroup = Convert.ToInt32(dr["Expr1"]);
                        //ViewState["MoldingType"] = intIdOptionGroup.ToString();
                        imgURL = dr["imgURLPng"].ToString();
                        imgMonitorArmSub.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
                        imgMonitorArmSub.Visible = true;

                    }

                }

            }
        }
        else
        {

            imgMonitorArmSub.Visible = false;
        }
    }


    protected void rdoDeskBottomPanel_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoDeskBottomPanel.SelectedIndex != -1)
        {
            int intIdOptionCategory = 9;
            int intIdBaseColor = 0;
            int intIdOption = 0;
            int intSelect = 0;
            int intIdOptionGroup = 0;
            string imgLeg = String.Empty;
            intSelect = Convert.ToInt32(rdoDeskBottomPanel.SelectedValue);

            if (intSelect == 1)
            {
                imgDeskBottomMoldingColor.Visible = false;
                imgDeskBottomPanel.Visible = false;


            }
            else
            {
                if (ViewState["deskcolorSelect"] != null)
                {
                    // intDeskGroup = Convert.ToInt32(ViewState["Caster"]);
                    //  lblDeskColor.Text = intDeskGroup.ToString();
                    //DataTable dt = sdb.getIdOptionGroup(intDeskGroup);

                    intIdBaseColor = Convert.ToInt32(ViewState["deskcolorSelect"]);
                    // lblDeskCaster.Text = "what is  ViewState[deskmetal] option " + intIdBaseColor.ToString();
                    DataTable dt = sdb.getOptionColorMatchSelect(intIdBaseColor, intIdOptionCategory, intSelect);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            intIdOption = Convert.ToInt32(dr["idOption"]);
                            ViewState["DeskBottomSelect"] = intIdOption.ToString();
                            //    ViewState["desklegcolortext"] = dr["Material"].ToString();
                            //  intIdOptionGroup = Convert.ToInt32(dr["Expr1"]);
                            //   ViewState["Caster"] = intIdOptionGroup.ToString();
                            imgURL = dr["imgURLPng"].ToString();

                            imgDeskBottomPanel.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
                            imgDeskBottomPanel.Visible = true;


                        }
                    }
                    getCasterExtra();
                    HideSelection();
                }
                

            }

           

        }
    }




    protected void rdoDeskLeg_SelectedIndexChanged(object sender, EventArgs e)
    {
        int intIdOption = 0;
        int intIdOptionGroup = 0;
        int intColorOptionSelect = 0;
        if (rdoDeskLeg.SelectedIndex != -1)
        {
            int intSelect = Convert.ToInt32(rdoDeskLeg.SelectedValue);
            if (ViewState["DeskLeg"] != null)
            {
                intColorOptionSelect = Convert.ToInt32(ViewState["DeskLeg"]);
                //  lblDeskLeg.Text = intColorOptionSelect.ToString();
                DataTable dt = sdb.getIdOptionGroupSelect(intColorOptionSelect, intSelect);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        intIdOption = Convert.ToInt32(dr["idOption"]);
                        // ViewState["deskcolor"] = intIdOption.ToString();
                        ViewState["DeskLegSelect"] = intIdOption.ToString();
                        ViewState["desklegcolortext"] = dr["Material"].ToString();
                        intIdOptionGroup = Convert.ToInt32(dr["Expr1"]);
                        ViewState["MoldingType"] = intIdOptionGroup.ToString();
                        imgURL = dr["imgURLPng"].ToString();
                        imgDeskLeg.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
                        imgDeskLeg.Visible = true;

                        imgTopShelfMoldingColor.Visible = false;
                        imgDeskCabinetFrameColor.Visible = false;
                        imgCabinet.Visible = false;
                    }

                }
               getCaster();
            }


        }
        else
        {
            imgDeskLeg.Visible = false;
            imgCaster.Visible = false;
           
           

        }
     
    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView gv = (GridView)sender;
        Int32 rowIndex = Convert.ToInt32(e.CommandArgument.ToString());

        Cart = (DataTable)Session["SelectPrice"];
        DataRow dr = Cart.NewRow();
        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow selectedRow = ((GridView)e.CommandSource).Rows[index];

        //Label courseNumber1 = (Label)selectedRow.FindControl("lblMaterial");
        courseNumber1 = selectedRow.Cells[1].Text;
        courseName1 = selectedRow.Cells[2].Text;

        CartView = new DataView(Cart);
        if (e.CommandName == "RemoveFromCart")
        {
            CartView.RowFilter = "Material='" + courseNumber1 + "'";

            if (CartView.Count > 0) CartView.Delete(0);
            CartView.RowFilter = "";
            if (CartView.Count == 0)
            {
                //pnlTutitionTotal.Visible = false;

            }
        }
        GridView1.DataSource = CartView;
        GridView1.DataBind();
    }


    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.Header)
        {
            //e.Row.Cells[1].Visible = false;
            //e.Row.Cells[3].Visible = false;
            //e.Row.Cells[4].Visible = false;
            //e.Row.Cells[5].Visible = false;

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            //Label lblPriceC = (Label)e.Row.FindControl("lblTotalPrice");
            decimal decTotal = 0;
            //decTotal = totalPriceFooter;
            ViewState["decTotal"] = decTotal;
            e.Row.Cells[3].Font.Bold = true;
           // e.Row.Cells[3].Text = decTotal.ToString("F");
            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
            e.Row.Cells[3].BackColor = System.Drawing.Color.Yellow;

            //lblPriceC.Text = totalPriceFooter.ToString();
            //lblPriceC.BackColor = System.Drawing.Color.Yellow;
            //e.Row.Cells[3].Visible = false;
            //e.Row.Cells[4].Visible = false;
            //e.Row.Cells[5].Visible = false;

        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            decimal decPrice = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Selling_Price"));
            decimal decTotalPrice = Convert.ToDecimal(decPrice);
          //  totalPriceFooter += decTotalPrice;

            string strMaterialHTML = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Material"));
            // strFinal= Server.HtmlDecode(strMaterialHTML);
            string strMaterial = strMaterialHTML;
            e.Row.Cells[1].Text = strMaterial.ToString();


            string strDescriptionHTML = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Description"));
            //strFinal = Server.HtmlDecode(strDescriptionHTML);
         //   strFinal = strDescriptionHTML;
        //    e.Row.Cells[2].Text = strFinal.ToString();

           // e.Row.Cells[4].Text = intSKU1.ToString();
        }


    }

  
    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        //if (Profile.SCart == null)
        //{
        //    Profile.SCart = new ShoppingCartExample.Cart();
        //}

        int ProductID = 123;
        string strDescriptionLong = String.Empty;
        // Profile.SCart.Insert(ProductID, callTotal, decWeight, 1, strProductName, strDetails, strergo, strOptionText, douOpitonPriceV, strProductImageUrl);

        if (ViewState["desksizetext"] != "" || ViewState["desktopcolortext"] != "" || ViewState["desklegcolortext"] != "" || ViewState["deskmoldingcolortext"] != "")
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<br/>desk size: " + Convert.ToString(ViewState["desksizetext"]));
            sb.Append("<br/> top color: " + Convert.ToString(ViewState["desktopcolortext"].ToString()));
            sb.Append("<br/> leg color: " + Convert.ToString(ViewState["desklegcolortext"].ToString()));
            sb.Append("<br/> molding color: " + Convert.ToString(ViewState["deskmoldingcolortext"].ToString()));
            strDescriptionLong = sb.ToString();
        }

        Random rand = new Random();
    //    Profile.SCart.Insert(rand.Next(), 10,23,1, "configurator", strDescriptionLong, "configurator", "dfafgfdgfd",34,"REEageUrL");
        //  Server.Transfer(address+"UserCart.aspx");
        

       // int ProductID = intProductID;
      //  Profile.SCart.Insert(ProductID, callTotal, decWeight, 1, strProductName, strDetails, strergo, strOptionText, douOpitonPriceV, strProductImageUrl);
               
        Server.Transfer("../../UserCart.aspx");
    }







    

    protected void rdoCpuHolder_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoCpuHolder.SelectedIndex != -1)
        {
            int intSelect = Convert.ToInt32(rdoCpuHolder.SelectedValue);
            int intIdOption = 0;
            int intIdOptionGroup = 0;
            int intColorOptionSelect = 0;


            if (ViewState["CpuHolder"] != null)
            {
                intColorOptionSelect = Convert.ToInt32(ViewState["CpuHolder"]);
                //  lblDeskLeg.Text = intColorOptionSelect.ToString();
                DataTable dt = sdb.getIdOptionGroupSelect(intColorOptionSelect, intSelect);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        intIdOption = Convert.ToInt32(dr["idOption"]);

                        imgURL = dr["imgURLPng"].ToString();
                        imgCpuHolder.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
                        imgCpuHolder.Visible = true;

                    }

                }

            }

            getPhoneArm();
            getTaskLight();
            getUSBhub();
            getCupHolder();
            getChkWireManagement();
            lblDeskAccessories.Text = "11. Accessories";
            lblDeskAccessories.Attributes.Add("class", "stepSegement");
            deskAccessories.Attributes.Add("class", "color-container1");
        
        }
        else
        {
            imgCpuHolder.Visible =false;

        }

    }



    protected void chkPhoneArm_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (chkPhoneArm.SelectedIndex != -1)
        {
            int intSelect = Convert.ToInt32(chkPhoneArm.SelectedValue);
            int intIdOption = 0;
            int intIdOptionGroup = 0;
            int intColorOptionSelect = 0;


            if (ViewState["PhoneArm"] != null)
            {
                intColorOptionSelect = Convert.ToInt32(ViewState["PhoneArm"]);
                //  lblDeskLeg.Text = intColorOptionSelect.ToString();
                DataTable dt = sdb.getIdOptionGroupSelect(intColorOptionSelect, intSelect);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        intIdOption = Convert.ToInt32(dr["idOption"]);

                        imgURL = dr["imgURLPng"].ToString();
                        imgPhoneArm.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
                        imgPhoneArm.Visible = true;

                    }

                }

            }
        }
        else
        { imgPhoneArm.Visible =false; }
    }

    protected void chkTaskLight_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (chkTaskLight.SelectedIndex != -1)
        {
            int intSelect = Convert.ToInt32(chkTaskLight.SelectedValue);
            int intIdOption = 0;
            int intIdOptionGroup = 0;
            int intColorOptionSelect = 0;


            if (ViewState["TaskLight"] != null)
            {
                intColorOptionSelect = Convert.ToInt32(ViewState["TaskLight"]);
                //  lblDeskLeg.Text = intColorOptionSelect.ToString();
                DataTable dt = sdb.getIdOptionGroupSelect(intColorOptionSelect, intSelect);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        intIdOption = Convert.ToInt32(dr["idOption"]);

                        imgURL = dr["imgURLPng"].ToString();
                        imgTaskLight.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
                        imgTaskLight.Visible = true;

                    }

                }

            }


        }
        else
        {
            imgTaskLight.Visible = false;

        }
    }

   
    protected void chkCupHolder_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (chkCupHolder.SelectedIndex != -1)
        {
            int intSelect = Convert.ToInt32(chkCupHolder.SelectedValue);
            int intIdOption = 0;
            int intIdOptionGroup = 0;
            int intColorOptionSelect = 0;


            if (ViewState["CupHolder"] != null)
            {
                intColorOptionSelect = Convert.ToInt32(ViewState["CupHolder"]);
                //  lblDeskLeg.Text = intColorOptionSelect.ToString();
                DataTable dt = sdb.getIdOptionGroupSelect(intColorOptionSelect, intSelect);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        intIdOption = Convert.ToInt32(dr["idOption"]);

                        imgURL = dr["imgURLPng"].ToString();
                        imgCupHolder.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
                        imgCupHolder.Visible = true;

                    }

                }

            }


        }
        else
        {
            imgCupHolder.Visible = false;

        }
    }

    protected void chkUSBhub_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (chkUSBhub.SelectedIndex != -1)
        {
            int intSelect = Convert.ToInt32(chkUSBhub.SelectedValue);
            int intIdOption = 0;
            int intIdOptionGroup = 0;
            int intColorOptionSelect = 0;


            if (ViewState["USBhub"] != null)
            {
                intColorOptionSelect = Convert.ToInt32(ViewState["USBhub"]);
                //  lblDeskLeg.Text = intColorOptionSelect.ToString();
                DataTable dt = sdb.getIdOptionGroupSelect(intColorOptionSelect, intSelect);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        intIdOption = Convert.ToInt32(dr["idOption"]);

                        imgURL = dr["imgURLPng"].ToString();
                        imgUSBhub.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
                        imgUSBhub.Visible = true;

                    }

                }

            }


        }
        else
        {
            imgUSBhub.Visible = false;

        }
    }

    protected void chkWireManagement_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (chkWireManagement.SelectedIndex != -1)
        {
            int intSelect = Convert.ToInt32(chkWireManagement.SelectedValue);
            int intIdOption = 0;
            int intIdOptionGroup = 0;
            int intColorOptionSelect = 0;


            if (ViewState["Wiremanagement"] != null)
            {
                intColorOptionSelect = Convert.ToInt32(ViewState["Wiremanagement"]);
                //  lblDeskLeg.Text = intColorOptionSelect.ToString();
                DataTable dt = sdb.getIdOptionGroupSelect(intColorOptionSelect, intSelect);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        intIdOption = Convert.ToInt32(dr["idOption"]);

                        imgURL = dr["imgURLPng"].ToString();
                        imgWiremanagement.ImageUrl = address + "Configurator/Desk/imgPng/" + imgURL.ToString();
                        imgWiremanagement.Visible = true;

                    }

                }

            }


        }
        else
        {
            imgWiremanagement.Visible = false;

        }
    }
}



