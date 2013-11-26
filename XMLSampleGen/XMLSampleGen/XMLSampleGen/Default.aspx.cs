using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.Configuration;



namespace XMLSampleGen
{
    public partial class _Default : System.Web.UI.Page
    {

        int rowcount1 = 0, rowcount2 = 0, rowcount3 = 0, rowcount4 = 0, rowcount5 = 0, rowcount6 = 0;
        string Bid = "", Bname = "", Bnameid = "", BLocale = "", BLocalName = "";
        string Cid = "", Cname = "", CpgUrl = "", CimgUrl = "", Cnameid = "", Clocale = "", CLocalName = "", CLocalpgUrl = "", ClocalimgUrl = "";
        string Pid = "", PBid = "", PCid = "", Pname = "", PDesc = "", PpgUrl = "", PimgUrl = "", Pnameid = "", Plocale = "", PLocalName = "", PLocalDesc = "", PLocalpgUrl = "", PlocalimgUrl = "";
        string Pmodel = "", Pmanufacturer = "", PEANs = "", PUPCs = "", PattributeId = "", PattributeValue = "";

        string conn = ConfigurationManager.ConnectionStrings["XMLConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
        }

        protected void btnXmlGeneration_Click(object sender, EventArgs e)
        {

            //Creating XML file
            XmlTextWriter xwriter = new XmlTextWriter("D:/ProductFeed.xml", Encoding.UTF8);
            XDeclaration xdecl = new XDeclaration("1.0", "utf-8", "true");
            xwriter.WriteStartDocument();
            xwriter.WriteStartElement("Feed");

            SqlConnection con = new SqlConnection(conn);
            //con.ConnectionString = "Data Source=SYSTEM005-PC\\SQLEXPRESS;Initial Catalog=sampleweb;Integrated Security=True;Pooling=False";
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT * from tblBrands", con);
            DataSet ds1 = new DataSet();
            ds1.DataSetName = "set1";
            da1.Fill(ds1);
            con.Close();

            
            #region brand definition

            rowcount1 = 0;
            rowcount1 = ds1.Tables[0].Rows.Count;
            Bid = Bname = Bnameid = "";

            //Create Parent element
            xwriter.WriteStartElement("Brands");


            for (int i = 0; i < rowcount1; i++)
            {
                Bid = ds1.Tables[0].Rows[i][0].ToString();
                Bname = ds1.Tables[0].Rows[i][1].ToString();
                Bnameid = ds1.Tables[0].Rows[i][2].ToString();

                xwriter.WriteStartElement("Brand");

                xwriter.WriteElementString("ExternalId", Bid);
                xwriter.WriteElementString("Name", Bname);

                con.Open();
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT * from BNameList where BNameId ='" + Bnameid + "'", con);
                DataSet ds2 = new DataSet();
                ds2.DataSetName = "set2";
                da2.Fill(ds2);
                con.Close();
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    rowcount2 = 0;
                    rowcount2 = ds2.Tables[0].Rows.Count;
                    xwriter.WriteStartElement("Names");
                    for (int m = 0; m < rowcount2; m++)
                    {
                        BLocale = ds2.Tables[0].Rows[m][1].ToString();
                        BLocalName = ds2.Tables[0].Rows[m][2].ToString();

                        xwriter.WriteStartElement("Name");
                        xwriter.WriteAttributeString("Locale", BLocale);
                        xwriter.WriteString(BLocalName);
                        xwriter.WriteEndElement(); //name
                    }
                    xwriter.WriteEndElement();//names
                }

                xwriter.WriteEndElement();//brand
                ds2.Dispose();
            }

            xwriter.WriteEndElement();//brands
            ds1.Dispose();

            #endregion

            //////category
            # region category definition

            con.Open();
            SqlDataAdapter da3 = new SqlDataAdapter("SELECT * from tblCategory", con);
            DataSet ds3 = new DataSet();
            ds3.DataSetName = "set3";
            da3.Fill(ds3);
            con.Close();

            rowcount3 = 0;
            rowcount3 = ds3.Tables[0].Rows.Count;
            Cid = Cname = CpgUrl = CimgUrl = Cnameid = "";

