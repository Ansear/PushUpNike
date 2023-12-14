using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace APP.Repository;
public class UsuarioRepository : GenericRepository<Usuario>, IUsuario
{
    private readonly NikeContext _context;

    public UsuarioRepository(NikeContext context) : base(context)
    {
        _context = context;
    }
}