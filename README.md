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
Se os requisitos estiverem atendidos basta apertar `F5` no projeto `docker-compose` e as três aplicações são executadas.
Ou se você preferir pode chamar uma a uma conforme os passos abaixo:

1. Execute o projeto **Jambo.Auth.WebAPI** e chame o método *Account/Token* com qualquer usuário e senha. *Guarde este token*.
![Auth](https://github.com/ivanpaulovich/jambo/blob/master/images/Auth.PNG)
![Auth com Token](https://github.com/ivanpaulovich/jambo/blob/master/images/Auth1.PNG)

3. Execute o projeto **Jambo.Producer.WebAPI** e clique no botão *Authorization* (topo direito da página).
Digite `bearer + valor_do_token` e clique em fechar. Algo assim:
![Autorizando](https://github.com/ivanpaulovich/jambo/blob/master/images/Producer.PNG)
Chame os métodos para manutenção dos dados do Blog, Posts e Comentários.
![Enviando comandos](https://github.com/ivanpaulovich/jambo/blob/master/images/Producer02.PNG)

2. Execute o projeto **Jambo.Consumer.Console** e garante que ele **contínua em execução**.
![Comsumer em execução](https://github.com/ivanpaulovich/jambo/blob/master/images/Consumer.PNG)

4. Visualize suas modificações
![Queries](https://github.com/ivanpaulovich/jambo/blob/master/images/Producer03.PNG)

#### Requisitos

* [Visual Studio 2017 + Update 3](https://www.visualstudio.com/en-us/news/releasenotes/vs2017-relnotes)
* [.NET SDK 2.0](https://www.microsoft.com/net/download/core)
* [Docker](https://docs.docker.com/docker-for-windows/install/) (Opcional)
* [Robomongo](https://robomongo.org/) (Opcional)
