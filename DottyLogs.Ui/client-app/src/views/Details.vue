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
