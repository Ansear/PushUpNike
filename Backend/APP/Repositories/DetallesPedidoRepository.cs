using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace APP.Repository;
public class DetallespedidoRepository : GenericRepository<Detallespedido>, IDetallespedido
{
    private readonly NikeContext _context;

    public DetallespedidoRepository(NikeContext context) : base(context)
    {
        _context = context;
    }
}