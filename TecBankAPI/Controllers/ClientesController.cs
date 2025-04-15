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
        //constructor
        public ClientesController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        //funcion para obtener todos los clientes
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            var clientes = _clienteService.GetClientes();
            return Ok(clientes);
        }
        //funcion para obtener un cliente por id
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
        //funcion para crear un cliente
        [HttpPost]
        public ActionResult<Cliente> Post([FromBody] Cliente nuevoCliente)
        {
            var clientes = _clienteService.GetClientes();
            nuevoCliente.Id = clientes.Max(c => c.Id) + 1;
            clientes.Add(nuevoCliente);
            _clienteService.SaveClientes(clientes);
            return CreatedAtAction(nameof(Get), new { id = nuevoCliente.Id }, nuevoCliente);
        }
        //funcion para actualizar un cliente
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Cliente clienteActualizado)
        {
            var clientes = _clienteService.GetClientes();
            var cliente = clientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            // Actualiza los campos del cliente
            cliente.Nombre = clienteActualizado.Nombre;
            cliente.Correo = clienteActualizado.Correo;
            cliente.Telefono = clienteActualizado.Telefono;

            _clienteService.SaveClientes(clientes);

            // Devuelve el cliente actualizado con un 200 OK
            return Ok(cliente);
        }

        //funcion para eliminar un cliente
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
