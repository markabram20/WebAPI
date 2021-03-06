﻿//using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApi.DAL;

namespace WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<WebApiDbContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<WebApiDbContext>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<WebApiDbContext>());
            ValueProviderFactories.Factories.Add(new JsonValueProviderFactory());
        }
    }
}
