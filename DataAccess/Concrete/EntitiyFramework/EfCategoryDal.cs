using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFramework.Contexs;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class EfCategoryDal : EfEntitiyRepositoryBase<Category, NorntwindContext>, ICategoryDal
    {
    }
}
