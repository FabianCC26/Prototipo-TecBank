<template>
    <div class="container mt-5">
        <h2>Eliminar Cliente</h2>
        <form @submit.prevent="eliminarCliente">
            <div class="mb-3">
                <label>ID del Cliente</label>
                <input v-model="idCliente" class="form-control" required>
            </div>
            <button class="btn btn-danger">Eliminar</button>
        </form>
    </div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'VentanaEliminarCliente',
  data() {
    return {
      idCliente: ''
    }
  },
        methods: {
      // Método para eliminar un cliente con Delete desde la API
    async eliminarCliente() {
      try {
        await axios.delete(`/api/clientes/${this.idCliente}`)
        alert('Cliente eliminado exitosamente')
        this.$router.push('/')
      } catch (error) {
        console.error('Error al eliminar cliente:', error)
      }
    }
  }
}
</script>
