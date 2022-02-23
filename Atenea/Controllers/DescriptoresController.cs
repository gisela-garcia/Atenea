using Atenea.Data;
using Atenea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace Atenea.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class DescriptoresController : Controller
    {
        DescriptoresData _DescriptoresData = new DescriptoresData();
        // GET: Prueba
        [HttpGet]
        public JsonResult GetListDescriptores()
        {
            return Json(_DescriptoresData.GetListDescriptores(), JsonRequestBehavior.AllowGet);
        }
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpGet]
        public JsonResult AgregaDescriptor(Descriptor Data)
        {
            return Json(_DescriptoresData.AgregaDescriptor(Data), JsonRequestBehavior.AllowGet);
        }
    }
}