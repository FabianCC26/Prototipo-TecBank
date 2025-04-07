<template>
    <div class="container mt-5">
        <h2>Agregar Cliente</h2>
        <form @submit.prevent="agregarCliente">
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <input v-model="cliente.nombre" class="form-control" required>
            </div>
            <div class="mb-3">
                <label class="form-label">Correo</label>
                <input v-model="cliente.correo" class="form-control" required>
            </div>
            <div class="mb-3">
                <label class="form-label">Telefono</label>
                <input v-model="cliente.telefono" class="form-control" required>
            </div>
            <button type="submit" class="btn btn-success">Registrar</button>
        </form>
    </div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'VentanaAgregarCliente',
  data() {
    return {
      cliente: {
        nombre: '',
        correo: '',
        telefono: ''
      }
    }
  },
  methods: {
    async agregarCliente() {
          try {
          // Enviar la solicitud POST a la API para agregar un nuevo cliente
        await axios.post('/api/clientes', this.cliente)
        alert('Cliente agregado exitosamente')
        this.$router.push('/')
      } catch (error) {
        console.error('Error al agregar cliente:', error)
      }
    }
  }
}
</script>
