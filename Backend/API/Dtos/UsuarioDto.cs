using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class UsuarioDto : BaseDto
    {
        public string NombreUsuario { get; set; } = null!;

        public string CorreoElectronico { get; set; } = null!;

        public string Contrasena { get; set; } = null!;

        public int RolId { get; set; }
    }
}