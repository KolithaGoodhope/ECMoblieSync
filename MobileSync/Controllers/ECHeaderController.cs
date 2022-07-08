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
    public class ECHeaderController : ApiController
    {
        [HttpGet]
        [ActionName("GetUpdateConfirmation")]
        public int GetUpdateConfirmation(int userUID, int value, int ecHeaderUID)   // locationType - 0: reject, 1: approved
        {
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ListDbConnectionString"].ToString()))
                {
                    connection.Open();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        using (var cmdRegSite = new SqlCommand("getUpdateECHeaderConfirmation"))
                        {
                            cmdRegSite.Connection = connection;
                            cmdRegSite.CommandType = CommandType.StoredProcedure;
                            SqlParameter siteparam1 = cmdRegSite.Parameters.Add("@userUID", SqlDbType.Int, 32);
                            siteparam1.Value = userUID;
                            SqlParameter siteparam2 = cmdRegSite.Parameters.Add("@value", SqlDbType.Int, 32);
                            siteparam2.Value = value;
                            SqlParameter siteparam3 = cmdRegSite.Parameters.Add("@ECHeaderUID", SqlDbType.Int, 32);
                            siteparam3.Value = ecHeaderUID;

                            SqlDataReader reader = cmdRegSite.ExecuteReader();
                            if (reader.HasRows & reader.Read())
                            {
                               return int.Parse(reader[0].ToString());                                
                            }
                            else
                            {
                                return 0;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"The file could not be opened: '{ex}'");
                return 0;
            }
        }

    }
}