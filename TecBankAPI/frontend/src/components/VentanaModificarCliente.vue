<template>
    <div class="container mt-5">
        <h2>Modificar Cliente</h2>
        <form @submit.prevent="modificarCliente">
            <div class="mb-3">
                <label>ID del Cliente</label>
                <input v-model="cliente.id" class="form-control" required>
            </div>
            <div class="mb-3">
                <label>Nombre</label>
                <input v-model="cliente.nombre" class="form-control">
            </div>
            <div class="mb-3">
                <label>Correo</label>
                <input v-model="cliente.correo" class="form-control">
            </div>
            <div class="mb-3">
                <label>Telefono</label>
                <input v-model="cliente.telefono" class="form-control">
            </div>
            <button class="btn btn-warning">Modificar</button>
        </form>
    </div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'VentanaModificarCliente',
  data() {
    return {
      cliente: {
        id: '',
        nombre: '',
        correo: '',
        telefono: ''
      }
    }
  },
  methods: {
    async modificarCliente() {
          try {
          // Enviar la solicitud PUT a la API para modificar el cliente
        await axios.put(`/api/clientes/${this.cliente.id}`, this.cliente)
        alert('Cliente modificado correctamente')
        this.$router.push('/')
      } catch (error) {
        console.error('Error al modificar cliente:', error)
      }
    }
  }
}
</script>
