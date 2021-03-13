import { RouteRecordRaw, createRouter, createWebHistory } from 'vue-router';
import Home from '../views/Home.vue'
const routes: Array<RouteRecordRaw> = [
    {
        path: '/',
        name: 'Home',
        component: Home
    },
    {
        path: '/history',
        name: 'History',
        component: () => import(/* webpackChunkName: "history" */ '../views/History.vue')
    },
    {
        path: '/',
        name: 'Details',
        component: () => import(/* webpackChunkName: "details" */ '../views/Details.vue')
    },
    {
        path: '/about',
        name: 'About',
        // route level code-splitting
        // this generates a separate chunk (about.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
    }
]
const router = createRouter({
    history: createWebHistory(),
    routes
})
export default router