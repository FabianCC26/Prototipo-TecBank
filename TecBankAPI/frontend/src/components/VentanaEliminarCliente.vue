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
    import api from '../axios'

    export default {
        name: 'VentanaEliminarCliente',
        data() {
            return {
                idCliente: ''
            }
        },
        methods: {
            async eliminarCliente() {
                try {
                    // Enviar solicitud DELETE al backend para eliminar el cliente
                    await api.delete(`/api/clientes/${this.idCliente}`)
                    alert('Cliente eliminado exitosamente')
                    // Redireccionar a la página principal después de eliminar el cliente
                    this.$router.push('/')
                } catch (error) {
                    console.error('Error al eliminar cliente:', error)
                    alert('No se pudo eliminar el cliente. Revisa que el ID exista.')
                }
            }
        }
    }
</script>
