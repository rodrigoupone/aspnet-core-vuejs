export default {
  items: [
    {
      name: 'Dashboard',
      url: '/dashboard',
      icon: 'fa fa-home'
    },
    {
      divider: true
    },
    {
      name: 'Pessoas',
      url: '/cadastros',
      icon: 'fa fa-group',
      children: [
        {
          name: 'Listar',
          url: '/pessoas/listar',
          icon: 'fa fa-list'
        },
        {
          name: 'Novo',
          url: '/pessoas/adicionar',
          icon: 'fa fa-plus'
        }
      ]
    },
    {
      name: 'Embarcações',
      url: '/cadastros',
      icon: 'fa fa-ship',
      children: [
        {
          name: 'Listar',
          url: '/embarcacoes/listar',
          icon: 'fa fa-list'
        },
        {
          name: 'Novo',
          url: '/embarcacoes/adicionar',
          icon: 'fa fa-plus'
        }
      ]
    },
    {
      name: 'Relatórios',
      url: '/relatorios',
      icon: 'fa fa-pie-chart',
      children: [
        {
          name: 'Medições',
          url: '/views/embarcacoes/listar',
          icon: 'fa fa-angle-double-right'
        },
        {
          name: 'Pagamentos',
          url: '/views/embarcacoes/adicionar',
          icon: 'fa fa-angle-double-right'
        }
      ]
    },
    {
      name: 'Configurações',
      url: '/components',
      icon: 'fa fa-puzzle-piece',
      children: [
        {
          name: 'Dispositivos',
          url: '/configuracoes/dispositivos',
          icon: 'fa fa-mobile'
        },
        {
          name: 'Perfil',
          url: '/seguranca/perfil',
          icon: 'fa fa-lock'
        }
      ]
    }
  ]
}
