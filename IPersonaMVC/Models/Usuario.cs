using System;
using System.Collections.Generic;

namespace IPersonaMVC.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string ClaveUsuario { get; set; } = null!;
        public int IdTipoUsuario { get; set; }
        public bool? Activo { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; } = null!;
    }
}
