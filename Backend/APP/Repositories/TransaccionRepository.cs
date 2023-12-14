using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace APP.Repository;
public class TransaccionRepository : GenericRepository<Transaccione>, ITransaccion
{
    private readonly NikeContext _context;

    public TransaccionRepository(NikeContext context) : base(context)
    {
        _context = context;
    }
}