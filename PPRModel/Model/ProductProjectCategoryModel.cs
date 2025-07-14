using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PPRModel.Model
{
    public class ProductProjectCategoryModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the Name")]
        [AllowHtml]
        public string Name { get;set; }
        [Required(ErrorMessage = "Please enter the Description")]
        [AllowHtml]
        public string Discription { get;set; }
        [Required(ErrorMessage = "Please select status")]
        public string Status { get;set; } 
        public List<SelectListItem> _StatusList { get;set; } 
        public string CreatedBy {get;set; } 
        public string ReturnMessage {get;set; } 
        public int ReturnCode {get;set; } 
        public List<ProductProjectCategoryModel> _ProductProjectCategoryList { get; set; }
    }
}
