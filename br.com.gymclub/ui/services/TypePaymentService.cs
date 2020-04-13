using System;
using System.Collections.Generic;
using api.models;
using api.repositories.Interfaces;
using api.services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using settings;

namespace services
{
    public class TypePaymentService : ITypePaymentService
    {
        private readonly ITypepaymentRepository _typepaymentRepository;
        private readonly AppSettings _appSettings;


        public TypePaymentService(ITypepaymentRepository typepaymentRepository, IOptions<AppSettings> appSettings)
        {

            _typepaymentRepository = typepaymentRepository;
            _appSettings = appSettings.Value;
        }

        public List<TypePayment> GetAll()
        {
            return _typepaymentRepository.GetAll();
        }

        
    }
}
