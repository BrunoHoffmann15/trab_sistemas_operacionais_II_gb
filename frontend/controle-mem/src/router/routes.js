
const routes = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      { path: '/memoria-virtual', component: () => import('pages/MemoriaVirtual.vue') },
      { path: '/processo', component: () => import('pages/Processo.vue') },
      { path: '/', component: () => import('pages/Processo.vue') },
      { path: '/memoria-fisica', component: () => import('pages/MemoriaFisica.vue') },
    ]
  },

  // Always leave this as last one,
  // but you can also remove it
  {
    path: '/:catchAll(.*)*',
    component: () => import('pages/ErrorNotFound.vue')
  }
]

export default routes
