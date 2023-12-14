using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace APP.Repository;
public class RoleRepository : GenericRepository<Role>, IRole
{
    private readonly NikeContext _context;

    public RoleRepository(NikeContext context) : base(context)
    {
        _context = context;
    }
}