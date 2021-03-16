<h1 style="font-weight:normal">
  <a href="https://github.com/dottylogs/dottylogs">
    <img src=https://github.com/dottylogs/dottylogs/raw/master/docs/icon.png alt="DottyLogs" width=35>
  </a>
  &nbsp;dottylogs&nbsp;
  <a href="https://github.com/dottylogs/dottylogs/releases"><img src=https://img.shields.io/github/release/dottylogs/dottylogs.svg?colorB=58839b></a>
  <a href="https://github.com/dottylogs/dottylogs/blob/master/LICENSE"><img src=https://img.shields.io/github/license/dottylogs/dottylogs.svg?colorB=ff0000></a>
</h1>

A better log viewer for humans
<br>

<p align="center">
  <img alt="gif" src="https://raw.githubusercontent.com/dottylogs/dottylogs/master/docs/dottyweek1.gif">
</p>

Warning
=======

This project is only at proof of concept stage. Please feel free to run it, but it will lose your data every time.

Features
========

* Instant realtime log viewing
* History of traces
* Insight into parallel flow of services and microservices
* Easy integration into ASP.NET Core applications (and Generic Host too)

Roadmap
=======

* Full diagnosis on traces
* Integration with tracing libraries
* Other languages

Get started
===========

The easiest way is the use the DottyLogs server docker image. That's available here: https://github.com/orgs/dottylogs/packages
´docker pull ghcr.io/dottylogs/dottylogs:latest´

You'll then be able to go directly to it, and start sending traces

Build and run
=============

Run the vue.js application seperately:
cd DottyLogs.Ui/client-app/
npm run start

You can then run the rest together with the example application with Project Type:
type run --watch

License
=======
DottyLogs is under the MIT license. See the [LICENSE](https://github.com/dottylogs/dottylogs/blob/develop/LICENSE.md) for more information.
