<template>
<div class="h-screen flex overflow-hidden bg-white">
  <LeftMenu />
  <router-view></router-view>
</div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import LeftMenu from "./components/LeftMenu.vue";

export default defineComponent({
  name: 'App',
  components: {
    LeftMenu: LeftMenu,
  }
})
</script>

<style>
</style>