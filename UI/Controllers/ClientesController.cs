using MentoriaQuintaFeira2021.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MentoriaQuintaFeira2021.Controllers
{
    public class ClientesController : Controller
    {      

        // GET: Clientes
        public IActionResult Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://localhost:44357");
                var response = client.GetAsync("/api/cliente").Result;
                var stringJson = response.Content.ReadAsStringAsync().Result;
                Cliente cliente = JsonConvert.DeserializeObject<Cliente>(stringJson);
                return View(cliente);
            }   
        }

        // GET: Clientes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Cliente cliente;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://localhost:44357");
                var response = client.GetAsync("/api/cliente/"+id).Result;
                var stringJson = response.Content.ReadAsStringAsync().Result;
                cliente = JsonConvert.DeserializeObject<Cliente>(stringJson);                
            }

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
                
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new System.Uri("https://localhost:44357");
                    var content = new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8, "application/json");

                    var response = client.PostAsync("/api/cliente/", content).Result;
                    var stringJson = response.Content.ReadAsStringAsync().Result;                    
                }

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

            Cliente cliente;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://localhost:44357");
                var response = client.GetAsync("/api/cliente/" + id).Result;
                var stringJson = response.Content.ReadAsStringAsync().Result;
                cliente = JsonConvert.DeserializeObject<Cliente>(stringJson);
            }

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
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new System.Uri("https://localhost:44357");
                    var content = new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8, "application/json");

                    var response = client.PutAsync("/api/cliente/"+id, content).Result;
                    var stringJson = response.Content.ReadAsStringAsync().Result;
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

            Cliente cliente;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://localhost:44357");
                var response = client.GetAsync("/api/cliente/" + id).Result;
                var stringJson = response.Content.ReadAsStringAsync().Result;
                cliente = JsonConvert.DeserializeObject<Cliente>(stringJson);
            }

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
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://localhost:44357");
                var response = client.DeleteAsync("/api/cliente/" + id).Result;
                var stringJson = response.Content.ReadAsStringAsync().Result;                
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://localhost:44357");
                var response = client.GetAsync("/api/cliente/" + id).Result;
                var stringJson = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Cliente>(stringJson) != null;
            }
        }
    }
}
