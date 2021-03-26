<template>
  
    <div class="flex flex-col w-0 flex-1 overflow-hidden">
      <!-- Search header -->
      <div
        class="relative z-10 flex-shrink-0 flex h-16 bg-white border-b border-gray-200 lg:hidden"
      >
        <!-- Sidebar toggle, controls the 'sidebarOpen' sidebar state. -->
        <button
          class="px-4 border-r border-gray-200 text-gray-500 focus:outline-none focus:ring-2 focus:ring-inset focus:ring-purple-500 lg:hidden"
        >
          <span class="sr-only">Open sidebar</span>
          <!-- Heroicon name: outline/menu-alt-1 -->
          <svg
            class="h-6 w-6"
            xmlns="http://www.w3.org/2000/svg"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
            aria-hidden="true"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M4 6h16M4 12h8m-8 6h16"
            />
          </svg>
        </button>
        <div class="flex-1 flex justify-between px-4 sm:px-6 lg:px-8">
          <div class="flex-1 flex">
            <form class="w-full flex md:ml-0" action="#" method="GET">
              <label for="search_field" class="sr-only">Search</label>
              <div
                class="relative w-full text-gray-400 focus-within:text-gray-600"
              >
                <div
                  class="absolute inset-y-0 left-0 flex items-center pointer-events-none"
                >
                  <!-- Heroicon name: solid/search -->
                  <svg
                    class="h-5 w-5"
                    xmlns="http://www.w3.org/2000/svg"
                    viewBox="0 0 20 20"
                    fill="currentColor"
                    aria-hidden="true"
                  >
                    <path
                      fill-rule="evenodd"
                      d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z"
                      clip-rule="evenodd"
                    />
                  </svg>
                </div>
                <input
                  id="search_field"
                  name="search_field"
                  class="block w-full h-full pl-8 pr-3 py-2 border-transparent text-gray-900 placeholder-gray-500 focus:outline-none focus:ring-0 focus:border-transparent focus:placeholder-gray-400 sm:text-sm"
                  placeholder="Search"
                  type="search"
                />
              </div>
            </form>
          </div>
          <div class="flex items-center">
            <!-- Profile dropdown -->
            <div class="ml-3 relative">
              <div>
                <button
                  class="max-w-xs bg-white flex items-center text-sm rounded-full focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-purple-500"
                  id="user-menu"
                  aria-haspopup="true"
                >
                  <span class="sr-only">Open user menu</span>
                  <img
                    class="h-8 w-8 rounded-full"
                    src="https://images.unsplash.com/photo-1502685104226-ee32379fefbe?ixlib=rb-1.2.1&ixqx=PbYQhi5uSS&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=facearea&facepad=2&w=256&h=256&q=80"
                    alt=""
                  />
                </button>
              </div>
              <!--
              Profile dropdown panel, show/hide based on dropdown state.

              Entering: "transition ease-out duration-100"
                From: "transform opacity-0 scale-95"
                To: "transform opacity-100 scale-100"
              Leaving: "transition ease-in duration-75"
                From: "transform opacity-100 scale-100"
                To: "transform opacity-0 scale-95"
            -->
              <div
                class="origin-top-right absolute right-0 mt-2 w-48 rounded-md shadow-lg bg-white ring-1 ring-black ring-opacity-5 divide-y divide-gray-200"
                role="menu"
                aria-orientation="vertical"
                aria-labelledby="user-menu"
              >
                <div class="py-1" role="none">
                  <a
                    href="#"
                    class="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100 hover:text-gray-900"
                    role="menuitem"
                    >View profile</a
                  >
                  <a
                    href="#"
                    class="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100 hover:text-gray-900"
                    role="menuitem"
                    >Settings</a
                  >
                  <a
                    href="#"
                    class="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100 hover:text-gray-900"
                    role="menuitem"
                    >Notifications</a
                  >
                </div>
                <div class="py-1" role="none">
                  <a
                    href="#"
                    class="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100 hover:text-gray-900"
                    role="menuitem"
                    >Get desktop app</a
                  >
                  <a
                    href="#"
                    class="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100 hover:text-gray-900"
                    role="menuitem"
                    >Support</a
                  >
                </div>
                <div class="py-1" role="none">
                  <a
                    href="#"
                    class="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100 hover:text-gray-900"
                    role="menuitem"
                    >Logout</a
                  >
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <main class="flex-1 relative z-0 overflow-y-auto focus:outline-none">
        <div
          class="border-b border-gray-200 px-4 py-4 sm:flex sm:items-center sm:justify-between sm:px-6 lg:px-8"
        >
          <div class="flex-1 min-w-0">
            <h1 class="text-lg font-medium leading-6 text-gray-900 sm:truncate">
              Details drilldown
            </h1>
          </div>
        </div>
        
        <!-- Page header -->
        <div
          class="px-8 pt-4"
        >
          <div class="flex items-center space-x-5">
            <div>
              <h1 class="text-2xl font-bold text-gray-900">{{ trace.requestUrl }}</h1>
              <p class="text-sm font-medium text-gray-500">
                Started on 
                <!-- <span class="text-gray-900">{{ trace.spanData?.applicationName }}</span> on <span class="text-gray-900">{{ trace.spanData.hostname }}</span> at  -->
                <time datetime="2020-08-25">timestamp</time>
              </p>
            </div>
          </div>
        </div>

        <div
          class="mt-8 grid grid-cols-2 gap-6"
        >
          <div v-if="trace.spanData" class="space-y-6 lg:col-start-1 lg:col-span-2">
            <!-- Description list-->
            <section>
              <div class="bg-white shadow rounded">
                <div class="border-t border-opacity-80 border-gray-200 px-4 py-5 sm:px-6">
                  <dl class="grid grid-cols-1 gap-x-4 gap-y-8 sm:grid-cols-2">
                    <div class="sm:col-span-1">
                      <dt class="text-sm font-medium text-gray-500">
                        Application
                      </dt>
                      <dd class="mt-1 text-sm text-gray-900">
                        {{ trace.spanData.applicationName }}
                      </dd>
                    </div>
                    <div class="sm:col-span-1">
                      <dt class="text-sm font-medium text-gray-500">
                        Hostname
                      </dt>
                      <dd class="mt-1 text-sm text-gray-900">
                        {{ trace.spanData.hostname }}
                      </dd>
                    </div>
                    <div class="sm:col-span-1">
                      <dt class="text-sm font-medium text-gray-500">
                        Started at
                      </dt>
                      <dd class="mt-1 text-sm text-gray-900">TODO</dd>
                    </div>
                    <div class="sm:col-span-1">
                      <dt class="text-sm font-medium text-gray-500">Username</dt>
                      <dd class="mt-1 text-sm text-gray-900">
                        TODO
                      </dd>
                    </div>
                    <div class="sm:col-span-2">
                      <dt class="text-sm font-medium text-gray-500">
                        Logs/Traces
                      </dt>
                      <dd class="mt-1 text-sm text-gray-900">
                        
                        <ul
                          class="border border-gray-200 rounded-md divide-y divide-gray-200"
                        >
                          <SpanDetail v-bind:span="trace.spanData" />
                        </ul>
                      </dd>
                    </div>
                  </dl>
                </div>
              </div>
            </section>
          </div>

          <section
            aria-labelledby="timeline-title"
            class="lg:col-start-3 lg:col-span-1"
          >
            <div class="bg-white px-4 py-5 shadow sm:rounded-lg sm:px-6">
              <h2 id="timeline-title" class="text-lg font-medium text-gray-900">
                Breakdown (coming!)
              </h2>

              <!-- Activity Feed -->
              <div class="mt-6 flow-root">
                <ul class="-mb-8">
                  <li>
                    <div class="relative pb-8">
                      <div class="relative flex space-x-3">
                        <div>
                          <span
                            class="h-8 w-8 rounded-full bg-gray-400 flex items-center justify-center ring-8 ring-white"
                          >
                            <!-- Heroicon name: solid/user -->
                            <svg
                              class="h-5 w-5 text-white"
                              xmlns="http://www.w3.org/2000/svg"
                              viewBox="0 0 20 20"
                              fill="currentColor"
                              aria-hidden="true"
                            >
                              <path
                                fill-rule="evenodd"
                                d="M10 9a3 3 0 100-6 3 3 0 000 6zm-7 9a7 7 0 1114 0H3z"
                                clip-rule="evenodd"
                              />
                            </svg>
                          </span>
                        </div>
                        <div
                          class="min-w-0 flex-1 pt-1.5 flex justify-between space-x-4"
                          v-if="trace.spanData"
                        >
                          <div>
                            <p class="text-sm text-gray-500">
                              30%
                              <a href="#" class="font-medium text-gray-900"
                                >{{ trace.spanData.applicationName }} SQL</a
                              >
                            </p>
                          </div>
                          <div
                            class="text-right text-sm whitespace-nowrap text-gray-500"
                          >
                            <time datetime="2020-09-20">Sep 20</time>
                          </div>
                        </div>
                      </div>
                    </div>
                  </li>
                </ul>
              </div>
            </div>
          </section>
        </div>
      </main>
    </div>
