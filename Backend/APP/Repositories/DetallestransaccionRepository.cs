using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace APP.Repository;
public class DetallestransaccionRepository : GenericRepository<Detallestransaccion>, IDetallestransaccion
{
    private readonly NikeContext _context;

    public DetallestransaccionRepository(NikeContext context) : base(context)
    {
        _context = context;
    }
}