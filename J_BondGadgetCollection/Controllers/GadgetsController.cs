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

        public ActionResult Details(int id)
        {
            GadgetDAO gadgetDAO = new GadgetDAO();
            GadgetModel gadget = gadgetDAO.FetchOne(id);

            return View("Details", gadget);
        }

        public ActionResult Create()
        {
            return View("GadgetForm");
        }

        public ActionResult processCreate(GadgetModel gadgetModel)
        {
            //save to the database

            GadgetDAO gadgetDAO = new GadgetDAO();
            gadgetDAO.Create(gadgetModel);

            return View("Details", gadgetModel);
        }
    }
}