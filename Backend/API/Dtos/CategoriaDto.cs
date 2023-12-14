using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class CategoriaDto : BaseDto
    {
        public int CategoriaId { get; set; }
        public string NombreCategoria { get; set; }
    }
}