using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class UsuarioComprasDto : BaseDto
    {
        public int UsuarioId { get; set; }

        public decimal TotalCompras { get; set; }
    }
}