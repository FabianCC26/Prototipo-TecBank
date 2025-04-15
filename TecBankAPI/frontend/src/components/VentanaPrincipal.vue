<template>
    <div class="container mt-5">
        <h2 class="mb-4">Gestión de Clientes</h2>

        <div class="d-grid gap-3">
            <router-link to="/agregar" class="btn btn-success">Agregar Cliente</router-link>
            <router-link to="/modificar" class="btn btn-warning">Modificar Cliente</router-link>
            <router-link to="/eliminar" class="btn btn-danger">Eliminar Cliente</router-link>
            <button class="btn btn-primary" @click="cargarClientes">Mostrar Todos</button>
            <button class="btn btn-secondary" @click="generarPDF" :disabled="clientes.length === 0">Generar PDF</button>
        </div>

        <ul class="list-group mt-4" v-if="clientes.length">
            <li class="list-group-item" v-for="cliente in clientes" :key="cliente.id">
                {{ cliente.nombre }} - {{ cliente.correo }} - {{ cliente.telefono }}
            </li>
        </ul>

        <p v-else class="mt-4 text-muted">No hay clientes por mostrar.</p>
    </div>
</template>

<script>
    import jsPDF from 'jspdf'
    import autoTable from 'jspdf-autotable'
    import api from '../axios'

    export default {
        name: 'VentanaPrincipal',
        data() {
            return {
                clientes: []
            }
        },
        methods: {
            async cargarClientes() {

                try {
                    // Enviar solicitud GET al backend para obtener la lista de clientes
                    const res = await api.get('/api/clientes')
                    this.clientes = res.data
                } catch (err) {
                    console.error('Error al cargar los clientes:', err)
                    alert('Error al conectar con la API')
                }
            },
            generarPDF() {
                // Verificar si hay clientes para generar el PDF
                if (this.clientes.length === 0) {
                    alert('No hay clientes para generar PDF.')
                    return
                }
                // Crear un nuevo documento PDF
                const doc = new jsPDF()
                doc.text('Listado de Clientes', 14, 15)

                const filas = this.clientes.map(cliente => [
                    cliente.id,
                    cliente.nombre,
                    cliente.correo,
                    cliente.telefono
                ])

                autoTable(doc, {
                    head: [['ID', 'Nombre', 'Correo', 'Teléfono']],
                    body: filas,
                    startY: 20,
                })

                doc.save('clientes.pdf')
            }
        }
    }
</script>

<style scoped>
    h2 {
        color: #2c3e50;
    }
</style>
