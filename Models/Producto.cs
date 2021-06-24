using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentaOnline.Models
{
    public class Producto
    {
        [Key]
        public int id { get; set; }
        public int usuarioId { get; set; }
        public Usuario usuario { get; set; }
        public string nombre { get; set; }
        public int precio { get; set; }
        public string descripcion { get; set; }
        public string marca { get; set; }
        public bool estado { get; set; }
    }
}
