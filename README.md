# Trabalho Sistemas Operacionais II - GB

Aluno: Bruno da Siqueira Hoffmann

Professor: Cristiano Bonato Both

Disciplina: Análise e Aplicação de Sistemas Operacionais

## Contextualização
O presente trabalho foi desenvolvido com o intuito de aprendizagem da estrutura da memória física e virtual. Para isso, foram desenvolvidos duas aplicações, uma frontend onde é possível verificar dados relacionados a execução de processos e o uso da memória, e uma API que possui a lógica de fato e sua camada de exposição dessa lógica.

Como domínio o trabalho contém algumas entidades, dentre elas:
- Memória física: Vai representar a memória física, contendo suas páginas.
- Memória virtual: Vai representar a memória virtual, que contém uma tabela de páginas que faz o mapeamento de memória virtual -> memória física.
- Processo: Vai representar o processo que demandará das páginas para execução.

Obs: No presente trabalho não foi considerado a estrutura de disco, apenas as memórias e os processos.

## Requisitos
Para executar o presente trabalho é preciso ter instalado na sua máquina as seguintes ferramentas:
- Node: https://nodejs.org/en/
- Dotnet 5: https://dotnet.microsoft.com/en-us/download/dotnet/5.0
- Quasar Cli: https://quasar.dev/start/quasar-cli


## Estruturação do Projeto
O projeto apresenta as seguintes pastas:
- backend
  - src
    - SistemasOperacionais
      - SistemasOperacionais.ControleMemoria: Contém a lógica de execução das memórias e criação dos processos.
      - SistemasOperacionais.ControleMemoria.Api: Contém a apresentação, ou seja, um meio para que aplicações externas se comuniquem com a lógica.
      - SistemasOperacionais.ControleMemoria.UnitTests: Contém os testes de unidade que garantem o funcionamento do sistema.
- frontend
  - controle-mem: Contém todo o desenvolvimento visual da aplicação

## Como Executar o Trabalho

Para executar o presente trabalho, é importante certificar-se que possuí todos os requisitos para o mesmo. Como primeiro passo é necessário executar a API.

```sh
cd backend/src/SistemasOperacionais/SistemasOperacionais.ControleMemoria.Api
dotnet run
```

Em seguida execute o sistema frontend.

```sh
cd frontend/src/controle/mem
quasar dev
```

Caso tenha interesse em executar o projeto de testes:

```sh
cd backend/src/SistemasOperacionais/SistemasOperacionais.ControleMemoria.UnitTests
dotnet test
```


## Tecnologias Usadas

O presente trabalho utilizou das seguintes tecnologias abaixo:
- Vue Js: para parte visual.
- Swagger: para facilitar a visualização do back-end.
- Quasar: para parte visual.
- Axios: para fazer as integrações entre front-end e back-end.
- Dotnet 5: para parte de API.
- Nunit: para a parte de testes