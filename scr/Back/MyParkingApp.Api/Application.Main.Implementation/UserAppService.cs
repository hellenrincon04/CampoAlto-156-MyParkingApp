using System;
using Application.Main.Definition;
using Core.DataTransferObject;
using Core.Entities;

namespace Application.Main.Implementation
{
    public class UserAppService : IUserAppService
    {
        public BaseApiResponse RegisterUser(User data)
        {
            return  new BaseApiResponse{Message = "Esta Vivo jejeje :)"};
        }
    }
}
