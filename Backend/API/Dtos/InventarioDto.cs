using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class InventarioDto : BaseDto
    {
        public int ProductoId { get; set; }

        public int CantidadAnterior { get; set; }

        public int CantidadNueva { get; set; }

        public DateTime? FechaMovimiento { get; set; }
    }
}