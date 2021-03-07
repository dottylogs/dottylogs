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
            {{ trace.requestUrl }}
            <span class="text-gray-500 font-normal"
              >({{ trace.topSpan.logs.length }} log messages,
              {{ trace.topSpan.childrenCount }} spans)</span
            >
          </span>
        </a>
      </div>
      <div
        v-show="trace.topSpan.logs.length > 0"
        class="console mx-7 my-2 px-2 py-1 rounded"
      >
          <p
            v-for="log in fiveLogEntries"
            v-bind:key="log.timestamp"
            class="console-item"
          >
            {{ log.message }}
          </p>
        <span v-if="trace.topSpan.inProgress" class="blinker"></span>
      </div>
      <div v-show="trace.topSpan.childSpans.length > 0">
        <div class="hidden mt-8 sm:block ml-8">
          <div
            class="align-middle inline-block min-w-full"
          >

          <h2>Child Spans</h2>
            <ul
              class="mt-3 grid grid-cols-1 gap-5 sm:gap-6 sm:grid-cols-2 lg:grid-cols-4"
            >
              <SpanBox
                v-for="span in trace.topSpan.childSpans"
                v-bind:key="span.spanIdentifier"
                :span="span"
              />
            </ul>
          </div>
        </div>
      </div>
    </td>
  </tr>
</template>

<script lang="ts">
import { ref, defineComponent } from "vue";
import Trace from "../models/trace";
import SpanBox from "./SpanBox.vue";

export default defineComponent({
  name: "TraceRow",
  props: {
    trace: Trace,
  },
  components: {
    SpanBox: SpanBox,
  },
  computed: {
    fiveLogEntries(): String[] {
      return this.trace.topSpan.logs.slice(-5);
    },
  },
});
</script>

<style>
.console-item {
  transition: all 0.2s ease;
}

.console-enter-from,
.console-leave-to {
  opacity: 0;
  transform: translateX(30px);
}
</style>