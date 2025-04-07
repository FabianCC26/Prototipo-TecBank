import { createRouter, createWebHistory } from 'vue-router'
import VentanaPrincipal from '../components/VentanaPrincipal.vue'
import VentanaAgregarCliente from '../components/VentanaAgregarCliente.vue'
import VentanaModificarCliente from '../components/VentanaModificarCliente.vue'
import VentanaEliminarCliente from '../components/VentanaEliminarCliente.vue'

const routes = [                // Definición de rutas de cada vista
    { path: '/', component: VentanaPrincipal },
    { path: '/agregar', component: VentanaAgregarCliente },
    { path: '/modificar', component: VentanaModificarCliente },
    { path: '/eliminar', component: VentanaEliminarCliente },
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router
