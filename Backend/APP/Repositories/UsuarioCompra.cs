using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace APP.Repository;
public class UsuarioscompraRepository : GenericRepository<Usuarioscompra>, IUsuariosCompra
{
    private readonly NikeContext _context;

    public UsuarioscompraRepository(NikeContext context) : base(context)
    {
        _context = context;
    }
}