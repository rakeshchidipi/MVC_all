using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_all.Comp;
using MVC_all.Models;
using AutoMapper;
using System.Text;

namespace MVC_all.Controllers
{
    [MyExceptionHandle]
    public class EmpController : Controller
    {
        private IDBComp _dbcomp;
        public EmpController(IDBComp dbcomp)
        {
            _dbcomp = dbcomp;
        }

        // GET: Emp
        [HttpGet]
        public ActionResult Index()
        {
            //throw new Exception("test");
          
            List<EmpView> empviewlist = new List<EmpView>();
            List<EmpModel> emplist = _dbcomp.GetEmpList();

            //Automap

            ////// use cfg to configure AutoMapper
            ////var config = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDto>());

            ////var mapper = config.CreateMapper();
            ////// or
            ////var mapper = new Mapper(config);
            //OrderDto dto = mapper.Map<OrderDto>(order);


            MapperConfiguration cong = new MapperConfiguration((m) => m.CreateMap<EmpModel, EmpView >());
            var mapper = cong.CreateMapper();
            mapper.Map(emplist, empviewlist);


            //Func<List<string>, List<SelectListItem>> ss1 = (input) => { return new List<SelectListItem>(); };
           


            return View("EmpList", empviewlist);
        }


        [HttpGet]
        [Route("get/{id}")]
        public ActionResult get(int id)
        {
            EmpModel emp = _dbcomp.GetEmp(id);

            MapperConfiguration config = new MapperConfiguration(m => m.CreateMap<EmpModel, EmpView>());
            var mapper = config.CreateMapper();
            EmpView empv=new EmpView();
            mapper.Map(emp, empv);

            return View("Emp",empv);
        }

        [HttpPost]
        public ActionResult add(EmpView empv)
        {
            if (ModelState.IsValid) {
                //Save 

                MapperConfiguration config = new MapperConfiguration(m => m.CreateMap<EmpView,EmpModel >());
                var mapper = config.CreateMapper();
                EmpModel emp = new EmpModel();
                mapper.Map(empv,emp );

                _dbcomp.AddEmp(emp);
            }else
            {
                var res = new ViewResult() { ViewName = "Error" };
                StringBuilder ss = new StringBuilder();
                foreach (var modelError in ModelState)
                {
                    string propertyName = modelError.Key;
                    if (modelError.Value.Errors.Count > 0)
                    {
                        foreach(var err in modelError.Value.Errors)
                        {
                            ss.Append("\n" + err.ErrorMessage);
                        }
                       
                    }
                }
                res.TempData["error"] = ss.ToString();

                return res;

            }

            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult addnew()
        {
            EmpView empv = new EmpView();
            return View("Empedit",empv);
        }


        [HttpGet]
        public ActionResult getedit(int id)
        {
            EmpModel emp = _dbcomp.GetEmp(id);

            MapperConfiguration config = new MapperConfiguration(m => m.CreateMap<EmpModel, EmpView>());
            var mapper = config.CreateMapper();
            EmpView empv = new EmpView();
            mapper.Map(emp, empv);

            ViewBag.genderlist = new SelectList(empv.genderList, "id", "type",2);

            return View("Empedit", empv);
        }

        [HttpPost]
        public ActionResult edit(EmpView empv)
        {
            if (ModelState.IsValid)
            {
                //Update 
            }

            return RedirectToAction("index");
        }



        //protected override void OnException(ExceptionContext expcontext)
        //{
        //    expcontext.ExceptionHandled = true;
        //    expcontext.Result = RedirectToAction("index", "error");

        //    //expcontext.Exception.
        //}


    }
}