using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProductoDto : BaseDto
    {
        public string NombreProducto { get; set; } = null!;

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int Existencias { get; set; }

        public int StockMinimo { get; set; }

        public int StockMaximo { get; set; }

        public string UrlProducto { get; set; }
    }
}