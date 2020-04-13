using System;
using System.Collections.Generic;
using System.Data;
using api.Extensions;
using api.models;
using api.services.Interfaces;
using api.viewmodels;
using helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ui.helpers;
using ui.viewmodels;

namespace api.Controllers
{
    
   
    public class InadimplentesController : Controller
    {
        private readonly IPaymentService _paymentService;

        public InadimplentesController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            
                
             return View(_paymentService.GetPaymentsThatAreNotPaidAndNeeded());
              
           
        }

        [HttpPost]
        //[Authorize(Roles = "Recepcionista")]
        public ActionResult Index([Bind("searchValue,searchOld,initDateOld,initDate,finalDateOld,finalDate")] VMSearchpayment payload)
        {
            try
            {
                if (string.IsNullOrEmpty(payload.searchValue) || string.IsNullOrWhiteSpace(payload.searchValue))
                {
                    return View(_paymentService.GetPaymentsThatAreNotPaidAndNeeded());
                }
                else
                {
                    ViewData["searchOld"] = payload.searchValue;
                    ViewData["finalDateOld"] = payload.finalDate;
                    ViewData["initDateOld"] = payload.initDateOld;
                    return View(_paymentService.GetPaymentsByNameOrRGOrCPF(payload.searchValue));
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
               
                TempData["_mensagem"] = new VMMessages()
                {
                    Css = "alert alert-danger",
                    Text = "Um erro insperado ocorreu"
                };
            }
            return View(_paymentService.GetPaymentsThatAreNotPaidAndNeeded());
        }

        #region Export Excel

        public ActionResult Export([Bind("searchValue,searchOld,initDateOld,initDate,finalDateOld,finalDate")] VMSearchpayment payload)
        {

            List<Payment> list;
            if (string.IsNullOrEmpty(payload.searchValue) || string.IsNullOrWhiteSpace(payload.searchValue))
            {
                list= _paymentService.GetPaymentsThatAreNotPaidAndNeeded();
            }
            else
            {
                list= _paymentService.GetPaymentsByNameOrRGOrCPF(payload.searchValue);
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
            return excel.ExportData("Lista de Inadimplentes", dt);




        }
        #endregion
        #region GetDataTable

        private DataTable GetDataTable(List<Payment> payments)
        {


            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(string));
            table.Columns.Add("Nome", typeof(string));
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("Rg", typeof(string));
            table.Columns.Add("Cpf", typeof(string));
            table.Columns.Add("Plano", typeof(string));

            DataRow rowReturn = null;


            foreach (Payment item in payments)
            {
                rowReturn = table.NewRow();
                rowReturn["Id"] = item.Id.ToString();
                rowReturn["Nome"] = item.client.User.Name.ToString();
                rowReturn["Email"] = item.client.User.Email.ToString();
                rowReturn["Rg"] = item.client.User.Rg.ToString();
                rowReturn["Cpf"] = item.client.User.Cpf.ToString();



                table.Rows.Add(rowReturn);

            }







            return table;
        }
        #endregion




        [HttpGet]
        public ActionResult<List<Payment>> list()
        {
            try
            {

                return _paymentService.GetPaymentsThatAreNotPaidAndNeeded();


            }
            catch (CustomHttpException ex)
            {
                return StatusCode(ex.StatusCode, ex.ErrorMessage);
            }
            catch (Exception ex)
            {
                // TODO: Log ex
                return StatusCode(500, new { error = "Internal server error" });
            }
        }

        [HttpGet]
        public ActionResult<List<Payment>> list([FromBody] VMSearchpayment payload)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorMessages());
                }
                if (string.IsNullOrEmpty(payload.searchValue) || string.IsNullOrWhiteSpace(payload.searchValue))
                {
                    return _paymentService.GetPaymentsThatAreNotPaidAndNeeded();
                }
                else
                {
                    return _paymentService.GetPaymentsByNameOrRGOrCPF(payload.searchValue);
                }

            }
            catch (CustomHttpException ex)
            {
                return StatusCode(ex.StatusCode, ex.ErrorMessage);
            }
            catch (Exception ex)
            {
                // TODO: Log ex
                return StatusCode(500, new { error = "Internal server error" });
            }
        }
    }
}
