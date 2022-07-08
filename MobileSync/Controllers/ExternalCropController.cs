using MobileSync.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;

namespace MobileSync.Controllers
{
    public class ExternalCropController : ApiController
    {
        [HttpGet]
        public int getExternalCrop(String ecHeaderJson, String ecDetailJson, int userUID) // Type  1- Save, 2 - Update
        {

            try
            {

                var resultHeader = JsonConvert.DeserializeObject<ECHeader>(ecHeaderJson);
                List<ECDetail> resultDetail = (List<ECDetail>)Newtonsoft.Json.JsonConvert.DeserializeObject(ecDetailJson, typeof(List<ECDetail>)); ;

                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ListDbConnectionString"].ToString()))
                {
                    connection.Open();
                    using (var cmdRegSite = new SqlCommand("AddExternalCropHeaderData"))
                    {
                        cmdRegSite.Connection = connection;
                        cmdRegSite.CommandType = CommandType.StoredProcedure;
                        SqlParameter siteparam1 = cmdRegSite.Parameters.Add("@USER_ID", SqlDbType.Int, 32);
                        siteparam1.Value = userUID;
                        SqlParameter siteparam2 = cmdRegSite.Parameters.Add("@ECH_INCENTIVE_PER_MT", SqlDbType.Decimal, 32);
                        siteparam2.Value = resultHeader.ECH_INCENTIVE_PER_MT;
                        SqlParameter siteparam3 = cmdRegSite.Parameters.Add("@ECH_TOTAL_PURCHASED_QTY", SqlDbType.Int, 32);
                        siteparam3.Value = resultHeader.ECH_TOTAL_PURCHASED_QTY;
                        SqlParameter siteparam4 = cmdRegSite.Parameters.Add("@ECH_INCENTIVE", SqlDbType.Decimal, 32);
                        siteparam4.Value = resultHeader.ECH_INCENTIVE;
                        SqlParameter siteparam5 = cmdRegSite.Parameters.Add("@ECH_EXTERNAL_CROP_COST", SqlDbType.Decimal, 32);
                        siteparam5.Value = resultHeader.ECH_EXTERNAL_CROP_COST;
                        SqlParameter siteparam6 = cmdRegSite.Parameters.Add("@ECH_COST_AVG_PER_MT", SqlDbType.Decimal, 32);
                        siteparam6.Value = resultHeader.ECH_COST_AVG_PER_MT;
                        SqlParameter siteparam7 = cmdRegSite.Parameters.Add("@ECH_TOTAL_PENALTY_COST", SqlDbType.Decimal, 32);
                        siteparam7.Value = resultHeader.ECH_TOTAL_PENALTY_COST;
                        SqlParameter siteparam8 = cmdRegSite.Parameters.Add("@ECH_COST_AFTER_PENALTY", SqlDbType.Decimal, 32);
                        siteparam8.Value = resultHeader.ECH_COST_AFTER_PENALTY; 
                        SqlParameter siteparam9 = cmdRegSite.Parameters.Add("@ECH_PREVIOUS_ID", SqlDbType.Int, 32);
                        siteparam9.Value = resultHeader.ECH_ID; 
                        SqlParameter siteparam10 = cmdRegSite.Parameters.Add("@ECH_DATE", SqlDbType.DateTime,32);
                        siteparam10.Value = resultHeader.ECH_PURCHASE_DATE;

                        SqlDataReader reader = cmdRegSite.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int ech_Header_UID = int.Parse(reader[0].ToString());
                                if (ech_Header_UID > 0)
                                {
                                    using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ListDbConnectionString"].ToString()))
                                    {                                        
                                        foreach (ECDetail ecDetail in resultDetail)
                                        {
                                            conn.Open();
                                            using (var cmdLine = new SqlCommand("AddExternalCropLineData"))
                                            {
                                                cmdLine.Connection = conn;
                                                cmdLine.CommandType = CommandType.StoredProcedure;
                                                SqlParameter lineparam1 = cmdLine.Parameters.Add("@USERID", SqlDbType.Int, 32);
                                                lineparam1.Value = userUID;
                                                SqlParameter lineparam2 = cmdLine.Parameters.Add("@ECD_ECH_ID", SqlDbType.Int, 32);
                                                lineparam2.Value = ech_Header_UID;
                                                SqlParameter lineparam3 = cmdLine.Parameters.Add("@ECD_PURCHASED_LOCATION_ID", SqlDbType.Decimal, 32);
                                                lineparam3.Value = ecDetail.LOCATION_ID;
                                                SqlParameter lineparam4 = cmdLine.Parameters.Add("@ECD_PURCHASED_QTY", SqlDbType.Decimal, 32);
                                                lineparam4.Value = ecDetail.LOCATION_CROP_QTY;
                                                SqlParameter lineparam5 = cmdLine.Parameters.Add("@ECD_RATE_PER_MT", SqlDbType.Decimal, 32);
                                                lineparam5.Value = ecDetail.LOCATION_CROP_RATE;
                                                SqlParameter lineparam6 = cmdLine.Parameters.Add("@ECD_PENALTY_PERCENTAGE", SqlDbType.Decimal, 32);
                                                lineparam6.Value = ecDetail.LOCATION_CROP_PENALTY_PERCENTAGE;
                                                SqlParameter lineparam7 = cmdLine.Parameters.Add("@ECD_PENALTY_COST", SqlDbType.Decimal, 32);
                                                lineparam7.Value = ecDetail.LOCATION_CROP_PENALTY_COST;
                                                SqlParameter lineparam8 = cmdLine.Parameters.Add("@ECD_COMPANY_ID", SqlDbType.Int, 32);
                                                lineparam8.Value = ecDetail.COMPANY_ID;
                                                SqlParameter lineparam9 = cmdLine.Parameters.Add("@ECD_SUPPLIER_ID", SqlDbType.Int, 32);
                                                lineparam9.Value = ecDetail.SUPPLIER_ID;

                                                SqlDataReader readerLine = cmdLine.ExecuteReader();
                                                if (readerLine.HasRows)
                                                {
                                                    while (readerLine.Read())
                                                    {
                                                        int result = int.Parse(readerLine[0].ToString());

                                                    }
                                                }
                                            }
                                            conn.Close();
                                        }                                        
                                    }
                                }
        
                            }
                        }
                    }
                    connection.Close();
                    return 1;
                }
            }

