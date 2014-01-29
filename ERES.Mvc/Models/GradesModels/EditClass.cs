using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EresData;
using System.Web.Mvc;

namespace ERES.Mvc.Models.GradesModels
{
    public class EditClass
    {
        public IEnumerable<SelectListItem> realisationList;
        public Grades grade;
    }
}