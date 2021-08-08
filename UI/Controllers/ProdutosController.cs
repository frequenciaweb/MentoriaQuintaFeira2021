using MentoriaQuintaFeira2021.Domain.Contracts.Repositories;
using MentoriaQuintaFeira2021.Domain.Contracts.Services;
using MentoriaQuintaFeira2021.Domain.Entities;
using MentoriaQuintaFeira2021.Domain.Filters;
using MentoriaQuintaFeira2021.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentoriaQuintaFeira2021.Controllers
{
    public class ProdutosController : Controller
    {
        private IServicoProduto ServicoProduto { get; set; }
        private IRepositorioProduto RepositorioProduto { get; set; }

        public ProdutosController(IServicoProduto servicoProduto, IRepositorioProduto repositorioProduto)
        {
            ServicoProduto = servicoProduto;
            RepositorioProduto = repositorioProduto;
        }

        // GET: Produtos
        public IActionResult Index()
        {
            return View(RepositorioProduto.Obter());
        }

        [HttpPost]
        public IActionResult Index(IFormCollection form)
        {
            if (string.IsNullOrEmpty(form["tipoPesquisa[]"]) || string.IsNullOrEmpty(form["valor[]"]))
            {
                ViewBag.Erro = "Selecione os tipos de pesquisa e informe os valores";
                return View(new List<Produto>());
            }

            FiltroProdutos filtro = new FiltroProdutos
            {
                Tipos = form["tipoPesquisa[]"].Select(x => int.Parse(x)).ToList(),
                Valores = form["valor[]"].ToList()
            };

            List<Produto> produtos = RepositorioProduto.ListarProdutosComFiltro(filtro);
            return View(produtos);
        }

        // GET: Produtos/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produto produto = RepositorioProduto.Obter((int)id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                ServicoProduto.Incluir(produto);
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produto produto = RepositorioProduto.Obter((int)id);

            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Produto produto)
        {
            if (id != produto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ServicoProduto.Alterar(produto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produto produto = RepositorioProduto.Obter((int)id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var produto = RepositorioProduto.Obter(id);
            if (produto == null)
            {
                return NotFound();
            }
            ServicoProduto.Excluir(produto);
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return RepositorioProduto.Obter(id) != null;
        }
    }
}
