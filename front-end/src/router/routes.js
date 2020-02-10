// Dynamic Loading Modules

// Views
const Pedido = resolve => { require.ensure(['../views/pedido'], () => { resolve(require('../views/pedido')); }); };


export const routes = [
    {
        path: '/',
        name: 'pedido',
        components: {
            default: Pedido
        }
    }

];