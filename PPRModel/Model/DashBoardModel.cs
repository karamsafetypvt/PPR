using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPRModel.Model
{
    public class DashBoardModel
    {
        public string UserName { get; set; }
        public string UserID { get; set; }
        public string Level { get; set; }
        public String LevelType { get; set; }
        public Int32 LevelOneCount { get; set; }
        public Int32 LevelTwoCount { get; set; }
        public Int32 LevelThreeCount { get; set; }
        public List<DashBoardModel> _DashBoardModelList { get; set; }
        public List<DevelopmentSheetLevelModel> _DevelopmentSheetLevelList { get; set; }
    }
    public class DevelopmentSheetLevelModel
    {
        public string UserName { get; set; }
        public string UserID { get; set; }
        public string Level { get; set; }
        public String LevelType { get; set; }
        public Int32 LevelOneCount { get; set; }
        public Int32 LevelTwoCount { get; set; }
        public Int32 LevelThreeCount { get; set; }

    }
}
