using MentoriaQuintaFeira2021.Application.Api.RequestResponse;
using MentoriaQuintaFeira2021.Domain.Contracts.Repositories;
using MentoriaQuintaFeira2021.Domain.Contracts.Services;
using MentoriaQuintaFeira2021.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MentoriaQuintaFeira2021.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IServicoCliente ServicoCliente { get; set; }
        private IRepositorioCliente RepositorioCliente { get; set; }
        
        public ClienteController(IServicoCliente servicoCliente, IRepositorioCliente repositorioCliente)
        {
            ServicoCliente = servicoCliente;
            RepositorioCliente = repositorioCliente;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public List<ClienteResponse> Get()
        {
            return RepositorioCliente.Obter().Select(x => new ClienteResponse { ID = x.ID, Nome = x.Nome }).ToList();
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public ClienteResponse Get(int id)
        {
            return new ClienteResponse(RepositorioCliente.Obter(id));
        }

        // POST api/<ClienteController>
        [HttpPost]
        public void Post(ClienteRequest cliente)
        {
            if (ModelState.IsValid)
            {
                ServicoCliente.Incluir(cliente);
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,ClienteRequest cliente)
        {
            return BadRequest();        
            ServicoCliente.Alterar(cliente);
            return Ok();
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var cliente = RepositorioCliente.Obter(id);
            ServicoCliente.Excluir(cliente);
        }
    }
}
