Projeto de referência em Domain-Driven-Design com implementação de Aggregates + Event Sourcing.

#### Aplicações desta Solução
* Producer: Web API que recebe os comandos de edição de conteúdo, produz Eventos de Domínio e publica as mensagens em um tópico no Kafka.
  
* Consumer: Aplicativo Console que consome as mensagens do Kafka, deserializa em Eventos de Domínio e aplica nas agregações persistindo no MongoDB o novo estado.
  
* Auth: Web API Gera tokens de autenticação para acesso ao Jambo.Producer.WebAPI.

#### Demo

* Producer
IMAGEM 1
* Consumer
IMAGEM 2
* Auth
IMAGEM 3

#### Requisitos

* [Visual Studio 2017 + Update 3](https://www.visualstudio.com/en-us/news/releasenotes/vs2017-relnotes).
* [.NET SDK 2.0](https://www.microsoft.com/net/download/core).
* [Docker](https://docs.docker.com/docker-for-windows/install/) (Opcional)
* [Robomongo](https://robomongo.org/) (Opcional)
