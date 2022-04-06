using rohit_boothstrap.dbcontext;
using rohit_boothstrap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rohit_boothstrap.Controllers
{
    public class empController : Controller
    {
        // GET: emp
        public ActionResult Index()
        {
            Chetu1Entities obj = new Chetu1Entities();
            List<empclass1> mobj = new List<empclass1>();
            var x = obj.table4data.ToList();
            foreach (var item in x)
            {
                mobj.Add(new empclass1
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    Address = item.Address
                });

            }

            return View(mobj);
        }

        public ActionResult Delete(int Id)
        {

            Chetu1Entities obj = new Chetu1Entities();
            var del = obj.table4data.Where(x => x.Id == Id).First();
            obj.table4data.Remove(del);
            obj.SaveChanges();

            return RedirectToAction("Index", "emp");
        }


        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(empclass1 model)
        {

            Chetu1Entities obj = new Chetu1Entities();
            table4data tblobj = new table4data();
            tblobj.Id = model.Id;
            tblobj.Name = model.Name;
            tblobj.Email = model.Email;
            tblobj.Address = model.Address;


            if (tblobj.Id == 0)
            {
                obj.table4data.Add(tblobj);
                obj.SaveChanges();
            }
            else
            {
                obj.Entry(tblobj).State = System.Data.Entity.EntityState.Modified;
                obj.SaveChanges();
            }
            return RedirectToAction("Index", "emp");
        }

        public ActionResult Edit(int Id)
        {
            Chetu1Entities obj = new Chetu1Entities();
            table4data tblobj = new table4data();
            empclass1 mobj = new empclass1();
            var E = obj.table4data.Where(b => b.Id == Id).First();
            mobj.Id = E.Id;
            mobj.Name = E.Name;
            mobj.Email = E.Email;
            mobj.Address = E.Address;
            return View("AddEmployee", mobj);
        }


    }
}