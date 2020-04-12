using System;
using System.Collections.Generic;
using api.context;
using api.models;
using api.repositories.Interfaces;
using api.services.Interfaces;
using api.viewmodels;
using AutoMapper;

using helpers;
using Microsoft.Extensions.Options;

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

        public List<Client> GetAll()
        {
            return _clientRepository.GetAll();
        }

        public List<Client> GetClientByNameOrRGOrCPF(string searchValue)
        {
            return _clientRepository.GetClientByNameOrRGOrCPF(searchValue);
        }

        public Client Save(VMClient entity)
        {
            var existingUser = _userRepository.FindByEmail(entity.Email);
            if (existingUser != null)
            {
                throw new CustomHttpException(422, " Esse “E-mail” já existe na base de dados.");
            }
            var existingUserWithCpf = _userRepository.FindByCPF(entity.Email);
            if (existingUser != null)
            {
                throw new CustomHttpException(422, " Esse “CPF” já existe na base de dados.");
            }
            var existingUserWithRG = _userRepository.FindByRg(entity.Email);
            if (existingUserWithRG != null)
            {
                throw new CustomHttpException(422, " Esse “RG” já existe na base de dados.");
            }
            var user = _mapper.Map<User>(entity);
            user.UserTypeId = 5;
            user.Password = _passwordManager.HashPassword(user.Password);
            var transaction = _context.Database.BeginTransaction();
            try
            {

                var createdUser = _userRepository.Save(user);
                var client = _mapper.Map<Client>(entity);
                client.idUser = createdUser;
                var createdInstructor = _clientRepository.Save(client);
                transaction.Commit();
                return _clientRepository.FindById(createdInstructor);
            }
            catch (Exception ex)
            {
                //TODO: Log ex
                transaction.Rollback();
                throw new CustomHttpException(500, "Internal server error");
            }
        }
        public bool Remove(Client entity)
        {
            return _clientRepository.Remove(entity);
        }

        public bool Update(VMClient entity)
        {
            var existingUser = _userRepository.FindByEmail(entity.Email);
            if (existingUser != null && existingUser.Id != entity.idUser)
            {
                throw new CustomHttpException(422, " Esse “E-mail” já existe na base de dados.");
            }
            var existingUserWithCpf = _userRepository.FindByCPF(entity.Email);
            if (existingUserWithCpf != null && existingUserWithCpf.Id != entity.idUser)
            {
                throw new CustomHttpException(422, " Esse “CPF” já existe na base de dados.");
            }
            var existingUserWithRG = _userRepository.FindByRg(entity.Email);
            if (existingUserWithRG != null && existingUserWithRG.Id != entity.idUser)
            {
                throw new CustomHttpException(422, " Esse “RG” já existe na base de dados.");
            }
            var user = _mapper.Map<User>(entity);
            user.UserTypeId = 5;
            user.Password = _passwordManager.HashPassword(user.Password);
            var transaction = _context.Database.BeginTransaction();
            try
            {

                var createdUser = _userRepository.Update(user);
                var client = _mapper.Map<Client>(entity);

                var createdInstructor = _clientRepository.Update(client);
                transaction.Commit();
                return createdInstructor;
            }
            catch (Exception ex)
            {
                //TODO: Log ex
                transaction.Rollback();
                throw new CustomHttpException(500, "Internal server error");
            }
        }

        
    }
}
