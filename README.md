# Raspberry Pi Pico ATS/ETS2 Dashboard Companion App

## Intro

This companion app fetches the game data from the SCS SDK (ATS/ETS2) using the C# client scs-sdk-plugin forked from [RenCloud](https://github.com/RenCloud/scs-sdk-plugin) and [nlhans](https://github.com/nlhans/ets2-sdk-plugin), and sends it to the [scs-pico-dashboard](https://github.com/gpadilha/scs-pico-dashboard) via usb.

## Usage

It requires the game to be running with the telemetry plugin. The plugin build dll can be downloaded from the releases on [RenCloud repo](https://github.com/RenCloud/scs-sdk-plugin)

Place the telemetry plugin dll inside the `<ATS/ETS2 installation dir>/bin/win_x64/plugins/` folder. It is likely that the plugins folder doesn't exist yet and you will need to create it.

Once the you start the app it will look for devices using the COM port and list them. Select the Raspberry Pi Pico and click "Use selected device". Once it displays connected it will starts sending data.
