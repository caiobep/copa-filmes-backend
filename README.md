# Copa Filmes

> A .NET Core solution to look for the best film

![CircleCI](https://circleci.com/gh/caiobep/copa-filmes-backend/tree/master.svg?style=svg)

## Getting Started

Simply download .NET Core SDK
[https://www.microsoft.com/net/download/core](https://www.microsoft.com/net/download/core)

### Change the api URL in `launchSettings.json`

```json
"environmentVariables": {
    "ASPNETCORE_ENVIRONMENT": "Development",
    "API_URL": "<YOUR_API_URL_HERE>" // <-- That's it Right there!
}
```

## Docker Build

There is a `Makefile` for macOS and Linux:

- `make build` executes `docker-compose build`
- `make run` executes `docker-compose run`

The above might work for Docker on Windows

## Local Building

- Install Cake as a global tool using `dotnet tool install -g Cake.Tool`
- Run Cake: `dotnet cake build.cake`

## Special Thanks

This project was heavily inspired on [Beaultiful REST Api](https://github.com/nbarbettini/BeautifulRestApi) by [Nate Barbettini](https://github.com/nbarbettini) and [Aspnet Core RealWorld Example App](https://github.com/gothinkster/aspnetcore-realworld-example-app) by [Thinkster](https://github.com/gothinkster)
