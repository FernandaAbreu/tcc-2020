using System;
using System.Collections.Generic;
using api.repositories.Interfaces;
using api.services.Interfaces;
using Microsoft.Extensions.Options;
using settings;

namespace api.services
{
    public class PaymentService<Payment> : IPaymentService
    {

        private readonly IPaymentRepository _paymentRepository;
        private readonly AppSettings _appSettings;


        public PaymentService(IPaymentRepository paymentRepository, IOptions<AppSettings> appSettings)
        {

            _paymentRepository = paymentRepository;
            _appSettings = appSettings.Value;
        }

       

        public int Save(models.Payment entity)
        {
            return _paymentRepository.Save(entity);
        }

        public bool Update(Payment entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(models.Payment entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<models.Payment> IPaymentService.GetAll()
        {
            return _paymentRepository.GetAll();
        }

        List<models.Payment> IPaymentService.GetPaymentsByNameOrRGOrCPF(string searchValue)
        {
            return _paymentRepository.GetPaymentsByNameOrRGOrCPF(searchValue);
        }

        List<models.Payment> IPaymentService.GetPaymentsThatAreNotPaidAndNeeded()
        {
            return _paymentRepository.GetPaymentsThatAreNotPaidAndNeeded();
        }
    }
}
