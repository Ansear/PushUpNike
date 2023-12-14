using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Carrito, CarritoDto>().ReverseMap();
        CreateMap<Categoria, CategoriaDto>().ReverseMap();
        CreateMap<Detallescarrito, DetallescarritoDto>().ReverseMap();
        CreateMap<Detallespedido, DetallespedidoDto>().ReverseMap();
        CreateMap<Detallestransaccion, DetallestransaccionDto>().ReverseMap();
        CreateMap<Inventario, InventarioDto>().ReverseMap();
        CreateMap<Pedido, PedidoDto>().ReverseMap();
        CreateMap<Producto, ProductoDto>().ReverseMap();
        CreateMap<Role, RoleDto>().ReverseMap();
        CreateMap<Transaccione, TransaccionDto>().ReverseMap();
        CreateMap<Usuario, UsuarioDto>().ReverseMap();
        CreateMap<Usuarioscompra, UsuarioComprasDto>().ReverseMap();
    }
}