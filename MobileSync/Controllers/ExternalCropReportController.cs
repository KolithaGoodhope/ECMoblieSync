using MobileSync.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace MobileSync.Controllers
{
    public class ExternalCropReportController : ApiController
    {
        [HttpGet]
        [ActionName("ExternalCropReport")]
        public List<ECReportItem> Get(int userUID,int locationUID, DateTime month)
        {
            try
            {
                DateTime startDate = new DateTime(month.Year, month.Month, 1).Date;
                DateTime endDate = startDate.AddMonths(1).AddDays(-1).Date;

                List<ECReportItem> ECReportItemList = new List<ECReportItem>();
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ListDbConnectionString"].ToString()))
                {

                    using (var cmdRegSite = new SqlCommand("GetECPurchasedQty"))
                    {
                        connection.Open();
                        cmdRegSite.Connection = connection;
                        cmdRegSite.CommandType = CommandType.StoredProcedure;
                        SqlParameter siteparam1 = cmdRegSite.Parameters.Add("@UserUID", SqlDbType.Int, 32);
                        siteparam1.Value = userUID;
                        SqlParameter siteparam2 = cmdRegSite.Parameters.Add("@LocationUID", SqlDbType.Int, 32);
                        siteparam2.Value = locationUID;
                        SqlParameter siteparam3 = cmdRegSite.Parameters.Add("@StartDate", SqlDbType.DateTime, 32);
                        siteparam3.Value = startDate;
                        SqlParameter siteparam4 = cmdRegSite.Parameters.Add("@EndDate", SqlDbType.DateTime, 32);
                        siteparam4.Value = endDate;

                        SqlDataReader reader = cmdRegSite.ExecuteReader();
                        if (reader.HasRows)
                        {
                            List<ECReportItem> ECPurchaseQtyList = new List<ECReportItem>();
                            while (reader.Read())
                            {
                                ECReportItem ECreportItem;
                                if (!ECPurchaseQtyList.Exists(a => a.LOCATION_ID == int.Parse(reader[1].ToString())))
                                {
                                    ECreportItem = new ECReportItem();
                                    ECreportItem.LOCATION_ID = int.Parse(reader[1].ToString());
                                    ECreportItem.LOCATION_CODE = reader[2].ToString();
                                    ECreportItem.LOCATION_NAME = reader[3].ToString();
                                    ECreportItem.DESCRIPTION = reader[5].ToString();
                                }
                                else
                                {
                                    ECreportItem = ECPurchaseQtyList.Find(a => a.LOCATION_ID == int.Parse(reader[1].ToString()));
                                    ECPurchaseQtyList.Remove(ECreportItem);
                                }

                                DateTime date = DateTime.Parse(reader[0].ToString());
                                int day = date.Day;
                                switch (day) {
                                    case 1:
                                        ECreportItem.DAY_1_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 2:
                                        ECreportItem.DAY_2_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 3:
                                        ECreportItem.DAY_3_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 4:
                                        ECreportItem.DAY_4_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 5:
                                        ECreportItem.DAY_5_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 6:
                                        ECreportItem.DAY_6_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 7:
                                        ECreportItem.DAY_7_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 8:
                                        ECreportItem.DAY_8_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 9:
                                        ECreportItem.DAY_9_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 10:
                                        ECreportItem.DAY_10_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 11:
                                        ECreportItem.DAY_11_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 12:
                                        ECreportItem.DAY_12_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 13:
                                        ECreportItem.DAY_13_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 14:
                                        ECreportItem.DAY_14_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 15:
                                        ECreportItem.DAY_15_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 16:
                                        ECreportItem.DAY_16_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 17:
                                        ECreportItem.DAY_17_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 18:
                                        ECreportItem.DAY_18_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 19:
                                        ECreportItem.DAY_19_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 20:
                                        ECreportItem.DAY_20_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 21:
                                        ECreportItem.DAY_21_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 22:
                                        ECreportItem.DAY_22_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 23:
                                        ECreportItem.DAY_23_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 24:
                                        ECreportItem.DAY_24_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 25:
                                        ECreportItem.DAY_25_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 26:
                                        ECreportItem.DAY_26_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 27:
                                        ECreportItem.DAY_27_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 28:
                                        ECreportItem.DAY_28_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 29:
                                        ECreportItem.DAY_29_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 30:
                                        ECreportItem.DAY_30_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    case 31:
                                        ECreportItem.DAY_31_VALUE = int.Parse(reader[4].ToString());
                                        break;
                                    default:
                                        break;
                                }

                                ECPurchaseQtyList.Add(ECreportItem);
                            }

                            ECReportItemList.AddRange(ECPurchaseQtyList);
                            connection.Close();
                        }
                        else
                        {
                            connection.Close();
                        }
                    }
                    using (var cmdgetPurchaseRate = new SqlCommand("GetECPurchasedRate"))
                    {
                        connection.Open();
                        cmdgetPurchaseRate.Connection = connection;
                        cmdgetPurchaseRate.CommandType = CommandType.StoredProcedure;
                        SqlParameter siteparam1 = cmdgetPurchaseRate.Parameters.Add("@UserUID", SqlDbType.Int, 32);
                        siteparam1.Value = userUID;
                        SqlParameter siteparam2 = cmdgetPurchaseRate.Parameters.Add("@LocationUID", SqlDbType.Int, 32);
                        siteparam2.Value = locationUID;
                        SqlParameter siteparam3 = cmdgetPurchaseRate.Parameters.Add("@StartDate", SqlDbType.DateTime, 32);
                        siteparam3.Value = startDate;
                        SqlParameter siteparam4 = cmdgetPurchaseRate.Parameters.Add("@EndDate", SqlDbType.DateTime, 32);
                        siteparam4.Value = endDate;


                        SqlDataReader rateReader = cmdgetPurchaseRate.ExecuteReader();
                        if (rateReader.HasRows)
                        {
                            List<ECReportItem> ECPurchaseRateList = new List<ECReportItem>();
                            while (rateReader.Read())
                            {
                                ECReportItem ECreportItem;
                                if (!ECPurchaseRateList.Exists(a => a.LOCATION_ID == int.Parse(rateReader[1].ToString())))
                                {
                                    ECreportItem = new ECReportItem();
                                    ECreportItem.LOCATION_ID = int.Parse(rateReader[1].ToString());
                                    ECreportItem.LOCATION_CODE = rateReader[2].ToString();
                                    ECreportItem.LOCATION_NAME = rateReader[3].ToString();
                                    ECreportItem.DESCRIPTION = rateReader[5].ToString();
                                }
                                else
                                {
                                    ECreportItem = ECPurchaseRateList.Find(a => a.LOCATION_ID == int.Parse(rateReader[1].ToString()));
                                    ECPurchaseRateList.Remove(ECreportItem);
                                }

                                DateTime date = DateTime.Parse(rateReader[0].ToString());
                                int day = date.Day;
                                switch (day)
                                {
                                    case 1:
                                        ECreportItem.DAY_1_VALUE = Math.Round(double.Parse(rateReader[4].ToString()),2);
                                        break;
                                    case 2:
                                        ECreportItem.DAY_2_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 3:
                                        ECreportItem.DAY_3_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 4:
                                        ECreportItem.DAY_4_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 5:
                                        ECreportItem.DAY_5_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 6:
                                        ECreportItem.DAY_6_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 7:
                                        ECreportItem.DAY_7_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 8:
                                        ECreportItem.DAY_8_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 9:
                                        ECreportItem.DAY_9_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 10:
                                        ECreportItem.DAY_10_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 11:
                                        ECreportItem.DAY_11_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 12:
                                        ECreportItem.DAY_12_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 13:
                                        ECreportItem.DAY_13_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 14:
                                        ECreportItem.DAY_14_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 15:
                                        ECreportItem.DAY_15_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 16:
                                        ECreportItem.DAY_16_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 17:
                                        ECreportItem.DAY_17_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 18:
                                        ECreportItem.DAY_18_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 19:
                                        ECreportItem.DAY_19_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 20:
                                        ECreportItem.DAY_20_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 21:
                                        ECreportItem.DAY_21_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 22:
                                        ECreportItem.DAY_22_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 23:
                                        ECreportItem.DAY_23_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 24:
                                        ECreportItem.DAY_24_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 25:
                                        ECreportItem.DAY_25_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 26:
                                        ECreportItem.DAY_26_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 27:
                                        ECreportItem.DAY_27_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 28:
                                        ECreportItem.DAY_28_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 29:
                                        ECreportItem.DAY_29_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 30:
                                        ECreportItem.DAY_30_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    case 31:
                                        ECreportItem.DAY_31_VALUE = Math.Round(double.Parse(rateReader[4].ToString()), 2);
                                        break;
                                    default:
                                        break;
                                }

                                ECPurchaseRateList.Add(ECreportItem);
                            }

                            ECReportItemList.AddRange(ECPurchaseRateList);
                            connection.Close();
                        }
                        else
                        {
                            connection.Close();
                        }
                    }
                    using (var cmdgetPenaltyPercentage = new SqlCommand("GetECPenaltyPercentage"))
                    {
                        connection.Open();
                        cmdgetPenaltyPercentage.Connection = connection;
                        cmdgetPenaltyPercentage.CommandType = CommandType.StoredProcedure;
                        SqlParameter siteparam1 = cmdgetPenaltyPercentage.Parameters.Add("@UserUID", SqlDbType.Int, 32);
                        siteparam1.Value = userUID;
                        SqlParameter siteparam2 = cmdgetPenaltyPercentage.Parameters.Add("@LocationUID", SqlDbType.Int, 32);
                        siteparam2.Value = locationUID;
                        SqlParameter siteparam3 = cmdgetPenaltyPercentage.Parameters.Add("@StartDate", SqlDbType.DateTime, 32);
                        siteparam3.Value = startDate;
                        SqlParameter siteparam4 = cmdgetPenaltyPercentage.Parameters.Add("@EndDate", SqlDbType.DateTime, 32);
                        siteparam4.Value = endDate;


                        SqlDataReader penaltyPercReader = cmdgetPenaltyPercentage.ExecuteReader();
                        if (penaltyPercReader.HasRows)
                        {
                            List<ECReportItem> ECPenaltyPercList = new List<ECReportItem>();
                            while (penaltyPercReader.Read())
                            {
                                ECReportItem ECreportItem;
                                if (!ECPenaltyPercList.Exists(a => a.LOCATION_ID == int.Parse(penaltyPercReader[1].ToString())))
                                {
                                    ECreportItem = new ECReportItem();
                                    ECreportItem.LOCATION_ID = int.Parse(penaltyPercReader[1].ToString());
                                    ECreportItem.LOCATION_CODE = penaltyPercReader[2].ToString();
                                    ECreportItem.LOCATION_NAME = penaltyPercReader[3].ToString();
                                    ECreportItem.DESCRIPTION = penaltyPercReader[5].ToString();
                                }
                                else
                                {
                                    ECreportItem = ECPenaltyPercList.Find(a => a.LOCATION_ID == int.Parse(penaltyPercReader[1].ToString()));
                                    ECPenaltyPercList.Remove(ECreportItem);
                                }

                                DateTime date = DateTime.Parse(penaltyPercReader[0].ToString());
                                int day = date.Day;
                                switch (day)
                                {
                                    case 1:
                                        ECreportItem.DAY_1_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 2:
                                        ECreportItem.DAY_2_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 3:
                                        ECreportItem.DAY_3_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 4:
                                        ECreportItem.DAY_4_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 5:
                                        ECreportItem.DAY_5_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 6:
                                        ECreportItem.DAY_6_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 7:
                                        ECreportItem.DAY_7_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 8:
                                        ECreportItem.DAY_8_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 9:
                                        ECreportItem.DAY_9_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 10:
                                        ECreportItem.DAY_10_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 11:
                                        ECreportItem.DAY_11_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 12:
                                        ECreportItem.DAY_12_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 13:
                                        ECreportItem.DAY_13_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 14:
                                        ECreportItem.DAY_14_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 15:
                                        ECreportItem.DAY_15_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 16:
                                        ECreportItem.DAY_16_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 17:
                                        ECreportItem.DAY_17_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 18:
                                        ECreportItem.DAY_18_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 19:
                                        ECreportItem.DAY_19_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 20:
                                        ECreportItem.DAY_20_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 21:
                                        ECreportItem.DAY_21_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 22:
                                        ECreportItem.DAY_22_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 23:
                                        ECreportItem.DAY_23_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 24:
                                        ECreportItem.DAY_24_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 25:
                                        ECreportItem.DAY_25_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 26:
                                        ECreportItem.DAY_26_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 27:
                                        ECreportItem.DAY_27_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 28:
                                        ECreportItem.DAY_28_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 29:
                                        ECreportItem.DAY_29_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 30:
                                        ECreportItem.DAY_30_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    case 31:
                                        ECreportItem.DAY_31_VALUE = Math.Round(double.Parse(penaltyPercReader[4].ToString()), 2);
                                        break;
                                    default:
                                        break;
                                }

                                ECPenaltyPercList.Add(ECreportItem);
                            }

                            ECReportItemList.AddRange(ECPenaltyPercList);
                            connection.Close();
                        }
                        else
                        {
                            connection.Close();
                        }
                    }
                    using (var cmdgetPenaltyAmount = new SqlCommand("GetECPenaltyAmount"))
                    {
                        connection.Open();
                        cmdgetPenaltyAmount.Connection = connection;
                        cmdgetPenaltyAmount.CommandType = CommandType.StoredProcedure;
                        SqlParameter siteparam1 = cmdgetPenaltyAmount.Parameters.Add("@UserUID", SqlDbType.Int, 32);
                        siteparam1.Value = userUID;
                        SqlParameter siteparam2 = cmdgetPenaltyAmount.Parameters.Add("@LocationUID", SqlDbType.Int, 32);
                        siteparam2.Value = locationUID;
                        SqlParameter siteparam3 = cmdgetPenaltyAmount.Parameters.Add("@StartDate", SqlDbType.DateTime, 32);
                        siteparam3.Value = startDate;
                        SqlParameter siteparam4 = cmdgetPenaltyAmount.Parameters.Add("@EndDate", SqlDbType.DateTime, 32);
                        siteparam4.Value = endDate;


                        SqlDataReader penaltyAmountReader = cmdgetPenaltyAmount.ExecuteReader();
                        if (penaltyAmountReader.HasRows)
                        {
                            List<ECReportItem> ECPenaltyAmountList = new List<ECReportItem>();
                            while (penaltyAmountReader.Read())
                            {
                                ECReportItem ECreportItem;
                                if (!ECPenaltyAmountList.Exists(a => a.LOCATION_ID == int.Parse(penaltyAmountReader[1].ToString())))
                                {
                                    ECreportItem = new ECReportItem();
                                    ECreportItem.LOCATION_ID = int.Parse(penaltyAmountReader[1].ToString());
                                    ECreportItem.LOCATION_CODE = penaltyAmountReader[2].ToString();
                                    ECreportItem.LOCATION_NAME = penaltyAmountReader[3].ToString();
                                    ECreportItem.DESCRIPTION = penaltyAmountReader[5].ToString();
                                }
                                else
                                {
                                    ECreportItem = ECPenaltyAmountList.Find(a => a.LOCATION_ID == int.Parse(penaltyAmountReader[1].ToString()));
                                    ECPenaltyAmountList.Remove(ECreportItem);
                                }

                                DateTime date = DateTime.Parse(penaltyAmountReader[0].ToString());
                                int day = date.Day;
                                switch (day)
                                {
                                    case 1:
                                        ECreportItem.DAY_1_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 2:
                                        ECreportItem.DAY_2_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 3:
                                        ECreportItem.DAY_3_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 4:
                                        ECreportItem.DAY_4_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 5:
                                        ECreportItem.DAY_5_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 6:
                                        ECreportItem.DAY_6_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 7:
                                        ECreportItem.DAY_7_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 8:
                                        ECreportItem.DAY_8_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 9:
                                        ECreportItem.DAY_9_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 10:
                                        ECreportItem.DAY_10_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 11:
                                        ECreportItem.DAY_11_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 12:
                                        ECreportItem.DAY_12_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 13:
                                        ECreportItem.DAY_13_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 14:
                                        ECreportItem.DAY_14_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 15:
                                        ECreportItem.DAY_15_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 16:
                                        ECreportItem.DAY_16_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 17:
                                        ECreportItem.DAY_17_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 18:
                                        ECreportItem.DAY_18_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 19:
                                        ECreportItem.DAY_19_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 20:
                                        ECreportItem.DAY_20_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 21:
                                        ECreportItem.DAY_21_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 22:
                                        ECreportItem.DAY_22_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 23:
                                        ECreportItem.DAY_23_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 24:
                                        ECreportItem.DAY_24_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 25:
                                        ECreportItem.DAY_25_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 26:
                                        ECreportItem.DAY_26_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 27:
                                        ECreportItem.DAY_27_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 28:
                                        ECreportItem.DAY_28_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 29:
                                        ECreportItem.DAY_29_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 30:
                                        ECreportItem.DAY_30_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    case 31:
                                        ECreportItem.DAY_31_VALUE = Math.Round(double.Parse(penaltyAmountReader[4].ToString()), 2);
                                        break;
                                    default:
                                        break;
                                }

                                ECPenaltyAmountList.Add(ECreportItem);
                            }

                            ECReportItemList.AddRange(ECPenaltyAmountList);
                            connection.Close();
                        }
                        else
                        {
                            connection.Close();
                        }
                    }
                    using (var cmdgetTotalPenaltyCost = new SqlCommand("GetECTotalPenaltyCost"))
                    {
                        connection.Open();
                        cmdgetTotalPenaltyCost.Connection = connection;
                        cmdgetTotalPenaltyCost.CommandType = CommandType.StoredProcedure;
                        SqlParameter siteparam1 = cmdgetTotalPenaltyCost.Parameters.Add("@UserUID", SqlDbType.Int, 32);
                        siteparam1.Value = userUID;
                        SqlParameter siteparam2 = cmdgetTotalPenaltyCost.Parameters.Add("@LocationUID", SqlDbType.Int, 32);
                        siteparam2.Value = locationUID;
                        SqlParameter siteparam3 = cmdgetTotalPenaltyCost.Parameters.Add("@StartDate", SqlDbType.DateTime, 32);
                        siteparam3.Value = startDate;
                        SqlParameter siteparam4 = cmdgetTotalPenaltyCost.Parameters.Add("@EndDate", SqlDbType.DateTime, 32);
                        siteparam4.Value = endDate;


                        SqlDataReader totalPenaltyCtostReader = cmdgetTotalPenaltyCost.ExecuteReader();
                        if (totalPenaltyCtostReader.HasRows)
                        {
                            List<ECReportItem> totalPenaltyCostList = new List<ECReportItem>();
                            while (totalPenaltyCtostReader.Read())
                            {
                                ECReportItem ECreportItem;
                                if (!totalPenaltyCostList.Exists(a => a.LOCATION_ID == int.Parse(totalPenaltyCtostReader[1].ToString())))
                                {
                                    ECreportItem = new ECReportItem();
                                    ECreportItem.LOCATION_ID = int.Parse(totalPenaltyCtostReader[1].ToString());
                                    ECreportItem.LOCATION_CODE = totalPenaltyCtostReader[2].ToString();
                                    ECreportItem.LOCATION_NAME = totalPenaltyCtostReader[3].ToString();
                                    ECreportItem.DESCRIPTION = totalPenaltyCtostReader[5].ToString();
                                }
                                else
                                {
                                    ECreportItem = totalPenaltyCostList.Find(a => a.LOCATION_ID == int.Parse(totalPenaltyCtostReader[1].ToString()));
                                    totalPenaltyCostList.Remove(ECreportItem);
                                }

                                DateTime date = DateTime.Parse(totalPenaltyCtostReader[0].ToString());
                                int day = date.Day;
                                switch (day)
                                {
                                    case 1:
                                        ECreportItem.DAY_1_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 2:
                                        ECreportItem.DAY_2_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 3:
                                        ECreportItem.DAY_3_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 4:
                                        ECreportItem.DAY_4_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 5:
                                        ECreportItem.DAY_5_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 6:
                                        ECreportItem.DAY_6_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 7:
                                        ECreportItem.DAY_7_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 8:
                                        ECreportItem.DAY_8_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 9:
                                        ECreportItem.DAY_9_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 10:
                                        ECreportItem.DAY_10_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 11:
                                        ECreportItem.DAY_11_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 12:
                                        ECreportItem.DAY_12_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 13:
                                        ECreportItem.DAY_13_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 14:
                                        ECreportItem.DAY_14_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 15:
                                        ECreportItem.DAY_15_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 16:
                                        ECreportItem.DAY_16_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 17:
                                        ECreportItem.DAY_17_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 18:
                                        ECreportItem.DAY_18_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 19:
                                        ECreportItem.DAY_19_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 20:
                                        ECreportItem.DAY_20_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 21:
                                        ECreportItem.DAY_21_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 22:
                                        ECreportItem.DAY_22_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 23:
                                        ECreportItem.DAY_23_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 24:
                                        ECreportItem.DAY_24_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 25:
                                        ECreportItem.DAY_25_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 26:
                                        ECreportItem.DAY_26_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 27:
                                        ECreportItem.DAY_27_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 28:
                                        ECreportItem.DAY_28_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 29:
                                        ECreportItem.DAY_29_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 30:
                                        ECreportItem.DAY_30_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    case 31:
                                        ECreportItem.DAY_31_VALUE = Math.Round(double.Parse(totalPenaltyCtostReader[4].ToString()), 2);
                                        break;
                                    default:
                                        break;
                                }

                                totalPenaltyCostList.Add(ECreportItem);
                            }

                            ECReportItemList.AddRange(totalPenaltyCostList);
                            connection.Close();
                        }
                        else
                        {
                            connection.Close();
                       }
                    }
                    using (var cmdgetTotalPenaltyQty = new SqlCommand("GetECTotalPenaltyQty"))
                    {
                        connection.Open();
                        cmdgetTotalPenaltyQty.Connection = connection;
                        cmdgetTotalPenaltyQty.CommandType = CommandType.StoredProcedure;
                        SqlParameter siteparam1 = cmdgetTotalPenaltyQty.Parameters.Add("@UserUID", SqlDbType.Int, 32);
                        siteparam1.Value = userUID;
                        SqlParameter siteparam2 = cmdgetTotalPenaltyQty.Parameters.Add("@LocationUID", SqlDbType.Int, 32);
                        siteparam2.Value = locationUID;
                        SqlParameter siteparam3 = cmdgetTotalPenaltyQty.Parameters.Add("@StartDate", SqlDbType.DateTime, 32);
                        siteparam3.Value = startDate;
                        SqlParameter siteparam4 = cmdgetTotalPenaltyQty.Parameters.Add("@EndDate", SqlDbType.DateTime, 32);
                        siteparam4.Value = endDate;


                        SqlDataReader totalPenaltyQtyReader = cmdgetTotalPenaltyQty.ExecuteReader();
                        if (totalPenaltyQtyReader.HasRows)
                        {
                            List<ECReportItem> totalPenaltyQtyList = new List<ECReportItem>();
                            while (totalPenaltyQtyReader.Read())
                            {
                                ECReportItem ECreportItem;
                                if (!totalPenaltyQtyList.Exists(a => a.LOCATION_ID == int.Parse(totalPenaltyQtyReader[1].ToString())))
                                {
                                    ECreportItem = new ECReportItem();
                                    ECreportItem.LOCATION_ID = int.Parse(totalPenaltyQtyReader[1].ToString());
                                    ECreportItem.LOCATION_CODE = totalPenaltyQtyReader[2].ToString();
                                    ECreportItem.LOCATION_NAME = totalPenaltyQtyReader[3].ToString();
                                    ECreportItem.DESCRIPTION = totalPenaltyQtyReader[5].ToString();
                                }
                                else
                                {
                                    ECreportItem = totalPenaltyQtyList.Find(a => a.LOCATION_ID == int.Parse(totalPenaltyQtyReader[1].ToString()));
                                    totalPenaltyQtyList.Remove(ECreportItem);
                                }

                                DateTime date = DateTime.Parse(totalPenaltyQtyReader[0].ToString());
                                int day = date.Day;
                                switch (day)
                                {
                                    case 1:
                                        ECreportItem.DAY_1_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 2:
                                        ECreportItem.DAY_2_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 3:
                                        ECreportItem.DAY_3_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 4:
                                        ECreportItem.DAY_4_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 5:
                                        ECreportItem.DAY_5_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 6:
                                        ECreportItem.DAY_6_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 7:
                                        ECreportItem.DAY_7_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 8:
                                        ECreportItem.DAY_8_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 9:
                                        ECreportItem.DAY_9_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 10:
                                        ECreportItem.DAY_10_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 11:
                                        ECreportItem.DAY_11_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 12:
                                        ECreportItem.DAY_12_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 13:
                                        ECreportItem.DAY_13_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 14:
                                        ECreportItem.DAY_14_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 15:
                                        ECreportItem.DAY_15_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 16:
                                        ECreportItem.DAY_16_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 17:
                                        ECreportItem.DAY_17_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 18:
                                        ECreportItem.DAY_18_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 19:
                                        ECreportItem.DAY_19_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 20:
                                        ECreportItem.DAY_20_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 21:
                                        ECreportItem.DAY_21_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 22:
                                        ECreportItem.DAY_22_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 23:
                                        ECreportItem.DAY_23_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 24:
                                        ECreportItem.DAY_24_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 25:
                                        ECreportItem.DAY_25_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 26:
                                        ECreportItem.DAY_26_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 27:
                                        ECreportItem.DAY_27_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 28:
                                        ECreportItem.DAY_28_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 29:
                                        ECreportItem.DAY_29_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 30:
                                        ECreportItem.DAY_30_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    case 31:
                                        ECreportItem.DAY_31_VALUE = Math.Round(double.Parse(totalPenaltyQtyReader[4].ToString()), 2);
                                        break;
                                    default:
                                        break;
                                }

                                totalPenaltyQtyList.Add(ECreportItem);
                            }

                            ECReportItemList.AddRange(totalPenaltyQtyList);
                            connection.Close();
                        }
                        else
                        {
                            connection.Close();
                        }
                    }
                    using (var cmdgetTotalIncentivePerMT = new SqlCommand("GetECTotalIncentivePerMT"))
                    {
                        connection.Open();
                        cmdgetTotalIncentivePerMT.Connection = connection;
                        cmdgetTotalIncentivePerMT.CommandType = CommandType.StoredProcedure;
                        SqlParameter siteparam1 = cmdgetTotalIncentivePerMT.Parameters.Add("@UserUID", SqlDbType.Int, 32);
                        siteparam1.Value = userUID;
                        SqlParameter siteparam2 = cmdgetTotalIncentivePerMT.Parameters.Add("@LocationUID", SqlDbType.Int, 32);
                        siteparam2.Value = locationUID;
                        SqlParameter siteparam3 = cmdgetTotalIncentivePerMT.Parameters.Add("@StartDate", SqlDbType.DateTime, 32);
                        siteparam3.Value = startDate;
                        SqlParameter siteparam4 = cmdgetTotalIncentivePerMT.Parameters.Add("@EndDate", SqlDbType.DateTime, 32);
                        siteparam4.Value = endDate;


                        SqlDataReader totalIncentivePerMTReader = cmdgetTotalIncentivePerMT.ExecuteReader();
                        if (totalIncentivePerMTReader.HasRows)
                        {
                            List<ECReportItem> totalIncentivePerMTList = new List<ECReportItem>();
                            while (totalIncentivePerMTReader.Read())
                            {
                                ECReportItem ECreportItem;
                                if (!totalIncentivePerMTList.Exists(a => a.LOCATION_ID == int.Parse(totalIncentivePerMTReader[1].ToString())))
                                {
                                    ECreportItem = new ECReportItem();
                                    ECreportItem.LOCATION_ID = int.Parse(totalIncentivePerMTReader[1].ToString());
                                    ECreportItem.LOCATION_CODE = totalIncentivePerMTReader[2].ToString();
                                    ECreportItem.LOCATION_NAME = totalIncentivePerMTReader[3].ToString();
                                    ECreportItem.DESCRIPTION = totalIncentivePerMTReader[5].ToString();
                                }
                                else
                                {
                                    ECreportItem = totalIncentivePerMTList.Find(a => a.LOCATION_ID == int.Parse(totalIncentivePerMTReader[1].ToString()));
                                    totalIncentivePerMTList.Remove(ECreportItem);
                                }

                                DateTime date = DateTime.Parse(totalIncentivePerMTReader[0].ToString());
                                int day = date.Day;
                                switch (day)
                                {
                                    case 1:
                                        ECreportItem.DAY_1_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 2:
                                        ECreportItem.DAY_2_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 3:
                                        ECreportItem.DAY_3_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 4:
                                        ECreportItem.DAY_4_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 5:
                                        ECreportItem.DAY_5_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 6:
                                        ECreportItem.DAY_6_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 7:
                                        ECreportItem.DAY_7_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 8:
                                        ECreportItem.DAY_8_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 9:
                                        ECreportItem.DAY_9_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 10:
                                        ECreportItem.DAY_10_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 11:
                                        ECreportItem.DAY_11_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 12:
                                        ECreportItem.DAY_12_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 13:
                                        ECreportItem.DAY_13_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 14:
                                        ECreportItem.DAY_14_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 15:
                                        ECreportItem.DAY_15_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 16:
                                        ECreportItem.DAY_16_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 17:
                                        ECreportItem.DAY_17_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 18:
                                        ECreportItem.DAY_18_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 19:
                                        ECreportItem.DAY_19_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 20:
                                        ECreportItem.DAY_20_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 21:
                                        ECreportItem.DAY_21_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 22:
                                        ECreportItem.DAY_22_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 23:
                                        ECreportItem.DAY_23_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 24:
                                        ECreportItem.DAY_24_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 25:
                                        ECreportItem.DAY_25_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 26:
                                        ECreportItem.DAY_26_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 27:
                                        ECreportItem.DAY_27_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 28:
                                        ECreportItem.DAY_28_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 29:
                                        ECreportItem.DAY_29_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 30:
                                        ECreportItem.DAY_30_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    case 31:
                                        ECreportItem.DAY_31_VALUE = Math.Round(double.Parse(totalIncentivePerMTReader[4].ToString()), 2);
                                        break;
                                    default:
                                        break;
                                }

                                totalIncentivePerMTList.Add(ECreportItem);
                            }

                            ECReportItemList.AddRange(totalIncentivePerMTList);
                            connection.Close();
                        }
                        else
                        {
                            connection.Close();
                        }
                    }
                    using (var cmdgetTotalIncentive = new SqlCommand("GetECTotalIncentive"))
                    {
                        connection.Open();
                        cmdgetTotalIncentive.Connection = connection;
                        cmdgetTotalIncentive.CommandType = CommandType.StoredProcedure;
                        SqlParameter siteparam1 = cmdgetTotalIncentive.Parameters.Add("@UserUID", SqlDbType.Int, 32);
                        siteparam1.Value = userUID;
                        SqlParameter siteparam2 = cmdgetTotalIncentive.Parameters.Add("@LocationUID", SqlDbType.Int, 32);
                        siteparam2.Value = locationUID;
                        SqlParameter siteparam3 = cmdgetTotalIncentive.Parameters.Add("@StartDate", SqlDbType.DateTime, 32);
                        siteparam3.Value = startDate;
                        SqlParameter siteparam4 = cmdgetTotalIncentive.Parameters.Add("@EndDate", SqlDbType.DateTime, 32);
                        siteparam4.Value = endDate;


                        SqlDataReader totalIncentiveReader = cmdgetTotalIncentive.ExecuteReader();
                        if (totalIncentiveReader.HasRows)
                        {
                            List<ECReportItem> totalIncentiveList = new List<ECReportItem>();
                            while (totalIncentiveReader.Read())
                            {
                                ECReportItem ECreportItem;
                                if (!totalIncentiveList.Exists(a => a.LOCATION_ID == int.Parse(totalIncentiveReader[1].ToString())))
                                {
                                    ECreportItem = new ECReportItem();
                                    ECreportItem.LOCATION_ID = int.Parse(totalIncentiveReader[1].ToString());
                                    ECreportItem.LOCATION_CODE = totalIncentiveReader[2].ToString();
                                    ECreportItem.LOCATION_NAME = totalIncentiveReader[3].ToString();
                                    ECreportItem.DESCRIPTION = totalIncentiveReader[5].ToString();
                                }
                                else
                                {
                                    ECreportItem = totalIncentiveList.Find(a => a.LOCATION_ID == int.Parse(totalIncentiveReader[1].ToString()));
                                    totalIncentiveList.Remove(ECreportItem);
                                }

                                DateTime date = DateTime.Parse(totalIncentiveReader[0].ToString());
                                int day = date.Day;
                                switch (day)
                                {
                                    case 1:
                                        ECreportItem.DAY_1_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 2:
                                        ECreportItem.DAY_2_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 3:
                                        ECreportItem.DAY_3_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 4:
                                        ECreportItem.DAY_4_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 5:
                                        ECreportItem.DAY_5_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 6:
                                        ECreportItem.DAY_6_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 7:
                                        ECreportItem.DAY_7_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 8:
                                        ECreportItem.DAY_8_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 9:
                                        ECreportItem.DAY_9_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 10:
                                        ECreportItem.DAY_10_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 11:
                                        ECreportItem.DAY_11_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 12:
                                        ECreportItem.DAY_12_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 13:
                                        ECreportItem.DAY_13_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 14:
                                        ECreportItem.DAY_14_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 15:
                                        ECreportItem.DAY_15_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 16:
                                        ECreportItem.DAY_16_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 17:
                                        ECreportItem.DAY_17_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 18:
                                        ECreportItem.DAY_18_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 19:
                                        ECreportItem.DAY_19_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 20:
                                        ECreportItem.DAY_20_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 21:
                                        ECreportItem.DAY_21_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 22:
                                        ECreportItem.DAY_22_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 23:
                                        ECreportItem.DAY_23_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 24:
                                        ECreportItem.DAY_24_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 25:
                                        ECreportItem.DAY_25_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 26:
                                        ECreportItem.DAY_26_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 27:
                                        ECreportItem.DAY_27_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 28:
                                        ECreportItem.DAY_28_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 29:
                                        ECreportItem.DAY_29_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 30:
                                        ECreportItem.DAY_30_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    case 31:
                                        ECreportItem.DAY_31_VALUE = Math.Round(double.Parse(totalIncentiveReader[4].ToString()), 2);
                                        break;
                                    default:
                                        break;
                                }

                                totalIncentiveList.Add(ECreportItem);
                            }

                            ECReportItemList.AddRange(totalIncentiveList);
                            connection.Close();
                        }
                        else
                        {
                            connection.Close();
                        }
                    }
                    using (var cmdgetTotalCropCost = new SqlCommand("GetECTotalCropCost"))
                    {
                        connection.Open();
                        cmdgetTotalCropCost.Connection = connection;
                        cmdgetTotalCropCost.CommandType = CommandType.StoredProcedure;
                        SqlParameter siteparam1 = cmdgetTotalCropCost.Parameters.Add("@UserUID", SqlDbType.Int, 32);
                        siteparam1.Value = userUID;
                        SqlParameter siteparam2 = cmdgetTotalCropCost.Parameters.Add("@LocationUID", SqlDbType.Int, 32);
                        siteparam2.Value = locationUID;
                        SqlParameter siteparam3 = cmdgetTotalCropCost.Parameters.Add("@StartDate", SqlDbType.DateTime, 32);
                        siteparam3.Value = startDate;
                        SqlParameter siteparam4 = cmdgetTotalCropCost.Parameters.Add("@EndDate", SqlDbType.DateTime, 32);
                        siteparam4.Value = endDate;


                        SqlDataReader totalCropCostReader = cmdgetTotalCropCost.ExecuteReader();
                        if (totalCropCostReader.HasRows)
                        {
                            List<ECReportItem> totalIncentiveotalCropCostList = new List<ECReportItem>();
                            while (totalCropCostReader.Read())
                            {
                                ECReportItem ECreportItem;
                                if (!totalIncentiveotalCropCostList.Exists(a => a.LOCATION_ID == int.Parse(totalCropCostReader[1].ToString())))
                                {
                                    ECreportItem = new ECReportItem();
                                    ECreportItem.LOCATION_ID = int.Parse(totalCropCostReader[1].ToString());
                                    ECreportItem.LOCATION_CODE = totalCropCostReader[2].ToString();
                                    ECreportItem.LOCATION_NAME = totalCropCostReader[3].ToString();
                                    ECreportItem.DESCRIPTION = totalCropCostReader[5].ToString();
                                }
                                else
                                {
                                    ECreportItem = totalIncentiveotalCropCostList.Find(a => a.LOCATION_ID == int.Parse(totalCropCostReader[1].ToString()));
                                    totalIncentiveotalCropCostList.Remove(ECreportItem);
                                }

                                DateTime date = DateTime.Parse(totalCropCostReader[0].ToString());
                                int day = date.Day;
                                switch (day)
                                {
                                    case 1:
                                        ECreportItem.DAY_1_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 2:
                                        ECreportItem.DAY_2_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 3:
                                        ECreportItem.DAY_3_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 4:
                                        ECreportItem.DAY_4_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 5:
                                        ECreportItem.DAY_5_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 6:
                                        ECreportItem.DAY_6_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 7:
                                        ECreportItem.DAY_7_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 8:
                                        ECreportItem.DAY_8_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 9:
                                        ECreportItem.DAY_9_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 10:
                                        ECreportItem.DAY_10_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 11:
                                        ECreportItem.DAY_11_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 12:
                                        ECreportItem.DAY_12_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 13:
                                        ECreportItem.DAY_13_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 14:
                                        ECreportItem.DAY_14_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 15:
                                        ECreportItem.DAY_15_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 16:
                                        ECreportItem.DAY_16_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 17:
                                        ECreportItem.DAY_17_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 18:
                                        ECreportItem.DAY_18_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 19:
                                        ECreportItem.DAY_19_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 20:
                                        ECreportItem.DAY_20_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 21:
                                        ECreportItem.DAY_21_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 22:
                                        ECreportItem.DAY_22_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 23:
                                        ECreportItem.DAY_23_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 24:
                                        ECreportItem.DAY_24_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 25:
                                        ECreportItem.DAY_25_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 26:
                                        ECreportItem.DAY_26_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 27:
                                        ECreportItem.DAY_27_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 28:
                                        ECreportItem.DAY_28_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 29:
                                        ECreportItem.DAY_29_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 30:
                                        ECreportItem.DAY_30_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    case 31:
                                        ECreportItem.DAY_31_VALUE = Math.Round(double.Parse(totalCropCostReader[4].ToString()), 2);
                                        break;
                                    default:
                                        break;
                                }

                                totalIncentiveotalCropCostList.Add(ECreportItem);
                            }

                            ECReportItemList.AddRange(totalIncentiveotalCropCostList);
                            connection.Close();
                        }
                        else
                        {
                            connection.Close();
                        }
                    }
                    using (var cmdgetTotalCropCostAfterPenalty = new SqlCommand("GetECTotalCropCostAfterPenalty"))
                    {
                        connection.Open();
                        cmdgetTotalCropCostAfterPenalty.Connection = connection;
                        cmdgetTotalCropCostAfterPenalty.CommandType = CommandType.StoredProcedure;
                        SqlParameter siteparam1 = cmdgetTotalCropCostAfterPenalty.Parameters.Add("@UserUID", SqlDbType.Int, 32);
                        siteparam1.Value = userUID;
                        SqlParameter siteparam2 = cmdgetTotalCropCostAfterPenalty.Parameters.Add("@LocationUID", SqlDbType.Int, 32);
                        siteparam2.Value = locationUID;
                        SqlParameter siteparam3 = cmdgetTotalCropCostAfterPenalty.Parameters.Add("@StartDate", SqlDbType.DateTime, 32);
                        siteparam3.Value = startDate;
                        SqlParameter siteparam4 = cmdgetTotalCropCostAfterPenalty.Parameters.Add("@EndDate", SqlDbType.DateTime, 32);
                        siteparam4.Value = endDate;


                        SqlDataReader totalCropCostAfterPenaltyReader = cmdgetTotalCropCostAfterPenalty.ExecuteReader();
                        if (totalCropCostAfterPenaltyReader.HasRows)
                        {
                            List<ECReportItem> totalIncentiveotalCropCostAfterPenaltyList = new List<ECReportItem>();
                            while (totalCropCostAfterPenaltyReader.Read())
                            {
                                ECReportItem ECreportItem;
                                if (!totalIncentiveotalCropCostAfterPenaltyList.Exists(a => a.LOCATION_ID == int.Parse(totalCropCostAfterPenaltyReader[1].ToString())))
                                {
                                    ECreportItem = new ECReportItem();
                                    ECreportItem.LOCATION_ID = int.Parse(totalCropCostAfterPenaltyReader[1].ToString());
                                    ECreportItem.LOCATION_CODE = totalCropCostAfterPenaltyReader[2].ToString();
                                    ECreportItem.LOCATION_NAME = totalCropCostAfterPenaltyReader[3].ToString();
                                    ECreportItem.DESCRIPTION = totalCropCostAfterPenaltyReader[5].ToString();
                                }
                                else
                                {
                                    ECreportItem = totalIncentiveotalCropCostAfterPenaltyList.Find(a => a.LOCATION_ID == int.Parse(totalCropCostAfterPenaltyReader[1].ToString()));
                                    totalIncentiveotalCropCostAfterPenaltyList.Remove(ECreportItem);
                                }

                                DateTime date = DateTime.Parse(totalCropCostAfterPenaltyReader[0].ToString());
                                int day = date.Day;
                                switch (day)
                                {
                                    case 1:
                                        ECreportItem.DAY_1_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 2:
                                        ECreportItem.DAY_2_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 3:
                                        ECreportItem.DAY_3_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 4:
                                        ECreportItem.DAY_4_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 5:
                                        ECreportItem.DAY_5_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 6:
                                        ECreportItem.DAY_6_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 7:
                                        ECreportItem.DAY_7_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 8:
                                        ECreportItem.DAY_8_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 9:
                                        ECreportItem.DAY_9_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 10:
                                        ECreportItem.DAY_10_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 11:
                                        ECreportItem.DAY_11_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 12:
                                        ECreportItem.DAY_12_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 13:
                                        ECreportItem.DAY_13_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 14:
                                        ECreportItem.DAY_14_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 15:
                                        ECreportItem.DAY_15_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 16:
                                        ECreportItem.DAY_16_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 17:
                                        ECreportItem.DAY_17_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 18:
                                        ECreportItem.DAY_18_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 19:
                                        ECreportItem.DAY_19_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 20:
                                        ECreportItem.DAY_20_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 21:
                                        ECreportItem.DAY_21_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 22:
                                        ECreportItem.DAY_22_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 23:
                                        ECreportItem.DAY_23_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 24:
                                        ECreportItem.DAY_24_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 25:
                                        ECreportItem.DAY_25_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 26:
                                        ECreportItem.DAY_26_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 27:
                                        ECreportItem.DAY_27_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 28:
                                        ECreportItem.DAY_28_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 29:
                                        ECreportItem.DAY_29_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 30:
                                        ECreportItem.DAY_30_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    case 31:
                                        ECreportItem.DAY_31_VALUE = Math.Round(double.Parse(totalCropCostAfterPenaltyReader[4].ToString()), 2);
                                        break;
                                    default:
                                        break;
                                }

                                totalIncentiveotalCropCostAfterPenaltyList.Add(ECreportItem);
                            }

                            ECReportItemList.AddRange(totalIncentiveotalCropCostAfterPenaltyList);
                            connection.Close();
                            return ECReportItemList;
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