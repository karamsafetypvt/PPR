using PPRModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPRBAL.Interface
{
    public interface IDevelopmentPlan
    {
        DevelopmentPlanModel GetAllActivity(string ProjectID);
        DevelopmentPlanModel AddOrEdit(DevelopmentPlanModel model);
        DevelopmentPlanModel GetAllDesignDevelopmentPlan(DevelopmentPlanModel model);
        DesignDataSheetModel AddOrEdit_DesignInputDataSheet(DesignDataSheetModel model);
        DesignReviewModel AddOrEdit_DesignReviewDataSheet(DesignReviewModel model);
        DesignDataSheetModel GetData(string ProjectID, string PlanID);
        DesignReviewModel GetDesignReviewData(string ProjectID, string PlanID);
        QualityPlanModel AddOrEdit_QualityPlanDataSheet(QualityPlanModel model);
        QualityPlanModel GetQualityPlanData(string ProjectID, string PlanID);
        DesignVerificationModel AddOrEdit_DesignVerification(DesignVerificationModel model);
        DesignVerificationModel GetDesignVerificationData(string ProjectID, string PlanID);
        DesignValidationModel GetDesignValidationData(string ProjectID, string PlanID);
        DesignValidationModel AddOrEdit_DesignValidationDataSheet(DesignValidationModel model);
        IndustrialisationModel AddOrEdit_InduatrilisationDataSheet(IndustrialisationModel model);
        IndustrialisationModel_New AddOrEdit_InduatrilisationDataSheet_New(IndustrialisationModel_New model);
        IndustrialisationModel GetIndustrialisationData(string ProjectID, string PlanID);
        IndustrialisationModel_New GetIndustrialisationData_New(string ProjectID, string PlanID);
    }
}
