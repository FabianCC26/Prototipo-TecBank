<template>
    <div>
        <h1>Clientes desde la API</h1>
        <button @click="fetchClientes">Cargar Clientes</button> <!-- Botón para cargar los clientes del json -->

        <ul v-if="clientes.length">
            <li v-for="cliente in clientes" :key="cliente.id">
                {{ cliente.nombre }} - {{ cliente.correo }} - {{ cliente.telefono }}
            </li>
        </ul>

        <p v-else>No hay datos aun.</p>
    </div>
</template>

<script>
    import axios from 'axios' // se usa axios para hacer peticiones HTTP

    export default {
        name: 'HelloWorld',
        data() {
            return {
                clientes: []
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
    h1 {
        color: #2c3e50;
    }
</style>
