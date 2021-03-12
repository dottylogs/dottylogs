<template>
  <div class="h-screen flex overflow-hidden bg-white">
    <!-- Off-canvas menu for mobile, show/hide based on off-canvas menu state. -->
    <div class="lg:hidden">
      <div class="fixed inset-0 flex z-40">
        <!--
        Off-canvas menu overlay, show/hide based on off-canvas menu state.

        Entering: "transition-opacity ease-linear duration-300"
          From: "opacity-0"
          To: "opacity-100"
        Leaving: "transition-opacity ease-linear duration-300"
          From: "opacity-100"
          To: "opacity-0"
      -->
        <div class="fixed inset-0" aria-hidden="true">
          <div class="absolute inset-0 bg-gray-600 opacity-75"></div>
        </div>
        <!--
        Off-canvas menu, show/hide based on off-canvas menu state.

        Entering: "transition ease-in-out duration-300 transform"
          From: "-translate-x-full"
          To: "translate-x-0"
        Leaving: "transition ease-in-out duration-300 transform"
          From: "translate-x-0"
          To: "-translate-x-full"
      -->
        <div
          class="relative flex-1 flex flex-col max-w-xs w-full pt-5 pb-4 bg-white"
        >
          <div class="absolute top-0 right-0 -mr-12 pt-2">
            <button
              class="ml-1 flex items-center justify-center h-10 w-10 rounded-full focus:outline-none focus:ring-2 focus:ring-inset focus:ring-white"
            >
              <span class="sr-only">Close sidebar</span>
              <!-- Heroicon name: outline/x -->
              <svg
                class="h-6 w-6 text-white"
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
                  d="M6 18L18 6M6 6l12 12"
                />
              </svg>
            </button>
          </div>
          <div class="flex-shrink-0 flex items-center px-4">
            <span>DottyLogs</span>
          </div>
          <div class="mt-5 flex-1 h-0 overflow-y-auto">
            <nav class="px-2">
              <div class="space-y-1">
                <!-- Current: "bg-gray-100 text-gray-900", Default: "text-gray-600 hover:text-gray-900 hover:bg-gray-50" -->
                <a
                  href="#"
                  class="bg-gray-100 text-gray-900 group flex items-center px-2 py-2 text-base leading-5 font-medium rounded-md"
                  aria-current="page"
                >
                  <!-- Current: "text-gray-500", Default: "text-gray-400 group-hover:text-gray-500" -->
                  <!-- Heroicon name: outline/home -->
                  <svg
                    class="text-gray-500 mr-3 h-6 w-6"
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
                      d="M3 12l2-2m0 0l7-7 7 7M5 10v10a1 1 0 001 1h3m10-11l2 2m-2-2v10a1 1 0 01-1 1h-3m-6 0a1 1 0 001-1v-4a1 1 0 011-1h2a1 1 0 011 1v4a1 1 0 001 1m-6 0h6"
                    />
                  </svg>
                  Home
                </a>

                <a
                  href="#"
                  class="text-gray-600 hover:text-gray-900 hover:bg-gray-50 group flex items-center px-2 py-2 text-base leading-5 font-medium rounded-md"
                >
                  <!-- Heroicon name: outline/view-list -->
                  <svg
                    class="text-gray-400 group-hover:text-gray-500 mr-3 h-6 w-6"
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
                      d="M4 6h16M4 10h16M4 14h16M4 18h16"
                    />
                  </svg>
                  My tasks
                </a>

                <a
                  href="#"
                  class="text-gray-600 hover:text-gray-900 hover:bg-gray-50 group flex items-center px-2 py-2 text-base leading-5 font-medium rounded-md"
                >
                  <!-- Heroicon name: outline/clock -->
                  <svg
                    class="text-gray-400 group-hover:text-gray-500 mr-3 h-6 w-6"
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
                      d="M12 8v4l3 3m6-3a9 9 0 11-18 0 9 9 0 0118 0z"
                    />
                  </svg>
                  Recent
                </a>
              </div>
            </nav>
          </div>
        </div>
        <div class="flex-shrink-0 w-14" aria-hidden="true">
          <!-- Dummy element to force sidebar to shrink to fit close icon -->
        </div>
      </div>
    </div>

    <!-- Static sidebar for desktop -->
    <div class="hidden lg:flex lg:flex-shrink-0">
      <div
        class="flex flex-col w-64 border-r border-gray-200 pt-5 pb-4 bg-gray-100"
      >
        <div class="flex items-center flex-shrink-0 px-6">
          <h1 class="text-lg font-medium leading-6 text-gray-900 sm:truncate">
              DottyLogs
            </h1>
        </div>
        <!-- Sidebar component, swap this element with another sidebar if you like -->
        <div class="h-0 flex-1 flex flex-col overflow-y-auto">
          <!-- Sidebar Search -->
          <div class="px-3 mt-5">
            <label for="search" class="sr-only">Search</label>
            <div class="mt-1 relative rounded-md shadow-sm">
              <div
                class="absolute inset-y-0 left-0 pl-3 flex items-center pointer-events-none"
                aria-hidden="true"
              >
                <!-- Heroicon name: solid/search -->
                <svg
                  class="mr-3 h-4 w-4 text-gray-400"
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
                type="text"
                name="search"
                id="search"
                class="focus:ring-indigo-500 focus:border-indigo-500 block w-full pl-9 sm:text-sm border-gray-300 rounded-md"
                placeholder="Search"
              />
            </div>
          </div>
          <!-- Navigation -->
          <nav class="px-3 mt-6">
            <div class="space-y-1">
              <!-- Current: "bg-gray-200 text-gray-900", Default: "text-gray-700 hover:text-gray-900 hover:bg-gray-50" -->
              <a
                href="#"
                class="bg-gray-200 text-gray-900 group flex items-center px-2 py-2 text-sm font-medium rounded-md"
              >
                <!-- Current: "text-gray-500", Default: "text-gray-400 group-hover:text-gray-500" -->
                <!-- Heroicon name: outline/home -->
                <svg
                  class="text-gray-500 mr-3 h-6 w-6"
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
                    d="M3 12l2-2m0 0l7-7 7 7M5 10v10a1 1 0 001 1h3m10-11l2 2m-2-2v10a1 1 0 01-1 1h-3m-6 0a1 1 0 001-1v-4a1 1 0 011-1h2a1 1 0 011 1v4a1 1 0 001 1m-6 0h6"
                  />
                </svg>
                Live
              </a>

              <a
                href="#"
                class="text-gray-700 hover:text-gray-900 hover:bg-gray-50 group flex items-center px-2 py-2 text-sm font-medium rounded-md"
              >
                <!-- Heroicon name: outline/view-list -->
                <svg
                  class="text-gray-400 group-hover:text-gray-500 mr-3 h-6 w-6"
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
                    d="M4 6h16M4 10h16M4 14h16M4 18h16"
                  />
                </svg>
                History
              </a>

              <a
                href="#"
                class="text-gray-700 hover:text-gray-900 hover:bg-gray-50 group flex items-center px-2 py-2 text-sm font-medium rounded-md"
              >
                <!-- Heroicon name: outline/clock -->
                <svg
                  class="text-gray-400 group-hover:text-gray-500 mr-3 h-6 w-6"
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
                    d="M12 8v4l3 3m6-3a9 9 0 11-18 0 9 9 0 0118 0z"
                  />
                </svg>
                About
              </a>
            </div>
          </nav>
        </div>
      </div>
    </div>
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
          <ServerTopBox v-for="(server, ti) in serverTraceIdentifierLookup" v-bind:key="ti" v-bind:server="server"/>
            <transition-group name="server-list">
              
            </transition-group>
          </ul>
        </div>

        <!-- Projects list (only on smallest breakpoint) -->
        <div class="mt-10 sm:hidden">
          <div class="px-4 sm:px-6">
            <h2
              class="text-gray-500 text-xs font-medium uppercase tracking-wide"
            >
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
                <transition-group name="tracelist-animation" v-on:after-leave="clearOldTrace">
                  <TraceRow v-for="trace in traces" v-bind:key="trace.tracingIdentifier" v-bind:id="trace.traceIdentifier" :trace="trace" class="tracelist-animation-item"  />
                </transition-group>
                <!-- More items... -->
              </tbody>
            </table>
          </div>
        </div>
      </main>
    </div>
  </div>
