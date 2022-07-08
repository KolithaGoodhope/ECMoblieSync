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
    public class LoginController : ApiController
    {
        [HttpGet]
        [ActionName("GetLoginByUserDetails")]
        public int Get(string userName,string pw,string did)
        {

            try
            {
                if (String.IsNullOrEmpty(userName) || 0 == userName.Trim().Length)
                {
                    return ((int)-400);
                }

                userName = userName.Trim();
                var validator = new Regex("^([A-Za-z0-9 ])+$");
                var validatorEmail = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

                if (!validatorEmail.IsMatch(userName) && !validator.IsMatch(userName))
                {
                    return ((int)-400);
                }

                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ListDbConnectionString"].ToString()))
                {
                    connection.Open();

                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = String.Format("SELECT USR_ID, USR_FIRST_NAME,USR_LAST_NAME FROM [ECM_M_USERS] WHERE [USR_USER_NAME] = '{0}'", userName);
                        SqlDataReader rdLogin = command.ExecuteReader();

                        int loginUID = -1;
                        if (rdLogin.Read())
                        {
                            loginUID = Convert.ToInt32(rdLogin["USR_ID"]);
                            rdLogin.Close();
                            using (var cmdRegSite = new SqlCommand("vaRegisterSite"))
                            {
                                cmdRegSite.Connection = connection;
                                cmdRegSite.CommandType = CommandType.StoredProcedure;
                                SqlParameter siteparam1 = cmdRegSite.Parameters.Add("@LoginID", SqlDbType.NVarChar, 32);
                                siteparam1.Value = userName;
                                SqlParameter siteparam2 = cmdRegSite.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 64);
                                siteparam2.Value = pw.Trim();
                                SqlParameter siteparam3 = cmdRegSite.Parameters.Add("@DeviceID", SqlDbType.NVarChar, 50);
                                siteparam3.Value = did.Trim();

                                object retVal = cmdRegSite.ExecuteScalar();
                                if (null != retVal)
                                {
                                    int respVal;
                                    switch (Convert.ToInt32(retVal))
                                    {
                                        case 1:
                                            //login authentication failed
                                            respVal = ((int)-1);
                                            break;
                                        case 2:
                                            //login already has an active site for a different device
                                            respVal = ((int)-2);
                                            break;
                                        case 3:
                                            //server side login disabled
                                            respVal = ((int)-3);
                                            break;

                                        case 0:
                                            //login success
                                            respVal = ((int)loginUID);
                                            break;
                                        default:
                                            //unexpected error occure
                                            respVal = ((int)-100);
                                            break;
                                    }
                                    return respVal;
                                }
                                else
                                {
                                    return ((int)-200);
                                }
                            }
                        }
                        else
                        {
                            return ((int)-400);
                        }
                    }
                }
            }
            catch
            {
                return ((int)-500);
            }
        }

        [HttpGet]
        [ActionName("GetLoginByUserDetails")]
        public Login Get(string userName, string pw)
        {

            try
            {
                userName = userName.Trim();
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ListDbConnectionString"].ToString()))
                {
                    connection.Open();
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = String.Format("SELECT USR_ID, USR_FIRST_NAME,USR_LAST_NAME,USR_USER_NAME,USR_PASSWORD,USR_LOCATION,USER_ROLE_ID FROM [ECM_M_USERS] WHERE [USR_USER_NAME] = '{0}'", userName);
                        SqlDataReader rdLogin = command.ExecuteReader();
                        Login login = null;
                        if (rdLogin.Read())
                        {
                            login = new Login();
                            login.USR_ID = Convert.ToInt32(rdLogin.GetValue(0));
                            login.USR_FIRST_NAME = rdLogin.GetValue(1).ToString();
                            login.USR_LAST_NAME = rdLogin.GetValue(2).ToString();
                            login.USR_USER_NAME = rdLogin.GetValue(3).ToString();
                            login.USR_PASSWORD = rdLogin.GetValue(4).ToString();
                            login.USER_ROLE_ID = Convert.ToInt32(rdLogin.GetValue(6));
                        }
                        return login;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"The file was not found: '{ex}'");
                return null;
            }
        }

        [HttpGet]
        [ActionName("GetUpdateUserPassword")]
        public int GetUpdateUserPassword(int userId, string currentpwd, string newpwd)
        {
            try
            {
               using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ListDbConnectionString"].ToString()))
                {
                    using (var cmdUsrPwd = new SqlCommand("updateUserPassword"))
                    {
                        conn.Open();
                        cmdUsrPwd.Connection = conn;
                        cmdUsrPwd.CommandType = CommandType.StoredProcedure;
                        SqlParameter paramhead1 = cmdUsrPwd.Parameters.Add("@UserUID", SqlDbType.Int, 32);
                        paramhead1.Value = userId;
                        SqlParameter paramhead2 = cmdUsrPwd.Parameters.Add("@CurrentPwd", SqlDbType.VarChar, 80);
                        paramhead2.Value = currentpwd;
                        SqlParameter paramhead3 = cmdUsrPwd.Parameters.Add("@NewPwd", SqlDbType.VarChar, 80);
                        paramhead3.Value = newpwd;

                        object retVal = cmdUsrPwd.ExecuteScalar();
                        int respVal = 0;
                        if (null != retVal)
                        {
                            switch (Convert.ToInt32(retVal))
                            {
                                case 1:
                                    //Invalid Current Password
                                    respVal = ((int)-1);
                                    break;
                                case 2:
                                    //success
                                    respVal = ((int)1);
                                    break;

                                default:
                                    //unexpected error occure
                                    respVal = ((int)-100);
                                    break;
                            }
                        }
                        else
                        {
                            //unexpected error occure
                            respVal = ((int)-100);
                        }
                        conn.Close();
                        return respVal;
                    }
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The file could not be opened: '{ex}'");
                return ((int)-100);
            }
        }

        [HttpPost]
        public void UpdateLogin(Login login)
        {

            SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ListDbConnectionString"].ToString());
            myConnection.Open();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE ECM_M_USERS SET USR_ACTIVE = @USR_ACTIVE WHERE USR_USER_NAME = @USR_USER_NAME ";
            sqlCmd.Connection = myConnection;
            sqlCmd.Parameters.AddWithValue("@USR_USER_NAME", login.USR_USER_NAME);
            sqlCmd.Parameters.AddWithValue("@USR_ACTIVE", login.USR_LOCATION);
            myConnection.Open();
            int rowInserted = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }
    }
}
