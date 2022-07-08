using MobileSync.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace MobileSync.Controllers
{
    public class ECMillDetailController : ApiController
    {
        [HttpGet]
        [ActionName("GetECMillItemDetails")]
        public List<ECMillDetail> GetECMillItemDetails(int ECHeaderUID)
        {
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ListDbConnectionString"].ToString()))
                {

                    using (var cmdRegSite = new SqlCommand("GetECMillItemDetails"))
                    {
                        connection.Open();
                        cmdRegSite.Connection = connection;
                        cmdRegSite.CommandType = CommandType.StoredProcedure;
                        SqlParameter siteparam1 = cmdRegSite.Parameters.Add("@ECHeaderUID", SqlDbType.Int, 32);
                        siteparam1.Value = ECHeaderUID;

                        SqlDataReader reader = cmdRegSite.ExecuteReader();
                        if (reader.HasRows)
                        {
                            List<ECMillDetail> ECMillDetailList = new List<ECMillDetail>();
                            while (reader.Read())
                            {
                                ECMillDetail ECMillDetail = new ECMillDetail();
                                ECMillDetail.MILL_ID = int.Parse(reader[0].ToString());
                                ECMillDetail.MILL_CODE = reader[1].ToString();
                                ECMillDetail.MILL_NAME = reader[2].ToString();
                                ECMillDetail.MILL_CROP_QTY = int.Parse(reader[3].ToString());
                                ECMillDetail.MILL_CROP_RATE = double.Parse(reader[4].ToString());
                                ECMillDetail.MILL_CROP_PENALTY_PERCENTAGE = double.Parse(reader[5].ToString());
                                ECMillDetail.MILL_CROP_PENALTY_COST = double.Parse(reader[6].ToString());
                                ECMillDetail.SUPPLIER_NAME = reader[7].ToString();
                                ECMillDetailList.Add(ECMillDetail);
                            }

                            connection.Close();
                            return ECMillDetailList;
                        }
                        else
                        {
                            connection.Close();
                            return null;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"The file could not be opened: '{ex}'");
                return null;
            }
        }

        [HttpGet]
        [ActionName("GetECHeaderWithMill")]
        public ECHeader GetECHeaderWithMill(int UserUID, DateTime requestDate)
        {
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ListDbConnectionString"].ToString()))
                {

                    using (var cmdRegSite = new SqlCommand("getECMillItemDetailByUserDate"))
                    {
                        connection.Open();
                        cmdRegSite.Connection = connection;
                        cmdRegSite.CommandType = CommandType.StoredProcedure;
                        SqlParameter siteparam1 = cmdRegSite.Parameters.Add("@UserUID", SqlDbType.Int, 32);
                        siteparam1.Value = UserUID;
                        SqlParameter siteparam2 = cmdRegSite.Parameters.Add("@RequestDate", SqlDbType.DateTime, 32);
                        siteparam2.Value = requestDate.Date;

                        SqlDataReader reader = cmdRegSite.ExecuteReader();
                        if (reader.HasRows)
                        {
                            List<ECMillDetail> ECMillDetailList = new List<ECMillDetail>();
                            while (reader.Read())
                            {
                                ECMillDetail ECMillDetail = new ECMillDetail();
                                ECMillDetail.MILL_ID = int.Parse(reader[0].ToString());
                                ECMillDetail.MILL_CODE = reader[1].ToString();
                                ECMillDetail.MILL_NAME = reader[2].ToString();
                                ECMillDetail.MILL_CROP_QTY = int.Parse(reader[3].ToString());
                                ECMillDetail.MILL_CROP_RATE = double.Parse(reader[4].ToString());
                                ECMillDetail.MILL_CROP_PENALTY_PERCENTAGE = double.Parse(reader[5].ToString());
                                ECMillDetail.MILL_CROP_PENALTY_COST = double.Parse(reader[6].ToString());
                                ECMillDetail.COMPANY_ID = int.Parse(reader[7].ToString());
                                ECMillDetail.SUPPLIER_ID = int.Parse(reader[8].ToString());
                                ECMillDetail.SUPPLIER_NAME = reader[9].ToString();
                                ECMillDetailList.Add(ECMillDetail);
                            }

                            connection.Close();
                            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ListDbConnectionString"].ToString()))
                            {
                                using (var cmdLocHeader = new SqlCommand("getECHeader"))
                                {
                                    conn.Open();
                                    cmdLocHeader.Connection = conn;
                                    cmdLocHeader.CommandType = CommandType.StoredProcedure;
                                    SqlParameter siteparamhead1 = cmdLocHeader.Parameters.Add("@UserUID", SqlDbType.Int, 32);
                                    siteparamhead1.Value = UserUID;
                                    SqlParameter siteparamhead2 = cmdLocHeader.Parameters.Add("@RequestDate", SqlDbType.DateTime, 32);
                                    siteparamhead2.Value = requestDate.Date;

                                    ECHeader ECheader = new ECHeader();
                                    SqlDataReader readerHeader = cmdLocHeader.ExecuteReader();
                                    if (readerHeader.HasRows)
                                    {
                                        while (readerHeader.Read())
                                        {
                                            ECheader.ECH_ID = int.Parse(readerHeader[0].ToString());
                                            ECheader.ECH_INCENTIVE_PER_MT = double.Parse(readerHeader[1].ToString());
                                            ECheader.ECH_TOTAL_PURCHASED_QTY = int.Parse(readerHeader[2].ToString());
                                            ECheader.ECH_INCENTIVE = double.Parse(readerHeader[3].ToString());
                                            ECheader.ECH_EXTERNAL_CROP_COST = double.Parse(readerHeader[4].ToString());
                                            ECheader.ECH_COST_AVG_PER_MT = double.Parse(readerHeader[5].ToString());
                                            ECheader.ECH_TOTAL_PENALTY_COST = double.Parse(readerHeader[6].ToString());
                                            ECheader.ECH_COST_AFTER_PENALTY = double.Parse(readerHeader[7].ToString());
                                            if (readerHeader[8].ToString() == "")
                                            {
                                                ECheader.ECH_CONFIRMED = 0;
                                            }
                                            else
                                            {
                                                ECheader.ECH_CONFIRMED = int.Parse(readerHeader[8].ToString());
                                            }
                                            ECheader.ECH_ECMILL_DETAIL_LIST = ECMillDetailList;
                                        }
                                    }
                                    conn.Close();
                                    return ECheader;
                                }
                            }
                        }
                        else
                        {
                            connection.Close();
                            return null;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"The file could not be opened: '{ex}'");
                return null;
            }
        }

    }
}