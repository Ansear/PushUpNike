using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class CarritoDto : BaseDto
    {
        public int UsuarioId { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}