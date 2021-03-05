<template>
  <li class="col-span-1 flex shadow-sm rounded-md">
    <div
      class="flex-shrink-0 flex items-center justify-center w-16 bg-pink-600 text-white text-sm font-medium rounded-l-md"
    >
      GA
    </div>
    <div
      class="flex-1 flex items-center justify-between border-t border-r border-b border-gray-200 bg-white rounded-r-md truncate"
    >
      <div class="flex-1 px-4 py-2 text-sm truncate">
        {{ span.requestUrl }}
        <p class="text-gray-500">{{ span.applicationName }}</p>
      </div>
      <div class="flex-shrink-0 pr-2">
        <!-- Heroicon name: solid/dots-vertical -->
        <svg
          class="w-5 h-5"
          xmlns="http://www.w3.org/2000/svg"
          viewBox="0 0 20 20"
          fill="currentColor"
          aria-hidden="true"
        >
          <path
            d="M10 6a2 2 0 110-4 2 2 0 010 4zM10 12a2 2 0 110-4 2 2 0 010 4zM10 18a2 2 0 110-4 2 2 0 010 4z"
          />
        </svg>
      </div>
    </div>
  </li>
</template>

<script lang="ts">
import { PropType, defineComponent } from "vue";
import Span from "../models/span";

export default defineComponent({
  name: "SpanBox",
  props: {
    span: {
      type: Object as PropType<Span>,
      required: true,
    },
  },
  computed: {
    threeLogEntries(): String[] {
      return this.span.logs.slice(-3);
    },
  },
});
</script>

<style>
</style>