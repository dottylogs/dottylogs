<template>
  <tr>
    <td
      class="px-6 py-3 max-w-0 w-full whitespace-nowrap text-sm font-medium text-gray-900"
    >
      <div class="flex items-center space-x-3 lg:pl-2">
        <div
          class="flex-shrink-0 w-2.5 h-2.5 rounded-full bg-pink-600"
          aria-hidden="true"
        ></div>
        <a href="#" class="truncate hover:text-gray-600">
          <span>
            {{ span.requestUrl }}
            <span class="text-gray-500 font-normal"
              >({{ span.logs.length }} log messages, {{ span.childrenCount }} spans)</span
            >
          </span>
        </a>
      </div>
      <div
        v-show="span.logs.length > 0"
        class="console mx-7 my-2 px-2 py-1 rounded"
      >
        <p v-for="log in threeLogEntries" v-bind:key="log.message">
          {{ log.message }}
        </p>
        <span v-if="span.inProgress" class="blinker"></span>
      </div>
    </td>
  </tr>
</template>

<script lang="ts">
import { PropType, defineComponent } from "vue";
import Span from "../models/span";

export default defineComponent({
  name: "SpanRow",
  props: {
    span: {
      type: Object as PropType<Span>,
      required: true
    }
  },
  computed: {
    threeLogEntries(): String[] {
      return this.span.logs.slice(-3);
    }
  }
});
</script>

<style>
</style>