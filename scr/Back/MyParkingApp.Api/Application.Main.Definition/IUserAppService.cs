
using Core.DataTransferObject;
using Core.Entities;

namespace Application.Main.Definition
{
    public interface  IUserAppService
    {
        BaseApiResponse RegisterUser(User data);

    }
}
