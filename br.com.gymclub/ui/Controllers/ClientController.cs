using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    [Authorize]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly AppDbContext _context;
        private readonly IStateService _stateService;
        private readonly ILogger<ClientController> _logger;
        private readonly IPlanTypeService _planTypeService;
        private readonly ITypePaymentService _typePaymentService;
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;
        public ClientController(IClientService clientService,ICityService cityService,
            AppDbContext context, IStateService stateService, ILogger<ClientController> logger,
            IPlanTypeService planTypeService,ITypePaymentService  typePaymentService, IMapper mapper)
        {
            _clientService = clientService;
            _context = context;
            _stateService = stateService;
            _logger = logger;
            _planTypeService = planTypeService;
            _typePaymentService = typePaymentService;
            _mapper = mapper;
            _cityService = cityService;
        }

        // GET: Client/Create
        [Authorize(Roles = "Recepcionista")]
        public IActionResult Create()
        {
            //ViewData["idCity"] = new SelectList(_context.City, "Id", "Name");
            ViewData["idPlanType"] = new SelectList(_planTypeService.GetAll(), "Id", "Name");
            ViewData["idState"] = new SelectList(_stateService.GetAll(), "Id", "Name");
            ViewData["idTypePayment"] = new SelectList(_typePaymentService.GetAll(), "Id", "Name");
            return View();
        }
        // GET: Clients
        [Authorize(Roles = "Recepcionista")]
        public IActionResult Index()
        {
            if (TempData["_mensagem"] != null)
            {
                TempData["_mensagem"] = JsonConvert.DeserializeObject<VMMessages>(TempData["_mensagem"].ToString());
            }
            return View(_clientService.GetAll());
        }

        // GET: Clients/Details/5
        [Authorize(Roles = "Recepcionista")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var client = _clientService.findById(id.Value);
            
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Recepcionista")]
        public ActionResult Create([Bind("Name,Email,Password,RG,cpf,Street,Neighborhood,idCity,idState,ContractStartDate,idPlanType,idTypePayment,idUser")] VMClient payload)
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
                    //return BadRequest(ModelState.GetErrorMessages());
                    ViewData["idCity"] = new SelectList(_cityService.GetCitiesByState(payload.idState), "Id", "Name", payload.idCity);

                    ViewData["idPlanType"] = new SelectList(_planTypeService.GetAll(), "Id", "Name");
                    ViewData["idState"] = new SelectList(_stateService.GetAll(), "Id", "Name");
                    ViewData["idTypePayment"] = new SelectList(_typePaymentService.GetAll(), "Id", "Name");
                    return View(payload);
                }
                var result = _clientService.Save(payload);
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
                    Text = ex.ErrorMessage
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

            ViewData["idPlanType"] = new SelectList(_planTypeService.GetAll(), "Id", "Name");
            ViewData["idState"] = new SelectList(_stateService.GetAll(), "Id", "Name");
            ViewData["idTypePayment"] = new SelectList(_typePaymentService.GetAll(), "Id", "Name");
            return View(payload);
        }

        // GET: Clients/Edit/5
        [Authorize(Roles = "Recepcionista")]
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

            var client = _clientService.findById(id.Value);
            if (client == null)
            {
               var _msg= new VMMessages()
                {
                    Css = "alert alert-danger",
                    Text = "Um erro insperado ocorreu"
                };
                TempData["_mensagem"] = JsonConvert.SerializeObject(_msg);
                return RedirectToAction(nameof(Index));
            }
            ViewData["idCity"] = new SelectList(_cityService.GetCitiesByState(client.idState), "Id", "Name", client.idCity);
            ViewData["idPlanType"] = new SelectList(_planTypeService.GetAll(), "Id", "Name", client.idPlanType);
            ViewData["idState"] = new SelectList(_stateService.GetAll() ,"Id", "Name", client.idState);
            ViewData["idTypePayment"] = new SelectList(_typePaymentService.GetAll(), "Id", "Name", client.idTypePayment);
            return View(_mapper.Map<VMClient>(client));
        }

        [HttpPost]
        [Authorize(Roles = "Recepcionista")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("IdRegistration,Name,Email,Password,RG,cpf,Street,Neighborhood,idCity,idState,ContractStartDate,ContractEndDate,idPlanType,idTypePayment,idUser,CreatedAt,UpdatedAt,DeletedAt")] VMClient payload)
        {
            try
            {
                if (id != payload.IdRegistration)
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
                    
                    var result = _clientService.Update(payload);
                    if (result)
                    {
                        var _msg= new VMMessages()
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
                    Text = ex.ErrorMessage
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
            ViewData["idPlanType"] = new SelectList(_planTypeService.GetAll(), "Id", "Name", payload.idPlanType);
            ViewData["idState"] = new SelectList(_stateService.GetAll(), "Id", "Name", payload.idState);
            ViewData["idTypePayment"] = new SelectList(_typePaymentService.GetAll(), "Id", "Name", payload.idTypePayment);
            return View(payload);
        }

        // GET: Clients/Delete/5
        [Authorize(Roles = "Recepcionista")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _clientService.findById(id.Value);
            if (client == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<VMClient>(client));
        }
      
        [Authorize(Roles = "Recepcionista")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var payload = _clientService.findById(id);
                if(payload==null)
                {
                    return NotFound();
                }
                if (_clientService.Remove(payload))
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
                    return View(_clientService.GetAll());
                }
                else
                {
                    ViewData["searchOld"] = payload.searchValue;
                    return View(_clientService.GetClientByNameOrRGOrCPF(payload.searchValue));
                }
                
            }
            catch (CustomHttpException ex)
            {
                TempData["_mensagem"] = new VMMessages()
                {
                    Css = "alert alert-danger",
                    Text = ex.ErrorMessage
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
            return View(_clientService.GetAll());
        }

        #region Export Excel
       [Authorize(Roles = "Recepcionista")]
        public ActionResult Export([Bind("searchValue,searchOld")] VMSearchClient payload)
        {

            List<Client> list;
            if (string.IsNullOrEmpty(payload.searchOld) || string.IsNullOrWhiteSpace(payload.searchOld))
            {
                list= _clientService.GetAll();
            }
            else
            {

                list=_clientService.GetClientByNameOrRGOrCPF(payload.searchOld);
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
            return excel.ExportData("Clientes", dt);

          
            

        }
        #endregion
        #region GetDataTable
        
        private DataTable GetDataTable(List<Client> clients)
        {


            DataTable table = new DataTable();
            table.Columns.Add("Código Matricula", typeof(string));
            table.Columns.Add("Nome", typeof(string));
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("Rg", typeof(string));
            table.Columns.Add("Cpf", typeof(string));
            table.Columns.Add("Tipo de plano", typeof(string));

            DataRow rowReturn = null;


            foreach (Client item in clients)
            {
                rowReturn = table.NewRow();
                rowReturn["Código Matricula"] = item.IdRegistration.ToString();
                rowReturn["Nome"] = item.User.Name.ToString();
                rowReturn["Email"] = item.User.Email.ToString();
                rowReturn["Rg"] = item.User.Rg.ToString();
                rowReturn["Cpf"] = item.User.Cpf.ToString();
                rowReturn["Tipo de plano"] = item.planType.Name.ToString();


                table.Rows.Add(rowReturn);

            }







            return table;
        }
        #endregion


    }
}
