# covid19-asp-net-core
> Covid19 Asp.Net Core Realtime fetching of information using WebSockets with SignalR
> Covid19 Asp.Net Core Realtime in a university project that creates a web application which provides realtime data for Covid19.

# Docker
## Local build
`docker build . --tag covid19-asp-net-core:dev`

## Local run
`docker run --rm -d -p 5000:5000 -p 5001:5001 --name covid19_asp_net_core covid19-asp-net-core:dev`
