using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PPRModel.Model
{
    public class DevelopmentPlanModel
    {
        public Int32 ProjectID { get; set; }
        public Decimal AllProgress { get; set; }
        public Decimal AllSelectedProgress { get; set; }
        public Decimal AllSelectedActivityProgress { get; set; }
        public Decimal AllActitvity { get; set; }
        public int ActivityCount { get; set; }
        public Int32 AllProgressPercentage { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectNO { get; set; }
        public string Coordinator { get; set; }
        public string OpeningDate { get; set; }
        public string ProductRefNo { get; set; }
        public string Status { get; set; }
        public List<DevelopmentPlanModelList> _ActivityList { get; set; }
        public int ReturnCode { get; set; }
        public string ReturnMessage { get; set; }
        public string CreatedBy { get; set; }
        public string FurtherModification4 { get; set; }
        public string FurtherModification10 { get; set; }
        public string ApplicationforPatent { get; set; }
        public string NeedOfDevelopment { get; set; }
        public HttpPostedFileBase DesignValidation_DOCUMENTS { get; set; }
        public string DesignValidation_DOCUMENTSPATH { get; set; }
        public string DesignValidation_DocumentName { get; set; }
        public DesignDataSheetModel DesignSheet { get; set; }
        public List<SelectListItem> _ResponsibilityList { get; set; }
        public List<SelectListItem> _AuthorityList { get; set; }
    }

    public class DevelopmentPlanModelList
    {
        public int PlanID { get; set; }
        public Decimal Progress { get; set; }
        public Decimal SelectedProgress { get; set; }
        public Int32 ProgressPercentage { get; set; }
        public int ActivityId { get; set; }
        public string Activity { get; set; }
        public HttpPostedFileBase DesignValidation_DOCUMENTS { get; set; }
        public string DesignValidation_DOCUMENTSPATH { get; set; }
        public string DesignValidation_DocumentName { get; set; }
        public string Nature { get; set; }
        public string FurtherModification4 { get; set; }
        public string FurtherModification10 { get; set; }
        public string ApplicationforPatent { get; set; }
        public string NeedOfDevelopment { get; set; }
        public string ResourcesReq { get; set; }
        public string Responsibility { get; set; }
        public string AssignedDate { get; set; }
        public string TargetDate { get; set; }
        public string ApprovingAuthority { get; set; }
        public string CompletionDate { get; set; }
        public string Remarks { get; set; }
        public int? Aging { get; set; }
        public bool  ActivityMarkAsComplete { get; set; }
        public string CreatedBy { get; set; }
        public Int32 ProjectID { get; set; }
        public string SubActivity { get; set; }
        public string SubActivityPageName { get; set; }
        public int ReturnCode { get; set; }
        public string ReturnMessage { get; set; }
        public DesignDataSheetModel DesignSheet { get; set; }
        public DesignReviewModel DesignReview { get; set; }

    }

    public class DesignDataSheetModel
    {
        public string PPR_Status { get; set; }
        public Int32 PlanID { get; set; }
        public Int32 ProjectID { get; set; }
        public string ProjectNO { get; set; }
        [Required(ErrorMessage = "Please enter the PROJECT NO")]

        public string ProjectTitle { get; set; }
        [Required(ErrorMessage = "Please enter the PROJECT TITLE")]

        public string Coordinator { get; set; }
        //[Required(ErrorMessage = "Please enter the NAME OF THE CO – ORDINATOR")]

        public string ProductRefNo { get; set; }
        //[Required(ErrorMessage = "Please enter the REFERENCE STANDARDS")]
        public string Functional_Performar_Requirement { get; set; }
        //[Required(ErrorMessage = "Please enter Static Strength")]
        public string StaticStrength { get; set; }
        //[Required(ErrorMessage = "Please enter Dynamic Strength")]
        public string DynamicStrength { get; set; }
        //[Required(ErrorMessage = "Please enter Corrosion Resistance")]
        public string corrosionResistance { get; set; }
        //[Required(ErrorMessage = "Please enter Other")]
        public string Other { get; set; }
        [Required(ErrorMessage = "Please enter Material Specific")]
        public string MaterialSpecific { get; set; }
        [Required(ErrorMessage = "Please enter Process Specific")]
        public string ProcessSpecific { get; set; }
        public string Statutory_Regulatory_Requirement { get; set; }
        public string SPECIAL_ENVIRONMENT_CONDITIONS { get; set; }
        [Required(ErrorMessage = "Please enter Packaging")]
        public string Packaging { get; set; }
        [Required(ErrorMessage = "Please enter Sticker Labels")]
        public string StickerLabels { get; set; }
        [Required(ErrorMessage = "Please enter User Instruction")]
        public string UserInstruction { get; set; }
        [Required(ErrorMessage = "Please enter Benchmarking Criteria")]
        public string Benchmarking_Criteria { get; set; }
        public string INFORMATION_EARLIER_PROJECTS { get; set; }
        public string CUSTOMER_IN_DEVELOPMENT { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CompletionDate { get; set; }
        public string REF_Date { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public string Status { get; set; }
        public Int32 ReturnCode { get; set; } //-1:Error/0:missing or validation /1:success
        public String ReturnMessage { get; set; }
        public List<SelectListItem> _UnitList { get; set; }

        public int Static_Unit { get; set; }
        public int Dyanmic_Unit { get; set; }
        public int Corrosion_Unit { get; set; }
        public int Other_Unit { get; set; }

        public int Packaging_Unit { get; set; }
        public int StickerLabels_Unit { get; set; }
        public int UserInstruction_Unit { get; set; }

        public int MaterialSpecific_Unit { get; set; }
        public int ProcessSpecific_Unit { get; set; }
    }

    public class DesignReviewModel
    {
        public string PPR_Status { get; set; }
        public string ProjectDate { get; set; }
        public string ProjectNO { get; set; }
        public Int32 ProjectID { get; set; }
        public Int32 PlanID { get; set; }
        public int ReviewID { get; set; }
        public int ActivityId { get; set; }
        public bool AVAILABILITYOFMATERIALSPROPOSED_STATUS { get; set; }
        public string AVAILABILITYOFMATERIALSPROPOSED_REMARKS { get; set; }
        public bool WORKABILITYOFDESIGNASPERFUNCTIONALPERFORMANCEREQUIREMENTS_STATUS { get; set; }
        public string WORKABILITYOFDESIGNASPERFUNCTIONALPERFORMANCEREQUIREMENTS_REMARKS { get; set; }
        public bool FEASIBILITYOFMANUFACTURINGINCLUDINGTOOLMAKING_STATUS { get; set; }
        public string FEASIBILITYOFMANUFACTURINGINCLUDINGTOOLMAKING_REMARKS { get; set; }
        public bool PROBABILITYOFMEETINGTHETESTRESULTS_STATUS { get; set; }
        public string PROBABILITYOFMEETINGTHETESTRESULTS_REMARKS { get; set; }
        public bool PROBABILITYOFMEETINGCONSTRUCTIONAL_STATUS { get; set; }
        public string PROBABILITYOFMEETINGCONSTRUCTIONAL_REMARKS { get; set; }
        public bool PROBABILITYOFMEETINGSTATUTORYREGULATORYREQUIREMENTS_STATUS { get; set; }
        public string PROBABILITYOFMEETINGSTATUTORYREGULATORYREQUIREMENTS_REMARKS { get; set; }
        public bool EASEOFPACKAGINGAVAILABILITY_STATUS { get; set; }
        public string EASEOFPACKAGINGAVAILABILITY_REMARKS { get; set; }
        public bool EASEOFINSTALLATIONBYUSER_STATUS { get; set; }
        public string EASEOFINSTALLATIONBYUSER_REMARKS { get; set; }
        public bool FTOSEARCHINCOORDINATIONWITHKARAMIPRTEAM_STATUS { get; set; }
        public string FTOSEARCHINCOORDINATIONWITHKARAMIPRTEAM_REMARKS { get; set; }
        public bool AVAILABILITYOFMANPOWER_STATUS { get; set; }
        public string AVAILABILITYOFMANPOWER_REMARKS { get; set; }
        public bool AVAILABILITYOFMACHINERY_STATUS { get; set; }
        public string AVAILABILITYOFMACHINERY_REMARKS { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public int Status { get; set; }
        public Int32 ReturnCode { get; set; } //-1:Error/0:missing or validation /1:success
        public String ReturnMessage { get; set; }
        public HttpPostedFileBase DesignReview_DOCUMENTS { get; set; }
        public string DesignReview_DOCUMENTSPATH { get; set; }
        public string DesignReview_DocumentName { get; set; }
        public string REF_Date { get; set; }
    }

    public class QualityPlanModel
    {
        public string PPR_Status { get; set; }
        public Int32 PlanID { get; set; }
        public Int32 ProjectID { get; set; }
        public string ProjectNO { get; set; }
        public DateTime ProjectDate { get; set; }
        public string ProjectTitle { get; set; }
        public string Coordinator { get; set; }
        public bool WORKINSTRUCTIONS_STATUS { get; set; }
        public HttpPostedFileBase WORKINSTRUCTIONS_DOCUMENTS { get; set; }
        public string WORKINSTRUCTIONS_DOCUMENTSPATH { get; set; }
        public string WORKINSTRUCTIONS_REMARKS { get; set; }
        public string WORKINSTRUCTIONS_DocumentName { get; set; }

        public bool INSPECTIONCRITERION_STATUS { get; set; }
        public HttpPostedFileBase INSPECTIONCRITERION_DOCUMENTS { get; set; }
        public string INSPECTIONCRITERION_DOCUMENTSPATH { get; set; }
        public string INSPECTIONCRITERION_REMARKS { get; set; }
        public string INSPECTIONCRITERION_DocumentName { get; set; }

        public bool TESTINGPLAN_STATUS { get; set; }
        public HttpPostedFileBase TESTINGPLAN_DOCUMENTS { get; set; }
        public string TESTINGPLAN_DOCUMENTSPATH { get; set; }
        public string TESTINGPLAN_REMARKS { get; set; }
        public string TESTINGPLAN_DocumentName { get; set; }

        public bool TechnicalDataSheet_STATUS { get; set; }
        public HttpPostedFileBase TechnicalDataSheet_DOCUMENTS { get; set; }
        public string TechnicalDataSheet_DOCUMENTSPATH { get; set; }
        public string TechnicalDataSheet_REMARKS { get; set; }
        public string TechnicalDataSheet_DocumentName { get; set; }

        public bool TechnicalDrawings_STATUS { get; set; }
        public HttpPostedFileBase[] TechnicalDrawings_DOCUMENTS { get; set; }
        public string TechnicalDrawings_DOCUMENTSPATH { get; set; }
        public string TechnicalDrawings_REMARKS { get; set; }
        public string TechnicalDrawings_DocumentName { get; set; }

        public bool TechnicalFile_STATUS { get; set; }
        public HttpPostedFileBase TechnicalFile_DOCUMENTS { get; set; }
        public string TechnicalFile_DOCUMENTSPATH { get; set; }
        public string TechnicalFile_REMARKS { get; set; }
        public string TechnicalFile_DocumentName { get; set; }

        public bool UserInstruction_STATUS { get; set; }
        public HttpPostedFileBase UserInstruction_DOCUMENTS { get; set; }
        public string UserInstruction_DOCUMENTSPATH { get; set; }
        public string UserInstruction_REMARKS { get; set; }
        public string UserInstruction_DocumentName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public int Status { get; set; }
        public Int32 ReturnCode { get; set; } //-1:Error/0:missing or validation /1:success
        public String ReturnMessage { get; set; }
        //public HttpPostedFileBase HttpPostedFileBase { get; set; }
        public List<QualityPlanModel> _QualityPlanList { get; set; }
        public List<DocDetails> _DocDetailsList { get; set; }
        public string REF_Date { get; set; }
    }
    public class DocDetails
    {
        public string DocPath { get; set; }
        public string DocTitle { get; set; }
    }

    public class DesignVerificationModel
    {
        public string PPR_Status { get; set; }
        public List<SelectListItem> _UnitList { get; set; }
        public Int32 ProjectID { get; set; }
        public Int32 PlanID { get; set; }
        public int VerficationID { get; set; }
        public string ProjectNO { get; set; }
        public string ProjectTitle { get; set; }
        public string Coordinator { get; set; }
        public string ProductRefNo { get; set; }
        public string ProjectDate { get; set; }
        [Required(ErrorMessage = "Please enter the Requirements")]
        public string Functional_Performar_Requirement { get; set; }
        [Required(ErrorMessage = "Please enter the Observation")]
        public string Functional_Performar_Observation { get; set; }
        [Required(ErrorMessage = "Please enter the Remarks")]
        public string Functional_Performar_Remarks { get; set; }
        //[Required(ErrorMessage = "Please enter the Requirements")]
        public string Static_Strengh_Req { get; set; }
        //[Required(ErrorMessage = "Please enter the Observation")]
        public string Static_Strengh_Observation { get; set; }
        //[Required(ErrorMessage = "Please enter the Remarks")]
        public string Static_Strengh_Remarks { get; set; }
        //[Required(ErrorMessage = "Please enter the Requirements")]
        public string Dynamic_Strengh_Requirement { get; set; }
        //[Required(ErrorMessage = "Please enter the Observation")]
        public string Dynamic_Strengh_Observation { get; set; }
        //[Required(ErrorMessage = "Please enter the Remarks")]
        public string Dynamic_Strengh_Remarks { get; set; }
        //[Required(ErrorMessage = "Please enter the Requirements")]
        public string corrosion_Resistance_Requirement { get; set; }
        //[Required(ErrorMessage = "Please enter the Observation")]
        public string corrosion_Resistance_Observation { get; set; }
        //[Required(ErrorMessage = "Please enter the Remarks")]
        public string corrosion_Resistance_Remarks { get; set; }
        //[Required(ErrorMessage = "Please enter the Requirements")]
        public string Other_Requirement { get; set; }
        //[Required(ErrorMessage = "Please enter the Observation")]
        public string Other_Observation { get; set; }
        //[Required(ErrorMessage = "Please enter the Remarks")]
        public string Other_Remarks { get; set; }
        [Required(ErrorMessage = "Please enter the Requirements")]
        public string MaterialSpecific_Requirement { get; set; }
        [Required(ErrorMessage = "Please enter the Observation")]
        public string MaterialSpecific_Observation { get; set; }
        [Required(ErrorMessage = "Please enter the Remarks")]
        public string MaterialSpecific_Remarks { get; set; }
        [Required(ErrorMessage = "Please enter the Requirements")]
        public string ProcessSpecific_Requirement { get; set; }
        [Required(ErrorMessage = "Please enter the Observation")]
        public string ProcessSpecific_Observation { get; set; }
        [Required(ErrorMessage = "Please enter the Remarks")]
        public string ProcessSpecific_Remarks { get; set; }
        public string Statutory_Regulatory_Requirement { get; set; }
        public string Statutory_Regulatory_Observation { get; set; }
        public string Statutory_Regulatory_Remark { get; set; }
        public string SPECIAL_ENVIRONMENT_CONDITIONS_Req { get; set; }
        public string SPECIAL_ENVIRONMENT_CONDITIONS_Observation { get; set; }
        public string SPECIAL_ENVIRONMENT_CONDITIONS_Remarks { get; set; }
        [Required(ErrorMessage = "Please enter the Requirements")]
        public string Packaging_Requirement { get; set; }
        [Required(ErrorMessage = "Please enter the Observation")]
        public string Packaging_Observation { get; set; }
        [Required(ErrorMessage = "Please enter the Remarks")]
        public string Packaging_Remarks { get; set; }
        [Required(ErrorMessage = "Please enter the Requirements")]
        public string StickerLabel_Requirement { get; set; }
        [Required(ErrorMessage = "Please enter the Observation")]
        public string StickerLabel_Observation { get; set; }
        [Required(ErrorMessage = "Please enter the Remarks")]
        public string StickerLabel_Remarks { get; set; }
        [Required(ErrorMessage = "Please enter the Requirements")]
        public string UserInstruction_Requirement { get; set; }
        [Required(ErrorMessage = "Please enter the Observation")]
        public string UserInstruction_Observation { get; set; }
        [Required(ErrorMessage = "Please enter the Remarks")]
        public string UserInstruction_Remarks { get; set; }

        public string INFORMATION_EARLIER_PROJECTS_REQ { get; set; }

        public string INFORMATION_EARLIER_PROJECTS_Observation { get; set; }

        public string INFORMATION_EARLIER_PROJECTS_Remarks { get; set; }

        public string CUSTOMER_IN_DEVELOPMENT_REQ { get; set; }

        public string CUSTOMER_IN_DEVELOPMENT_Observation { get; set; }

        public string CUSTOMER_IN_DEVELOPMENT_Remarks { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public int Status { get; set; }
        public Int32 ReturnCode { get; set; } //-1:Error/0:missing or validation /1:success
        public String ReturnMessage { get; set; }
        [Required(ErrorMessage = "Please enter the Static Unit")]
        public int Static_Unit { get; set; }
        [Required(ErrorMessage = "Please enter the Dyanmic Unit")]
        public int Dyanmic_Unit { get; set; }
        [Required(ErrorMessage = "Please enter the Corrosion Unit")]
        public int Corrosion_Unit { get; set; }
        [Required(ErrorMessage = "Please enter the Other Unit")]
        public int Other_Unit { get; set; }
        public HttpPostedFileBase DesignVerification_DOCUMENTS { get; set; }
        public string DesignVerification_DOCUMENTSPATH { get; set; }
        public string DesignVerification_DocumentName { get; set; }
        public string REF_Date { get; set; }
    }

    public class DesignValidationModel
    {
        public string PPR_Status { get; set; }
        public Int32 ProjectID { get; set; }
        public Int32 PlanID { get; set; }
        public string ProjectNO { get; set; }
        public string ProjectDate { get; set; }
        //[Required(ErrorMessage = "Please Enter Date Of Sample Sent.")]
        //[DataType(DataType.Date)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string DateOfSampleSent { get; set; }
        public bool SampleSentToKTC { get; set; }
        public string FEEDBACKRECEIVED { get; set; }
        public string IMPROVEMENTSREQUIRED { get; set; }
        public string ACTIONPLAN { get; set; }
        public string TARGETDATE { get; set; }
        public string RESPONSIBILITY { get; set; }
        public string SAMPLESRESUBMITTEDON { get; set; }
        public string FINALFEEDBACK { get; set; }
        public string REMARKS { get; set; }
        public string REF_Date { get; set; }
        public int Status { get; set; }
        public string CreatedBy { get; set; }
        public string Reason { get; set; }
        public HttpPostedFileBase DesignValidation_DOCUMENTS { get; set; }
        public string DesignValidation_DOCUMENTSPATH { get; set; }
        public string DesignValidation_DocumentName { get; set; }
        public Int32 ReturnCode { get; set; } //-1:Error/0:missing or validation /1:success
        public String ReturnMessage { get; set; }
    }

    public class IndustrialisationModel
    {
        public string PPR_Status { get; set; }
        public Int32 ProjectID { get; set; }
        public Int32 PlanID { get; set; }
        public string ProjectNO { get; set; }
        [Required(ErrorMessage = "Please Enter Date Of Sample Sent.")]
        //[DataType(DataType.Date)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string INDUSTRIALISATIONDate { get; set; }
        [Required(ErrorMessage = "Please enter the JIG FIXTURES Tools New")]
        public string JIGFIXTURESTOOLSNew { get; set; }
        [Required(ErrorMessage = "Please enter the Modification In Old")]
        public string MODIFICATIONINOLD { get; set; }
        [Required(ErrorMessage = "Please enter the Additional Machine Required")]
        public string ADDITIONALMACHINESREQUIRED { get; set; }
        [Required(ErrorMessage = "Please enter the Additional Test Equipment Required")]
        public string ADDITIONALTESTEQUIPMENTREQUIRED { get; set; }
        public string CHANGEINISODOCUMENT { get; set; }
        public string UPDATIONINERPSYSTEMS { get; set; }
        [Required(ErrorMessage = "Please enter the Planning Of Component Development")]
        public string PLANNINGOFCOMPONENTDEVELOPMENT { get; set; }
        [Required(ErrorMessage = "Please enter the Quality Plan")]
        public string QUALITYPLAN { get; set; }
        public string REF_Date { get; set; }
        public int Status { get; set; }
        public string CreatedBy { get; set; }
        public string Reason { get; set; }
        public Int32 ReturnCode { get; set; } //-1:Error/0:missing or validation /1:success
        public String ReturnMessage { get; set; }
        public HttpPostedFileBase QUALITYPLAN_DOCUMENTS { get; set; }
        public string QUALITYPLAN_DOCUMENTSPATH { get; set; }
        public string QUALITYPLAN_DocumentName { get; set; }
        public List<DETAILOfCOMPONENTSModel> _detailofcomponent { get; set; }
    }
    public class DETAILOfCOMPONENTSModel
    {
        public string Status { get; set; }
        public int DetailsID { get; set; }
        public int IndustrilisationID { get; set; }
        public string DRGNO { get; set; }
        public string Title { get; set; }
        public string Quantity { get; set; }
        public string Inhouse { get; set; }
        public string Outside { get; set; }
        public string ToolingStatus { get; set; }
        public string ComponentStatus { get; set; }
        public string REF_Date { get; set; }
    }

    public class IndustrialisationModel_New
    {
        public string PPR_Status { get; set; }
        public Int32 ProjectID { get; set; }
        public Int32 PlanID { get; set; }
        public string ProjectNO { get; set; }
        [Required(ErrorMessage = "Please Enter Date Of Sample Sent.")]
        //[DataType(DataType.Date)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string INDUSTRIALISATIONDate { get; set; }

        [Required(ErrorMessage = "Please enter the Product Category")]
        public string ProductCategory { get; set; }
        [Required(ErrorMessage = "Please enter the Item Picture")]
        public string ItemPicture { get; set; }
        [Required(ErrorMessage = "Please enter the TDS")]
        public string TDS { get; set; }
        [Required(ErrorMessage = "Please enter the Manual Instruction")]
        public string ManualInstruction { get; set; }
        [Required(ErrorMessage = "Please enter the Certification")]
        public string Certification { get; set; }
        [Required(ErrorMessage = "Please enter the Item Code")]
        public string ItemCode { get; set; }
        [Required(ErrorMessage = "Please enter the Applicable Standard")]
        public string ApplicableStandard { get; set; }
        [Required(ErrorMessage = "Please enter Customer Name")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Please enter BOM Creation Status in ERP")]
        public string BOMCreationStatus { get; set; }
        [Required(ErrorMessage = "Please enter Safety Stock Creation Status")]
        public string SafetyStockCreationStatus { get; set; }
        [Required(ErrorMessage = "Please enter Sample")]
        public string Sample { get; set; }
        [Required(ErrorMessage = "Please enter Packaging")]
        public string Packaging { get; set; }
        [Required(ErrorMessage = "Please enter Work Instructions")]
        public string WorkInstructions { get; set; }
        [Required(ErrorMessage = "Please enter Inspection Criterion")]
        public string InspectionCriterion { get; set; }
        public string Remark { get; set; }
        public int Status { get; set; }
        public string CreatedBy { get; set; }
        public string Reason { get; set; }
        public Int32 ReturnCode { get; set; } //-1:Error/0:missing or validation /1:success
        public String ReturnMessage { get; set; }
        public HttpPostedFileBase QUALITYPLAN_DOCUMENTS { get; set; }
        public string QUALITYPLAN_DOCUMENTSPATH { get; set; }
        public string QUALITYPLAN_DocumentName { get; set; }
        
    }
}
