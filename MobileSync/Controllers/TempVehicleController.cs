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

namespace MobileSync.Controllers
{
    public class TempVehicleController : ApiController
    {
        // GET: TempVehicleList
        [HttpGet]
        [ActionName("GetTempVehicleList")]
        public List<TempVehicle> Get(int UserUID)
        {
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ListDbConnectionString"].ToString()))
                {
                    connection.Open();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        using (var cmdRegSite = new SqlCommand("GetTempVehicleList"))
                        {
                            cmdRegSite.Connection = connection;
                            cmdRegSite.CommandType = CommandType.StoredProcedure;
                            SqlParameter siteparam1 = cmdRegSite.Parameters.Add("@UserUID", SqlDbType.Int, 32);
                            siteparam1.Value = UserUID;

                            SqlDataReader reader = cmdRegSite.ExecuteReader();
                            if (reader.HasRows)
                            {
                                List<TempVehicle> vehicleList = new List<TempVehicle>();
                                while (reader.Read())
                                {
                                    TempVehicle vehicle = new TempVehicle();
                                    vehicle.ECM_TEMP_VEH_LIST_VEHICLE_ID = int.Parse(reader[0].ToString());
                                    vehicle.ECM_TEMP_VEH_LIST_VEHICLE_DESCRIPTION = reader[1].ToString();
                                    vehicle.ECM_TEMP_VEH_LIST_ALIAS = reader[2].ToString();
                                    vehicle.ECM_TEMP_VEH_LIST_IS_ASSIGNED = int.Parse(reader[3].ToString());
                                    vehicleList.Add(vehicle);
                                }
                                return vehicleList;
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