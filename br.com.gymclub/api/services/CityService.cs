using System;
using System.Collections.Generic;
using api.models;
using api.repositories.Interfaces;
using api.services.Interfaces;
using Microsoft.Extensions.Options;
using settings;

namespace api.services
{
    public class CityService : ICityService
    {
        
        private readonly ICityRepository _cityRepository;
        private readonly AppSettings _appSettings;


        public CityService(ICityRepository cityRepository, IOptions<AppSettings> appSettings)
        {

            _cityRepository = cityRepository;
            _appSettings = appSettings.Value;
        }


        

        List<City> ICityService.GetCitiesByState(int stateId)
        {
            return _cityRepository.FindByStateId(stateId);
        }
    }
}
