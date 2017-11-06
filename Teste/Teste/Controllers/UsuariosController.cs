using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Teste.Contexts;
using Teste.Models;

namespace Teste.Controllers
{
    public class UsuariosController : ChamadoControllerBase<Models.Usuario>
    {
        protected override Usuario GetById(int id)
        {
            return dbSet
                .Include(u => u.Chamados)
                .FirstOrDefault(u => u.UsuarioId == id);
        }
    }
}
