using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace APP.Repository;
public class InventarioRepository : GenericRepository<Inventario>, IInventario
{
    private readonly NikeContext _context;

    public InventarioRepository(NikeContext context) : base(context)
    {
        _context = context;
    }
}