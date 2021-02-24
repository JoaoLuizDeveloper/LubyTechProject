import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
            <h1># Desafio Back-end Luby Software</h1>
            <p>Primeiramente, obrigado pelo seu interesse em trabalhar na Luby. Somos uma f�brica de software com mais de 110 desenvolvedores e 15 anos de mercado. Temos atua��o em mais de 5 pa�ses e estamos em busca de talentos para integrar o nosso time no desenvolvimento .NET de forma 100% remota.</p>
            <h2>#### Premissas:</h2>
            <p>
                - Criar uma API usando .NET CORE.
                - O banco de dados pode ser  MySql ou SQL Server.
            </p>
            <h2>#### Teste:</h2>
            <p>
                Desenvolver um servi�o que seja capaz de gerar um lan�amento de horas.
                - Um lan�amento de horas � composta por pelo menos **id**, **data inicio**, **data fim**, **desenvolvedor**.
            </p>
            <h2>#### Sua tarefa � desenvolver os servi�os REST abaixo:</h2>
            <p>
                - CRUD para desenvolvedor (Ser� considerado um diferencial pagina��o na listagem)
                - CRUD de projeto (Ser� considerado um diferencial pagina��o na listagem)
                - Criar um lan�amento de hora
                - Retornar ranking dos 5 desenvolvedores da semana com maior m�dia de horas trabalhadas.
            </p>
            <h2>#### Algumas regras � serem consideradas</h2>
            <p>
                - Um desenvolvedor s� pode lan�ar horas em projetos que ele esteja vinculado
                - Um desenvolvedor s� pode lan�ar horas se estiver autenticado (Autentica��o JWT com expira��o de 5 minutos)
                - Valida��es de integridade e duplicidade
                - Antes de cadastrar um desenvolvedor, devemos validar se seu CPF � v�lido, para essa valida��o, pode ser usado o endpoint (https://run.mocky.io/v3/067108b3-77a4-400b-af07-2db3141e95c9)
                - Na confirma��o do lan�amento de horas, uma notifica��o � enviada, e o servi�o pode estar indispon�vel/inst�vel. Para enviar a notifica��o, use o endpoint abaixo (https://run.mocky.io/v3/a1b59b8e-577d-4996-a4c5-56215907d9dd)
            </p>
            <h2>#### Instru��es:</h2>
            <p>
                1. Realizar `fork` deste projeto.
                2. Desenvolver em cima do seu `fork`.
                3. Ap�s finalizar, realizar o `pull request`.
                4. Atualize esse README.md com sua identifica��o no fim do arquivo
                5. Fique � vontade para perguntar qualquer d�vida aos recrutadores.
            </p>
            <h2>#### E por fim:</h2>
            <p>
                - Gostar�amos de ver o uso do controle de vers�o.
                - Entendimento de design patterns, OO, conceitos de SOLID, e outros relacionados
                - Entendimento de OO, conceitos de SOLID, e outros relacionados
                - Reuso do c�digo
                - Vamos avaliar a maneira que voc� escreveu seu c�digo, a solu��o apresentada.
                - Caso encontre algum impedimento no decorrer do desenvolvimento, entregue da maneira que preferir e fa�a uma explica��o sobre o impedimento.
                - Avaliaremos tamb�m sua postura, honestidade e a maneira que resolve problemas.
            </p>

            <h2>#### Desej�vel (Ser� considerado um diferencial)</h2>
            <p>
                - Automa��o de testes - unit�rios e integra��o.
                - Configurar o Swagger para termos acesso a documenta��o da API.
                - � de suma import�ncia se utilizar das melhores pr�ticas para um projeto seguro e organizado, como a utiliza��o de controllers, services, factory, middlewares, controle de exce��es, utiliza��o de um ORM ou MicroORM (Object Relational Mapper) para opera��es de banco de dados.
                - Criar um client WEB para consumir essa API
            </p>
      </div>
    );
  }
}
