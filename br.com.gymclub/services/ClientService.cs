using System;
using System.Collections.Generic;
using data.repositories.Interfaces;
using domain.models;
using Microsoft.Extensions.Options;
using services.Interfaces;
using settings;

namespace services
{
    public class ClientService : IClientService
    {

        private readonly IClientRepository _clientRepository;
        private readonly IUserRepository _userRepository;
        private readonly AppSettings _appSettings;


        public ClientService(IClientRepository clientRepository, IUserRepository userRepository , IOptions<AppSettings> appSettings)
        {

            _clientRepository = clientRepository;
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }

        public IEnumerable<Client> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Client> GetClientByNameOrRGOrCPF(string searchValue)
        {
            throw new NotImplementedException();
        }

        public int Save<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public bool Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
