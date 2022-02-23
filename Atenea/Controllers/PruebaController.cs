using Atenea.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Http.Cors;
using System.Data.SqlClient;
using System.Data;
using Atenea.Data;

namespace Atenea.Controllers
{
    public class PruebaController : Controller
    {
        PruebaData _PruebaData = new PruebaData();
        // GET: Prueba
        [HttpGet]
        public JsonResult GetAssignments()
        {
            return Json(_PruebaData.GetListDescriptores(), JsonRequestBehavior.AllowGet);
        }
    }
}