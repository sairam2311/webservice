using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace TSIIC
{
    public partial class index : System.Web.UI.Page
    {
       // private sqlconn _connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["conStringArcgis"].ConnectionString);

        public static readonly string _connection = Convert.ToString(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"]);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                getdata();
               
               
               
            }

        }

        public void getdata()
        {
          
            SqlConnection conn = new SqlConnection(_connection);
            //conn.Open();

            //DataTable dt = Select_All_Data("parks_boundary1", "CID,CAST( CAST( geometry::STGeomFromWKB(geom.STAsBinary(),4326).STAsText() as geography) as geography) AS A", "", "", "", "");
            // GEOMETRY::STGeomFromWKB( GEOGRAPHY::STGeomFromText(geom.MakeValid().STAsText(), 4326).STAsBinary(),4326) as geom", "","","", "");


            using (SqlConnection con = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand("select * from parks_boundary_2 where flag = '0' and park_name != ''", con))


                //"select  st_name,st_lgc,dist_lgc,dist_cencd,sub_dist,vname,park_name,park_sd,land_cat,land_avail,park_type,poll_cat,envtclob,LandSale_M,LandSale_1,LandLease_,LandLease1,LeaseRenta,LeasePerio,TotalPlots,average__1,PlotsAlloc,Plots_vaca,total_land, sector,mixed_sect,sub_sector,nh,dist_nh,railst,dist_rails,airport,dist_airpo,seaport,dist_seapo,drytport,dist_drytp,zonal,dist_zonal,police_st,dist_polic,fire_st,dist_fire_,bank,dist_bank,hospital,dist_hospi,elec_avai,elec_cap,elec_uti,water_avai,water_cap,water_uti,gas_avai,gas_uti,stp_avai,stp_uti,elec_pole_,powerss_av,powerss_ca,powerss_ut,wtp_avai,wtp_cap,wtp_uti,ict_avai,ict_speed,swd_avai,swd_cap,swd_uti,dha,pta,oth_info,adm_name,adm_desi,adm_email,adm_phone,mkt_name,mkt_email,mkt_phone,project_ur,url_enquir,url_land_a,entry_date,geom, sh, dist_sh from parks_boundary ", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ada = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            ada.Fill(dt);
                            // int jm = dt.Rows[2]["nh"].ToString() == "" || dt.Rows[2]["nh"].ToString() == "Null" ? 0 : Convert.ToInt32(dt.Rows[2]["LandSale_M"]);
                            //string data = (string)dt.Rows[0][1];

                          // DataTable dt2 = convertjsongrid(dt);

                            GridView1.DataSource = dt;
                            GridView1.DataBind();

                            Session["myTable"] = dt;

                        }
                    }
                }
            }


            // GridView1.DataSource = dt;
            // GridView1.DataBind();

            //for (int i = 0; i < Table.Rows.Count - 1; i++) //Looping through rows
            //{
            //    var myValue = Table.Rows[i]["MyFieldName"]; //Getting my field value

            //}



        }


        public DataTable convertjsongrid(DataTable dt)
        {
            DataTable dtdestination = new DataTable();
            DataColumn dc = new DataColumn();
            //dc.ColumnName = "Park Name";
            //dc.ColumnName = "Json";
            dtdestination.Columns.Add("Park Name", typeof(System.String));
            dtdestination.Columns.Add("Json", typeof(System.String));
            //for (int i = 0; i < dtExcelData.Rows.Count; i++)
            //{
            //    if (dtExcelData.Rows[i]["F15"].ToString().ToLower() == "nil")
            //    {
            //        dtExcelData.Rows[i]["F15"] = "0";
            //    }
            //    if (dtExcelData.Rows[i][5].ToString().ToLower() == "-")
            //    {
            //        dtExcelData.Rows[i][5] = "0";
            //    }
            //    if (dtExcelData.Rows[i][6].ToString().ToLower() == "nil")
            //    {
            //        dtExcelData.Rows[i][6] = "0";
            //    }
            //    if (dtExcelData.Rows[i][4].ToString().ToLower() == "nil")
            //    {
            //        dtExcelData.Rows[i][4] = "0";
            //    }
            //}


            for (int i = 0; i<dt.Rows.Count;i++)
            {
                var arlist2 = new ArrayList()
                {
                    dt.Rows[i]["mixed_sect"].ToString()
                };

                string hmacstr = "uZaPDgrKRJ2B6M3d6guTM9xjNkEt8J2Q" + dt.Rows[i]["st_lgc"].ToString() + dt.Rows[i]["dist_lgc"].ToString() + dt.Rows[i]["park_name"].ToString() + dt.Rows[i]["park_type"].ToString() + dt.Rows[i]["land_cat"].ToString();

                var hmacfinal = ComputeSha256Hash(hmacstr);


               var inputdata = new
                {
                st_lgc = dt.Rows[i]["st_lgc"].ToString(),
                agcy_code = "",
                dist_name = dt.Rows[i]["st_name"].ToString(),
                dist_lgc = dt.Rows[i]["dist_lgc"].ToString(),
                dist_cencd = dt.Rows[i]["dist_cencd"].ToString(),
                sub_dist = dt.Rows[i]["sub_dist"].ToString(),
                vname = dt.Rows[i]["vname"].ToString(),
                park_name = dt.Rows[i]["park_name"].ToString(),
                park_sd = dt.Rows[i]["park_sd"].ToString(),
                land_cat = dt.Rows[i]["land_cat"].ToString(),

                park_type = dt.Rows[i]["park_type"].ToString(),
                poll_cat = dt.Rows[i]["poll_cat"].ToString(),
                envtclob = dt.Rows[i]["envtclob"].ToString(),
                landsale_m = dt.Rows[i]["LandSale_M"].ToString () == "" ? 0 :  Convert.ToInt32(dt.Rows[i]["LandSale_M"]),
                landsale_1 = dt.Rows[i]["LandSale_1"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["LandSale_1"]),
                landlease_ = dt.Rows[i]["LandLease_"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["LandLease_"]),
                landlease1 = dt.Rows[i]["LandLease1"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["LandLease1"]),
                leaserenta = dt.Rows[i]["LeaseRenta"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["LeaseRenta"]),
                leaseperio = dt.Rows[i]["LeasePerio"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["LeasePerio"]),
                totalplots = dt.Rows[i]["TotalPlots"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["TotalPlots"]),
                average_si = dt.Rows[i]["average__1"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["average__1"]),
                plotsalloc = dt.Rows[i]["PlotsAlloc"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["PlotsAlloc"]),
                plots_vaca = dt.Rows[i]["Plots_vaca"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["Plots_vaca"]),
                land_avail = dt.Rows[i]["land_avail"].ToString() == "" ? 0 : Convert.ToDecimal(dt.Rows[i]["land_avail"]),
                total_land = dt.Rows[i]["total_land"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["total_land"]),
                sector = dt.Rows[i]["sector"].ToString(),
                mixesSectList = arlist2,
                sub_sector = dt.Rows[i]["sub_sector"].ToString(),
                nh = dt.Rows[i]["nh"].ToString(),
                dist_nh = dt.Rows[i]["dist_nh"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["dist_nh"]),
                sh = dt.Rows[i]["sh"].ToString(),
                dist_sh = dt.Rows[i]["dist_sh"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["dist_sh"]),
                railst = dt.Rows[i]["railst"].ToString(),
                dist_rails = dt.Rows[i]["dist_rails"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["dist_rails"]),
                airport = dt.Rows[i]["airport"].ToString(),
                dist_airpo = dt.Rows[i]["dist_airpo"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["dist_airpo"]),
                seaport = dt.Rows[i]["seaport"].ToString(),
                dist_seapo = dt.Rows[i]["dist_seapo"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["dist_seapo"]),
                drytport = dt.Rows[i]["drytport"].ToString(),
                dist_drytp = dt.Rows[i]["dist_drytp"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["dist_drytp"]),
                zonal = dt.Rows[i]["zonal"].ToString(),
                dist_zonal = dt.Rows[i]["dist_zonal"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["dist_zonal"]),
                police_st = dt.Rows[i]["police_st"].ToString(),
                dist_polic = dt.Rows[i]["dist_polic"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["dist_polic"]),
                fire_st = dt.Rows[i]["fire_st"].ToString(),
                dist_fire_ = dt.Rows[i]["dist_fire_"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["dist_fire_"]),
                bank = dt.Rows[i]["bank"].ToString(),
                dist_bank = dt.Rows[i]["dist_bank"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["dist_bank"]),
                hospital = dt.Rows[i]["hospital"].ToString(),
                dist_hospi = dt.Rows[i]["dist_hospi"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["dist_hospi"]),
                elec_avai = dt.Rows[i]["elec_avai"].ToString(),
                elec_cap = dt.Rows[i]["elec_cap"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["elec_cap"]),
                elec_uti = dt.Rows[i]["elec_uti"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["elec_uti"]),
                water_avai = dt.Rows[i]["water_avai"].ToString(),
                water_cap = dt.Rows[i]["water_cap"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["water_cap"]),
                water_uti = dt.Rows[i]["water_uti"].ToString(),
                gas_avai = dt.Rows[i]["gas_avai"].ToString(),
                gas_cap = dt.Rows[i]["gas_cap"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["gas_cap"]),
                gas_uti = dt.Rows[i]["gas_uti"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["gas_uti"]),
                stp_avai = dt.Rows[i]["stp_avai"].ToString(),

                stp_cap = dt.Rows[i]["stp_cap"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["stp_cap"]),
                stp_uti = dt.Rows[i]["stp_uti"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["stp_uti"]),
                elec_pole_ = dt.Rows[i]["elec_pole_"].ToString(),
                powerss_av = dt.Rows[i]["stp_avai"].ToString(),
                powerss_ca = dt.Rows[i]["powerss_ca"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["powerss_ca"]),
                powerss_ut = dt.Rows[i]["powerss_ut"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["powerss_ut"]),
                wtp_avai = dt.Rows[i]["wtp_avai"].ToString(),
                wtp_cap = dt.Rows[i]["wtp_cap"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["wtp_cap"]),
                wtp_uti = dt.Rows[i]["wtp_uti"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["wtp_uti"]),
                ict_avai = dt.Rows[i]["elec_pole_"].ToString(),
                ict_speed = dt.Rows[i]["ict_speed"].ToString(),
                swd_avai = dt.Rows[i]["swd_avai"].ToString(),
                swd_cap = dt.Rows[i]["swd_cap"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["swd_cap"]),
                swd_uti = dt.Rows[i]["swd_uti"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["swd_uti"]),
                dha = dt.Rows[i]["dha"].ToString(),
                pta = dt.Rows[i]["pta"].ToString(),
                oth_info = dt.Rows[i]["oth_info"].ToString(),
                adm_name = dt.Rows[i]["adm_name"].ToString(),
                adm_desi = dt.Rows[i]["adm_desi"].ToString(),
                adm_email = dt.Rows[i]["adm_email"].ToString(),
                adm_phone = dt.Rows[i]["adm_phone"].ToString(),
                mkt_name = dt.Rows[i]["mkt_name"].ToString(),
                mkt_desi = dt.Rows[i]["mkt_desi"].ToString(),
                mkt_email = dt.Rows[i]["mkt_email"].ToString(),
                mkt_phone = dt.Rows[i]["mkt_phone"].ToString(),
                project_ur = dt.Rows[i]["project_ur"].ToString(),
                url_enquir = dt.Rows[i]["url_enquir"].ToString(),
                url_land_a = dt.Rows[i]["url_land_a"].ToString(),
                public_pri = dt.Rows[i]["entry_date"].ToString(),
                geom = dt.Rows[i]["geom"].ToString(),
                dist_port = 0,
                port_name = "",
                data_owner_agency = " ",
                hmac = hmacfinal

               };

                string inputJson = (new JavaScriptSerializer()).Serialize(inputdata);
                HttpClient client = new HttpClient();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");

                DataRow drow = dtdestination.NewRow();
                drow["Park Name"] = dt.Rows[i]["park_name"].ToString();
                drow["Json"] = inputJson;

                dtdestination.Rows.Add(drow);

            }
            return dtdestination;
        }


        public void InsertData(string  condition)
        {

            string apiUrl = "https://iis.ncog.gov.in/IIS_api";
            DataTable dtdestination = new DataTable();
            DataColumn dc = new DataColumn();
            //dc.ColumnName = "Park Name";
            //dc.ColumnName = "Json";
            dtdestination.Columns.Add("Park Name", typeof(System.String));
            dtdestination.Columns.Add("Json", typeof(System.String));
            //for (int i = 0; i < dtExcelData.Rows.Count; i++)
            //{
            //    if (dtExcelData.Rows[i]["F15"].ToString().ToLower() == "nil")
            //    {
            //        dtExcelData.Rows[i]["F15"] = "0";
            //    }
            //    if (dtExcelData.Rows[i][5].ToString().ToLower() == "-")
            //    {
            //        dtExcelData.Rows[i][5] = "0";
            //    }
            //    if (dtExcelData.Rows[i][6].ToString().ToLower() == "nil")
            //    {
            //        dtExcelData.Rows[i][6] = "0";
            //    }
            //    if (dtExcelData.Rows[i][4].ToString().ToLower() == "nil")
            //    {
            //        dtExcelData.Rows[i][4] = "0";
            //    }
            //}

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand("select * from parks_boundary_2 where Park_Name = '" +condition + "'", con))


                //"select  st_name,st_lgc,dist_lgc,dist_cencd,sub_dist,vname,park_name,park_sd,land_cat,land_avail,park_type,poll_cat,envtclob,LandSale_M,LandSale_1,LandLease_,LandLease1,LeaseRenta,LeasePerio,TotalPlots,average__1,PlotsAlloc,Plots_vaca,total_land, sector,mixed_sect,sub_sector,nh,dist_nh,railst,dist_rails,airport,dist_airpo,seaport,dist_seapo,drytport,dist_drytp,zonal,dist_zonal,police_st,dist_polic,fire_st,dist_fire_,bank,dist_bank,hospital,dist_hospi,elec_avai,elec_cap,elec_uti,water_avai,water_cap,water_uti,gas_avai,gas_uti,stp_avai,stp_uti,elec_pole_,powerss_av,powerss_ca,powerss_ut,wtp_avai,wtp_cap,wtp_uti,ict_avai,ict_speed,swd_avai,swd_cap,swd_uti,dha,pta,oth_info,adm_name,adm_desi,adm_email,adm_phone,mkt_name,mkt_email,mkt_phone,project_ur,url_enquir,url_land_a,entry_date,geom, sh, dist_sh from parks_boundary ", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ada = new SqlDataAdapter(cmd))
                    {
                       
                            ada.Fill(dt);
                            // int jm = dt.Rows[2]["nh"].ToString() == "" || dt.Rows[2]["nh"].ToString() == "Null" ? 0 : Convert.ToInt32(dt.Rows[2]["LandSale_M"]);
                            //string data = (string)dt.Rows[0][1];

                            // DataTable dt2 = convertjsongrid(dt);

                         

                        
                    }
                }
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {




                var arlist2 = new ArrayList()
                {
                    dt.Rows[i]["mixed_sect"].ToString() == "NULL" ? "" : ""
                };

                string hmacstr = "uZaPDgrKRJ2B6M3d6guTM9xjNkEt8J2Q" + dt.Rows[i]["st_lgc"].ToString() + dt.Rows[i]["dist_lgc"].ToString() + dt.Rows[i]["park_name"].ToString() + dt.Rows[i]["park_type"].ToString() + dt.Rows[i]["land_cat"].ToString();

                var hmacfinal = ComputeSha256Hash(hmacstr);


                var inputdata = new
                {
                    st_lgc = dt.Rows[i]["st_lgc"].ToString(),
                    agcy_code = "",
                    dist_name = dt.Rows[i]["st_name"].ToString(),
                    dist_lgc = dt.Rows[i]["dist_lgc"].ToString(),
                    dist_cencd = dt.Rows[i]["dist_cencd"].ToString(),
                    sub_dist = dt.Rows[i]["sub_dist"].ToString(),
                    vname = dt.Rows[i]["vname"].ToString(),
                    park_name = dt.Rows[i]["park_name"].ToString(),
                    park_sd = dt.Rows[i]["park_sd"].ToString(),
                    land_cat = dt.Rows[i]["land_cat"].ToString(),

                    park_type = dt.Rows[i]["park_type"].ToString(),
                    poll_cat = dt.Rows[i]["poll_cat"].ToString(),
                    envtclob = dt.Rows[i]["envtclob"].ToString(),
                    landsale_m = dt.Rows[i]["LandSale_M"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["LandSale_M"]),
                    landsale_1 = dt.Rows[i]["LandSale_1"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["LandSale_1"]),
                    landlease_ = dt.Rows[i]["LandLease_"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["LandLease_"]),
                    landlease1 = dt.Rows[i]["LandLease1"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["LandLease1"]),
                    leaserenta = dt.Rows[i]["LeaseRenta"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["LeaseRenta"]),
                    leaseperio = dt.Rows[i]["LeasePerio"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["LeasePerio"]),
                    totalplots = dt.Rows[i]["TotalPlots"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["TotalPlots"]),
                    average_si = dt.Rows[i]["average__1"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["average__1"]),
                    plotsalloc = dt.Rows[i]["PlotsAlloc"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["PlotsAlloc"]),
                    plots_vaca = dt.Rows[i]["Plots_vaca"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["Plots_vaca"]),
                    land_avail = dt.Rows[i]["land_avail"].ToString() == "" ? 0 : Convert.ToDecimal(dt.Rows[i]["land_avail"]),
                    total_land = dt.Rows[i]["total_land"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["total_land"]),
                    sector = dt.Rows[i]["sector"].ToString(),
                    mixesSectList = arlist2,
                    sub_sector = dt.Rows[i]["sub_sector"].ToString(),
                    nh = dt.Rows[i]["nh"].ToString(),
                    dist_nh = dt.Rows[i]["dist_nh"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["dist_nh"]),
                    sh = dt.Rows[i]["sh"].ToString(),
                    dist_sh = dt.Rows[i]["dist_sh"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["dist_sh"]),
                    railst = dt.Rows[i]["railst"].ToString(),
                    dist_rails = dt.Rows[i]["dist_rails"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["dist_rails"]),
                    airport = dt.Rows[i]["airport"].ToString(),
                    dist_airpo = dt.Rows[i]["dist_airpo"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["dist_airpo"]),
                    seaport = dt.Rows[i]["seaport"].ToString(),
                    dist_seapo = dt.Rows[i]["dist_seapo"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["dist_seapo"]),
                    drytport = dt.Rows[i]["drytport"].ToString(),
                    dist_drytp = dt.Rows[i]["dist_drytp"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["dist_drytp"]),
                    zonal = dt.Rows[i]["zonal"].ToString(),
                    dist_zonal = dt.Rows[i]["dist_zonal"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["dist_zonal"]),
                    police_st = dt.Rows[i]["police_st"].ToString(),
                    dist_polic = dt.Rows[i]["dist_polic"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["dist_polic"]),
                    fire_st = dt.Rows[i]["fire_st"].ToString(),
                    dist_fire_ = dt.Rows[i]["dist_fire_"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["dist_fire_"]),
                    bank = dt.Rows[i]["bank"].ToString(),
                    dist_bank = dt.Rows[i]["dist_bank"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["dist_bank"]),
                    hospital = dt.Rows[i]["hospital"].ToString(),
                    dist_hospi = dt.Rows[i]["dist_hospi"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["dist_hospi"]),
                    elec_avai = dt.Rows[i]["elec_avai"].ToString(),
                    elec_cap = dt.Rows[i]["elec_cap"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["elec_cap"]),
                    elec_uti = dt.Rows[i]["elec_uti"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["elec_uti"]),
                    water_avai = dt.Rows[i]["water_avai"].ToString(),
                    water_cap = dt.Rows[i]["water_cap"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["water_cap"]),
                    water_uti = dt.Rows[i]["water_uti"].ToString(),
                    gas_avai = dt.Rows[i]["gas_avai"].ToString(),
                    gas_cap = dt.Rows[i]["gas_cap"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["gas_cap"]),
                    gas_uti = dt.Rows[i]["gas_uti"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["gas_uti"]),
                    stp_avai = dt.Rows[i]["stp_avai"].ToString(),

                    stp_cap = dt.Rows[i]["stp_cap"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["stp_cap"]),
                    stp_uti = dt.Rows[i]["stp_uti"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["stp_uti"]),
                    elec_pole_ = dt.Rows[i]["elec_pole_"].ToString(),
                    powerss_av = dt.Rows[i]["stp_avai"].ToString(),
                    powerss_ca = dt.Rows[i]["powerss_ca"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["powerss_ca"]),
                    powerss_ut = dt.Rows[i]["powerss_ut"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["powerss_ut"]),
                    wtp_avai = dt.Rows[i]["wtp_avai"].ToString(),
                    wtp_cap = dt.Rows[i]["wtp_cap"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["wtp_cap"]),
                    wtp_uti = dt.Rows[i]["wtp_uti"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["wtp_uti"]),
                    ict_avai = dt.Rows[i]["elec_pole_"].ToString(),
                    ict_speed = dt.Rows[i]["ict_speed"].ToString(),
                    swd_avai = dt.Rows[i]["swd_avai"].ToString(),
                    swd_cap = dt.Rows[i]["swd_cap"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["swd_cap"]),
                    swd_uti = dt.Rows[i]["swd_uti"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[i]["swd_uti"]),
                    dha = dt.Rows[i]["dha"].ToString(),
                    pta = dt.Rows[i]["pta"].ToString(),
                    oth_info = dt.Rows[i]["oth_info"].ToString(),
                    adm_name = dt.Rows[i]["adm_name"].ToString(),
                    adm_desi = dt.Rows[i]["adm_desi"].ToString(),
                    adm_email = dt.Rows[i]["adm_email"].ToString(),
                    adm_phone = dt.Rows[i]["adm_phone"].ToString(),
                    mkt_name = dt.Rows[i]["mkt_name"].ToString(),
                    mkt_desi = dt.Rows[i]["mkt_desi"].ToString(),
                    mkt_email = dt.Rows[i]["mkt_email"].ToString(),
                    mkt_phone = dt.Rows[i]["mkt_phone"].ToString(),
                    project_ur = dt.Rows[i]["project_ur"].ToString(),
                    url_enquir = dt.Rows[i]["url_enquir"].ToString(),
                    url_land_a = dt.Rows[i]["url_land_a"].ToString(),
                    public_pri = dt.Rows[i]["entry_date"].ToString(),
                    geom = dt.Rows[i]["geom"].ToString(),
                    dist_port = 0,
                    port_name = "",
                    data_owner_agency = " ",
                    hmac = hmacfinal

                };

                string inputJson = (new JavaScriptSerializer()).Serialize(inputdata);
                HttpClient client = new HttpClient();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(apiUrl + "/insertParkDetails", inputContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        // List<Customer> customers = (new JavaScriptSerializer()).Deserialize<List<Customer>>(response.Content.ReadAsStringAsync().Result);

                        string s = response.Content.ReadAsStringAsync().Result;

                        char[] delim = new char[] {'{','}','\r', '\n','\\','"' };

                        string[] part = s.Split(delim);

                       if( part[4].ToString() == "1")
                        {
                            string sts = part[4].ToString();
                            string msg = part[8].ToString();
                            string flag = "1";
                            updatedata(flag, condition);
                            getdata();
                        }

                      //  List<result> res = (List<result>)JsonConvert.DeserializeObject(s, typeof(List<result>));
                    }
                    catch (Exception ex)
                    {
                    }
                    // gvCustomers.DataSource = customers;
                    // gvCustomers.DataBind();
                }


                DataRow drow = dtdestination.NewRow();
                drow["Park Name"] = dt.Rows[i]["park_name"].ToString();
                drow["Json"] = inputJson;

                dtdestination.Rows.Add(drow);

            }
            //return dtdestination;
        }


        public class result
        {
            public string statusCode { get; set; }
           // public string parkname { get; set; }
        }

        public void updatedata(string flag, string name)
        {
            using (SqlConnection con = new SqlConnection(_connection))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update parks_boundary_2 set flag =" + "'" + flag + "' where park_name = '" + name + "'", con);
                    
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch(Exception ex)
                {
                    
                }
            }

        }



        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static DataTable Select_All_Data(string TableName, string TFieldName, string Condition, string OrderbyCondition, string Sortcondition, string OtherConnection)
        {
            DataTable dtcombo = new DataTable();
            try
            {
                string WConditions = Condition.Length > 0 ? " where " + Condition : "";
                string OrderbyvalueMem = OrderbyCondition.Length > 0 ? " order by " + OrderbyCondition + "  " : "";
                string sortbycondi = Sortcondition.Length > 0 ? "" + Sortcondition : "";
                string FieldName = TFieldName.Length > 0 ? TFieldName : "";
                SqlParameter[] paramvT = new SqlParameter[]
                        {
                            new SqlParameter("@TableName",TableName),
                            new SqlParameter("@Condition",WConditions),
                            new SqlParameter("@OrderbyvalueMem",OrderbyvalueMem),
                            new SqlParameter("@sortbycondi",sortbycondi),
                            new SqlParameter("@FieldName",FieldName),

                        };

                dtcombo = GetDataTable(_connection, CommandType.StoredProcedure, "Get_Select_Table_Data_Common", paramvT);
            }
            catch (Exception ex)
            {
                //string mmsg = ex.Message; showMessages(mmsg);
                //showMessages("(SelectAllData)  " + mmsg);
            }
            return dtcombo;
        }

        public static int ExecuteNonQuery(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                PrepareCommand(cmd, conn, cmdType, cmdText, cmdParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static int ExecuteNonQuery(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] cmdParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, conn, cmdType, cmdText, cmdParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] cmdParameters)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = cmdType;
            cmd.CommandText = cmdText;
            if (cmdParameters != null)
            {
                foreach (SqlParameter param in cmdParameters)
                {
                    cmd.Parameters.Add(param);
                }
            }
        }





        public static DataTable GetDataTable(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParameters)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, conn, cmdType, cmdText, cmdParameters);
                da.SelectCommand = new SqlCommand();
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;
            }
            catch (Exception Ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }





    


        

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();


            DataTable table = Session["myTable"] as DataTable;
            GridView1.DataSource = table;
            GridView1.DataBind();


        }


        protected void grdCustomPagging_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VIEW")
            {
                LinkButton lnkView = (LinkButton)e.CommandSource;
                string dealId = lnkView.CommandArgument;


                InsertData(dealId);

               // CommonFunctions.IndustrialParkName = dealId;


                //Response.Redirect("../Default.aspx?indusParkName=" + ((System.Web.UI.WebControls.LinkButton)(e.CommandSource)).CommandArgument);
                // Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('./Default.aspx','_newtab');", true);
                //string redirect = "<script>window.open('./Default.aspx');</script>";
                //Response.Write(redirect);
                //Response.Redirect("../Default.aspx");
                //table2.Visible = true;
            }
        }
    }
}