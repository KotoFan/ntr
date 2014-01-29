using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EresData;

namespace ERES.Mvc.Controllers
{
    public class GradesController : Controller
    {
        //
        // GET: /Grades/

        public ActionResult Index()
        {
            Model model = new Model();

            return View(model.getGrades().ToList());
        }

        //
        // GET: /Grades/Details/5

        public ActionResult Details(int id)
        {

            return View();
        }

        //
        // GET: /Grades/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Grades/Create

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
        // GET: /Grades/Edit/5

        public ActionResult Edit(int id)
        {

            Model m = new Model();

            Models.GradesModels.EditClass model = new Models.GradesModels.EditClass();

            model.grade = m.getGrade(id);
            model.realisationList = getRealisationSelectList(model.grade.RealisationID.ToString()) ;

            return View(model);
        }

        //
        // POST: /Grades/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                string name = Convert.ToString(collection["grade.Name"]);
                int realisation = Convert.ToInt32(collection["grade.RealisationID"]);
                string maxValue = Convert.ToString(collection["grade.MaxValue"]);

                Model m = new Model();

                if (string.IsNullOrEmpty(name))
                    ModelState.AddModelError("name", "Trzeba podać nazwę.");

                if (ModelState.IsValid)
                {
                    m.updateGrade(name, maxValue, realisation, id);
                    return RedirectToAction("Index");
                }
                else
                {
                    Models.GradesModels.EditClass model = new Models.GradesModels.EditClass();

                    model.grade = m.getGrade(id);
                   
                    model.grade.MaxValue = maxValue;
                    model.grade.Name = name;
                    model.grade.RealisationID = realisation;

                    model.realisationList = getRealisationSelectList(realisation.ToString());
                    return View(model);
                }
                //   
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        //
        // GET: /Grades/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Grades/Delete/5

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
        private SelectList getRealisationSelectList(string realisation)
        {
            Model m = new Model();
            var roles = m.getRealisations().Select(x =>
                            new SelectListItem
                            {
                                Value = x.RealisationID.ToString(),
                                Text = x.ToString(),

                            });
            return new SelectList(roles, "Value", "Text", realisation); ;
        }
    }

   
}
