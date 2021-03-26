<template>
  <li class="mx-1 flex flex-col justify-between text-sm" v-if="span">
    <div class="pl-1 pr-1 py-2 flex items-center justify-between text-sm">
      <div class="w-0 flex-1 flex items-center">
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