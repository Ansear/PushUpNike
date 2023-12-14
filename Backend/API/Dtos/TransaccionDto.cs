using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class TransaccionDto : BaseDto
    {
        public int UsuarioId { get; set; }

        public DateTime FechaTransaccion { get; set; }

        public decimal Total { get; set; }
    }
}