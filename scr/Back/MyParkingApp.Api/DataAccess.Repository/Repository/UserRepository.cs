using Core.Entities;
using Core.GlobalRepository;
using Data.Common.Definition;
using Data.Common.Implementation;

namespace DataAccess.Repository.Repository
{
    public partial class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }

    public partial class RoleUserRepository : Repository<RoleUser>, IRoleUserRepository
    {
        public RoleUserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
