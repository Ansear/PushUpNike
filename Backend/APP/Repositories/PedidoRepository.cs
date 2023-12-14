using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace APP.Repository;
public class PedidoRepository : GenericRepository<Pedido>, IPedido
{
    private readonly NikeContext _context;

    public PedidoRepository(NikeContext context) : base(context)
    {
        _context = context;
    }
}