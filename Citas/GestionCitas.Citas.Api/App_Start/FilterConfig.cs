﻿using System.Web;
using System.Web.Mvc;

namespace GestionCitas.Citas.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
