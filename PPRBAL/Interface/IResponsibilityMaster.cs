using PPRModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPRBAL.Interface
{
    public interface IResponsibilityMaster
    {
        ResponsibilityMasterModel GetResponsibilityMasterData(ResponsibilityMasterModel model);
        ResponsibilityMasterModel GetResponsibilityMasterDataById(ResponsibilityMasterModel model);
        ResponsibilityMasterModel AddOrEdit(ResponsibilityMasterModel model);
    }
}
