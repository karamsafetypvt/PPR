using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PPRModel.Model
{
    public class LevelMasteranDesignMasterModel
    {
        public Int32 PPRUserLevel1 { get; set; }
        public Int32 UserId { get; set; }
        public int PPRUserLevel2 { get; set; }
        public int PPRUserLevel3 { get; set; }
        public int DevelopmentsheetUserLevel1 { get; set; }
        public int DevelopmentsheetUserLevel2 { get; set; }
        public int DevelopmentsheetUserLevel3 { get; set; }
        public List<SelectListItem> _PPRUserLevel1List { get; set; }
        public List<SelectListItem> _PPRUserLevel2List { get; set; }
        public List<SelectListItem> _PPRUserLevel3List { get; set; }
        public List<SelectListItem> _DevelopmentsheetUserLevel1List { get; set; }
        public List<SelectListItem> _DevelopmentsheetUserLevel2List { get; set; }
        public List<SelectListItem> _DevelopmentsheetUserLevel3List { get; set; }
        public string PPRLevel1Ids { get; set; }
        public string PPRLevel2Ids { get; set; }
        public string PPRLevel3Ids { get; set; }
        public string Developmentsheet1Ids { get; set; }
        public string Developmentsheet2Ids { get; set; }
        public string Developmentsheet3Ids { get; set; }
        public Int32 ReturnCode { get; set; } //-1:Error/0:missing or validation /1:success
        public String ReturnMessage { get; set; }
        public List<LevelMasteranDesignMasterModel> _Levellist { get; set; }
    }
}
