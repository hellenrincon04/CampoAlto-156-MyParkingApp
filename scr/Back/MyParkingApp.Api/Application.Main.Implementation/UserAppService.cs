using System;
using Application.Main.Definition;
using Core.DataTransferObject;
using Core.Entities;
using Core.GlobalRepository;

namespace Application.Main.Implementation
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;

        public UserAppService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public BaseApiResponse RegisterUser(User data)
        {
            var response = new BaseApiResponse();
            try
            {
                _userRepository.AddItem(data);
                _userRepository.UnitOfWork.CommitInt();
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
