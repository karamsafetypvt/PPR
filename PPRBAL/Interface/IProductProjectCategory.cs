using PPRModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPRBAL.Interface
{
    public interface IProductProjectCategory
    {
        ProductProjectCategoryModel GetProductProjectCategoryData(ProductProjectCategoryModel model);
        ProductProjectCategoryModel GetProductProjectCategoryDataById(ProductProjectCategoryModel model);
        ProductProjectCategoryModel AddOrEdit(ProductProjectCategoryModel model);
    }
}
