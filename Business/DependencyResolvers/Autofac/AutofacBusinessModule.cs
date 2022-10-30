using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFramework;
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

            //Users

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthSerivice>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
           
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
