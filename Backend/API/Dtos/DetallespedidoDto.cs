using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class DetallespedidoDto : BaseDto
    {
        public int PedidoId { get; set; }

        public int ProductoId { get; set; }

        public int Cantidad { get; set; }
    }
}