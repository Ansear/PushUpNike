using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace APP.Repository;
public class CarritoRepository : GenericRepository<Carrito>, ICarrito
{
    private readonly NikeContext _context;

    public CarritoRepository(NikeContext context) : base(context)
    {
        _context = context;
    }
}