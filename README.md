Projeto de referência em Domain-Driven-Design com implementação de Aggregates + Event Sourcing + CQRS.

#### Domínio
Imagem do Domínio

#### Aplicações desta Solução
* Producer: Web API que recebe os comandos de edição de conteúdo, produz Eventos de Domínio e publica as mensagens em um tópico no Kafka.
* Consumer: Aplicativo Console que consome as mensagens do Kafka, deserializa em Eventos de Domínio e aplica nas agregações persistindo no MongoDB o novo estado.  
* Auth: Web API que gera tokens de autenticação para acesso ao WebAPI.

#### Demo

* Producer
IMAGEM 1
* Consumer
IMAGEM 2
* Auth
IMAGEM 3

#### Por onde começar?
1. Execute o projeto AverbacaoOnline.Auth.WebAPI e chame o método *Account/Token* com qualquer usuário e senha. *Guarde este token*.
2. Execute o projeto AverbacaoOnline.Consumer.Console e garante que ele *contínua em execução*.
3. Execute o projeto AverbacaoOnline.Producer.WebAPI e clique no botão Authorization (topo direito da página).
  - Digite "bearer + 'valor do token'" e clique em fechar.
  - Chame os métodos para manutenção dos dados do Blog, Posts e Comentários.

#### Requisitos

* [Visual Studio 2017 + Update 3](https://www.visualstudio.com/en-us/news/releasenotes/vs2017-relnotes)
* [.NET SDK 2.0](https://www.microsoft.com/net/download/core)
* [Docker](https://docs.docker.com/docker-for-windows/install/) (Opcional)
* [Robomongo](https://robomongo.org/) (Opcional)
