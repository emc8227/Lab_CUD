using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_CUD.Models;

namespace Lab_CUD.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            Lab_CUDEntities db = new Lab_CUDEntities();

            return View(db.students.ToList());
        }

        public ActionResult Detail(int id) {
            Lab_CUDEntities db = new Lab_CUDEntities();
            student st = db.students.Find(id);
            return View(st);
        }

        public ActionResult Create() {
            return View();
        }


        [HttpPost]
        public ActionResult Create(student newForm) {
            ViewBag.id = newForm.ID;
            ViewBag.name=newForm.name;
            ViewBag.phone=newForm.phone;
            
            
            if (newForm.ID == 0 ||
                string.IsNullOrEmpty(newForm.ID.ToString()) ||
                string.IsNullOrEmpty(newForm.name.ToString()) ||
                string.IsNullOrEmpty(newForm.phone.ToString())) {
                return View();
            }
            Lab_CUDEntities db = new Lab_CUDEntities();
            db.students.Add(newForm);
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }

        public ActionResult Update(int id) {
            Lab_CUDEntities db = new Lab_CUDEntities();
            student st = db.students.Find(id);
            return View(st);
        }


        [HttpPost]
        public ActionResult Update(student newst) {
            Lab_CUDEntities db = new Lab_CUDEntities();
            student st = db.students.Find(newst.ID);
            st.ID = newst.ID;
            st.name = newst.name;
            st.phone = newst.phone;
            
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }
        
        
        public ActionResult Delete(int id) {
            Lab_CUDEntities db = new Lab_CUDEntities();
            student st = db.students.Find(id);
            db.students.Remove(st);
            db.SaveChanges();
            return RedirectToAction("Index");
        }    
           
            
           
        
    }
}