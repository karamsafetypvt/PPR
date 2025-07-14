using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PPRModel.Model
{
   public class ActivityMasterModel
    {
        public int ActivityID { get; set; }
        [Required(ErrorMessage = "Please enter the Activity Name")]
        public string ActivityName { get; set; }
        [Required(ErrorMessage = "Please Select Nature")]
        public string Nature { get; set; }
        public List<SelectListItem> _NatureList { get; set; }
        [Required(ErrorMessage = "Please enter the ResourceReq")]
        public string ResourceReq { get; set; }
        [Required(ErrorMessage = "Please enter the Responsibility")]
        public string Responsibility { get; set; }
        [Required(ErrorMessage = "Please enter the Approving Authority")]
        public string ApprovingAuthority { get; set; }
        [Required(ErrorMessage = "Please Select Status")]
        public string Status { get; set; }
        public Int32 SequenceNo { get; set; }
        public List<SelectListItem> _StatusList { get; set; }
        public string SubActivity { get; set; }
        public List<SelectListItem> _SubActivityList { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string ReturnMessage { get; set; }
        public Int32 ReturnCode { get; set; }
        public List<ActivityMasterModel> _ActivityMasterModelList { get; set; }
    }
}
