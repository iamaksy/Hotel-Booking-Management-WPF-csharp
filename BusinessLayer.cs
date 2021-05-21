using HBM.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBM
{
    public class BusinessLayer
    {
        SqlConnection Con;
        SqlCommand Cmd;

        public BusinessLayer()
        {
            Con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL_Conn"].ConnectionString);

            Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandType = System.Data.CommandType.StoredProcedure;
        }

        public bool Register(Register ViewData, out string Password)
        {
            bool res = false;
            string Passw = string.Empty;

            try
            {
                Cmd.Parameters.Clear();
                Cmd.CommandText = "UDP_REGISTER";
                Cmd.Parameters.AddWithValue("@USERNAME", ViewData.Username);
                Cmd.Parameters.AddWithValue("@ISADMIN", false);
                Cmd.Parameters.AddWithValue("@CONTACT", ViewData.Contact1);
                Cmd.Parameters.AddWithValue("@ALT_CONTACT", ViewData.Contact2);
                Cmd.Parameters.AddWithValue("@EMAIL", ViewData.Email);
                Cmd.Parameters.AddWithValue("@LOCATION", ViewData.Location);
                Cmd.Parameters.AddWithValue("@ADDRESS", string.Empty);
                Cmd.Parameters.AddWithValue("@PINCODE", ViewData.PinCode);

                Con.Open();
                if (Cmd.ExecuteNonQuery() > 0)
                {
                    res = true;

                    #region Random Passowrd

                    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    var stringChars = new char[8];
                    var random = new Random();

                    for (int i = 0; i < stringChars.Length; i++)
                    {
                        stringChars[i] = chars[random.Next(chars.Length)];
                    }

                    Passw = new String(stringChars);
                    Register_trigger(ViewData.Username, Passw);

                    #endregion
                }
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
            finally
            {
                Con.Close();
                Password = Passw;
            }
            return res;
        }

        public bool Register_trigger(string Username, String Password)
        {
            bool res = false;
            try
            {
                Cmd.Parameters.Clear();
                Cmd.CommandText = "UDP_REGISTERPASSWORD";
                Cmd.Parameters.AddWithValue("@USERNAME", Username);
                Cmd.Parameters.AddWithValue("@Password", Password);
                if (Cmd.ExecuteNonQuery() > 0)
                { res = true; }
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
            finally
            {
                Con.Close();
            }
            return res;
        }

        public bool Register(string Name, bool Admin, long Cont1, long Cont2, string Email, string Loc, String Add, int PinCode, out string Password)
        {
            bool res = false;
            string Passw = string.Empty;

            try
            {
                Cmd.Parameters.Clear();
                Cmd.CommandText = "UDP_REGISTER";
                Cmd.Parameters.AddWithValue("@USERNAME", Name);
                Cmd.Parameters.AddWithValue("@ISADMIN", false);
                Cmd.Parameters.AddWithValue("@CONTACT", Cont1);
                Cmd.Parameters.AddWithValue("@ALT_CONTACT", Cont2);
                Cmd.Parameters.AddWithValue("@EMAIL", Email);
                Cmd.Parameters.AddWithValue("@LOCATION", Loc);
                Cmd.Parameters.AddWithValue("@ADDRESS", Add);
                Cmd.Parameters.AddWithValue("@PINCODE", PinCode);

                Con.Open();
                if (Cmd.ExecuteNonQuery() > 0)
                {
                    res = true;

                    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    var stringChars = new char[8];
                    var random = new Random();

                    for (int i = 0; i < stringChars.Length; i++)
                    {
                        stringChars[i] = chars[random.Next(chars.Length)];
                    }

                    Passw = new String(stringChars);
                }

            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
            finally
            {
                Con.Close();
                Password = Passw;
            }
            return res;
        }

        public bool Login(Login ViewData)
        {
            bool res = false;
            string Passw = string.Empty;

            try
            {
                Cmd.Parameters.Clear();
                Cmd.CommandText = "UDP_LOGIN";
                Cmd.Parameters.AddWithValue("@USERNAME", ViewData.Username);
                Cmd.Parameters.AddWithValue("@PASSWORD", ViewData.Password);

                Con.Open();
                var data = Cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        if (data.GetInt32(0) == 1)
                            res = true;
                    }
                }
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
            finally
            {
                Con.Close();
            }
            return res;
        }

        public RoomDetail GetRoom(string RoomCode)
        {
            RoomDetail RD = null;
            try
            {
                Cmd.Parameters.Clear();
                Cmd.CommandText = "UDP_GETROOM";
                Cmd.Parameters.AddWithValue("@CODE", RoomCode);

                Con.Open();
                var result = Cmd.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        RD = new RoomDetail();

                        RD.Title = result.GetString(1);
                        RD.Description = result.GetString(2);
                        RD.Television = result.GetBoolean(3);
                        RD.WiFi = result.GetBoolean(4);
                        RD.OutDoorGames = result.GetBoolean(5);
                        RD.Breakfast = result.GetBoolean(6);
                        RD.Lunch = result.GetBoolean(7);
                        RD.BedType = result.GetString(8);
                        RD.Aminity_1 = result.GetString(9);
                        RD.Aminity_2 = result.GetString(10);
                        RD.Luggage = result.GetBoolean(11);
                        RD.BellBoy = result.GetBoolean(12);
                        RD.Aminity_3 = result.GetString(13);

                        break;
                    }
                }
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
            finally
            {
                Con.Close();
            }
            return RD;
        }

        public List<Dashboard> GetDashBoard()
        {
            List<Dashboard> DB_list = new List<Dashboard>();
            try
            {
                Cmd.Parameters.Clear();
                Cmd.CommandText = "UDP_GETDASHBOARD";

                Con.Open();
                var result = Cmd.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        Dashboard o = new Dashboard();

                        o.RoomCode = result.GetString(0);
                        o.Title = result.GetString(1);
                        o.Description = result.GetString(2);
                        o.Price = result.GetDouble(14);
                        o.DPrice = result.GetDouble(15);

                        DB_list.Add(o);
                    }
                }
            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
            finally
            {
                Con.Close();
            }
            return DB_list;
        }

        public Booking LoadBookingData(string RoomCode)
        {
            Booking o = null;
            try
            {
                Cmd.Parameters.Clear();
                Cmd.CommandText = "UDP_GETBOOKINGDATA";
                Cmd.Parameters.AddWithValue("@CODE", RoomCode);

                Con.Open();
                var result = Cmd.ExecuteReader();
                if (result.HasRows)
                {
                    o = new Booking();
                    while (result.Read())
                    {
                        o = new Booking();

                        o.RoomCode = result.GetString(0);
                        o.Title = result.GetString(1);
                        o.Desc = result.GetString(2);
                        o.RoomPrice = result.GetDouble(3);

                        break;
                    }
                }
            }
            catch (SqlException ex) { ex.ToString(); }
            finally
            {
                Con.Close();
            }
            return o;
        }

        public void BookRoom(Booking o, int TotalDays, string UserName)
        {
            try
            {
                Cmd.Parameters.Clear();
                Cmd.CommandText = "UDP_BOOKROOM";
                Cmd.Parameters.AddWithValue("@CODE", o.RoomCode);
                Cmd.Parameters.AddWithValue("@GUESTUSERNAME", UserName);
                Cmd.Parameters.AddWithValue("@CHECKIN", o.CheckIN);
                Cmd.Parameters.AddWithValue("@CHECKOUT", o.ChecckOut);
                Cmd.Parameters.AddWithValue("@DAYSCOUNT", TotalDays);
                Cmd.Parameters.AddWithValue("@PRICE", o.Price);

                Con.Open();
                if (Cmd.ExecuteNonQuery() > 0) { }
            }
            catch (SqlException ex) { ex.ToString(); }
            finally
            {
                Con.Close();
            }
        }

    }
}