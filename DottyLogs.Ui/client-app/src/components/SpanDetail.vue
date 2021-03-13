<template>
  <li class="mx-1 flex flex-col justify-between text-sm" v-if="span">
    <div class="pl-1 pr-1 py-2 flex items-center justify-between text-sm">
      <div class="w-0 flex-1 flex items-center">
        <!-- Heroicon name: solid/paper-clip -->
        <svg
          class="flex-shrink-0 h-5 w-5 text-gray-400"
          xmlns="http://www.w3.org/2000/svg"
          viewBox="0 0 20 20"
          fill="currentColor"
          aria-hidden="true"
        >
          <path
            fill-rule="evenodd"
            d="M8 4a3 3 0 00-3 3v4a5 5 0 0010 0V7a1 1 0 112 0v4a7 7 0 11-14 0V7a5 5 0 0110 0v4a3 3 0 11-6 0V7a1 1 0 012 0v4a1 1 0 102 0V7a3 3 0 00-3-3z"
            clip-rule="evenodd"
          />
        </svg>
        <span class="ml-2 flex-1 w-0 truncate" v-if="span && span.requestUrl">
          {{ span.requestUrl }}
        </span>
      </div>
    </div>
    <div v-if="span.logs" class="console ml-8 mr-2 my-2 px-2 py-1 rounded">
      <p v-for="log in span.logs" v-bind:key="log.message">
        {{ log.message }}
      </p>
      <span v-if="span.inProgress" class="blinker"></span>
    </div>
    <ul
      class="border border-gray-200 rounded-md divide-y divide-gray-200"
      v-if="span.childSpans"
    >
      <SpanDetail
        v-for="childSpan in span.childSpans"
        :key="childSpan.spanIdentifier"
        :span="childSpan"
      />
    </ul>
  </li>
</template>

<script lang="ts">
import { PropType, defineComponent } from "vue";
import Span from "../models/span";

export default defineComponent({
  name: "SpanDetail",
  props: {
    span: {
      type: Object as PropType<Span>,
      required: true,
    },
  },
});
</script>

<style>
</style>