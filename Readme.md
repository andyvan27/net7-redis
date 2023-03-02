# Sample .Net7 API accessing Redis DB in Docker

## Create .Net7 API app
```
dotnet new --list
dotnet new webapi -n RedisAPI
code .\RedisAPI\ -r
dotnet run
curl http://localhost:5098/WeatherForecast
```

## Run Redis in Docker
docker-compose.yml:
```
version: '3.8'
services:
  redis:
    image: redis
    container_name: redis_cache
    ports:
      - "6379:6379"
```
```
docker compose up/stop/down -d
docker ps
docker exec -it 21a7ad48daed /bin/bash
redis-cli
set myfirstkey:01 Apple
get myfirstkey:01
del myfirstkey:01
```

## Add Redis NuGet package
```
dotnet add package Microsoft.Extensions.Caching.StackExchangeRedis --version 8.0.0-preview.1.23112.2
```
## Grab code from this repo
```
dotnet build
dotnet run
```

## Test
```
POST http://localhost:5098/api/fruits
{
    "name": "Orange"
}
GET http://localhost:5098/api/fruits
GET http://localhost:5098/api/fruits/fruit:88f44e36-757c-4e42-99ba-14bc025d0ed2
```

## References
Big thank to Le Jackson in this video: https://www.youtube.com/watch?v=DgVjEo3OGBI&list=LL&index=9