using PPRModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPRBAL.Interface
{
    public interface IUnitMaster
    {
        UnitMasterModel GetUnitMasterData(UnitMasterModel model);
        UnitMasterModel GetUnitMasterDataById(UnitMasterModel model);
        UnitMasterModel AddOrEdit(UnitMasterModel model);
    }
}
