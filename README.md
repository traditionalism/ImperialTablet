# <img src="https://d1muf25xaso8hp.cloudfront.net/https%3A%2F%2F346d62bb180eb082d30ee3499d6f0c43.cdn.bubble.io%2Ff1727909594965x579428480876060500%2F432342432.png?w=64&h=64&auto=compress&dpr=1&fit=max" width="48" height="48"> ImperialTablet

[![](https://dcbadge.limes.pink/api/server/https://discord.gg/FCx9eaWFn4/?style=flat&theme=clean-inverted)](https://discord.gg/FCx9eaWFn4) [![Build status](https://ci.appveyor.com/api/projects/status/r8wi567unkb451on?svg=true)](https://ci.appveyor.com/project/traditionalism/imperialtablet)

## Overview

**ImperialTablet** is an in-game NUI integration for Imperial CAD. 

## Installation

- _Firstly_, start the installation process of ImperialTablet by downloading the latest [release binaries](https://github.com/traditionalism/ImperialLibrary/releases).
> [!WARNING]
> _If this is your first time using an Imperial CAD plugin, you **MUST** set your community ID in your server.cfg using the [setr command](https://docs.fivem.net/docs/scripting-reference/convars/#server-replicated-convars) below (you can safely skip this step if you've used one of our plugins before)_
```
setr imperial_community_id "COMMUNITY_ID_HERE"
```
- After ensuring your Imperial CAD community ID is set, you can configure **ImperialTablet** using the provided `Config.ini` file.
- _Finally_, start **ImperialTablet** on server start by adding the following line to your `server.cfg`
```
ensure ImperialTablet
```
