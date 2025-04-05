const { defineConfig } = require('@vue/cli-service');
module.exports = defineConfig({
    transpileDependencies: true,
    devServer: {
        proxy: {
            '/api': {
                target: 'https://localhost:7022', // Aseg�rate de que este puerto es el correcto
                changeOrigin: true,
                secure: false,
            }
        }
    }
});

