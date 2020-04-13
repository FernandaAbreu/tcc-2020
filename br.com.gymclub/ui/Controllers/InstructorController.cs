using System;
using System.Collections.Generic;
using System.Data;
using api.context;
using api.Extensions;
using api.models;
using api.services.Interfaces;
using api.viewmodels;
using AutoMapper;
using helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ui.helpers;
using ui.viewmodels;

namespace api.Controllers
{
   
    public class InstructorController : Controller
    {
       
        private readonly AppDbContext _context;
        private readonly IStateService _stateService;
        private readonly ILogger<InstructorController> _logger;
        private readonly IMapper _mapper;
        private readonly IInstructorService _instructorService;
        private readonly ICityService _cityService;
        public InstructorController(IInstructorService instructorService,ICityService cityService,
            AppDbContext context, IStateService stateService, ILogger<InstructorController> logger,
             IMapper mapper)
        {
            _instructorService = instructorService;
            _context = context;
            _stateService = stateService;
            _logger = logger;
          
            _mapper = mapper;
            _cityService = cityService;
        }

        // GET: Instructor/Create
        public IActionResult Create()
        {

            ViewData["idState"] = new SelectList(_stateService.GetAll(), "Id", "Name");
            return View();
        }
        // GET: Instructor
        public IActionResult Index()
        {
            if (TempData["_mensagem"] != null)
            {
                TempData["_mensagem"] = JsonConvert.DeserializeObject<VMMessages>(TempData["_mensagem"].ToString());
            }
            return View(_instructorService.GetAll());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Recepcionista")]
        public ActionResult Create([Bind("Name,Email,Password,RG,cpf,Street,Neighborhood,idCity,idState,idUser")] VMInstructor payload)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["_mensagem"] = new VMMessages()
                    {
                        Css = "alert alert-danger",
                        Text = "Não foi possivel realizar seu cadastro,tente novamente!"
                    };
                   
                    ViewData["idState"] = new SelectList(_stateService.GetAll(), "Id", "Name");
                    return View(payload);
                }
                var result = _instructorService.Save(payload);
                var _msg = new VMMessages()
                {
                    Css = "alert alert-success",
                    Text = "Cadastro salvo com sucesso!"
                };
                TempData["_mensagem"] = JsonConvert.SerializeObject(_msg);
                return RedirectToAction(nameof(Index));
            }
            catch (CustomHttpException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                TempData["_mensagem"] = new VMMessages()
                {
                    Css = "alert alert-danger",
                    Text = ex.Message
                };

            }
            catch (Exception ex)
            {

                _logger.Log(LogLevel.Error, ex.Message);
                TempData["_mensagem"] = new VMMessages()
                {
                    Css = "alert alert-danger",
                    Text = "Um erro insperado ocorreu"
                };

            }
           
