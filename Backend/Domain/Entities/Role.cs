using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Role : BaseEntity
{ 

    public string NombreRol { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
