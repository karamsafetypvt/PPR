using PPRModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPRBAL.Interface
{
   public interface IActivityMaster
    {
        ActivityMasterModel GetActivityCommonData();
        ActivityMasterModel GetAllActivityData();
        ActivityMasterModel AddOrEdit(ActivityMasterModel model);
        ActivityMasterModel GetActivityMasterDatabyId(int ActivityID);
        ActivityMasterModel DeleteActivityMaster(int ActivityID);
    }
}
