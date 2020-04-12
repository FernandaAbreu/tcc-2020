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
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;
        private readonly AppSettings _appSettings;


        public StateService(IStateRepository stateRepository, IOptions<AppSettings> appSettings)
        {

            _stateRepository = stateRepository;
            _appSettings = appSettings.Value;
        }


        List<State> IStateService.GetAll()
        {
            return _stateRepository.GetAll();
        }
    }
}