            catch(Exception ex) {                
                Console.WriteLine($"The file could not be opened: '{ex}'");
                return -1;
            }
        }

        [HttpGet]
        [ActionName("GetPendingExternalCropHeader")]
        public List<ECHeader> getPendingExternalCropHeader(int UserUID)   
        {
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ListDbConnectionString"].ToString()))
                {
                    connection.Open();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        using (var cmdRegSite = new SqlCommand("getPendingExternalCropHeader"))
                        {
                            cmdRegSite.Connection = connection;
                            cmdRegSite.CommandType = CommandType.StoredProcedure;
                            SqlParameter siteparam1 = cmdRegSite.Parameters.Add("@UserUID", SqlDbType.Int, 32);
                            siteparam1.Value = UserUID;

                            SqlDataReader reader = cmdRegSite.ExecuteReader();
                            if (reader.HasRows)
                            {
                                List<ECHeader> ecHeaderList = new List<ECHeader>();
                                while (reader.Read())
                                {
                                    ECHeader ecHeader = new ECHeader();
                                    ecHeader.ECH_ID = int.Parse(reader[0].ToString());
                                    ecHeader.ECH_PURCHASE_DATE = DateTime.Parse(reader[1].ToString());
                                    ecHeader.ECH_INCENTIVE_PER_MT = double.Parse(reader[2].ToString());
                                    ecHeader.ECH_TOTAL_PURCHASED_QTY = int.Parse(reader[3].ToString());
                                    ecHeader.ECH_INCENTIVE = double.Parse(reader[4].ToString());
                                    ecHeader.ECH_EXTERNAL_CROP_COST = double.Parse(reader[5].ToString());
                                    ecHeader.ECH_COST_AVG_PER_MT = double.Parse(reader[6].ToString());
                                    ecHeader.ECH_TOTAL_PENALTY_COST = double.Parse(reader[7].ToString());
                                    ecHeader.ECH_COST_AFTER_PENALTY = double.Parse(reader[8].ToString());
                                    ecHeaderList.Add(ecHeader);
                                }
                                return ecHeaderList;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
        }

    }
}