            xwriter.WriteStartElement("Categories");

            for (int n = 0; n < rowcount3; n++)
            {
                Cid = ds3.Tables[0].Rows[n][0].ToString();
                Cname = ds3.Tables[0].Rows[n][1].ToString();
                CpgUrl = ds3.Tables[0].Rows[n][2].ToString();
                CimgUrl = ds3.Tables[0].Rows[n][3].ToString();
                Cnameid = ds3.Tables[0].Rows[n][4].ToString();

                xwriter.WriteStartElement("Category");

                xwriter.WriteElementString("ExternalId", Cid);
                xwriter.WriteElementString("Name", Cname);

                con.Open();
                SqlDataAdapter da4 = new SqlDataAdapter("SELECT * from CnameList where CnameId ='" + Cnameid + "'", con);
                DataSet ds4 = new DataSet();
                ds4.DataSetName = "set4";
                da4.Fill(ds4);
                con.Close();

                // category Name
                if (ds4.Tables[0].Rows.Count > 0)
                {
                    rowcount4 = 0;
                    rowcount4 = ds4.Tables[0].Rows.Count;
                    xwriter.WriteStartElement("Names");
                    Clocale = CLocalName = "";
                    for (int j = 0; j < rowcount4; j++)
                    {
                        Clocale = ds4.Tables[0].Rows[j][1].ToString();
                        CLocalName = ds4.Tables[0].Rows[j][2].ToString();

                        xwriter.WriteStartElement("Name");
                        xwriter.WriteAttributeString("Locale", Clocale);
                        xwriter.WriteString(CLocalName);
                        xwriter.WriteEndElement();//name
                    }
                    xwriter.WriteEndElement();//names
                }

                xwriter.WriteElementString("CategoryPageUrl", CpgUrl);

                // category page url
                Clocale = CLocalpgUrl = "";
                if (ds4.Tables[0].Rows.Count > 0)
                {
                    rowcount4 = 0;
                    rowcount4 = ds4.Tables[0].Rows.Count;
                    xwriter.WriteStartElement("CategoryPageUrls");
                    Clocale = CLocalName = "";
                    for (int k = 0; k < rowcount4; k++)
                    {
                        Clocale = ds4.Tables[0].Rows[k][0].ToString();
                        CLocalpgUrl = ds4.Tables[0].Rows[k][2].ToString();

                        xwriter.WriteStartElement("CategoryPageUrl");
                        xwriter.WriteAttributeString("Locale", Clocale);
                        xwriter.WriteString(CLocalpgUrl);
                        xwriter.WriteEndElement();//CategoryPageUrl
                    }
                    xwriter.WriteEndElement();//CategoryPageUrls
                }

                // Category image url
                xwriter.WriteElementString("ImageUrl", CpgUrl);


                Clocale = ClocalimgUrl = "";
                if (ds4.Tables[0].Rows.Count > 0)
                {
                    rowcount4 = 0;
                    rowcount4 = ds4.Tables[0].Rows.Count;
                    xwriter.WriteStartElement("ImageUrls");
                    Clocale = CLocalName = "";
                    for (int k = 0; k < rowcount4; k++)
                    {
                        Clocale = ds4.Tables[0].Rows[k][0].ToString();
                        ClocalimgUrl = ds4.Tables[0].Rows[k][3].ToString();

                        xwriter.WriteStartElement("ImageUrl");
                        xwriter.WriteAttributeString("Locale", Clocale);
                        xwriter.WriteString(ClocalimgUrl);
                        xwriter.WriteEndElement();//ImageUrl
                    }
                    xwriter.WriteEndElement();//ImageUrls
                }

                xwriter.WriteEndElement(); //Category
            }

            xwriter.WriteEndElement();//catergoires

            #endregion

           
            # region Product definition

            con.Open();
            SqlDataAdapter da5 = new SqlDataAdapter("SELECT * from tblProduct", con);
            DataSet ds5 = new DataSet();
            ds5.DataSetName = "set5";
            da5.Fill(ds5);
            con.Close();

