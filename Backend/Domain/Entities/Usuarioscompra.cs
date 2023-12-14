using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Usuarioscompra : BaseEntity
{
    public int UsuarioId { get; set; }

    public decimal TotalCompras { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
