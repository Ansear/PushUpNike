using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace APP.Repository;
public class DetallescarritoRepository : GenericRepository<Detallescarrito>, IDetallescarrito
{
    private readonly NikeContext _context;

    public DetallescarritoRepository(NikeContext context) : base(context)
    {
        _context = context;
    }
}