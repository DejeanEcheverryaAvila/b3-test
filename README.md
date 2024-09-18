# CDB - B3

## Tabela de Conteúdos 📖
- [CDB - B3](#cdb---b3)
  - [Tabela de Conteúdos 📖](#tabela-de-conteúdos-)
  - [Descrição 📝](#descrição-)
  - [Pré-Requisitos 📋](#pré-requisitos-)
  - [Descrição 📝](#descrição--1)
  - [Características Técnicas da API 🔎](#características-técnicas-da-api-)
  - [Estrutura da API 📂](#estrutura-da-api-)
  - [Como usar 🚀](#como-usar-)
  - [Obs. ❓](#obs-)
  - [Características Técnicas do Frontend 🔎](#características-técnicas-do-frontend-)
  - [Estrutura do Frontend: 📂](#estrutura-do-frontend-)
  - [Como usar 🚀](#como-usar--1)
  - [Obs. ❓](#obs--1)
## Descrição 📝

Esse projeto foi desenvolvido para o teste da B3. Ele implementa uma calculadora de Certificado de Depósito (CDB), demonstrando boas práticas de desenvolvimento e recursos técnicos relevantes.

## Pré-Requisitos 📋

Para executar este projeto, você precisará ter instalado:

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download) - Para o backend.
- [Node.js](https://nodejs.org/) (versão 14.x ou superior) - Para o frontend.
- [Angular CLI](https://angular.io/cli) (versão 16.x ou superior) - Para compilar e servir o frontend.


## Descrição 📝
...


## Características Técnicas da API 🔎

* **.NET Core Web API:** Framework moderno e robusto para construção de APIs RESTful.
* **Versionamento de API:** Utiliza o pacote `Microsoft.AspNetCore.Mvc.Versioning` para permitir o controle de versões da API, garantindo compatibilidade com diferentes clientes.
* **Swagger/OpenAPI:** Documentação interativa da API gerada com `Swashbuckle.AspNetCore`, facilitando a compreensão e o uso da API por desenvolvedores.
* **Testes Unitários:** Utiliza o framework xUnit para garantir a qualidade e a confiabilidade do código através de testes unitários abrangentes.
* **Injeção de Dependência:** Implementa o padrão de injeção de dependência para facilitar a testabilidade e a manutenção do código.
* **Boas Práticas de Código:** O código segue boas práticas de organização, nomenclatura e documentação, tornando-o mais legível e fácil de entender.

## Estrutura da API 📂

* **Controllers:** Contém o `CdbController`, responsável por expor o endpoint para cálculo de CDB.
* **Interfaces:** Define a interface `ICdbCalculator`, promovendo o baixo acoplamento e facilitando a implementação de diferentes estratégias de cálculo.
* **Models:** Define os modelos `CdbCalculationRequestModel` e `CdbCalculationResultModel`, representando os dados de entrada e saída da API.
* **Services:** Implementa o serviço `CdbCalculatorService`, responsável pela lógica de cálculo do CDB.

## Como usar 🚀

1. **Clone o repositório:**
   ```bash
   git clone git@github.com:DejeanEcheverryaAvila/b3-test.git
   cd b3-test/CDB-B3
   ```

 2. **Restaure as dependências da API:**
   ```bash
   dotnet restore
   ```


 3. **Execute a API:**
   ```bash
   dotnet run
   ```

A documentação da API ficará disponível em: https://localhost:5001/swagger



**Cobertura de testes da API**

![image](https://github.com/user-attachments/assets/b1843e1e-fd64-4b50-8734-1e81dd2605fb)
![image](https://github.com/user-attachments/assets/f94a6142-a721-44df-88dc-404da7676a36)
![image](https://github.com/user-attachments/assets/97735dee-480f-48ea-bbbd-f8a0ccbe79de)
![image](https://github.com/user-attachments/assets/0531dd19-3c1d-4343-850c-aaa741b0f47b)

![image](https://github.com/user-attachments/assets/d4d34891-fda9-4ff7-9dd5-a21c3280d264)


## Obs. ❓
O relatório contendo a descrição dos resultados dos testes pode ser consultado em CDB-B3.Tests/coverage-report

## Características Técnicas do Frontend 🔎
* **Angular Framework:** Angular é conhecido pela sua eficiência em criar aplicações dinâmicas e responsivas.
* **Gestão de Estados com RxJS:** Aproveita a biblioteca RxJS para gerenciar estados e fluxos de dados de forma reativa
* **Formatação Monetária:** Implementa ng2-currency-mask para manipular e formatar campos de entrada de dados monetários, garantindo que as interações com valores financeiros sejam precisas e amigáveis ao usuário.
* **Testes Unitários:** Utiliza Jasmine (~4.6.0) e Karma (~6.4.0) para realizar testes unitários, garantindo a qualidade e a confiabilidade do código. 
* **Tipagem Forte:** Uso do Typescript
* **Roteamento Dinâmico:** Configurações de roteamento feitas com @angular/router, permitindo a criação de uma navegação  modular dentro da aplicação.
  
## Estrutura do Frontend: 📂
* **src/app:** Diretório contendo o código do projeto


## Como usar 🚀
1. Após clonar o repositório, vá até o diretório do frontend:
  ```bash
   cd b3-frontend-main
  ```
2. Instale as dependências necessárias:
  ```
    bash
    npm install
  ```
3. Execute o projeto:
  ```
    bash
    ng serve --ssl
  ```

4. Copie a URL HTTPS e abra em seu navegador.

## Obs. ❓
Para instalar as dependências do projeto, é necessário ter o Node instalado em seu sistema.