using PPRModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPRBAL.Interface
{
    public interface ILevelMaster
    {
        LevelMasteranDesignMasterModel GetAllUsers(string PPR_For);
        LevelMasteranDesignMasterModel GetAllSelectedUsers();
        LevelMasteranDesignMasterModel GetAllSelectedDevelopmentsheetLeveUsers();
        LevelMasteranDesignMasterModel AddEditLevels(LevelMasteranDesignMasterModel models);
        LevelMasteranDesignMasterModel AddEditDevelopmentsheetLevels(LevelMasteranDesignMasterModel models);
    }
}
