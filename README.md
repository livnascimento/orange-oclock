
<img src="./ProjetoMyTeDev/wwwroot/img/logo.png" width="150"/>

# Orange O'Clock

## Pré-visualização

<video controls>
    <source src="./ProjetoMyTeDev/wwwroot/video/preview.mp4" type="video/mp4">
</video>

## Tecnologias utilizadas

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![Bootstrap](https://img.shields.io/badge/bootstrap-%238511FA.svg?style=for-the-badge&logo=bootstrap&logoColor=white)
![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)
![JavaScript](https://img.shields.io/badge/javascript-%23323330.svg?style=for-the-badge&logo=javascript&logoColor=%23F7DF1E)

## Descrição

O Orange O'Clock é um programa desenvolvido para registrar as horas trabalhadas pelos funcionários em atividades específicas, conhecidas como Work Breakdown Structure (WBS).

## Diagramas

### Casos de Uso 

<img src="./ProjetoMyTeDev/wwwroot/img/diagramaCasosUso.jpg" />

### Diagrama de Classes

<img src="./ProjetoMyTeDev/wwwroot/img/MyTeClasses.jpg"/>


## Funcionalidades Principais:

### Admin

#### Gerenciamento de Departamentos

- Adicionar, visualizar, atualizar e excluir registros de departamentos.

- Filtrar departamentos por nome ou ID.

- Existem departamentos pré-configurados no banco que podem, também, ser gerenciados.

#### Gerenciamento de Funcionários

- O admin pode adicionar, visualizar, atualizar e excluir as WBS.

#### Gerenciar Wbs

- O admin pode adicionar, visualizar, atualizar e excluir as informações dos funcionários.

- Cada registro de funcionário contém informações como ID, nome, departamento e data de contratação.

- Filtrar WBS por código e descrição.

#### Gerenciamento de Cargos

- O admin pode adicionar, visualizar, atualizar e excluir os cargos.

- Filtrar cargos por nome ou ID.

- Existem departamentos pré-configurados no banco que podem, também, ser gerenciados.

#### Métricas dos funcionários

- O usuário consegue ver um relatório com as métricas dos registros de horas de todos os funcionários.

### User

#### Métricas

- O usuário consegue ver um relatório com suas próprias métricas de registro de horas.

### Funcionalidades comuns (admins e users)

#### Login

- É possível logar com e-mail e senha.

#### Gerenciar seu próprio registro de horas

- É possível adicionar, visualizar e editar o registro de horas.

#### Gerenciar sua própria senha

- É possível alterar a senha inserindo a antiga e confirmando a nova.

