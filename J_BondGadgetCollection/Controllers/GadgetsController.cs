using J_BondGadgetCollection.Data;
using J_BondGadgetCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace J_BondGadgetCollection.Controllers
{
    public class GadgetsController : Controller
    {
        // GET: Gadgets
        public ActionResult Index()
        {
            List<GadgetModel> gadgets = new List<GadgetModel>();
            GadgetDAO gadgetDAO = new GadgetDAO();
            gadgets = gadgetDAO.FetchAll();
            
            return View("Index",gadgets);
        }
    }
}