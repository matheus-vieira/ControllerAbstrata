
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Teste.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DataNascimento { get; set; }

        public virtual ICollection<Chamado> Chamados { get; set; }
    }
}