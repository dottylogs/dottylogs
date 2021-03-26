<template>
  <!-- Main column -->
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
    <main
      class="flex-1 relative z-0 overflow-y-auto focus:outline-none"
      tabindex="0"
    >
      <!-- Page title & actions -->
      <div
        class="border-b border-gray-200 px-4 py-4 sm:flex sm:items-center sm:justify-between sm:px-6 lg:px-8"
      >
        <div class="flex-1 min-w-0">
          <h1 class="text-lg font-medium leading-6 text-gray-900 sm:truncate">
            Live Dashboard
          </h1>
        </div>
      </div>
      <!-- Pinned projects -->
      <div class="px-4 mt-6 sm:px-6 lg:px-8">
        <h2 class="text-gray-500 text-xs font-medium uppercase tracking-wide">
          Servers
        </h2>
        <ul
          class="grid grid-cols-1 gap-4 sm:gap-6 sm:grid-cols-2 xl:grid-cols-4 mt-3"
        >
          <ServerTopBox
            v-for="(server, ti) in serverTraceIdentifierLookup"
            v-bind:key="ti"
            v-bind:server="server"
          />
          <transition-group name="server-list"> </transition-group>
        </ul>
      </div>

      <!-- Projects list (only on smallest breakpoint) -->
      <div class="mt-10 sm:hidden">
        <div class="px-4 sm:px-6">
          <h2 class="text-gray-500 text-xs font-medium uppercase tracking-wide">
            Requests
          </h2>
        </div>
        <ul class="mt-3 border-t border-gray-200 divide-y divide-gray-100">
          <li>
            <a
              href="#"
              class="group flex items-center justify-between px-4 py-4 hover:bg-gray-50 sm:px-6"
            >
              <span class="flex items-center truncate space-x-3">
                <span
                  class="w-2.5 h-2.5 flex-shrink-0 rounded-full bg-pink-600"
                  aria-hidden="true"
                ></span>
                <span class="font-medium truncate text-sm leading-6">
                  GraphQL API
                  <span class="truncate font-normal text-gray-500"
                    >in Engineering</span
                  >
                </span>
              </span>
              <!-- Heroicon name: solid/chevron-right -->
              <svg
                class="ml-4 h-5 w-5 text-gray-400 group-hover:text-gray-500"
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 20 20"
                fill="currentColor"
                aria-hidden="true"
              >
                <path
                  fill-rule="evenodd"
                  d="M7.293 14.707a1 1 0 010-1.414L10.586 10 7.293 6.707a1 1 0 011.414-1.414l4 4a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0z"
                  clip-rule="evenodd"
                />
              </svg>
            </a>
          </li>

          <!-- More items... -->
        </ul>
      </div>

      <!-- Projects table (small breakpoint and up) -->
      <div class="hidden mt-8 sm:block">
        <div
          class="align-middle inline-block min-w-full border-b border-gray-200"
        >
          <table class="min-w-full">
            <thead>
              <tr class="border-t border-gray-200">
                <th
                  class="px-6 py-3 border-b border-gray-200 bg-gray-50 text-left text-xs font-medium text-gray-500 uppercase tracking-wider"
                >
                  <span class="lg:pl-2">URL</span>
                </th>
                <th
                  class="pr-6 py-3 border-b border-gray-200 bg-gray-50 text-right text-xs font-medium text-gray-500 uppercase tracking-wider"
                ></th>
              </tr>
            </thead>
            <tbody class="bg-white divide-y divide-gray-100">
              <transition-group name="tracelist-animation">
                <TraceRow
                  v-for="trace in traces"
                  v-bind:key="trace.traceIdentifier"
                  v-bind:id="trace.traceIdentifier"
                  :trace="trace"
                  class="tracelist-animation-item"
                />
              </transition-group>
              <!-- More items... -->
            </tbody>
          </table>
        </div>
      </div>
    </main>
  </div>
</template>

