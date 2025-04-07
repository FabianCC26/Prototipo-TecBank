<template>
    <div id="app">
        <VentanaPrincipal /> <!--  Aquí se usa el componente -->
    </div>
</template>

<script>
    import VentanaPrincipal from './components/VentanaPrincipal.vue' // Importa el componente VentanaPrincipal

export default {
  name: 'App',
  components: {
    VentanaPrincipal // Registra el componente VentanaPrincipal
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
