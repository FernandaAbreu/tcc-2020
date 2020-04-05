using System;
using System.Collections.Generic;
using AutoMapper;
using data.Contexts;
using data.repositories.Interfaces;
using domain.models;
using helpers;
using Microsoft.Extensions.Options;
using services.Interfaces;
using settings;

namespace services
{
    public class ClientService : IClientService
    {

       

        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;
        private readonly IUserRepository _userRepository;
        private readonly AppSettings _appSettings;
        private readonly IPasswordManager _passwordManager;
        private readonly AppDbContext _context;


        public ClientService(AppDbContext context,
            IClientRepository clientRepository,
            IUserRepository userRepository ,
            IOptions<AppSettings> appSettings,
            IPasswordManager passwordManager,
             IMapper mapper)
        {
            _context = context;
            _passwordManager = passwordManager;
            _mapper = mapper;
            _clientRepository = clientRepository;
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }

        public IEnumerable<Client> GetAll()
        {
            return 
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