</template>

<script lang="ts">
import { ref, defineComponent } from "vue";
import * as signalR from "@microsoft/signalr";
import StartSpan from "../models/startspan";
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
  spanLookup: {[spanId: string]:Span};
  servers: Server[];
  serverTraceIdentifierLookup: {[serveId: string]:Server};
}

export default defineComponent({
  name: "Index",
  props: {

  },
  data: () => {
    return {
      traces: [] as Trace[],
      spanLookup: {} as {[spanId: string]:Span},
      servers: [] as Server[],
      serverTraceIdentifierLookup: {} as {[serveId: string]:Server}
    } as MainAppData
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
      const trace = this.traces.find(s => s.tracingIdentifier == message.tracingIdentifier)
      const newSpan = new Span(message.spanIdentifier, message.requestUrl, message.tracingIdentifier, message.hostname, message.applicationName);

      this.spanLookup[message.spanIdentifier] = newSpan;
      if (trace) {
        // We already have a trace, so just add the span beneath the current parent one.
        const parentSpan = this.spanLookup[message.parentSpanIdentifier];

        parentSpan.childSpans.push(newSpan);

        trace.runningSpansCount = trace.runningSpansCount + 1;
      } else {

        const newTrace = new Trace(newSpan, message.requestUrl, message.tracingIdentifier);
        
        this.traces.unshift(newTrace);
      }
    });

    connection.on("StopSpan", (message: StartSpan) => {
      let span = this.spanLookup[message.spanIdentifier];
      span.inProgress = false;

      const trace = this.traces.find(s => s.tracingIdentifier == message.tracingIdentifier);

      trace.runningSpansCount = trace.runningSpansCount - 1;

      if (trace.runningSpansCount == 0) {
        trace.inProgress = false;
        this.traces.forEach((trace, index) => {
        // if (trace.tracingIdentifier == message.tracingIdentifier) {
        //   this.traces.splice(index, 1)
        // }
      });
      }
    });

    connection.on("LogMessage", (message: LogMessage) => {
      let span = this.spanLookup[message.spanIdentifier];
      span.logs.push(message);
    });

    connection.on("ServerConnected", (message: ServerConnectedEvent) => {
      let existingServer = this.servers.find(s => s.traceIdentifier === message.traceIdentifier);
      if (!existingServer) {
        const server = new Server(message.traceIdentifier, message.hostName, message.applicationName);
        this.servers.push(server)

        this.serverTraceIdentifierLookup[message.traceIdentifier] = server;
      }
    });

    connection.on("ServerDisconnected", (message: ServerDisconnectedEvent) => {
      console.info("disconnecting")
      console.log({message, s: this.servers});
      this.servers.forEach((server, index) => {
        if (server.tracingIdentifier == message.traceIdentifier) {
          this.servers.splice(index, 1)
        }
      });

      delete this.serverTraceIdentifierLookup[message.traceIdentifier];
    });

    connection.start().catch(err => document.write(err));
  },
  methods: {
    clearOldTrace(el: any) {
      console.log({el});
    }
  },
  components: {
    'TraceRow': TraceRow,
    'ServerTopBox': ServerTopBox
  }
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
  }  100% {    
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
