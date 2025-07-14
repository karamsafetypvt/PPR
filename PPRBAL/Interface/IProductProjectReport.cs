using PPRModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPRBAL.Interface
{
    public interface IProductProjectReport
    {
        ProductProjectReportModel AddOrEdit(ProductProjectReportModel model);
        ProductProjectReportModel GetProductProjectReportData(ProductProjectReportModel model, string UserType);
        ProductProjectReportModel GetProductProjectReportDataById(Int32 ProjectID);
        ProductProjectReportModel GetProjectNumber();
        ProductProjectReportModel GetProjectCommondata();
        ProductProjectReportModel DeleteProductProjectReport(Int32 ProjectID);
        ProductProjectReportModel ChangeProductStatus(Int32 ProjectID, ProductProjectReportModel model);
        DevelopmentSheetModel GetDevelopmentSheetImprovisation(Int32 ProjectId, Int32 ActivityID);
        DevelopmentSheetModel AddADevelopmentSheetImprovisation(DevelopmentSheetModel model);
    }
}
