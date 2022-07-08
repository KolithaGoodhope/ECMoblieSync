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
    public class RegistrationController : ApiController
    {
        [HttpGet]
        [ActionName("GetInsertNFCCardData")]
        public int GetInsertNFCCardData(String ecDetailJson, int userUID)
        {
          try
            {
                List<ECDetail> resultDetail = (List<ECDetail>)Newtonsoft.Json.JsonConvert.DeserializeObject(ecDetailJson, typeof(List<ECDetail>));                 
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ListDbConnectionString"].ToString()))
                {                                        
                    foreach (ECDetail ecDetail in resultDetail)
                    {
                        conn.Open();
                        using (var cmdLine = new SqlCommand("AddRegistrationLineData"))
                        {
                            cmdLine.Connection = conn;
                            cmdLine.CommandType = CommandType.StoredProcedure;
                            SqlParameter lineparam1 = cmdLine.Parameters.Add("@USERID", SqlDbType.Int, 32);
                            lineparam1.Value = userUID;
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
                return 1;
                
            }

            catch(Exception ex) {                
                Console.WriteLine($"The file could not be opened: '{ex}'");
                return -1;
            }
        }
    }
}