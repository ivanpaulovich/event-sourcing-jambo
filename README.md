A solution for Blogging based on a Event-Driven architecture with DDD and CQRS. The full solution contains three applications.
* A Web API which receives Commands to produces Domain Events also receives Queries to return JSON. 
* A Consumer App that reads the Event Stream and do a projection to a MongoDB database.
* A Web API for authentication and JWT generation.

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

#### The Domain
![Domain](https://github.com/ivanpaulovich/jambo/blob/master/docs/images/Domain.png)

#### As Aplicações desta Solução
* **Producer**: Web API que recebe os comandos de edição de conteúdo, produz Eventos de Domínio e publica as mensagens em um tópico no Kafka.
* **Consumer**: Aplicativo Console que consome as mensagens do Kafka, deserializa em Eventos de Domínio e aplica nas agregações persistindo no MongoDB o novo estado.  
* **Auth**: Web API que gera tokens de autenticação para acesso ao WebAPI.

#### Por onde começar?
Há duas formas de iniciar a solução. 

##### 1. O jeito fácil

Resolver os [pré-requisitos](https://github.com/ivanpaulovich/jambo/#prerequisitos), definir o projeto inicial como sendo o `docker-compose` e então apertar `Ctrl+F5` para executar todas as aplicações. Se tudo estiver correto, digite `docker ps` no seu terminal para verificar em quais portas cada aplicação está executando. Será algo assim:

![Enviando comandos](https://github.com/ivanpaulovich/jambo/blob/master/docs/images/Docker-PS.PNG)

A partir daí basta acessar:
* Auth em http://localhost:32775/swagger/
* Producer em http://localhost:32776/swagger/

Leia o [o jeito não tão fácil](https://github.com/ivanpaulovich/jambo/#2-o-jeito-não-tão-fácil) para entender como criar um Token no Auth API para consumir os serviços do Producer API via swagger.

##### 2. O jeito não tão fácil

A outra opção é inicializar aplicação por aplicação, seguindo o seguintes passos:

1. Execute o projeto **Jambo.Auth.WebAPI** e chame o método *Account/Token* com qualquer usuário e senha. *Guarde este token*.

![Auth](https://github.com/ivanpaulovich/jambo/blob/master/docs/images/Auth.PNG)

![Auth com Token](https://github.com/ivanpaulovich/jambo/blob/master/docs/images/Auth1.PNG)

3. Execute o projeto **Jambo.Producer.WebAPI** e clique no botão *Authorization* (topo direito da página).

Digite `bearer + valor_do_token` e clique em fechar. Algo assim:
![Autorizando](https://github.com/ivanpaulovich/jambo/blob/master/docs/images/Producer.PNG)
Chame os métodos para manutenção dos dados do Blog, Posts e Comentários.
![Enviando comandos](https://github.com/ivanpaulovich/jambo/blob/master/docs/images/Producer02.PNG)

2. Execute o projeto **Jambo.Consumer.Console** e garante que ele **contínua em execução**.

![Comsumer em execução](https://github.com/ivanpaulovich/jambo/blob/master/docs/images/Consumer.PNG)

4. Visualize suas modificações

![Queries](https://github.com/ivanpaulovich/jambo/blob/master/docs/images/Producer03.PNG)

#### Demo
* **Auth API**: http://jambo.westus.cloudapp.azure.com:7070/swagger/.
* **Producer**: http://jambo.westus.cloudapp.azure.com:7080/swagger/.
* **Consumer**: Executa em background neste servidor.

#### Próximos passos?
1. Publicar os containers no Azure.
2. Criar um CI/CD para atualizar os containers a cada commit.
3. Criar testes de unidade, testes automatizados.
4. Consumir serviços externos.
5. Implementação alternativa de barramento: Azure Event Hubs
6. Implementação alternativa de snapshot: Azure Cosmos DB
7. Implementar um HealthCheck

#### Pré-requisitos

* [Visual Studio 2017 + Update 3](https://www.visualstudio.com/en-us/news/releasenotes/vs2017-relnotes)
* [.NET SDK 2.0](https://www.microsoft.com/net/download/core)
* [Docker](https://docs.docker.com/docker-for-windows/install/) (Opcional)
* [Robomongo](https://robomongo.org/) (Opcional)

#### Agradecimentos
Obrigado aos amigos que me estimularam a criar este projeto e estão sempre contribuindo e dando feedback.
* [Vinicius Baldotto](https://github.com/Baldotto)
* [André Paulovich](https://github.com/andrepaulovich)
* André Mendes

Obrigado de verdade!

#### Deixe o seu feedback
Agradeço todo comentário sobre o projeto. Envie  suas dúvidas e sugestões no [Fórum](https://github.com/ivanpaulovich/jambo/issues).

#### Histórico de Versões
* 10/set/2017:
[![release](https://img.shields.io/github/release/ivanpaulovich/nixy.svg?style=flat-square)](https://github.com/ivanpaulovich/jambo/releases/latest)