<script lang="ts">
import { ref, defineComponent } from "vue";
import * as signalR from "@microsoft/signalr";
import StartSpan from "../models/startspan";
import StopSpan from "../models/stopspan";
import Span from "../models/span";
import Trace from "../models/trace";
import Server from "../models/server";
import ServerConnectedEvent from "../models/serverconnectedevent";
import ServerDisconnectedEvent from "../models/serverdisconnectedevent";

import LogMessage from "../models/logmessage";
import TraceRow from "../components/TraceRow.vue";
import ServerTopBox from "../components/ServerTopBox.vue";
import { debug } from "node:console";

interface MainAppData {
  traces: Trace[];
  spanLookup: { [spanId: string]: Span };
  servers: Server[];
  serverTraceIdentifierLookup: { [serveId: string]: Server };
}

export default defineComponent({
  name: "Home",
  props: {},
  data: () => {
    return {
      traces: [] as Trace[],
      spanLookup: {} as { [spanId: string]: Span },
      servers: [] as Server[],
      serverTraceIdentifierLookup: {} as { [serveId: string]: Server },
    } as MainAppData;
  },
  setup: () => {
    const count = ref(0);
    return { count };
  },
  mounted() {
    const connection = new signalR.HubConnectionBuilder()
      .withUrl("/ui-updates")
      .build();

    connection.on("StartSpan", (message: StartSpan) => {
      // See if we have a trace already
      const trace = this.traces.find(
        (s) => s.traceIdentifier == message.traceIdentifier
      );
      const newSpan = new Span(
        message.spanIdentifier,
        message.requestUrl,
        message.traceIdentifier,
        message.hostname,
        message.applicationName
      );

      this.spanLookup[message.spanIdentifier] = newSpan;
      if (trace) {
        // We already have a trace, so just add the span beneath the current parent one.
        const parentSpan = this.spanLookup[message.parentSpanIdentifier];

        parentSpan.childSpans.push(newSpan);

        trace.runningSpansCount = trace.runningSpansCount + 1;
      } else {
        const newTrace = new Trace();
        newTrace.spanData = newSpan;
        newTrace.requestUrl = message.requestUrl;
        newTrace.traceIdentifier = message.traceIdentifier;
        this.traces.unshift(newTrace);
      }
    });

    connection.on("StopSpan", (message: StopSpan) => {
      let span = this.spanLookup[message.spanIdentifier];
      span.inProgress = false;

      const trace = this.traces.find(
        (s) => s.traceIdentifier == message.traceIdentifier
      );

      trace.runningSpansCount = trace.runningSpansCount - 1;

      if (trace.runningSpansCount == 0) {
        trace.inProgress = false;
        this.traces.forEach((trace, index) => {
          if (trace.traceIdentifier == message.traceIdentifier) {
            this.traces.splice(index, 1);
          }
        });
      }
    });

    connection.on("LogMessage", (message: LogMessage) => {
      let span = this.spanLookup[message.spanIdentifier];
      span.logs.push(message);
    });

    connection.on("ServerConnected", (message: ServerConnectedEvent) => {
      let existingServer = this.servers.find(
        (s) => s.traceIdentifier === message.traceIdentifier
      );
      if (!existingServer) {
        const server = new Server(
          message.traceIdentifier,
          message.hostName,
          message.applicationName
        );
        this.servers.push(server);

        this.serverTraceIdentifierLookup[message.traceIdentifier] = server;
      }
    });

    connection.on("ServerDisconnected", (message: ServerDisconnectedEvent) => {
      console.info("disconnecting");
      console.log({ message, s: this.servers });
      this.servers.forEach((server, index) => {
        if (server.traceIdentifier == message.traceIdentifier) {
          this.servers.splice(index, 1);
        }
      });

      delete this.serverTraceIdentifierLookup[message.traceIdentifier];
    });

    connection.start().catch((err) => document.write(err));
  },
  components: {
    TraceRow: TraceRow,
    ServerTopBox: ServerTopBox
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
