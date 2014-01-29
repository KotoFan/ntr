using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERES.Mvc.Models.GradeValuesModels;
using EresData;

namespace ERES.Mvc.Controllers
{
    public class GradeValuesController : Controller
    {
        //
        // GET: /GradeValues/

        public ActionResult Index()
        {
            Model m = new Model();
            Models.GradeValuesModels.StudensForGrades model = new Models.GradeValuesModels.StudensForGrades();
            model.studentList = m.getStudents();

            return View(model);
        }

        //
        // GET: /GradeValues/StudentRegistrations/5

        public ActionResult StudentRegistrations(int id)
        {
            Model m = new Model();
            StudentRegistrations model = new StudentRegistrations();
            model.registrationList = m.getStudentRegistrations(id);
            // var a = ; 
            return View(model);
        }
        //
        // GET: /GradeValues/StudentGrades/5

        public ActionResult StudentGrades(int id)
        {
            Model m = new Model();
            GradeValuesViewModel model = new GradeValuesViewModel();
            model.allGrades = (m.getAllGrades(id));
           // var a = ; 
            return View(model);
        }


        //
        // GET: /GradeValues/Teacher

        public ActionResult Teacher()
        {

            TeacherLists model = new TeacherLists();
            model.realisationList = getRealisationSelectList();

            return View(model);
        }

        //
        // GET: /GradeValues/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /GradeValues/Create

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

        //
        // GET: /GradeValues/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /GradeValues/Edit/5

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

        //
        // GET: /GradeValues/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /GradeValues/Delete/5

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
        private SelectList getRealisationSelectList()
        {
            Model m = new Model();
            var roles = m.getRealisations().Select(x =>
                            new SelectListItem
                            {
                                Value = x.RealisationID.ToString(),
                                Text = x.ToString(),

                            });
            return new SelectList(roles, "Value", "Text"); ;
        }
    }
}
