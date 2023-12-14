using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        ICarrito Carritos { get; }
        ICategoria Categorias { get; }
        IDetallescarrito DetallesCarritos { get; }
        IDetallespedido DetallesPedidos { get; }
        IDetallestransaccion DetallesTransaccions { get; }
        IInventario Inventarios { get; }
        IPedido Pedidos { get; }
        IProducto Productos { get; }
        IRole Roles { get; }
        ITransaccion Transacciones { get; }
        IUsuario Usuarios { get; }
        IUsuariosCompra UsuariosCompras { get; }
        Task<int> SaveAsync();
    }
}