using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAgriculture.Models.UserInfo
{
    public class UserInfo
    {
        public int UsuCombId { get; set; }

        public String UserName { get; set; }

        public String Pass { get; set; }

        public String NombreUsuario { get; set; }

        public int CargoUsuario { get; set; }

        public int NivelAcceso { get; set; }
    }
}
