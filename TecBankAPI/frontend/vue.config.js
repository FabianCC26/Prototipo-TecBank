const { defineConfig } = require('@vue/cli-service')

module.exports = defineConfig({
    transpileDependencies: true,
    devServer: {
        proxy: {
            '/api': {
                target: 'http://localhost:8090', // Puerto donde corre tu API en IIS
                changeOrigin: true,
                secure: false
            }
        }
    }
})
