using MentoriaQuintaFeira2021.Contracts.Repositories;
using MentoriaQuintaFeira2021.Contracts.Services;
using MentoriaQuintaFeira2021.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MentoriaQuintaFeira2021.Controllers
{
    public class ClientesController : Controller
    {
        private IServicoCliente ServicoCliente { get; set; }
        private IRepositorioCliente RepositorioCliente { get; set; }

        public ClientesController(IServicoCliente servicoCliente, IRepositorioCliente repositorioCliente)
        {
            ServicoCliente = servicoCliente;
            RepositorioCliente = repositorioCliente;
        }

        // GET: Clientes
        public IActionResult Index()
        {
            return View(RepositorioCliente.Obter());
        }

        // GET: Clientes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cliente cliente = RepositorioCliente.Obter((int)id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                ServicoCliente.Incluir(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cliente cliente = RepositorioCliente.Obter((int)id);

            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Cliente cliente)
        {
            if (id != cliente.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ServicoCliente.Alterar(cliente);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.ID))
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
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cliente cliente = RepositorioCliente.Obter((int)id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var cliente = RepositorioCliente.Obter((int)id);
            if (cliente == null)
            {
                return NotFound();
            }
            ServicoCliente.Excluir(cliente);
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return RepositorioCliente.Obter(id) != null;
        }
    }
}
