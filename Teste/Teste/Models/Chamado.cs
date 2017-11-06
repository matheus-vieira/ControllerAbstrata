using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Teste.Models
{
    public class Chamado
    {
        public int ChamadoId { get; set; }
        public string Nome { get; set; }

        public string Status { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DataCriado { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DataUltimaAtualizacao { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}