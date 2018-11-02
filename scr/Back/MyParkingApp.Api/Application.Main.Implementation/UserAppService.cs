using System;
using System.Linq;
using Application.Main.Definition;
using Core.DataTransferObject;
using Core.Entities;
using Core.GlobalRepository;

namespace Application.Main.Implementation
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleUserRepository _roleUserRepository;

        public UserAppService(IUserRepository userRepository, IRoleUserRepository roleUserRepository)
        {
            _userRepository = userRepository;
            _roleUserRepository = roleUserRepository;
        }

        public BaseApiResponse RegisterUser(User data)
        {
            var response = new BaseApiResponse();
            try
            {
                if (_userRepository.GetFiltered(s => s.Email == data.Email).Any())
                {
                    response.ActionCompleted = false;
                    response.HttpCodeType = HttpCodeType.BadRequest;
                    response.Message = "Ya existe un usuario con el correo ";
                    return response;
                }
                

                if (_userRepository.GetFiltered(s => s.CellPhone == data.CellPhone).Any())
                {
                    response.ActionCompleted = false;
                    response.HttpCodeType = HttpCodeType.BadRequest;
                    response.Message = "Ya existe un usuario con el correo ";
                    return response;
                }

                _userRepository.AddItem(data);
                _userRepository.UnitOfWork.CommitInt();

                response.HttpCodeType = HttpCodeType.Success;
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                response.Message = e.InnerException != null ? e.InnerException.Message : e.Message;
            }

            return response;

        }

        public BaseApiResponse GetUserById(int id)
        {
            var response = new BaseApiResponse();
            try
            {
                var user = _userRepository.GetFiltered(s => s.Id == id).FirstOrDefault();

                if (user != null)
                {

                    response.ActionCompleted = true;
                    response.Data = user;
                    user.Platform = PlatformType.Android;

                }
                return response;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                response.Message = e.InnerException != null ? e.InnerException.Message : e.Message;
            }

            return response;
        }
    }
}
