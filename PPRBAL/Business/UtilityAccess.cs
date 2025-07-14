using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace PPRBAL.Business
{
    public class UtilityAccess : System.Web.Mvc.ActionFilterAttribute
    {
        //public static string BaseUrl = ConfigurationManager.AppSettings["baseurl"].ToString();
        public enum DropdownType
        {
            All = 0,
            Required = 1,
            NoRequired = 2,
        }
        public static CultureInfo enUS = new CultureInfo("en-US");
        public static string[] formatStrings = new string[] {
             "MM-dd-yyyy","MM-dd-yyyy hh:mm", "MM-dd-yyyy hh:mm:ss","MM-dd-yyyy hh:mm:ss tt", "MM-dd-yyyy hh:mm tt",
             "MM/dd/yyyy","MM/dd/yyyy hh:mm", "MM/dd/yyyy hh:mm:ss","MM/dd/yyyy hh:mm:ss tt", "MM/dd/yyyy hh:mm tt",
             "yyyy-MM-dd","yyyy-MM-dd hh:mm", "yyyy-MM-dd hh:mm:ss","yyyy-MM-dd hh:mm:ss tt", "yyyy-MM-dd hh:mm tt",
             "yyyy/MM/dd","yyyy/MM/dd hh:mm", "yyyy/MM/dd hh:mm:ss","yyyy/MM/dd hh:mm:ss tt", "yyyy/MM/dd hh:mm tt",
             "MM/dd/yyyy", "MM/dd/yyyy HH:mm", "MM/dd/yyyy HH:mm:ss", "MM/dd/yyyy HH:mm:ss tt", "MM/dd/yyyy HH:mm tt",
             "dd/MMM/yyyy", "dd/MMM/yyyy HH:mm", "dd/MMM/yyyy HH:mm:ss", "dd/MMM/yyyy HH:mm:ss tt", "dd/MMM/yyyy HH:mm tt",
             "MMM-dd-yyyy", "MMM-dd-yyyy HH:mm", "MMM-dd-yyyy HH:mm:ss", "MMM-dd-yyyy HH:mm:ss tt", "MMM-dd-yyyy HH:mm tt",
             "MMM/dd/yyyy", "MMM/dd/yyyy HH:mm", "MMM/dd/yyyy HH:mm:ss", "MMM/dd/yyyy HH:mm:ss tt", "MMM/dd/yyyy HH:mm tt", };
        public static List<SelectListItem> DRPBlankList()
        {
            List<SelectListItem> _items = new List<SelectListItem>();
            //_items.Add(new SelectListItem { Value = "FirstAid", Text = "First Aid" });
            //_items.Add(new SelectListItem { Value = "Ambulance", Text = "Ambulance" });
            //_items.Add(new SelectListItem { Value = "EmergencyKit", Text = "Emergency Kit" });
            return _items;
        }
        public static List<SelectListItem> RenderList(DataTable dt, Int32 Type)
        {
            List<SelectListItem> _items = new List<SelectListItem>();
            try
            {
                DropdownType drpType = (DropdownType)Type;
                switch (drpType)
                {
                    case DropdownType.All:
                        _items.Add(new SelectListItem { Value = "-1", Text = "All" });
                        break;
                    case DropdownType.Required:
                        _items.Add(new SelectListItem { Value = "", Text = "--Select--" });
                        break;
                    case DropdownType.NoRequired:
                        _items.Add(new SelectListItem { Value = "0", Text = "--Select--" });
                        break;
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        _items.Add(new SelectListItem { Value = Convert.ToString(row["Value"]), Text = Convert.ToString(row["Text"]) });
                    }
                }


                return _items;
            }
            catch (Exception ex)
            {
                //ApplicationLogger.LogError(ex, "UtilityAccess", "RenderList");
                return _items;
            }
        }

        public static List<SelectListItem> UnitList(DataTable dt, Int32 Type)
        {
            List<SelectListItem> _items = new List<SelectListItem>();
            try
            {
               //_items.Add(new SelectListItem { Value = "0", Text = "-Select-" });
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        _items.Add(new SelectListItem { Value = Convert.ToString(row["ID"]), Text = Convert.ToString(row["Unit"]) });
                    }
                }
                return _items;
            }
            catch (Exception ex)
            {
                ///ApplicationLogger.LogError(ex, "UtilityAccess", "RenderCountryList");
                return _items;
            }
        }
        public static List<SelectListItem> StatusListValTextNew(Int32 Type)
        {
            List<SelectListItem> _items = new List<SelectListItem>();
            DropdownType drpType = (DropdownType)Type;
            switch (drpType)
            {
                case DropdownType.All:
                    _items.Add(new SelectListItem { Value = "-1", Text = "All" });
                    break;
                //case DropdownType.Required:
                //    _items.Add(new SelectListItem { Value = "", Text = "--Select--" });
                //    break;
                case DropdownType.NoRequired:
                    _items.Add(new SelectListItem { Value = "0", Text = "--Select--" });
                    break;
            }

            _items.Add(new SelectListItem { Value = "Active", Text = "Active" });
            _items.Add(new SelectListItem { Value = "Inactive", Text = "Inactive" });

            return _items;
        }
        public static List<SelectListItem> StatusListValTextPPR(Int32 Type)
        {
            List<SelectListItem> _items = new List<SelectListItem>();
            DropdownType drpType = (DropdownType)Type;
            switch (drpType)
            {
                case DropdownType.All:
                    _items.Add(new SelectListItem { Value = "-1", Text = "All" });
                    break;
                //case DropdownType.Required:
                //    _items.Add(new SelectListItem { Value = "", Text = "--Select--" });
                //    break;
                case DropdownType.NoRequired:
                    _items.Add(new SelectListItem { Value = "0", Text = "--Select--" });
                    break;
            }

            _items.Add(new SelectListItem { Value = "0", Text = "New" });
            _items.Add(new SelectListItem { Value = "1", Text = "Level 1" });
            _items.Add(new SelectListItem { Value = "2", Text = "Level 2" });
            _items.Add(new SelectListItem { Value = "3", Text = "Level 3" });

            return _items;
        }
        public static List<SelectListItem> StatusListValcreate(Int32 Type)
        {
            List<SelectListItem> _items = new List<SelectListItem>();
            DropdownType drpType = (DropdownType)Type;
            switch (drpType)
            {
                case DropdownType.All:
                    _items.Add(new SelectListItem { Value = "-1", Text = "All" });
                    break;
                //case DropdownType.Required:
                //    _items.Add(new SelectListItem { Value = "", Text = "--Select--" });
                //    break;
                case DropdownType.NoRequired:
                    _items.Add(new SelectListItem { Value = "0", Text = "--Select--" });
                    break;
            }

            _items.Add(new SelectListItem { Value = "1", Text = "Open" });
            //_items.Add(new SelectListItem { Value = "2", Text = "Open" });
            _items.Add(new SelectListItem { Value = "3", Text = "Closed" });


            return _items;
        }
        public static List<SelectListItem> StatusListValcreateN(Int32 Type)
        {
            List<SelectListItem> _items = new List<SelectListItem>();
            DropdownType drpType = (DropdownType)Type;
            switch (drpType)
            {
                case DropdownType.All:
                    _items.Add(new SelectListItem { Value = "-1", Text = "All" });
                    break;
                //case DropdownType.Required:
                //    _items.Add(new SelectListItem { Value = "", Text = "--Select--" });
                //    break;
                case DropdownType.NoRequired:
                    _items.Add(new SelectListItem { Value = "0", Text = "Select Status" });
                    break;
            }

            _items.Add(new SelectListItem { Value = "1", Text = "New" });
            //_items.Add(new SelectListItem { Value = "2", Text = "Open" });
            _items.Add(new SelectListItem { Value = "3", Text = "Closed" });


            return _items;
        }
        public static List<SelectListItem> ApprovalStatusList(Int32 Type)
        {
            List<SelectListItem> _items = new List<SelectListItem>();
            DropdownType drpType = (DropdownType)Type;
            switch (drpType)
            {
                case DropdownType.All:
                    _items.Add(new SelectListItem { Value = "-1", Text = "All" });
                    break;
                //case DropdownType.Required:
                //    _items.Add(new SelectListItem { Value = "", Text = "--Select--" });
                //    break;
                case DropdownType.NoRequired:
                    _items.Add(new SelectListItem { Value = "-1", Text = "Select Approval Status" });
                    break;
            }

            _items.Add(new SelectListItem { Value = "0", Text = "Open" }); 
            _items.Add(new SelectListItem { Value = "1", Text = "Level 1" });
            _items.Add(new SelectListItem { Value = "2", Text = "Level 2" });
            _items.Add(new SelectListItem { Value = "3", Text = "Level 3" });
            _items.Add(new SelectListItem { Value = "4", Text = "Approved" });
            _items.Add(new SelectListItem { Value = "5", Text = "Closed" });


            return _items;
        }
        public static List<SelectListItem> StatusList(Int32 Type)
        {
            List<SelectListItem> _items = new List<SelectListItem>();
            try
            {
                DropdownType drpType = (DropdownType)Type;
                switch (drpType)
                {
                    case DropdownType.All:
                        _items.Add(new SelectListItem { Value = "-1", Text = "All" });
                        break;
                    case DropdownType.Required:
                        _items.Add(new SelectListItem { Value = "", Text = "--Select--" });
                        break;
                    case DropdownType.NoRequired:
                        _items.Add(new SelectListItem { Value = "0", Text = "--Select--" });
                        break;
                }
                _items.Add(new SelectListItem { Value = "1", Text = "Yes" });
                _items.Add(new SelectListItem { Value = "2", Text = "NO" });
                return _items;
            }
            catch (Exception ex)
            {
                //ApplicationLogger.LogError(ex, "UtilityAccess", "RenderList");
                return _items;
            }
        }
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
        public static double DateTimeToUnixTimestamp(DateTime dateTime)
        {
            return (dateTime - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
        }
        public static String SessionGet(String key)
        {
            try
            {
                String sValue = String.Empty;
                if (HttpContext.Current.Session[key] != null)
                    sValue = Convert.ToString(HttpContext.Current.Session[key]);
                else if (HttpContext.Current.Request.Cookies["FPCookie"][key] != null)
                {
                    HttpContext.Current.Session[key] = HttpContext.Current.Request.Cookies["FPCookie"][key];
                    sValue = HttpContext.Current.Request.Cookies["FPCookie"][key];
                }

                return sValue;
            }
            catch (Exception ex)
            {
                //ApplicationLogger.LogError(ex, "UtilitiesAccess", "SessionGet");
                return "";
            }
        }
        public static string Encrypt(string strText)
        {
            try
            {
                Exception exObj;
                string strEncryptedText;
                if (DevelopTech.security.Encrypt(strText, out strEncryptedText, out exObj) == -1)
                {
                    //ExceptionUtility.LogException(exObj, "converter class");
                    //ApplicationLogger.LogError(exObj, "Utilities", "Encrypt");
                }
                return strEncryptedText;
            }
            catch (Exception ex)
            {
                //ApplicationLogger.LogError(ex, "Utilities", "Encrypt");
                // ExceptionUtility.LogException(ex, "converter class");
                return "";
            }
        }
        public static string Decrypt(string strText)
        {
            try
            {
                strText = strText.Replace(" ", "+");
                Exception exObj;
                string strDecryptedText;

                if (DevelopTech.security.Decrypt(strText, out strDecryptedText, out exObj) == -1)
                {
                    //ExceptionUtility.LogException(exObj, "converter class");
                    //ApplicationLogger.LogError(exObj, "Utilities", "Decrypt");
                }
                return strDecryptedText;
            }
            catch (Exception ex)
            {
                ///ApplicationLogger.LogError(ex, "Utilities", "Decrypt");
                //ExceptionUtility.LogException(ex, "converter class");
                return "";
            }
        }
        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        public static String FromDate(String date = null)
        {
            try
            {
                var timeZone = "0";
                int hours = 0, minutes = 0;
                string operator_ = "-";
                if (date == null)
                {
                    HttpCookie seenAlertsCookie = HttpContext.Current.Request.Cookies["time_zone"];
                    if (seenAlertsCookie != null)
                    {
                        try
                        {
                            timeZone = seenAlertsCookie.Value == "" ? "0" : seenAlertsCookie.Value;
                        }
                        catch (Exception) { }
                    }
                    if (timeZone != "0")
                    {
                        operator_ = timeZone.Substring(0, 1);
                        timeZone = timeZone.Substring(1);
                        var splitstr = timeZone.Split(':');
                        hours = Convert.ToInt32(splitstr[0]) * (operator_ == "+" ? 1 : -1);
                        minutes = Convert.ToInt32(splitstr[1]) * (operator_ == "+" ? 1 : -1);
                    }
                }
                var dt = UtilityAccess.NullableTryParseDateTime(date) ?? null;
                return (dt != null ? dt.Value.AddHours(hours).AddMinutes(minutes).ToString("MM/dd/yyyy") : DateTime.UtcNow.AddHours(hours).AddMinutes(minutes).ToString("MM/dd/yyyy"));
            }
            catch
            {
                return "";
            }
        }
        public static String ToDate(String date = null)
        {
            try
            {
                var timeZone = "0";
                int hours = 0, minutes = 0;
                string operator_ = "-";
                if (date == null)
                {
                    HttpCookie seenAlertsCookie = HttpContext.Current.Request.Cookies["time_zone"];
                    if (seenAlertsCookie != null)
                    {
                        try
                        {
                            timeZone = seenAlertsCookie.Value == "" ? "0" : seenAlertsCookie.Value;
                        }
                        catch (Exception) { }
                    }
                    if (timeZone != "0")
                    {
                        operator_ = timeZone.Substring(0, 1);
                        timeZone = timeZone.Substring(1);
                        var splitstr = timeZone.Split(':');
                        hours = Convert.ToInt32(splitstr[0]) * (operator_ == "+" ? 1 : -1);
                        minutes = Convert.ToInt32(splitstr[1]) * (operator_ == "+" ? 1 : -1);
                    }
                }
                var dt = UtilityAccess.NullableTryParseDateTime(date) ?? null;
                return (dt != null ? dt.Value.AddHours(hours).AddMinutes(minutes).ToString("MM/dd/yyyy") + " 23:59:59" : DateTime.UtcNow.AddHours(hours).AddMinutes(minutes).ToString("MM/dd/yyyy") + " 23:59:59");
            }
            catch
            {
                return "";
            }
        }
        public static DateTime? NullableTryParseDateTime(string text = null)
        {
            DateTime value;
            return DateTime.TryParseExact(text, formatStrings, enUS, 0, out value) ? value : (DateTime?)null;
        }
        public static List<SelectListItem> CertificationStatusList(Int32 Type)
        {
            List<SelectListItem> _items = new List<SelectListItem>();
            DropdownType drpType = (DropdownType)Type;
            switch (drpType)
            {
                case DropdownType.All:
                    _items.Add(new SelectListItem { Value = "-1", Text = "All" });
                    break;
                //case DropdownType.Required:
                //    _items.Add(new SelectListItem { Value = "", Text = "--Select--" });
                //    break;
                case DropdownType.NoRequired:
                    _items.Add(new SelectListItem { Value = "0", Text = "--Select--" });
                    break;
            }
            _items.Add(new SelectListItem { Value = "1", Text = "Started" });
            _items.Add(new SelectListItem { Value = "2", Text = "Not Started" });
            _items.Add(new SelectListItem { Value = "3", Text = "Certified" });
            _items.Add(new SelectListItem { Value = "4", Text = "Under Testing(In House)" });
            _items.Add(new SelectListItem { Value = "5", Text = "NA" });

            return _items;
        }
        public static List<SelectListItem> CustomerList(DataTable dt, Int32 Type)
        {
            List<SelectListItem> _items = new List<SelectListItem>();
            try
            {
                _items.Add(new SelectListItem { Value = "0", Text = "-Select-" });
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        _items.Add(new SelectListItem { Value = Convert.ToString(row["ID"]), Text = Convert.ToString(row["CustomerName"]) });
                    }
                }
                return _items;
            }
            catch (Exception ex)
            {
                ///ApplicationLogger.LogError(ex, "UtilityAccess", "RenderCountryList");
                return _items;
            }
        }
        public static List<SelectListItem> AuthorityList(DataTable dt, Int32 Type)
        {
            List<SelectListItem> _items = new List<SelectListItem>();
            try
            {
                _items.Add(new SelectListItem { Value = "0", Text = "-Select-" });
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        _items.Add(new SelectListItem { Value = Convert.ToString(row["ID"]), Text = Convert.ToString(row["Name"]) });
                    }
                }
                return _items;
            }
            catch (Exception ex)
            {
                ///ApplicationLogger.LogError(ex, "UtilityAccess", "RenderCountryList");
                return _items;
            }
        }
        public static List<SelectListItem> StatusListCategory()
        {
            List<SelectListItem> _items = new List<SelectListItem>();
            //DropdownType drpType = (DropdownType)Type;
            //switch (drpType)
            //{
            //    case DropdownType.All:
            //        _items.Add(new SelectListItem { Value = "-1", Text = "All" });
            //        break;
            //    //case DropdownType.Required:
            //    //    _items.Add(new SelectListItem { Value = "", Text = "--Select--" });
            //    //    break;
            //    case DropdownType.NoRequired:
            //        _items.Add(new SelectListItem { Value = "0", Text = "--Select--" });
            //        break;
            //}

            _items.Add(new SelectListItem { Value = "1", Text = "Active" });
            _items.Add(new SelectListItem { Value = "2", Text = "Inactive" });

            return _items;
        }
        public static List<SelectListItem> underplanList(DataTable dt, Int32 Type)
        {
            List<SelectListItem> _items = new List<SelectListItem>();
            try
            {
                _items.Add(new SelectListItem { Value = "0", Text = "-Select-" });
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        _items.Add(new SelectListItem { Value = Convert.ToString(row["ID"]), Text = Convert.ToString(row["PlanName"]) });
                    }
                }
                return _items;
            }
            catch (Exception ex)
            {
                ///ApplicationLogger.LogError(ex, "UtilityAccess", "RenderCountryList");
                return _items;
            }
        }
        public static List<SelectListItem> RespList(DataTable dt, Int32 Type)
        {
            List<SelectListItem> _items = new List<SelectListItem>();
            try
            {
                _items.Add(new SelectListItem { Value = "0", Text = "-Select-" });
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        _items.Add(new SelectListItem { Value = Convert.ToString(row["ID"]), Text = Convert.ToString(row["RespoName"]) });
                    }
                }
                return _items;
            }
            catch (Exception ex)
            {
                ///ApplicationLogger.LogError(ex, "UtilityAccess", "RenderCountryList");
                return _items;
            }
        }
        public static List<SelectListItem> TransactionStatusList(Int32 Type)
        {
            List<SelectListItem> _items = new List<SelectListItem>();
            DropdownType drpType = (DropdownType)Type;
            switch (drpType)
            {
                case DropdownType.All:
                    _items.Add(new SelectListItem { Value = "-1", Text = "All" });
                    break;
                //case DropdownType.Required:
                //    _items.Add(new SelectListItem { Value = "", Text = "--Select--" });
                //    break;
                case DropdownType.NoRequired:
                    _items.Add(new SelectListItem { Value = "0", Text = "--Select--" });
                    break;
            }

            _items.Add(new SelectListItem { Value = "1", Text = "Started" });
            _items.Add(new SelectListItem { Value = "2", Text = "Not Started" });
            return _items;
        }
        public static List<SelectListItem> TransactionStatusList_ddl(DataTable dt, Int32 Type)
        {
            List<SelectListItem> _items = new List<SelectListItem>();
            try
            {
                _items.Add(new SelectListItem { Value = "0", Text = "-Select-" });
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        _items.Add(new SelectListItem { Value = Convert.ToString(row["ID"]), Text = Convert.ToString(row["StatusName"]) });
                    }
                }
                return _items;
            }
            catch (Exception ex)
            {
                ///ApplicationLogger.LogError(ex, "UtilityAccess", "RenderCountryList");
                return _items;
            }
        }
        public static List<SelectListItem> CertificationStatusList_DDL(DataTable dt, Int32 Type)
        {
            List<SelectListItem> _items = new List<SelectListItem>();
            try
            {
                _items.Add(new SelectListItem { Value = "0", Text = "-Select-" });
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        _items.Add(new SelectListItem { Value = Convert.ToString(row["ID"]), Text = Convert.ToString(row["StatusName"]) });
                    }
                }
                return _items;
            }
            catch (Exception ex)
            {
                ///ApplicationLogger.LogError(ex, "UtilityAccess", "RenderCountryList");
                return _items;
            }
        }
        public static void GetFromToDate(string Format, out string DateFrom, out string DateTo)
        {
            DateTo = string.Empty;
            DateFrom = string.Empty;
            string FDate = string.Empty;
            DateTime? df = null;
            int hours = 0, minutes = 0;
            try
            {
                if (Format == "Yearly")
                {
                    FDate = DateTime.Now.AddYears(-1).ToString();
                    df = NullableTryParseDateTime(FDate) ?? null;
                    DateFrom = (df != null ? df.Value.AddYears(-1).AddHours(hours).AddMinutes(minutes).ToString("MM/dd/yyyy") + " 00:00" : DateTime.UtcNow.AddYears(-1).AddHours(hours).AddMinutes(minutes).ToString("MM/dd/yyyy") + " 00:00");
                }

                df = NullableTryParseDateTime(FDate) ?? null;
                DateFrom = (df != null ? df.Value.AddHours(hours).AddMinutes(minutes).ToString("MM/dd/yyyy") + " 00:00" : DateTime.UtcNow.AddHours(hours).AddMinutes(minutes).ToString("MM/dd/yyyy") + " 00:00");

                string TDate = DateTime.Now.ToString();
                DateTime? dt = NullableTryParseDateTime(TDate) ?? null;
                DateTo = (dt != null ? dt.Value.AddHours(hours).AddMinutes(minutes).ToString("MM/dd/yyyy") + " 23:59" : DateTime.UtcNow.AddHours(hours).AddMinutes(minutes).ToString("MM/dd/yyyy") + " 23:59");
            }
            catch
            {
                //return "";
            }
        }
        public static string OtpGenerator()
        {
            var chars = "0123456789";
            var stringChars = new char[6];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            return finalString;
        }
        public static int SendEmail(String senderName, String emailTo, String subject, String emailBody, bool blnIsHtml = true)
        {
            try
            {
                if (ConfigurationManager.AppSettings["Enable_Email"].ToString() == "0")
                {
                    return 0;
                }
                string smtpFromEmail = ConfigurationManager.AppSettings["smtpFromEmail"].ToString();
                string smtpMailPassword = ConfigurationManager.AppSettings["smtpMailPassword"].ToString();
                string smtpClient = ConfigurationManager.AppSettings["smtpClient"].ToString();
                string KeyPort = ConfigurationManager.AppSettings["KeyPort"].ToString();

                MailMessage msg = new MailMessage();
                msg.To.Add(emailTo);
                //msg.From = new MailAddress("sukhvirs63@gmail.com", strEmailSubject);
                msg.From = new MailAddress(smtpFromEmail, "PPR Team");
                msg.Subject = subject;
                msg.Body = emailBody;
                msg.IsBodyHtml = blnIsHtml;
                /******** Using Gmail Domain ********/
                SmtpClient client = new SmtpClient(smtpClient, Convert.ToInt32(KeyPort));
                client.Credentials = new System.Net.NetworkCredential(smtpFromEmail, smtpMailPassword);
                //client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                /************************************/

                /******** Using Yahoo Domain ********/
                //SmtpClient client = new SmtpClient("smtp.mail.yahoo.com", 25);
                /************************************/

                client.Send(msg);         // Send our email.
                msg = null;


                return 1;
            }
            catch (Exception exc)
            {
                return -1;
            }
        }
        public static string AutoGenerateProjectNumber(string MaxProjectNumber)
        {
            int Number = 0;
            string[] words = MaxProjectNumber.Split('/');
            //string Prefix = "PNI/R&D/2023-2024/";
            string Prefix = words[0] + '/' + words[1] + '/' + words[2] + '/';
            //string Prefix = words[0] + '/' + words[1] + '/';
            string ProjectNumber = "";
            if (!string.IsNullOrEmpty(MaxProjectNumber))
            {
                Number = Convert.ToInt32(words[3]);
                Number = Number + 1;
                ProjectNumber = Prefix + (Number);
                return ProjectNumber;
            }
            else
            {
                ProjectNumber = words[0]+'/'+ words[1]+ '/' + words[2] + '/' +  1;
                return ProjectNumber;
            }
        }
    }

    public class MsgResponse
    {
        public static String Message(Int32 responseType)
        {
            if (responseType == 0)
                return "We hit a snag, please try again after some time.";
            else if (responseType == 1)
                return "Success";
            else if (responseType == 2)
                return "Retrieved successfully";
            else if (responseType == -5)
                return "Authentication failed";
            else if (responseType == -3)
                return "Email already exists!";
            else if (responseType == -4)
                return "Cannot process!";
            else if (responseType == -1)
                return "Technical error";
            else if (responseType == -2)
                return "No record found";
            else if (responseType == -16)
                return "The old password you have entered is incorrect";
            else if (responseType == 11)
                return "Data saved successfully";
            else if (responseType == 12)
                return "Data updated successfully";
            else if (responseType == 13)
                return "Data deleted successfully";
            else if (responseType == 14)
                return "Payment card set as primary successfully";
            else if (responseType == 15)
                return "Payment processed successfully";
            else if (responseType == 16)
                return "Your password has been changed successfully";
            else if (responseType == 17)
                return "Successfully disabled!!";
            else if (responseType == 18)
                return "Your account has been re-activated.";
            else if (responseType == 19)
                return "We have recieved your account delete request. Your account will be deleted with in 7 days. If you want you can re-activate your account with in 7 days";
            else if (responseType == 20)
                return "Data archived successfully";
            else if (responseType == 21)
                return "We have received your message and would like to thank you for writing to us. we will reply by phone / email as soon as possible.";
            else if (responseType == 23)
                return "Record already exists!";
            else if (responseType == 24)
                return "Data not available, please change your search criteria !";
            else if (responseType == 25)
                return "Your transaction is under process!";
            else if (responseType == 26)
                return "Your refund is successfull!";
            else if (responseType == 27)
                return "The credit card has expired";
            else if (responseType == -28)
                return "SubActivity can not be same.";
            else if (responseType == 29)
                return "Forwarded Successfully.";
            else if (responseType == 30)
                return "Closed Successfully.";
            else if (responseType == 31)
                return "Approved Successfully.";
            else if (responseType == -8)
                return "Sequence no. can not be same.";
            else
                return "We hit a snag, please try again after some time.";
        }
    }
}
