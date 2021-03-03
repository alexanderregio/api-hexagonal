# Hexagonal-WebApi
Modelo de projeto apoiado na Arquitetura Hexagonal - DDD

## Core

* ### Domain
Definição do negócio. Contém as interfaces dos <i>adapters</i> e <i>services</i> além dos modelos e exceções do negócio.

* ### Application
Implementação da camada de serviços que fornece às aplicações os recursos para serem consumidos.

* ### Application.Tests
Implementação dos testes sobre os <i>services</i>.

## Infra
Implementação dos <i>adapters</i> que fazem interface com recursos externos ao domínio (banco de dados, leitura de arquivos, consumo de outras API's)

## Presentation
Aplicação final que irá consumir os <i>services</i> do domínio.
