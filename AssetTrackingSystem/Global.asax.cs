using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AssetTrackingSystem.ViewModels;
using ATS.DAL.Database;
using ATS.Models;
using AutoMapper;

namespace AssetTrackingSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Mapper.Initialize(conf =>
            {
                conf.CreateMap<PurchasedEntryCreateVM, PurchasedAsset>();
            });
        }
    }
}
