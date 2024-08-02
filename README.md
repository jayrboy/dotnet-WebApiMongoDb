# .NET Core Web API - MongoDB

```bash
# dotnet new webapi --controllers -o <project-name>
dotnet new webapi --controllers -o WebApiMongoDb
cd WebApiMongoDb

dotnet run
# STOP: CTRL + C
```

# Dockerfile

1. CTRL + SHIFT + P
2. Docker: Add Docker Files to Workspace...
3. .NET Core Web
4. PORT: 8000
5. Create Docker Compose: Enter

## Docker image and container (แบบที่ 1)

1. build a image

```bash
# docker build ./ -t <image-name>
docker build ./ -t webapimongodb
docker image ls
```

2. run a container

```bash
# docker run --name <container-name> -d -p 8000:8000 --name <image-name>
docker run --name webapimongodb -d -p 8000:8000 webapimongodb
docker run --name webapimongodb -e ASPNETCORE_ENVIRONMENT=Development -d -p 8000:8000 webapimongodb
docker ps
```

3. remove a container

```bash
docker ps -a
docker stop <CONTAINER-ID>
docker rm -f <CONTAINER-ID>
```

### Docker image and container (แบบที่ 2)

build and run image and container from `docker-compose.yml`

```bash
docker compose up -d # Production
docker-compose -f docker-compose.debug.yml up -d # Development
docker compose ls

docker compose down
```

# Debugging

https://code.visualstudio.com/docs/csharp/debugger-settings

For launch.json

```json
{
  "configurations": [
    {
      "name": "Docker .NET Launch",
      "type": "docker",
      "request": "launch",
      "preLaunchTask": "docker-run: debug",
      "netCore": {
        "appProject": "${workspaceFolder}/WebApiMongoDb.csproj"
      },
      //TODO:
      "serverReadyAction": {
        "action": "openExternally",
        "pattern": "\\bNow listening on:\\s+http://\\S+:([0-9]+)",
        "uriFormat": "http://localhost:%s/swagger/index.html"
      }
    }
  ]
}
```

For tasks.json

```json
[
  {
    "type": "docker-run",
    "label": "docker-run: debug",
    "dependsOn": ["docker-build: debug"],
    "dockerRun": {
      //TODO:
      "ports": [
        {
          "containerPort": 8000,
          "hostPort": 8000
        }
      ]
    },
    "netCore": {
      "appProject": "${workspaceFolder}/WebApiMongoDb.csproj",
      "enableDebugging": true
    }
  }
]
```

# Run Repositories with Docker Hub

https://hub.docker.com/repositories

```bash
docker login

docker tag <IMAGE-NAME> <REPOSITORY>:latest
docker tag webapimongodb jayrjakkrit/webapimongodb:latest

docker push jayrjakkrit/webapimongodb
```

# Pull Docker Hub

```bash
docker pull mongo
```
