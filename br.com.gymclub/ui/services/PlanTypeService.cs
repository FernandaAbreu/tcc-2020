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
    public class PlanTypeService : IPlanTypeService
    {
        private readonly IPlanTypeRepository _planTypeRepository;
        private readonly AppSettings _appSettings;


        public PlanTypeService(IPlanTypeRepository planTypeRepository, IOptions<AppSettings> appSettings)
        {

            _planTypeRepository = planTypeRepository;
            _appSettings = appSettings.Value;
        }

        public List<PlanType> GetAll()
        {
            return _planTypeRepository.GetAll();
        }

        
    }
}
