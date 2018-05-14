export default [
  {
    path: '/',
    component: () => import('layouts/default'),
    children: [
      { path: '', component: () => import('pages/index') },
      { path: '/login', component: () => import('pages/Login') },
      { path: '/newsletter', component: () => import('pages/Newsletter') },
      { path: '/aboutme', component: () => import('pages/AboutMe') },
      {
        path: '/admin',
        component: () => import('pages/Admin'),
        meta: {
          requiresAdmin: true
        }
      }
    ]
  },

  {
    // Always leave this as last one
    path: '*',
    component: () => import('pages/404')
  }
];
