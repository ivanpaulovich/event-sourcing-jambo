Projeto de referência em Domain-Driven-Design com implementação de Aggregates + Event Sourcing + CQRS.

#### Domínio
*Em breve...*

#### Aplicações desta Solução
* Producer: Web API que recebe os comandos de edição de conteúdo, produz Eventos de Domínio e publica as mensagens em um tópico no Kafka.
* Consumer: Aplicativo Console que consome as mensagens do Kafka, deserializa em Eventos de Domínio e aplica nas agregações persistindo no MongoDB o novo estado.  
* Auth: Web API que gera tokens de autenticação para acesso ao WebAPI.

#### Por onde começar?
Há duas formas de iniciar as três aplicações. O jeito fácil que é resolver os [requisitos](https://github.com/ivanpaulovich/jambo/#requisitos), definir o projeto inicial como sendo o `docker-compose` e então apertar `Ctrl+F5` para executar todas as aplicações. Se tudo estiver correto, digite `docker ps` no terminal para verificar em quais portas cada aplicação está executando. Será algo assim:

![Enviando comandos](https://github.com/ivanpaulovich/jambo/blob/master/images/Docker-PS.PNG)

A partir daí basta acessar:
* Auth em http://localhost:32775
* Producer em http://localhost:32776

A outra opção é inicializar aplicação por aplicação, seguindo o seguintes passos:

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

#### Demo
*Em breve...*

#### Próximos passos?
1. Publicar os containers no Azure.
2. Criar um CI/CD para atualizar os containers a cada commit.
3. Criar testes de unidade, testes automatizados.
4. Consumir serviços externos.

#### Requisitos

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
* 12/set/2017:
*Em breve...*
