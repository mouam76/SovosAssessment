using DataAccess.Models;
using SovosAssessmentMVC.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using static DataAccess.Logic.CaseProcessor;

namespace SovosAssessmentMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CaseViewModel searchViewModel = new CaseViewModel();

            return View(searchViewModel);
        }

        public JsonResult GenerateDatatableData(DatatableModel datatableModel, CaseViewModel searchViewModel)
        {
            var CaseModelList = LoadCases(AutoMapper.AutoMapperConfig.Mapper.Map<CaseViewModel, CaseModel>(searchViewModel));

            var results = AutoMapper.AutoMapperConfig.Mapper.Map<List<CaseModel>, List<CaseViewModel>>(CaseModelList);

            return Json(new
            {
                recordsTotal = results.Count,
                recordsFiltered = 0,
                data = results
            });
        }
    }
}