            ViewData["idState"] = new SelectList(_stateService.GetAll(), "Id", "Name");
            return View(payload);
        }


        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["_mensagem"] = new VMMessages()
                {
                    Css = "alert alert-danger",
                    Text = "Um erro insperado ocorreu"
                };
                return RedirectToAction(nameof(Index));
            }

            var entity = _instructorService.findById(id.Value);
            if (entity == null)
            {
                var _msg = new VMMessages()
                {
                    Css = "alert alert-danger",
                    Text = "Um erro insperado ocorreu"
                };
                TempData["_mensagem"] = JsonConvert.SerializeObject(_msg);
                return RedirectToAction(nameof(Index));
            }
            ViewData["idCity"] = new SelectList(_cityService.GetCitiesByState(entity.idState), "Id", "Name", entity.idCity);
            ViewData["idState"] = new SelectList(_stateService.GetAll(), "Id", "Name", entity.idState);
            return View(_mapper.Map<VMInstructor>(entity));
        }
        [HttpPost]
        //[Authorize(Roles = "Recepcionista")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("id,Name,Email,Password,RG,cpf,Street,Neighborhood,idCity,idState,idUser,CreatedAt,UpdatedAt,DeletedAt")] VMInstructor payload)
        {
            try
            {
                if (id != payload.id)
                {
                    var _msg = new VMMessages()
                    {
                        Css = "alert alert-danger",
                        Text = "Um erro inseperado ocorreu"
                    };
                    TempData["_mensagem"] = JsonConvert.SerializeObject(_msg);
                    return RedirectToAction(nameof(Index));
                }

                if (ModelState.IsValid)
                {

                    var result = _instructorService.Update(payload);
                    if (result)
                    {
                        var _msg = new VMMessages()
                        {
                            Css = "alert alert-success",
                            Text = "Editado com sucesso!"
                        };
                        TempData["_mensagem"] = JsonConvert.SerializeObject(_msg);
                    }
                    else
                    {
                        var _msg = new VMMessages()
                        {
                            Css = "alert alert-danger",
                            Text = "Um erro insperado ocorreu"
                        };
                        TempData["_mensagem"] = JsonConvert.SerializeObject(_msg);
                    }

                    return RedirectToAction(nameof(Index));

                }


            }
            catch (CustomHttpException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                TempData["_mensagem"] = new VMMessages()
                {
                    Css = "alert alert-danger",
                    Text = ex.Message
                };

            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                TempData["_mensagem"] = new VMMessages()
                {
                    Css = "alert alert-danger",
                    Text = "Um erro insperado ocorreu"
                };

            }

            ViewData["idCity"] = new SelectList(_cityService.GetCitiesByState(payload.idState), "Id", "Name", payload.idCity);
            ViewData["idState"] = new SelectList(_stateService.GetAll(), "Id", "Name", payload.idState);
            return View(payload);
        }
        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _instructorService.findById(id.Value);
            if (client == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<VMClient>(client));
        }

        //[Authorize(Roles = "Recepcionista")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var payload = _instructorService.findById(id);
                if (payload == null)
                {
                    return NotFound();
                }
                if (_instructorService.Remove(payload))
                {
                    var mMessages = new VMMessages()
                    {
                        Css = "alert alert-success",
                        Text = "Cliente removido com sucesso!"
                    };
                    TempData["_mensagem"] = JsonConvert.SerializeObject(mMessages);
                }
                else
                {
                    var mMessages = new VMMessages()
                    {
                        Css = "alert alert-danger",
                        Text = "Um erro insperado ocorreu"
                    };
                    TempData["_mensagem"] = JsonConvert.SerializeObject(mMessages);
                }
                return RedirectToAction(nameof(Index));


            }
            catch (CustomHttpException ex)
            {
                //return StatusCode(ex.StatusCode, ex.ErrorMessage);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                //return StatusCode(500, new { error = "Internal server error" });
            }
            var _msg = new VMMessages()
            {
                Css = "alert alert-danger",
                Text = "Um erro insperado ocorreu"
            };
            TempData["_mensagem"] = JsonConvert.SerializeObject(_msg);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        //[Authorize(Roles = "Recepcionista")]
        public ActionResult Index([Bind("searchValue,searchOld")] VMSearchClient payload)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }
                if (string.IsNullOrEmpty(payload.searchValue) || string.IsNullOrWhiteSpace(payload.searchValue))
                {
                    return View(_instructorService.GetAll());
                }
                else
                {
                    ViewData["searchOld"] = payload.searchValue;
                    return View(_instructorService.GetInstructorByNameOrRGOrCPF(payload.searchValue));
                }

            }
            catch (CustomHttpException ex)
            {
                TempData["_mensagem"] = new VMMessages()
                {
                    Css = "alert alert-danger",
                    Text = "Um erro insperado ocorreu"
                };
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                TempData["_mensagem"] = new VMMessages()
                {
                    Css = "alert alert-danger",
                    Text = "Um erro insperado ocorreu"
                };
            }
            return View(_instructorService.GetAll());
        }

        #region Export Excel

        public ActionResult Export([Bind("searchValue,searchOld")] VMSearchClient payload)
        {

            List<Instructor> list;
            if (string.IsNullOrEmpty(payload.searchOld) || string.IsNullOrWhiteSpace(payload.searchOld))
            {
                list = _instructorService.GetAll();
            }
            else
            {

                list = _instructorService.GetInstructorByNameOrRGOrCPF(payload.searchOld);
            }

            DataTable dt = GetDataTable(list);

            if (dt.Rows.Count == 0)
            {
                var mMessages = new VMMessages()
                {
                    Css = "msg-sucesso",
                    Text = "Não há itens para serem exportados!"
                };
                TempData["_mensagem"] = JsonConvert.SerializeObject(mMessages);
                return RedirectToAction("Index");
            }



            Excel excel = new Excel();
            return excel.ExportData("Instrutores", dt);




        }
        #endregion
        #region GetDataTable

        private DataTable GetDataTable(List<Instructor> instructors)
        {


            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(string));
            table.Columns.Add("Nome", typeof(string));
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("Rg", typeof(string));
            table.Columns.Add("Cpf", typeof(string));
            

            DataRow rowReturn = null;


            foreach (Instructor item in instructors)
            {
                rowReturn = table.NewRow();
                rowReturn["Id"] = item.Id.ToString();
                rowReturn["Nome"] = item.User.Name.ToString();
                rowReturn["Email"] = item.User.Email.ToString();
                rowReturn["Rg"] = item.User.Rg.ToString();
                rowReturn["Cpf"] = item.User.Cpf.ToString();
                


                table.Rows.Add(rowReturn);

            }







            return table;
        }
        #endregion
    }
}
