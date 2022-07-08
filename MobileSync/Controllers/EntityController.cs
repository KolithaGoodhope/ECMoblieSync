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
    public class EntityController : ApiController
    {
        [HttpGet]
        [ActionName("GetEntities")]
        public List<Entity> Get(int UserUID)   
        {
            try
            {
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ListDbConnectionString"].ToString()))
                {
                    connection.Open();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        using (var cmdRegSite = new SqlCommand("GetEntity"))
                        {
                            cmdRegSite.Connection = connection;
                            cmdRegSite.CommandType = CommandType.StoredProcedure;
                            SqlParameter siteparam1 = cmdRegSite.Parameters.Add("@UserUID", SqlDbType.Int, 32);
                            siteparam1.Value = UserUID;

                            SqlDataReader reader = cmdRegSite.ExecuteReader();
                            if (reader.HasRows)
                            {
                                List<Entity> entityList = new List<Entity>();
                                while (reader.Read())
                                {
                                    Entity entity = new Entity();
                                    entity.ECM_ENTITY_ID = int.Parse(reader[0].ToString());
                                    entity.ECM_ENTITY_DESCRIPTION = reader[1].ToString();
                                    entity.ECM_ALIAS = reader[2].ToString();
                                    entity.ECM_ENTITY_REF_ID = int.Parse(reader[3].ToString());
                                    entity.ECM_ENTITY_REF_PARENT_ID = int.Parse(reader[4].ToString());
                                    entity.ECM_ENTITY_TYPE = int.Parse(reader[5].ToString());
                                    entityList.Add(entity);
                                }
                                return entityList;
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