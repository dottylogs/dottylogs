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
        <router-link :to="{ name: 'details', params: { traceIdentifier: trace.traceIdentifier }}" class="truncate hover:text-gray-600">
        
          <span>
            {{ trace.requestUrl }}
            <span class="text-gray-500 font-normal"
              >({{ trace.spanData.logChildrenCount }} log messages,
               {{ trace.spanData.childrenCount }} spans)</span
            >
          </span>

        </router-link>
      </div>
    </td>
  </tr>
</template>

<script lang="ts">
import { ref, defineComponent } from "vue";
import Trace from "../models/trace";

export default defineComponent({
  name: "HistoryTraceRow",
  props: {
    trace: Trace,
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