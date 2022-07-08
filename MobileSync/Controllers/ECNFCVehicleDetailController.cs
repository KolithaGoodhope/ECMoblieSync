using MobileSync.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using Newtonsoft.Json;

namespace MobileSync.Controllers
{
    public class ECNFCVehicleDetailController : ApiController
    {
        // GET: ECNFCVehicleDetail
        [HttpGet]
        [ActionName("GetUpdateECNFCVehicleDetail")]
        public int GetUpdateECNFCVehicleDetail(string jsonObjectString)
        {
            try
            {

                List<NFCVehicleDetail> result = (List<NFCVehicleDetail>)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonObjectString, typeof(List<NFCVehicleDetail>)); ;

                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ListDbConnectionString"].ToString()))
                {
                    foreach (NFCVehicleDetail NFCvehicleDetail in result)
                    {
                        conn.Open();
                        using (var cmdLine = new SqlCommand("AddExternalCropNFCVehicleDetails"))
                        {
                            cmdLine.Connection = conn;
                            cmdLine.CommandType = CommandType.StoredProcedure;
                            SqlParameter lineparam1 = cmdLine.Parameters.Add("@USER_ID", SqlDbType.Int, 32);
                            lineparam1.Value = NFCvehicleDetail.USER_ID;
                            SqlParameter lineparam2 = cmdLine.Parameters.Add("@VEHICLE_ID", SqlDbType.Int, 32);
                            lineparam2.Value = NFCvehicleDetail.VEHICLE_ID;
                            SqlParameter lineparam3 = cmdLine.Parameters.Add("@ENTITY_ID", SqlDbType.Int, 32);
                            lineparam3.Value = NFCvehicleDetail.ENTITY_ID;
                            SqlParameter lineparam4 = cmdLine.Parameters.Add("@DATE", SqlDbType.DateTime, 32);
                            lineparam4.Value = Convert.ToDateTime(NFCvehicleDetail.DATE);
                            SqlParameter lineparam5 = cmdLine.Parameters.Add("@ECD_IS_TEMP_VEHICLE", SqlDbType.Int, 32);
                            lineparam5.Value = NFCvehicleDetail.EC_NFC_IS_TEMP_VEHICLE;

                            SqlDataReader readerLine = cmdLine.ExecuteReader();
                            if (readerLine.HasRows)
                            {
                                while (readerLine.Read())
                                {
                                    int resultVal = int.Parse(readerLine[0].ToString());
                                }
                            }
                            conn.Close();

                            if (NFCvehicleDetail.EC_NFC_IS_TEMP_VEHICLE == 1)
                            {
                                conn.Close();
                                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ListDbConnectionString"].ToString()))
                                {
                                    connection.Open();
                                    using (var cmdNewLine = new SqlCommand("getUpdateAssignedTempVehicle"))
                                    {
                                        cmdNewLine.Connection = connection;
                                        cmdNewLine.CommandType = CommandType.StoredProcedure;
                                        SqlParameter newlineparam1 = cmdNewLine.Parameters.Add("@userUID", SqlDbType.Int, 32);
                                        newlineparam1.Value = NFCvehicleDetail.USER_ID;
                                        SqlParameter newlineparam2 = cmdNewLine.Parameters.Add("@VehicleUID", SqlDbType.Int, 32);
                                        newlineparam2.Value = NFCvehicleDetail.VEHICLE_ID;

                                        SqlDataReader readerNewLine = cmdNewLine.ExecuteReader();
                                        if (readerNewLine.HasRows)
                                        {
                                            while (readerNewLine.Read())
                                            {
                                                int resultVal = int.Parse(readerNewLine[0].ToString());
                                            }
                                        }
                                    }
                                    connection.Close();
                                }
                            }                                                            
                        }
                    }
                }
                return 1;
                
            }
            catch(Exception ex)
            {
                return -1;
            }
        }
    }
}