using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teste.Models.ViewModels
{
    public class ChamadoVM : Chamado
    {
        public ChamadoVM()
        {

        }

        public ChamadoVM(Chamado chamado)
        {
            this.ChamadoId = chamado.ChamadoId;
            this.Nome = chamado.Nome;
            this.Status = chamado.Status;
            this.Usuario = chamado.Usuario;
            this.UsuarioId = chamado.UsuarioId;
            this.DataCriado = chamado.DataCriado;
            this.DataUltimaAtualizacao = chamado.DataUltimaAtualizacao;
        }
        public string StatusClass
        {
            get
            {
                switch (Status)
                {
                    case ("Em Aberto"):
                        return "danger";
                    case ("Executando"):
                        return "warning";
                    default:
                        return "success";
                }
            }
        }
    }
}