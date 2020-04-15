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
    
    [Authorize]
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
            var finalDate = DateTime.Now;

            var initDate = DateTime.MinValue;

            return View(_paymentService.GetPaymentsThatAreNotPaidAndNeeded(initDate,finalDate));
              
           
        }

        [HttpPost]

        public ActionResult Index([Bind("searchValue,searchOld,initDateOld,initDate,finalDateOld,finalDate")] VMSearchpayment payload)
        {
            if (payload.finalDate == null )
            {
                payload.finalDate = DateTime.Now;
            }
            if (payload.initDate == null)
            {
                payload.initDate = DateTime.MinValue;
            }
            try
            {
                
                if (string.IsNullOrEmpty(payload.searchValue) || string.IsNullOrWhiteSpace(payload.searchValue))
                {
                    return View(_paymentService.GetPaymentsThatAreNotPaidAndNeeded(payload.initDate.Value, payload.finalDate.Value));
                }
                else
                {
                    ViewData["searchOld"] = payload.searchValue;
                    ViewData["finalDateOld"] = payload.finalDate;
                    ViewData["initDateOld"] = payload.initDateOld;
                    return View(_paymentService.GetPaymentsByNameOrRGOrCPF(payload.searchValue,payload.initDate.Value, payload.finalDate.Value));
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
            return View(_paymentService.GetPaymentsThatAreNotPaidAndNeeded(payload.initDate.Value, payload.finalDate.Value));
        }

        #region Export Excel

        public ActionResult Export([Bind("searchValue,searchOld,initDateOld,initDate,finalDateOld,finalDate")] VMSearchpayment payload)
        {
            if (payload.finalDateOld == null)
            {
                payload.finalDateOld = DateTime.Now;
            }
            if (payload.initDateOld == null)
            {
                payload.initDateOld = DateTime.MinValue;
            }

            List<Payment> list;
            if (string.IsNullOrEmpty(payload.searchOld) || string.IsNullOrWhiteSpace(payload.searchOld))
            {
                list= _paymentService.GetPaymentsThatAreNotPaidAndNeeded(payload.initDateOld.Value, payload.finalDateOld.Value);
            }
            else
            {
                list= _paymentService.GetPaymentsByNameOrRGOrCPF(payload.searchOld,payload.initDateOld.Value, payload.finalDateOld.Value);
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




       
    }
}
