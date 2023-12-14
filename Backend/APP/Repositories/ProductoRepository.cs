using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace APP.Repository;
public class ProductoRepository : GenericRepository<Producto>, IProducto
{
    private readonly NikeContext _context;

    public ProductoRepository(NikeContext context) : base(context)
    {
        _context = context;
    }
}