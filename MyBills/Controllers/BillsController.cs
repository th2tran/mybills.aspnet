using MyBills.Models;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBills.Controllers {
    /// <summary>
    /// Controller responsible for actions relating to bills: create, search,view, edit, delete,... 
    /// </summary>
    public class BillsController : Controller {
        BillDBContext db = new BillDBContext();
        //
        // GET: /Bills/

        public ActionResult Index() {
            // search for bills due in the next 30 days
            DateTime plus30 = DateTime.Now.AddDays(30);
            var bills = from b in db.Bills
                        where b.DueDate < plus30
                        select b;
            return View(bills.ToList());
        }
        /// <summary>
        /// Returns bills from the specified vendor.
        /// </summary>
        /// <param name="VendorName"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index(string VendorName) {
            var bills = from b in db.Bills select b;
            if (!String.IsNullOrEmpty(VendorName)) {
                bills = bills.Where(b => b.VendorName.Contains(VendorName));
            }
            return View(bills);
        }

        /// <summary>
        /// GET: /bills/create
        /// </summary>
        /// <returns></returns>
        public ActionResult Create() {
            return View();
        }

        /// <summary>
        /// GET: /bills/create
        /// </summary>
        /// <param name="newBill"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Bill newBill) {
            if (ModelState.IsValid) {
                db.Bills.Add(newBill);
                db.SaveChanges();
                return RedirectToAction("Index");
            } else {
                return View(newBill);
            }
        }

        /// <summary>
        /// GET: /bills/details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id) {
            Bill bill = db.Bills.Find(id);
            if (bill == null) return RedirectToAction("Index");
            return View("Details", bill);
        }

        public ActionResult Edit(int id) {
            var bill = db.Bills.Find(id);
            return View(bill);
        }

        [HttpPost]
        public ActionResult Edit(Bill bill) {
            if (ModelState.IsValid) {
                db.Entry(bill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bill);
        }

        public ActionResult Delete(int id) {
            Bill bill = db.Bills.Find(id);
            if (bill == null) return RedirectToAction("Index");
            return View(bill);
        }
        [HttpPost]
        public RedirectToRouteResult Delete(int id, FormCollection collection) {
            Bill bill = db.Bills.Find(id);
            db.Bills.Remove(bill);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
