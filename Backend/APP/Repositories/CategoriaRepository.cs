using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace APP.Repository;
public class CategoriaRepository : GenericRepository<Categoria>, ICategoria
{
    private readonly NikeContext _context;

    public CategoriaRepository(NikeContext context) : base(context)
    {
        _context = context;
    }
}