using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PedidoDto : BaseDto
    {
        public int UsuarioId { get; set; }

        public DateOnly FechaPedido { get; set; }

        public string EstadoPedido { get; set; }
    }
}