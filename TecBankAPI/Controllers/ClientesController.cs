using Microsoft.AspNetCore.Mvc;
using TecBankAPI.Models;
using TecBankAPI.Services;
using System.Collections.Generic;
using System.Linq;

namespace TecBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClientesController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            var clientes = _clienteService.GetClientes();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(int id)
        {
            var clientes = _clienteService.GetClientes();
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        public ActionResult<Cliente> Post([FromBody] Cliente nuevoCliente)
        {
            var clientes = _clienteService.GetClientes();
            nuevoCliente.Id = clientes.Max(c => c.Id) + 1;
            clientes.Add(nuevoCliente);
            _clienteService.SaveClientes(clientes);
            return CreatedAtAction(nameof(Get), new { id = nuevoCliente.Id }, nuevoCliente);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Cliente clienteActualizado)
        {
            var clientes = _clienteService.GetClientes();
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            cliente.Nombre = clienteActualizado.Nombre;
            cliente.Correo = clienteActualizado.Correo;
            cliente.Telefono = clienteActualizado.Telefono;
            _clienteService.SaveClientes(clientes);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var clientes = _clienteService.GetClientes();
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            clientes.Remove(cliente);
            _clienteService.SaveClientes(clientes);
            return NoContent();
        }
    }
}
