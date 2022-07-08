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
    public class KeyValueController : ApiController
    {
        [HttpGet]
        [ActionName("GetKeyValue")]
        public List<ECKeyValue> GetKeyValue(int UserUID, int roleID)
        {
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ListDbConnectionString"].ToString()))
                {
                    connection.Open();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        using (var cmdRegSite = new SqlCommand("GetKeyValue"))
                        {
                            cmdRegSite.Connection = connection;
                            cmdRegSite.CommandType = CommandType.StoredProcedure;
                            SqlParameter siteparam1 = cmdRegSite.Parameters.Add("@UserUID", SqlDbType.Int, 32);
                            siteparam1.Value = UserUID;
                            SqlParameter siteparam2 = cmdRegSite.Parameters.Add("@RoleID", SqlDbType.Int, 32);
                            siteparam2.Value = roleID;

                            SqlDataReader reader = cmdRegSite.ExecuteReader();
                            if (reader.HasRows)
                            {
                                List<ECKeyValue> ECKeyValueList = new List<ECKeyValue>();
                                while (reader.Read())
                                {
                                    ECKeyValue keyValue = new ECKeyValue();
                                    keyValue.ECM_VAL_ID = int.Parse(reader[0].ToString());
                                    keyValue.ECM_VAL_KEY = reader[1].ToString();
                                    keyValue.ECM_VAL_VALUE = reader[2].ToString();
                                    keyValue.ECM_VAL_DESCRIPTION = reader[3].ToString();
                                    keyValue.ECM_VAL_ACTIVE = int.Parse(reader[4].ToString());
                                    keyValue.ECM_VAL_VALUE_2 = reader[5].ToString();
                                    ECKeyValueList.Add(keyValue);
                                }
                                return ECKeyValueList;
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