using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPRModel.Model
{
   public abstract class ConnectionObjects
    {
        public static string ConnectionString 
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["DBPPR"].ConnectionString;
            }
        } 
        public static string masterConnectionString 
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["masterdb"].ConnectionString;
            }
        }
    }
}
