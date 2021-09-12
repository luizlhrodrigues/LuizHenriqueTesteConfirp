using LuizHenriqueTesteConfirp.Data;
using LuizHenriqueTesteConfirp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuizHenriqueTesteConfirp.Controllers
{
    public class PessoasController : Controller
    {    
        // GET: PessoasController
        public ActionResult Index()
        {

            List<Pessoa> lstPessoas = new PessoaDAL().GetPessoas();

            return View(lstPessoas);
        }

        // GET: PessoasController/Details/5
        public ActionResult Details(int id)
        {
            Pessoa pessoa = new PessoaDAL().GetPessoa(id);
            return View(pessoa);
        }

        // GET: PessoasController/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: PessoasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pessoa pessoa)
        {
            try
            {
                new PessoaDAL().AddPessoa(pessoa);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PessoasController/Edit/5
        public ActionResult Edit(int id)
        {
            Pessoa pessoa = new PessoaDAL().GetPessoa(id);
            return View(pessoa);
        }

        // POST: PessoasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pessoa pessoa)
        {
            try
            {
                new PessoaDAL().UpdatePessoa(pessoa);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: PessoasController/Delete/5
        public ActionResult Delete(int id)
        {
            Pessoa pessoa = new PessoaDAL().GetPessoa(id);
            return View(pessoa);
        }

        // POST: PessoasController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                new PessoaDAL().DeletePessoa(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
