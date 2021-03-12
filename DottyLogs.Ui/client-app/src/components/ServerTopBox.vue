<template>
  <li class="relative col-span-1 flex shadow-sm rounded-md server-list-item">
    <div :class="boxclass">
      {{ shortChars }}
    </div>
    <div
      class="flex-1 flex items-center justify-between border-t border-r border-b border-gray-200 bg-white rounded-r-md truncate"
    >
      <div class="flex-1 px-4 py-2 text-sm truncate">
        <a href="#" class="text-gray-900 font-medium hover:text-gray-600">
          {{ server.name }}
        </a>
        <p class="text-gray-500">
          {{ server.traceIdentifier }}|{{ server.hostName }}
        </p>
      </div>
    </div>
  </li>
</template>

<script lang="ts">
import { PropType, defineComponent } from "vue";
import Server from "../models/server";

export default defineComponent({
  name: "ServerTopBox",
  props: {
    key: String,
    server: {
      type: Object as PropType<Server>,
      required: true,
    },
  },
  computed: {
    shortChars() {
      return this.server.name.replace(/[a-z]/g, "");
    },
    color() {
      let sum = 0;
      this.server.name.split("").forEach((char) => {
        sum += char.charCodeAt();
      });

      const possibles = [
        "bg-purple-600",
        "bg-pink-600",
        "bg-blue-600",
        "bg-yellow-600",
        "bg-green-600",
      ];
      return possibles[sum % 5];
    },
    boxclass() {
      return (
        this.color +
        " flex-shrink-0 flex items-center justify-center w-16 text-white text-sm font-medium rounded-l-md"
      );
    },
  },
});
</script>

<style>
</style>