            rowcount5 = 0;
            rowcount5 = ds5.Tables[0].Rows.Count;
            Pid = PBid = PCid = Pname = PDesc = PpgUrl = PimgUrl = Pnameid = "";

            xwriter.WriteStartElement("Products");
            #region sample1
            for (int l = 0; l < rowcount5; l++)
            {
                Pid = ds5.Tables[0].Rows[l][0].ToString();
                PBid = ds5.Tables[0].Rows[l][1].ToString();
                PCid = ds5.Tables[0].Rows[l][2].ToString();
                Pname = ds5.Tables[0].Rows[l][3].ToString();
                PDesc = ds5.Tables[0].Rows[l][4].ToString();
                PpgUrl = ds5.Tables[0].Rows[l][5].ToString();
                PimgUrl = ds5.Tables[0].Rows[l][6].ToString();
                Pnameid = ds5.Tables[0].Rows[l][7].ToString();

                xwriter.WriteStartElement("Product");

                xwriter.WriteElementString("ExternalId", Pid);
                xwriter.WriteElementString("Name", PBid);

                con.Open();
                SqlDataAdapter da6 = new SqlDataAdapter("SELECT * from PNameList where PnameId ='" + Pnameid + "'", con);
                DataSet ds6 = new DataSet();
                ds6.DataSetName = "set6";
                da6.Fill(ds6);
                con.Close();
                #region product name
                // Product Name
                if (ds6.Tables[0].Rows.Count > 0)
                {
                    rowcount6 = 0;
                    rowcount6 = ds6.Tables[0].Rows.Count;
                    xwriter.WriteStartElement("Names");

                    Plocale = PLocalName = PLocalDesc = PLocalpgUrl = PlocalimgUrl = "";

                    for (int x = 0; x < rowcount6; x++)
                    {
                        Plocale = ds6.Tables[0].Rows[x][1].ToString();
                        PLocalName = ds6.Tables[0].Rows[x][2].ToString();

                        xwriter.WriteStartElement("Name");
                        xwriter.WriteAttributeString("Locale", Plocale);
                        xwriter.WriteString(PLocalName);
                        xwriter.WriteEndElement();//name
                    }
                    xwriter.WriteEndElement();//names
                }

                #endregion

                xwriter.WriteElementString("Description", PDesc);

                #region category
                // category Description
                if (ds6.Tables[0].Rows.Count > 0)
                {
                    rowcount6 = 0;
                    rowcount6 = ds6.Tables[0].Rows.Count;
                    xwriter.WriteStartElement("Descriptions");
                    Plocale = "";
                    for (int y = 0; y < rowcount6; y++)
                    {
                        Plocale = ds6.Tables[0].Rows[y][1].ToString();
                        PLocalDesc = ds6.Tables[0].Rows[y][3].ToString();

                        xwriter.WriteStartElement("Description");
                        xwriter.WriteAttributeString("Locale", Plocale);
                        xwriter.WriteString(PLocalDesc);
                        xwriter.WriteEndElement();//description
                    }
                    xwriter.WriteEndElement();//Descriptions
                }
                #endregion
                // Category page url
                xwriter.WriteElementString("ProductPageUrl", PpgUrl);

                #region Productpageruls
                Plocale = "";
                if (ds6.Tables[0].Rows.Count > 0)
                {
                    rowcount6 = 0;
                    rowcount6 = ds6.Tables[0].Rows.Count;
                    xwriter.WriteStartElement("ProductPageUrls");
                    for (int z = 0; z < rowcount6; z++)
                    {
                        Plocale = ds6.Tables[0].Rows[z][1].ToString();
                        PLocalpgUrl = ds6.Tables[0].Rows[z][4].ToString();

                        xwriter.WriteStartElement("ProductPageUrl");
                        xwriter.WriteAttributeString("Locale", Plocale);
                        xwriter.WriteString(PLocalpgUrl);
                        xwriter.WriteEndElement();//ProductPageUrl
                    }
                    xwriter.WriteEndElement();//ProductPageUrls
                }

                #endregion

                // Category image url
                xwriter.WriteElementString("ImageUrl", PpgUrl);

                #region image
                Plocale = "";
                if (ds6.Tables[0].Rows.Count > 0)
                {
                    rowcount6 = 0;
                    rowcount6 = ds6.Tables[0].Rows.Count;
                    xwriter.WriteStartElement("ImageUrls");
                    for (int z = 0; z < rowcount6; z++)
                    {
                        Plocale = ds6.Tables[0].Rows[z][1].ToString();
                        PlocalimgUrl = ds6.Tables[0].Rows[z][5].ToString();

                        xwriter.WriteStartElement("ImageUrl");
                        xwriter.WriteAttributeString("Locale", Plocale);
                        xwriter.WriteString(PlocalimgUrl);
                        xwriter.WriteEndElement();//ImageUrl
                    }
                    xwriter.WriteEndElement();//ImageUrls
                }
                #endregion

                #region category model
                // Category Model Number

                con.Open();
                SqlDataAdapter da7 = new SqlDataAdapter("SELECT * from PModelNumber where PnameId ='" + Pnameid + "'", con);
                DataSet ds7 = new DataSet();
                ds7.DataSetName = "set7";
                da7.Fill(ds7);
                con.Close();

                Pmodel = "";
                if (ds7.Tables[0].Rows.Count > 0)
                {
                    rowcount6 = 0;
                    rowcount6 = ds7.Tables[0].Rows.Count;
                    xwriter.WriteStartElement("ModelNumbers");

                    for (int z = 0; z < rowcount6; z++)
                    {

                        Pmodel = ds7.Tables[0].Rows[z][1].ToString();

                        xwriter.WriteStartElement("ModelNumber");
                        xwriter.WriteString(Pmodel);
                        xwriter.WriteEndElement();//ModelNumber
                    }
                    xwriter.WriteEndElement();//ModelNumbers
                }

                #endregion

                // Category Manufacture part number
                #region category manufacture
                con.Open();
                SqlDataAdapter da8 = new SqlDataAdapter("SELECT * from PManufacturerPartNumber where PnameId ='" + Pnameid + "'", con);
                DataSet ds8 = new DataSet();
                ds8.DataSetName = "set8";
                da8.Fill(ds8);
                con.Close();

                Pmanufacturer = "";
                if (ds8.Tables[0].Rows.Count > 0)
                {
                    rowcount6 = 0;
                    rowcount6 = ds8.Tables[0].Rows.Count;
                    xwriter.WriteStartElement("ManufacturerPartNumbers");

                    for (int z = 0; z < rowcount6; z++)
                    {

                        Pmodel = ds8.Tables[0].Rows[z][1].ToString();

                        xwriter.WriteStartElement("ManufacturerPartNumber");
                        xwriter.WriteString(Pmanufacturer);
                        xwriter.WriteEndElement();//ManufacturerPartNumber
                    }
                    xwriter.WriteEndElement();//ManufacturerPartNumbers
                }

                #endregion
                // Category EANs

                #region category eans
                con.Open();
                SqlDataAdapter da9 = new SqlDataAdapter("SELECT * from PEANs where PnameId ='" + Pnameid + "'", con);
                DataSet ds9 = new DataSet();
                ds9.DataSetName = "set9";
                da9.Fill(ds9);
                con.Close();

                PEANs = "";
                if (ds9.Tables[0].Rows.Count > 0)
                {
                    rowcount6 = 0;
                    rowcount6 = ds9.Tables[0].Rows.Count;
                    xwriter.WriteStartElement("EANs");

                    for (int z = 0; z < rowcount6; z++)
                    {

                        PEANs = ds9.Tables[0].Rows[z][1].ToString();

                        xwriter.WriteStartElement("EAN");
                        xwriter.WriteString(PEANs);
                        xwriter.WriteEndElement();//EAN
                    }
                    xwriter.WriteEndElement();//EANs
                }
                #endregion

                #region category upcs

                // Category UPCs

                con.Open();
                SqlDataAdapter da10 = new SqlDataAdapter("SELECT * from PUPCs where PnameId ='" + Pnameid + "'", con);
                DataSet ds10 = new DataSet();
                ds10.DataSetName = "set10";
                da10.Fill(ds10);
                con.Close();

                PUPCs = "";
                if (ds10.Tables[0].Rows.Count > 0)
                {
                    rowcount6 = 0;
                    rowcount6 = ds10.Tables[0].Rows.Count;
                    xwriter.WriteStartElement("UPCs");

                    for (int z = 0; z < rowcount6; z++)
                    {

                        PUPCs = ds10.Tables[0].Rows[z][1].ToString();

                        xwriter.WriteStartElement("UPC");
                        xwriter.WriteString(PUPCs);
                        xwriter.WriteEndElement();//UPC
                    }
                    xwriter.WriteEndElement();//UPCs
                }

                #endregion


                // Category Attributes
                #region catergory attributes
                con.Open();
                SqlDataAdapter da11 = new SqlDataAdapter("SELECT * from PAttribute where PnameId ='" + Pnameid + "'", con);
                DataSet ds11 = new DataSet();
                ds11.DataSetName = "set11";
                da11.Fill(ds11);
                con.Close();

                PattributeId = "";
                if (ds11.Tables[0].Rows.Count > 0)
                {
                    rowcount6 = 0;
                    rowcount6 = ds11.Tables[0].Rows.Count;
                    xwriter.WriteStartElement("Attributes");

                    for (int z = 0; z < rowcount6; z++)
                    {

                        PattributeId = ds11.Tables[0].Rows[z][1].ToString();

                        xwriter.WriteStartElement("Attribute");
                        xwriter.WriteString(PattributeId);
                        xwriter.WriteEndElement();//Attribute
                    }
                    xwriter.WriteEndElement();//Attributes
                }
                #endregion
                
                
                xwriter.WriteEndElement();//product


                ////////
            }
            #endregion

