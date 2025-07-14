using PPRModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPRBAL.Interface
{
    public interface IApprovingAuthorityMaster
    {
        ApprovingAuthorityMasterModel GetAuthorityMasterData(ApprovingAuthorityMasterModel model);
        ApprovingAuthorityMasterModel GetAuthorityMasterDataById(ApprovingAuthorityMasterModel model);
        ApprovingAuthorityMasterModel AddOrEdit(ApprovingAuthorityMasterModel model);
    }
}
