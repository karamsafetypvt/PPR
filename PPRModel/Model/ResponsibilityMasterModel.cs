using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PPRModel.Model
{
    public class ResponsibilityMasterModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the Name")]
        [RegularExpression(@"^(?!\s*$).+", ErrorMessage = "Name cannot be empty or just spaces.")]
        [AllowHtml]
        public string Name { get;set; }
        [Required(ErrorMessage = "Please enter the Description")]
        [AllowHtml]
        public string Discription { get;set; }
        [Required(ErrorMessage = "Please Select the Status")]
        public string Status { get;set; } 
        public List<SelectListItem> _StatusList { get;set; } 
        public string CreatedBy {get;set; } 
        public string ReturnMessage {get;set; } 
        public int ReturnCode {get;set; } 
        public List<ResponsibilityMasterModel> _ResponsibilityMasterModelList { get; set; }
    }
}
