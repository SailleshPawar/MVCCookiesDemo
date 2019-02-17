using MVCCookiesDemo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCCookiesDemo.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            

            List<Customer> customers = new List<Customer> {new Customer()
            {
                Address = "quinnox mumbai",
                Age = "30",
                CustomerFirstName = "Saillesh",
                CustomerLastName = "Pawar"
            },new Customer()
            {
                Address = "quinnox mumbai",
                Age = "30",
                CustomerFirstName = "Digambar",
                CustomerLastName = "Maharaj"
            },
           new Customer()
            {
                Address = "quinnox bangalore",
                Age = "35",
                CustomerFirstName = "Laxman",
                CustomerLastName = "Singh"
            } };

            Session["FirstName"] = customers.FirstOrDefault().CustomerFirstName;
            return View(customers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
