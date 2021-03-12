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
        <span class="text-gray-500 font-normal"
              >({{ span.logs.length }} log messages,
              {{ span.childrenCount }} spans)</span
            >
        <p class="text-gray-500">{{ span.applicationName }}</p>
      </div>
        <div class="flex-shrink-0 pr-2">
          <div
          v-show="span.inProgress"
          class="console mx-7 my-2 px-2 py-1 rounded"
        >
            <p
              class="console-item"
            >
              
            </p>
          <span class="blinker mt-1"></span>
        </div>
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