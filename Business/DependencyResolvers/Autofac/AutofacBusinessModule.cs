using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFramework;
using DataAccess.Concrete.EntitiyFramework.Contexs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
            protected override void Load(ContainerBuilder builder)
            {
            //Products
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            //Category
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

        }
    }

    
       
        //}
        //public class AutofacBusinessModule : Module
        //{
        //    protected override void Load(ContainerBuilder builder)
        //    {
        //        builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
        //        builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
        //    }
        //}


    }
