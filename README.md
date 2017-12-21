A solution for Blogging based on a Event-Driven architecture with DDD and CQRS. The full solution contains three applications.
* A Producer Web API which receives Commands to produces Domain Events also receives Queries to return JSON. 
* A Consumer Console App that reads the Event Stream and do a projection to a MongoDB database.
* A Web API for authentication and JWT generation.

[Blogging API Source Code on GitHub](https://github.com/ivanpaulovich/jambo)

#### Requirements
* [Visual Studio 2017 + Update 3](https://www.visualstudio.com/en-us/news/releasenotes/vs2017-relnotes)
* [.NET SDK 2.0](https://www.microsoft.com/net/download/core)
* [Docker](https://docs.docker.com/docker-for-windows/install/)

#### Environment setup

*If you already have valid connections strings for Kafka and MongoDB you could skip this topic and go to the Running the applications topic.*

* Run the `./up-kafka-mongodb.sh` script to run Kafka and MongoDB as Docker Containers. Please wait until the ~800mb download to be complete.

```
$ ./up-kafka-mongodb.sh
Pulling mongodb (mongo:latest)...
latest: Pulling from library/mongo
Digest: sha256:2c55bcc870c269771aeade05fc3dd3657800540e0a48755876a1dc70db1e76d9
Status: Downloaded newer image for mongo:latest
Pulling kafka (spotify/kafka:latest)...
latest: Pulling from spotify/kafka
Digest: sha256:cf8f8f760b48a07fb99df24fab8201ec8b647634751e842b67103a25a388981b
Status: Downloaded newer image for spotify/kafka:latest
Creating setup_mongodb_1 ...
Creating setup_kafka_1 ...
Creating setup_mongodb_1
Creating setup_mongodb_1 ... done
```
* Check if the data layer is ready with the following commands:

```
$ docker images
REPOSITORY          TAG                 IMAGE ID            CREATED             SIZE
mongo               latest              d22888af0ce0        17 hours ago        361MB
spotify/kafka       latest              a9e0a5b8b15e        11 months ago       443MB
```

```
$ docker ps
CONTAINER ID        IMAGE               COMMAND                  CREATED             STATUS              PORTS                                            NAMES
32452776153f        spotify/kafka       "supervisord -n"         2 days ago          Up 2 days           0.0.0.0:2181->2181/tcp, 0.0.0.0:9092->9092/tcp   setup_kafka_1
ba28cf144478        mongo               "docker-entrypoint..."   2 days ago          Up 2 days           0.0.0.0:27017->27017/tcp                         setup_mongodb_1
```

If Kafka is running good it will be working with the `10.0.75.1:9092` connection string and if MongoDB is running good it will be working at `mongodb://10.0.75.1:27017`.

## Running the applications

You have two options to run the three applications, one is by opening on Visual Studio 2017 and another is by dotnet core commands.

### Option 1 - Running with Visual Studio 2017

Open the three solutions with three Visual Studio 2017 them run the following projects.

* `Jambo.Auth.UI`
* `Jambo.Consumer.UI` 
* `Jambo.Producer.UI`.

### Option 2 - Running with dotnet commands

#### How to run the Bearer Authencation API

1. Run the command `dotnet run` at `source\Auth\Jambo.Auth.UI` folder.
```
$ dotnet run
Using launch settings from C:\git\jambo\source\Auth\Jambo.Auth.UI\Properties\launchSettings.json...
Hosting environment: Development
Content root path: C:\git\jambo\source\Auth\Jambo.Auth.UI
Now listening on: http://localhost:16024
Application started. Press Ctrl+C to shut down.
```
2. Navigate to the Swagger UI at (eg. http://localhost:16024/swagger).
3. Post the following credentials:
```
{
  "username": "ivanpaulovich",
  "password": "mysecret"
}
```
4. __Store the Bearer Token__ because you will need the token value later to log on Producer API.
```
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJhYzA4MmE3OS1lMWY3LTQ4MTktYmU1Mi1hOTQwMTBkM2VjZTciLCJzdWIiOiJzdHJpbmciLCJleHAiOjE1MTI0Nzg5ODgsImlzcyI6Imh0dHA6Ly9teWFjY291bnRhcGkiLCJhdWQiOiJodHRwOi8vbXlhY2NvdW50YXBpIn0.9YKGmKaptLBDcExHhPOQ3_j9TsdbkcRf8ZtvIkdq8Go",
  "expiration": "2017-12-05T13:03:08Z"
}
```
#### How to run the Consumer API

1. Run the command `dotnet run` at `source\Consumer\Jambo.Consumer.UI` folder 

```
$ dotnet run
11/5/2017 11:17:20 AM Waiting for events..
11/5/2017 11:18:20 AM Waiting for events..
11/5/2017 11:19:20 AM Waiting for events..
11/5/2017 11:20:20 AM Waiting for events..
11/5/2017 11:21:20 AM Waiting for events..
11/5/2017 11:22:20 AM Waiting for events..
```

3. __Attention:__ keep the Console App running for events processing.

#### How to run the Producer API

![Authorization](https://github.com/ivanpaulovich/jambo/blob/master/Producer.png)

1. Run the command `dotnet run` at the `source\Producer\Jambo.Producer.UI` folder.

```
$ dotnet run
Using launch settings from C:\git\jambo\source\Producer\Jambo.Producer.UI\Properties\launchSettings.json...
Hosting environment: Development
Content root path: C:\git\jambo\source\Producer\Jambo.Producer.UI
Now listening on: http://localhost:16959
Application started. Press Ctrl+C to shut down.
```

2. Navigate to the Swagger UI (eg. http://localhost:14398/swagger).