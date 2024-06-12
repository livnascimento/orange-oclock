<img src="./ProjetoMyTeDev/wwwroot/img/logo.png" width="150"/>

# Orange O'Clock

## Pré-visualização

![](./ProjetoMyTeDev/wwwroot/img/preview.gif)

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

## Pré-requisitos

- Visual Studio
- Microsoft SQL Server
- .NET

## Como testar?

- No Package Manager Console do Visual Studio, use o comando abaixo para criar o banco de dados local:

    ``` bash
    update-database
    ```

- Execute a aplicação e logue com o usuário padrão:

    - **E-mail**: `admin@avanade.com`
    - **Senha**: `Admin2024@` 

## Critérios e Regras

- Validação das credenciais de login.
- Validação do preenchimento de horas.
- Restrições de caracteres para códigos de WBS.
- Exigência de pelo menos 8 horas preenchidas por dia útil.
- Navegação de quinzenas não anterior a 01/01/2024.

## Conheça e contate nossa equipe

<code>
<div style="display: flex; justify-content: space-between;">
<div style="text-align: center;">

<img src="./ProjetoMyTeDev/wwwroot/img/deb.jpg" height=100 style="border-radius: 50%;" />

### Déborah Brodowski

_Assoc, Full-Stack Developer at Avanade_

[![LinkedIn](https://img.shields.io/badge/deborahpazb-%230077B5.svg?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/deborahpazb)
[![GitHub](https://img.shields.io/badge/deborahpaz-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)](https://github.com/deborahpaz)

</div>
<div style="text-align: center;">

<img src="./ProjetoMyTeDev/wwwroot/img/isabella.jpg" height=100 style="border-radius: 50%;" />

### Isabella Coutinho

_Assoc, Full-Stack Developer at Avanade_

[![LinkedIn](https://img.shields.io/badge/isaaregina-%230077B5.svg?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/isaaregina)
[![GitHub](https://img.shields.io/badge/isaaregina-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)](https://github.com/isaaregina)
</div>
</div>

<div style="display: flex; justify-content: space-between;">
<div style="text-align: center;">

<img src="./ProjetoMyTeDev/wwwroot/img/giovanna.jpg" height=100 style="border-radius: 50%;" />

### Giovanna Camelo

_Assoc, Full-Stack Developer at Avanade_

[![LinkedIn](https://img.shields.io/badge/giovanna--camelo--0220992a2-%230077B5.svg?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/giovanna-camelo-0220992a2)
[![GitHub](https://img.shields.io/badge/Giovanna--Camelo-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)](https://github.com/Giovanna-Camelo)
</div>

<div style="text-align: center;">
<img src="./ProjetoMyTeDev/wwwroot/img/livia.jpg" height=100 style="border-radius: 50%;" />

### Lívia Nascimento


_Assoc, Full-Stack Developer at Avanade_

[![LinkedIn](https://img.shields.io/badge/liviarnascimento-%230077B5.svg?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/liviarnascimento)
[![GitHub](https://img.shields.io/badge/livnascimento-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)](https://github.com/livnascimento)
</div>
</div>

<div style="text-align: center;">

<img src="./ProjetoMyTeDev/wwwroot/img/zandra.jpg" height=100 style="border-radius: 50%;" />

### Zandra Vieitez

_Assoc, Full-Stack Developer at Avanade_

[![LinkedIn](https://img.shields.io/badge/zandravieitez-%230077B5.svg?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/zandravieitez)
[![GitHub](https://img.shields.io/badge/Zvieitez-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)](https://github.com/Zvieitez)

</div>
</code>

## Contribuições

O nosso projeto é vivo e ainda temos muito a implementar, então ideias são muito bem-vindas! Caso identifique qualquer erro ou oportunidade de melhoria, pedimos que [nos contate](#conheça-e-contate-nossa-equipe) para bater um papo sobre! 

## Agradecimentos

Agradecemos à Avanade por nos disponibilizar o treinamento com a Impacta para que pudéssemos desenvolver um projeto tão completo, além de nos preparar muito mais para os desafios que virão. 

Também agradecemos ao nosso professor [Juan Pablo](https://www.linkedin.com/in/juan-pablo-santos-22889963) que nos acompanhou durante os últimos dois meses.

---

Apreciamos muito sua visita ao nosso projeto! 🧡

