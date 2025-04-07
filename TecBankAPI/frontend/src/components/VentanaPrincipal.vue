<template>
    <div class="container mt-5">
        <h2 class="mb-4 text-center">Gestion de Clientes</h2>

        <!-- Botones de acciones -->
        <div class="d-grid gap-3 col-6 mx-auto">
            <button class="btn btn-primary" @click="accion = 'crear'">Registrar Cliente</button>
            <button class="btn btn-warning" @click="accion = 'modificar'">Modificar Cliente</button>
            <button class="btn btn-danger" @click="accion = 'eliminar'">Eliminar Cliente</button>
            <button class="btn btn-success" @click="fetchClientes">Mostrar Todos</button>
        </div>

        <!-- Lista de clientes -->
        <div class="mt-4" v-if="clientes.length > 0">
            <h4>Lista de Clientes</h4>
            <ul class="list-group">
                <li v-for="cliente in clientes" :key="cliente.id" class="list-group-item">
                    {{ cliente.nombre }} - {{ cliente.correo }} - {{ cliente.telefono }}
                </li>
            </ul>
        </div>

        <p v-else class="text-center mt-3 text-muted">No hay datos aun.</p>
    </div>
</template>

<script>
    import axios from 'axios'

    export default {
        name: 'VentanaPrincipal',
        data() {
            return {
                clientes: [],
                accion: ''
            }
        },
        methods: {
            async fetchClientes() {
                try {
                    const response = await axios.get('/api/clientes')
                    this.clientes = response.data
                } catch (error) {
                    console.error('Error al obtener los clientes:', error)
                }
            }
        }
    }
</script>

<style scoped>
    h2 {
        color: #2c3e50;
    }
</style>