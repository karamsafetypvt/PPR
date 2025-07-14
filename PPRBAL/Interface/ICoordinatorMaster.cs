using PPRModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPRBAL.Interface
{
    public interface ICoordinatorMaster
    {
        CoordinatorMasterModel GetCoordinatorMasterData(CoordinatorMasterModel model);
        CoordinatorMasterModel GetCoordinatorMasterDataById(CoordinatorMasterModel model);
        CoordinatorMasterModel AddOrEdit(CoordinatorMasterModel model);
    }
}
