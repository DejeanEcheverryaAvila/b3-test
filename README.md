# CDB - B3

## Descrição 📝

Este projeto C# .NET Core Web API foi desenvolvido para o teste da B3. Ele implementa uma calculadora de Certificado de Depósito (CDB), demonstrando boas práticas de desenvolvimento e recursos técnicos relevantes.

## Características Técnicas 🔎

* **.NET Core Web API:** Framework moderno e robusto para construção de APIs RESTful.
* **Versionamento de API:** Utiliza o pacote `Microsoft.AspNetCore.Mvc.Versioning` para permitir o controle de versões da API, garantindo compatibilidade com diferentes clientes.
* **Swagger/OpenAPI:** Documentação interativa da API gerada com `Swashbuckle.AspNetCore`, facilitando a compreensão e o uso da API por desenvolvedores.
* **Testes Unitários:** Utiliza o framework xUnit para garantir a qualidade e a confiabilidade do código através de testes unitários abrangentes.
* **Injeção de Dependência:** Implementa o padrão de injeção de dependência para facilitar a testabilidade e a manutenção do código.
* **Boas Práticas de Código:** O código segue boas práticas de organização, nomenclatura e documentação, tornando-o mais legível e fácil de entender.

## Estrutura do Projeto 📂

* **Controllers:** Contém o `CdbController`, responsável por expor o endpoint para cálculo de CDB.
* **Interfaces:** Define a interface `ICdbCalculator`, promovendo o baixo acoplamento e facilitando a implementação de diferentes estratégias de cálculo.
* **Models:** Define os modelos `CdbCalculationRequestModel` e `CdbCalculationResultModel`, representando os dados de entrada e saída da API.
* **Services:** Implementa o serviço `CdbCalculatorService`, responsável pela lógica de cálculo do CDB.

## Como usar 🚀

1. **Clone o repositório:**
   ```bash
   git clone git@github.com:DejeanEcheverryaAvila/b3-test.git
   ```

 2. **Restaure as dependências:**
   ```bash
   dotnet restore
   ```


 3. **Execute o projeto:**
   ```bash
   dotnet run
   ```

A documentação da API ficará disponível em: https://localhost:5001/swagger 



**Cobertura de testes**

![image](https://github.com/user-attachments/assets/b1843e1e-fd64-4b50-8734-1e81dd2605fb)
![image](https://github.com/user-attachments/assets/f94a6142-a721-44df-88dc-404da7676a36)
![image](https://github.com/user-attachments/assets/97735dee-480f-48ea-bbbd-f8a0ccbe79de)
![image](https://github.com/user-attachments/assets/0531dd19-3c1d-4343-850c-aaa741b0f47b)

![image](https://github.com/user-attachments/assets/d4d34891-fda9-4ff7-9dd5-a21c3280d264)


** Obs. ❓:**
O relatório contendo a descrição dos resultados dos testes pode ser consultado em CDB-B3.Tests/coverage-report

