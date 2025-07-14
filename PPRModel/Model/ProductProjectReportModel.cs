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
    public class ProductProjectReportModel
    {
        public Int32 ProjectID { get; set; }
        [Required(ErrorMessage = "Please enter the Title")]
        public string ProjectTitle { get; set; }
        [Required(ErrorMessage = "Please enter the Project No.")]
        public string ProjectNO { get; set; }
        public string MaxProjectNO { get; set; }
        [Required(ErrorMessage = "Please enter the Coordinator")]
        [Range(1, int.MaxValue)]
        public string Coordinator { get; set; }
        [Required(ErrorMessage = "Please enter the Coordinator")]
        [Range(1, Int32.MaxValue, ErrorMessage = "*")]
        public int? Coordinatorid { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        public List<SelectListItem> _CoordinatorList { get; set; }
        [Required(ErrorMessage = "Please enter the Product Category")]
        public string ProductCategory { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        public List<SelectListItem> _ProductCategoryList { get; set; }
        [Required(ErrorMessage = "Please enter the Product Ref. No.")]
        public string ProductRefNo { get; set; }
        [Required(ErrorMessage = "Please enter the Product Description")]
        public string ProductDescription { get; set; }
        [Required(ErrorMessage = "Please enter the Company Name")]
        public Int32 CompanyName { get; set; }
        [Required(ErrorMessage = "Please enter Opening Date")]
        [DataType(DataType.Date)]
        public string OpeningDate { get; set; }
        public HttpPostedFileBase RefrenceImage
        {
            get; set;
        }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        //[Required(ErrorMessage = "Please Enter Closing Date")]
        [DataType(DataType.Date)]
        public string ClosingDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public string Status { get; set; }
        public int ApprovalStatus { get; set; }
        public List<SelectListItem> _StatusList { get; set; }
        public List<ProductProjectReportModel> _ProductProjectReportList { get; set; }
        public Int32 ReturnCode { get; set; } //-1:Error/0:missing or validation /1:success
        public String ReturnMessage { get; set; }
        public string Remark { get; set; }
        public string SearchbyProjectNo { get; set; }
        public string SearchbyStatus { get; set; }
        public List<SelectListItem> _SearchbyStatusList { get; set; }
        public string SearchbyDate { get; set; }
        public bool WithPPR { get; set; }
        public bool WithDevelopmentSheet { get; set; }
        [Required(ErrorMessage = "Please enter the PPR For ?")]
        public string PPR_For { get; set; }

    }
    public class DevelopmentSheetModel
    {
        public Int32 ProjectID { get; set; }
        public Int32 PlanID { get; set; }
        public Int32 ActivityID { get; set; }
        public Int32 SerialNo { get; set; }
        public Int32 Progress { get; set; }
        public String RefNo { get; set; }
        public String NewProductDescription { get; set; }
        public String PPRNo { get; set; }
        public string Status { get; set; }
        public int ReturnCode { get; set; }
        public string ReturnMessage { get; set; }
        public string CreatedBy { get; set; }
        public List<SelectListItem> _underplanList { get; set; }

        public List<SelectListItem> _CertificationStatusList { get; set; }
        public List<SelectListItem> _SampletobesentfortrialList { get; set; }
        public List<SelectListItem> _ItemcreationBOMRoutingList { get; set; }
        public List<SelectListItem> _TranslationStatusList { get; set; }
        public List<DevelopmentSheetComponent> _developmentSheetComponent { get; set; }
        public List<SelectListItem> _CustomerList { get; set; }
        public List<SelectListItem> _RespList { get; set; }

    }
    public class DevelopmentSheetComponent
    {
        [Required(ErrorMessage = "Required")]
        public string Statusofcurrentactionsunderplan { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Customer { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Resp { get; set; }
        public string TargetDate { get; set; }
        public string RevisedDate { get; set; }
        public string CompletionDate { get; set; }
        [Required(ErrorMessage = "Required")]
        public string CertificationStatus { get; set; }
        public List<SelectListItem> _CertificationStatusList { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Sampletobesentfortrial { get; set; }
        public List<SelectListItem> _SampletobesentfortrialList { get; set; }
        [Required(ErrorMessage = "Required")]
        public string ItemcreationBOMRouting { get; set; }
        public List<SelectListItem> _ItemcreationBOMRoutingList { get; set; }
        [Required(ErrorMessage = "Required")]
        public string TranslationStatus { get; set; }
        public List<SelectListItem> _TranslationStatusList { get; set; }
        [Required(ErrorMessage = "Please enter the Remarks")]
        public string Remarks { get; set; }
        public bool MarkAsComplete { get; set; }
    }
}
