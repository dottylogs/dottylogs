import { RouteRecordRaw, createRouter, createWebHistory } from 'vue-router';
import Home from '../views/Home.vue'
const routes: Array<RouteRecordRaw> = [
    {
        path: '/',
        name: 'home',
        component: Home
    },
    {
        path: '/history',
        name: 'history',
        component: () => import(/* webpackChunkName: "history" */ '../views/History.vue')
    },
    {
        path: '/trace/:traceIdentifier',
        name: 'details',
        component: () => import(/* webpackChunkName: "details" */ '../views/Details.vue')
    }
]
const router = createRouter({
    history: createWebHistory(),
    routes
})
export default router