            xwriter.WriteEndElement();//products

            #endregion


            //////Closing document
            xwriter.WriteEndElement();//feed

            xwriter.Close();
            //////SqlConnection con = new SqlConnection();
            //////con.ConnectionString = "Data Source=SYSTEM005-PC\\SQLEXPRESS;Initial Catalog=sampleweb;Integrated Security=True;Pooling=False";
            //////con.Open();
            //////SqlDataAdapter da1 = new SqlDataAdapter("SELECT * from tblXmlGen", con);
            //////DataSet ds1 = new DataSet();
            //////ds1.DataSetName = "set1";
            //////da1.Fill(ds1);
            //////con.Close();
            //////rowcount1 = 0;
            //////rowcount1 = ds1.Tables[0].Rows.Count;

            //////for (int i = 0; i < rowcount1; i++)
            //////{
            //////    strTbl = ds1.Tables[0].Rows[0][0].ToString();

            //////    xmlGenFun();
            //////}

            lblStatus.Visible=true;
            lblStatus.Text = "XML Product Feed File Generated successfully.";

        }



        public void xmlBrandGenFun()
        {

        }


        public void xmlGenFun()
        {
            //// SqlConnection cons = new SqlConnection();
            //// cons.ConnectionString = "Data Source=SYSTEM005-PC\\SQLEXPRESS;Initial Catalog=sampleweb;Integrated Security=True;Pooling=False";
            //// cons.Open();
            //// SqlDataAdapter da2 = new SqlDataAdapter("SELECT * from "+ strTbl , cons);
            //// DataSet ds2 = new DataSet();
            //// ds2.DataSetName = "set2";
            //// da2.Fill(ds2);
            //// cons.Close();
            //////// xml coding
            //// ds2.WriteXml("C:/Prefile.xml");

            //// StreamReader fread = new StreamReader(@"C:/Prefile.xml");

            //// using (System.IO.StreamWriter fwrite = new System.IO.StreamWriter(@"C:/ProductFeed.xml", true))
            //// {
            ////     //file.WriteLine(fread.ToString());
            ////     fwrite.WriteLine(fread.ReadToEnd());
            ////     fwrite.Dispose();
            //// }

            //// fread.Dispose();



        }

    }
}
