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


namespace api.services
{
    public class InstructorService<Instructor> : IInstructorService
    {
        private readonly IMapper _mapper;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IUserRepository _userRepository;
        private readonly AppSettings _appSettings;
        private readonly IPasswordManager _passwordManager;
        private readonly AppDbContext _context;
        public InstructorService(
            AppDbContext context,
            IInstructorRepository instructorRepository,
            IUserRepository userRepository,
            IPasswordManager passwordManager,
            IOptions<AppSettings> appSettings,
             IMapper mapper)
        {
            _context = context;
            _passwordManager = passwordManager;
            _instructorRepository = instructorRepository;
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        public IEnumerable<models.Instructor> GetAll()
        {
            return _instructorRepository.GetAll();
        }

        public List<models.Instructor> GetInstructorByNameOrRGOrCPF(string searchValue)
        {
            return _instructorRepository.GetInstructorByNameOrRGOrCPF(searchValue);
        }

        public models.Instructor Save(VMInstructor entity)
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
            user.UserTypeId =3;
            user.Password = _passwordManager.HashPassword(user.Password);
            var transaction = _context.Database.BeginTransaction();
            try
            {

                var createdUser = _userRepository.Save(user);
                var instructor = _mapper.Map<models.Instructor>(entity);
                instructor.userId= createdUser;
                var createdInstructor = _instructorRepository.Save(instructor);
                transaction.Commit();
                return _instructorRepository.FindById(createdInstructor);
            }
            catch (Exception ex)
            {
                //TODO: Log ex
                transaction.Rollback();
                throw new CustomHttpException(500, "Internal server error");
            }
        }

        public bool Update(VMInstructor entity)
        {
            var existingUser = _userRepository.FindByEmail(entity.Email);
            if (existingUser != null &&  existingUser.Id!=entity.idUser)
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
            user.UserTypeId = 3;
            user.Id = entity.idUser;
            user.Password = user.Password;
            user.CreatedAt = existingUser.CreatedAt;
            var transaction = _context.Database.BeginTransaction();
            try
            {

                var createdUser = _userRepository.Update(user, user.Id);
                var instructor = _mapper.Map<models.Instructor>(entity);
               
                var createdInstructor = _instructorRepository.Update(instructor,instructor.Id);
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

       

        List<models.Instructor> IInstructorService.GetAll()
        {
            return _instructorRepository.GetAll();
        }

        public bool Remove(models.Instructor entity)
        {
            var user = _userRepository.FindById(entity.userId);
            user.DeletedAt = DateTime.Now;
            _userRepository.Update(user, entity.userId);
            entity.DeletedAt = DateTime.Now;
            return _instructorRepository.Update(entity,entity.Id);
        }

        public models.Instructor findById(int id)
        {
            return _instructorRepository.FindById(id);
        }
    }
}