</template>

<script lang="ts">
import { ref, defineComponent } from "vue";
import * as signalR from "@microsoft/signalr";
import Trace from "../models/trace";

import TraceRow from "../components/TraceRow.vue";
import ServerTopBox from "../components/ServerTopBox.vue";
import StartSpan from "../models/startspan";
import Span from "../models/span";
import StopSpan from "../models/stopspan";
import LogMessage from "../models/logmessage";
import SpanDetail from "../components/SpanDetail.vue";

export default defineComponent({
  name: "Details",
  props: {},
  data: () => {
    return {
      traceIdentifier: "",
      trace: new Trace(),
      spanLookup: {} as { [spanId: string]: Span },
    };
  },
  setup: () => {},
  mounted() {
    const connection = new signalR.HubConnectionBuilder()
      .withUrl("/ui-updates")
      .build();

    this.traceIdentifier = Array.isArray(this.$route.params.traceIdentifier)
      ? this.$route.params.traceIdentifier[0]
      : this.$route.params.traceIdentifier;

    connection
      .start()
      .catch((err) => document.write(err))
      .then(() =>
        connection.send("startStreamingDetails", this.traceIdentifier)
      );

    connection.on("NewTrace", (message: Trace) => {
      this.trace.requestUrl = message.requestUrl;
      this.trace.inProgress = true;
      this.trace.traceIdentifier = message.traceIdentifier;
    });

    connection.on("StartSpan", (message: StartSpan) => {
      const trace = this.trace;
      const newSpan = new Span(
        message.spanIdentifier,
        message.requestUrl,
        message.traceIdentifier,
        message.hostname,
        message.applicationName
      );

      this.spanLookup[message.spanIdentifier] = newSpan;
      if (message.parentSpanIdentifier) {
        // We already have a span, so just add the span beneath the current parent one.
        const parentSpan = this.spanLookup[message.parentSpanIdentifier];

        parentSpan.childSpans.push(newSpan);

        trace.runningSpansCount = trace.runningSpansCount + 1;
      } else {
        this.trace.spanData = newSpan;
      }
    });

    connection.on("StopSpan", (message: StopSpan) => {
      let span = this.spanLookup[message.spanIdentifier];
      span.inProgress = false;

      const trace = this.trace;

      trace.runningSpansCount = trace.runningSpansCount - 1;

      if (trace.runningSpansCount == 0) {
        trace.inProgress = false;
      }
    });

    connection.on("LogMessage", (message: LogMessage): void => {
      let span = this.spanLookup[message.spanIdentifier];
      span.logs.push(message);
    });
  },
  components: {
    'SpanDetail': SpanDetail
  },
});
</script>

<style>
.console {
  background: rgba(56, 4, 40, 0.7);
  color: white;
  font: Inconsolata, monospace;
}

.blinker {
  height: 1em;
  display: block;
  width: 0.6em;
  margin-bottom: 4px;
  animation: blinky 1200ms linear infinite;
}
@keyframes blinky {
  0% {
    background: #ffffff;
  }
  49% {
    background: #ffffff;
  }
  60% {
    background: transparent;
  }
  99% {
    background: transparent;
  }
  100% {
    background: #ffffff;
  }
}

.server-list-item {
  transition: all 0.8s ease;
  display: inline-block;
  margin-right: 10px;
}

.server-list-enter-from,
.server-list-leave-to {
  opacity: 0;
}

.server-list-leave-active {
  position: absolute;
}

.tracelist-animation-item {
  transition: all 1s;
}
.tracelist-animation-enter, .tracelist-animation-leave-to
/* .list-complete-leave-active below version 2.1.8 */ {
  opacity: 0;
}
</style>
