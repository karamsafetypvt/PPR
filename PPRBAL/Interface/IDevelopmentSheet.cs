using PPRModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPRBAL.Interface
{
   public interface IDevelopmentSheet
    {
      
        ProductProjectReportModel GetDevelopmentSheetReportData(ProductProjectReportModel model, string UserType);
        ProductProjectReportModel ChangeDevelopmentSheetStatus(Int32 ProjectID, ProductProjectReportModel model);
        
    }
}
