using System;
using System.Collections.Generic;
using data.repositories.Interfaces;
using domain.models;
using Microsoft.Extensions.Options;
using services.Interfaces;
using settings;

namespace services
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
