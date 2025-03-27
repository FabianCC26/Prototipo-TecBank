using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TecBankAPI.Models;

namespace TecBankAPI.Services
{
    public class ClienteService
    {
        // Ruta relativa al archivo JSON dentro de la carpeta Data
        private const string FilePath = "Data/clientes.json";  // Ruta al archivo JSON

        // Leer clientes desde el archivo JSON
        public List<Cliente> GetClientes()
        {
            if (!File.Exists(FilePath))  // Si no existe el archivo, retorna una lista vacía
            {
                return new List<Cliente>();
            }

            var jsonData = File.ReadAllText(FilePath);  // Leer el contenido del archivo
            return JsonSerializer.Deserialize<List<Cliente>>(jsonData);  // Deserializar el JSON a una lista de clientes
        }

        // Guardar clientes en el archivo JSON
        public void SaveClientes(List<Cliente> clientes)
        {
            var jsonData = JsonSerializer.Serialize(clientes, new JsonSerializerOptions { WriteIndented = true }); // Serializar la lista de clientes a JSON
            File.WriteAllText(FilePath, jsonData);  // Escribir el JSON al archivo
        }
    }
}
