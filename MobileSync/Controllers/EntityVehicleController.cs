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
    public class EntityVehicleController : ApiController
    {
        // GET: EntityVehicle
        [HttpGet]
        [ActionName("GetEntityVehicleMapping")]
        public List<EntityVehicle> Get(int UserUID)   
        {
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ListDbConnectionString"].ToString()))
                {
                    connection.Open();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        using (var cmdRegSite = new SqlCommand("GetEntityVehicleMapping"))
                        {
                            cmdRegSite.Connection = connection;
                            cmdRegSite.CommandType = CommandType.StoredProcedure;
                            SqlParameter siteparam1 = cmdRegSite.Parameters.Add("@UserUID", SqlDbType.Int, 32);
                            siteparam1.Value = UserUID;

                            SqlDataReader reader = cmdRegSite.ExecuteReader();
                            if (reader.HasRows)
                            {
                                List<EntityVehicle> entityVehicleList = new List<EntityVehicle>();
                                while (reader.Read())
                                {
                                    EntityVehicle entityVehicle = new EntityVehicle();
                                    entityVehicle.ECM_ENT_VEH_MAP_ID = int.Parse(reader[0].ToString());
                                    entityVehicle.ECM_ENT_VEH_MAP_ENTITY_REF_ID = int.Parse(reader[1].ToString());
                                    entityVehicle.ECM_ENT_VEH_MAP_VEHICLE_REF_ID = int.Parse(reader[2].ToString());
                                    entityVehicleList.Add(entityVehicle);
                                }
                                return entityVehicleList;
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