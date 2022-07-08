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
    public class LocationController : ApiController
    {
        [HttpGet]
        [ActionName("GetLocations")]
        public List<Location> Get(int UserUID, int locationType)   // locationType - 0: All, 1:Assigned only, 2: Not Assigned only
        {
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ListDbConnectionString"].ToString()))
                {
                    connection.Open();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        using (var cmdRegSite = new SqlCommand("getLocation"))
                        {
                            cmdRegSite.Connection = connection;
                            cmdRegSite.CommandType = CommandType.StoredProcedure;
                            SqlParameter siteparam1 = cmdRegSite.Parameters.Add("@UserUID", SqlDbType.Int, 32);
                            siteparam1.Value = UserUID;
                            SqlParameter siteparam2 = cmdRegSite.Parameters.Add("@LocationType", SqlDbType.Int, 32);
                            siteparam2.Value = locationType;

                            SqlDataReader reader = cmdRegSite.ExecuteReader();
                            if (reader.HasRows)
                            {
                                List<Location> locationList = new List<Location>();
                                while (reader.Read())
                                {
                                    Location location = new Location();
                                    location.LOC_ID = int.Parse(reader[0].ToString());
                                    location.LOC_CODE = reader[1].ToString();
                                    location.LOC_LOCATION_NAME = reader[2].ToString();
                                    location.LOC_DESCRIPTION = reader[3].ToString();
                                    locationList.Add(location);
                                }
                                return locationList;
                            }
                            else
                            {
                                return null ;
                            }
                        }                        
                    }
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

    }
}