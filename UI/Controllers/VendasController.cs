using MentoriaQuintaFeira2021.Domain.Contracts.Repositories;
using MentoriaQuintaFeira2021.Domain.Contracts.Services;
using MentoriaQuintaFeira2021.Domain.Entities;
using MentoriaQuintaFeira2021.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MentoriaQuintaFeira2021.Controllers
{
    public class VendasController : Controller
    {
        private IRepositorioVenda RepositorioVenda { get; set; }
        private IRepositorioCliente RepositorioCliente { get; set; }
        private IRepositorioProduto RepositorioProduto { get; set; }
        private IServicoVenda ServicoVenda { get; set; }
        private IServicoProduto ServicoProduto { get; set; }

        public VendasController(IRepositorioVenda repositorioVenda,
            IRepositorioCliente repositorioCliente,
            IRepositorioProduto repositorioProduto,
            IServicoVenda servicoVenda,
            IServicoProduto servicoProduto)
        {
            RepositorioVenda = repositorioVenda;
            RepositorioCliente = repositorioCliente;
            RepositorioProduto = repositorioProduto;
            ServicoVenda = servicoVenda;
            ServicoProduto = servicoProduto;
        }

        // GET: Vendas
        public IActionResult Index()
        {
            return View(RepositorioVenda.Obter());
        }

        // GET: Vendas/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Venda venda = RepositorioVenda.Obter((int)id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Vendas/Create
        public IActionResult Create()
        {
            MontarCombos();
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMVenda venda)
        {
            if (ModelState.IsValid)
            {                
                if (!ServicoVenda.EfetuarVenda(venda.ProdutoID, venda.ClienteID, venda.Quantidade, out string erro))
                {
                    ModelState.AddModelError("Quantidade", erro);
                }
                else
                {
                    ServicoProduto.MonitoramentoDoEstoque(venda.ProdutoID);
                    return RedirectToAction(nameof(Index));
                }
            }
            MontarCombos();
            return View(venda);
        }

        private void MontarCombos()
        {
            ViewData["ClienteID"] = new SelectList(RepositorioCliente.Obter(), "ID", "Nome");
            ViewData["ProdutoID"] = new SelectList(RepositorioProduto.ListaProdutosDisponiveis(), "ID", "Descricao");
        }

        // GET: Vendas/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Venda venda = RepositorioVenda.Obter((int)id);
            if (venda == null)
            {
                return NotFound();
            }
            MontarCombos();
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Venda venda)
        {
            if (id != venda.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ServicoVenda.Alterar(venda);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.ID))
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
            MontarCombos();
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Venda venda = RepositorioVenda.Obter((int)id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Venda venda = RepositorioVenda.Obter((int)id);
            if (venda == null)
            {
                return NotFound();
            }
            ServicoVenda.CancelarVenda(id);
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
            return RepositorioVenda.Obter(id) != null;
        }
    }
}
