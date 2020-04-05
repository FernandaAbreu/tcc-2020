using System;
using System.Collections.Generic;
using data.repositories.Interfaces;
using domain.models;
using Microsoft.Extensions.Options;
using services.Interfaces;
using settings;

namespace services
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

       

        public int Save<Payment>(Payment entity) where Payment : class
        {
            return _paymentRepository.Save(entity);
        }

        public bool Update<Payment>(Payment entity) where Payment : class
        {
            throw new NotImplementedException();
        }

        IEnumerable<domain.models.Payment> IPaymentService.GetAll()
        {
            return _paymentRepository.GetAll();
        }

        List<domain.models.Payment> IPaymentService.GetPaymentsByNameOrRGOrCPF(string searchValue)
        {
            return _paymentRepository.GetPaymentsByNameOrRGOrCPF(searchValue);
        }

        List<domain.models.Payment> IPaymentService.GetPaymentsThatAreNotPaidAndNeeded()
        {
            return _paymentRepository.GetPaymentsThatAreNotPaidAndNeeded();
        }
    }
}
