using APP.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace APP.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ICarrito _carritos;
        private ICategoria _categorias;
        private IDetallescarrito _detallescarritos;
        private IDetallespedido _detallespedidos;
        private IDetallestransaccion _detallestransaccions;
        private IInventario _inventarios;
        private IPedido _pedidos;
        private IProducto _productos;
        private IRole _roles;
        private ITransaccion _transaccions;
        private IUsuario _usuarios;
        private IUsuariosCompra _usuariosCompras;
        private readonly NikeContext _context;

        public UnitOfWork(NikeContext context)
        {
            _context = context;
        }


        public ICarrito Carritos
        {
            get
            {
                if (_carritos == null)
                {
                    _carritos = new CarritoRepository(_context);
                }
                return _carritos;
            }
        }
        public ICategoria Categorias
        {
            get
            {
                if (_categorias == null)
                {
                    _categorias = new CategoriaRepository(_context);
                }
                return _categorias;
            }
        }
        public IDetallescarrito DetallesCarritos
        {
            get
            {
                if (_detallescarritos == null)
                {
                    _detallescarritos = new DetallescarritoRepository(_context);
                }
                return _detallescarritos;
            }
        }
        
        public IDetallespedido DetallesPedidos
        {
            get
            {
                if (_detallespedidos == null)
                {
                    _detallespedidos = new DetallespedidoRepository(_context);
                }
                return _detallespedidos;
            }
        }
        
        public IDetallestransaccion DetallesTransaccions
        {
            get
            {
                if (_detallestransaccions == null)
                {
                    _detallestransaccions = new DetallestransaccionRepository(_context);
                }
                return _detallestransaccions;
            }
        }
        
        public IInventario Inventarios
        {
            get
            {
                if (_inventarios == null)
                {
                    _inventarios = new InventarioRepository(_context);
                }
                return _inventarios;
            }
        }
        
        public IPedido Pedidos
        {
            get
            {
                if (_pedidos == null)
                {
                    _pedidos = new PedidoRepository(_context);
                }
                return _pedidos;
            }
        }
        
        public IProducto Productos
        {
            get
            {
                if (_productos == null)
                {
                    _productos = new ProductoRepository(_context);
                }
                return _productos;
            }
        }
        
        public IRole Roles
        {
            get
            {
                if (_roles == null)
                {
                    _roles = new RoleRepository(_context);
                }
                return _roles;
            }
        }
        
        public ITransaccion Transacciones
        {
            get
            {
                if (_transaccions == null)
                {
                    _transaccions = new TransaccionRepository(_context);
                }
                return _transaccions;
            }
        }
        public IUsuario Usuarios
        {
            get
            {
                if (_usuarios == null)
                {
                    _usuarios = new UsuarioRepository(_context);
                }
                return _usuarios;
            }
        }
        
        public IUsuariosCompra UsuariosCompras
        {
            get
            {
                if (_usuariosCompras == null)
                {
                    _usuariosCompras = new UsuarioscompraRepository(_context);
                }
                return _usuariosCompras;
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}