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
using Teste.Models.ViewModels;

namespace Teste.Controllers
{
    public class ChamadosController : ChamadoControllerBase<Chamado>
    {

        protected override IEnumerable<Chamado> GetAll()
        {
            return dbSet
                .Include(c => c.Usuario)
                .ToList();
        }

        protected override void PopulateViewBag()
        {
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Nome");
        }


        // GET: Chamados
        //public  ActionResult Index()
        //{
        //    var chamados = db
        //        .Chamados
        //        .Include(c => c.Usuario)
        //        .ToList()
        //        .Select(c => new ChamadoVM(c));
        //    return View(chamados
        //        .ToList());
        //}

        // POST: Chamados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Create([Bind(Include = "ChamadoId,Nome,UsuarioId")] Chamado chamado)
        {
            chamado.Status = "Em Aberto";
            chamado.DataCriado =
                chamado.DataUltimaAtualizacao = DateTime.Now;
            return base.Create(chamado);
        }

        // POST: Chamados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override ActionResult Edit([Bind(Include = "ChamadoId,Nome,UsuarioId,Status")] Chamado chamado)
        {
            chamado.DataUltimaAtualizacao = DateTime.Now;
            return base.Edit(chamado);
        }
    }
}
