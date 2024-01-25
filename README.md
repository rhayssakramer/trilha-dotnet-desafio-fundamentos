# DIO - Trilha .NET - Desafio Fundamentos

Esse foi o meu `Primeiro Projeto na Linguagem de Programação C#`e também o primeito desafio da trilha `.NET` do Decola Tech Avanade 4ª Edição 2024. 

## Versões
- [versão 1.0](https://github.com/rhayssakramer/trilha-dotnet-desafio-fundamentos.git) código em terminal original do desafio de Fundamentos com `C#` e `.NET` da DIO e Decola Tech 2024, implementado pelo professor Leonardo Buta da DIO, com lacunas para serem preenchidas pelos alunos.  
- [versão 1.1](https://github.com/rhayssakramer/trilha-dotnet-desafio-fundamentos.git) código em terminal implementado para conclusão do desafio de Fundamentos `C#`e `.NET` da Bootcamp do Decola Tech 2024.
- [versão 2.0](https://github.com/rhayssakramer/trilha-dotnet-desafio-fundamentos.git) código em terminal com melhorias e novos incrementos do desafio de Fundamentos `C#`e `.NET` para apresentação ao Decola Tech 2024.`
- [versão 3.0]() **Em andamento** - implementação de melhorias para transformar o projeto em API com implementação de Frontend (React) utilizando o ASP.NET.

## Resultado do Projeto
<img>

## Planejamento do Projeto
Para implementação de melhorias da [versão 2.0](https://github.com/rhayssakramer/trilha-dotnet-desafio-fundamentos.git) foi utilizado a plataforma Miro para desenvolver a lógica de programação e o processo de todo o código terminal.  
[Acesse aqui!](https://miro.com/welcomeonboard/WThoVHduTURrNXRucXd3ckFJZlJXYUpKdXBiSU1vbWptYURRaFVncEREVlJWRWxRQktBQ2h4NlVrSzZnSTFQc3wzNDU4NzY0NTc2Mjc1ODc1MDE4fDI=?share_link_id=85434865934)

Para implementação de API da [versão 3.0]() **Em andamento**, está sendo utilizado o Figma para elaboração de telas como base ao Frontend.  
[Acesse aqui!](https://www.figma.com/file/elOMqzYfEtznfTvrO774mg/Park-Olinda-Estacionamento?type=design&node-id=0%3A1&mode=design&t=zQLnpJSIFGiXoWFM-1)

## Tecnologias Utilizadas

| Linguagens de Programação | Ferramentas e Tecnologias |
| :-----------------: | :-----------------------: |
| <img height="40" src="https://github.com/rhayssakramer/rhayssakramer/blob/main/assets/icon/C%23.svg"> <img height="40" src="https://github.com/rhayssakramer/rhayssakramer/blob/main/assets/icon/dotnet.svg"> <img height="40" src="https://github.com/rhayssakramer/rhayssakramer/blob/main/assets/icon/NodeJS-Dark.svg"> | <img height="40" src="https://github.com/rhayssakramer/rhayssakramer/blob/main/assets/icon/VSCode-Dark.svg">

## Atualizações
[versão 1.0](https://github.com/rhayssakramer/trilha-dotnet-desafio-fundamentos.git) 
```
Código em terminal original.
```
[versão 1.1](https://github.com/rhayssakramer/trilha-dotnet-desafio-fundamentos.git)
```
Código em terminal implementado, foi utilizado uma lista para incluir as placas dos veículos adicionados, e no método iterado para a inclusão. A conversão de horas do tempo de permanência em valores a ser cobrado. Método iterado para remover a placa da lista ao finalizar o pagamento. E método para listar as placas inseridas, utilizando o foreach para busca.
```
[versão 2.0](https://github.com/rhayssakramer/trilha-dotnet-desafio-fundamentos.git) 
```
Código em terminal com melhorias e novos incrementos foi inserido duas novas classes que serão os objetos do programa, Cliente e Veiculo com suas propriedades e valores. Na classe Estacionamento fora implementado novos menus e métodos para maior interação com usuário, gerador de código aleatório, buscas de placas e diferentes listas.
```

[versão 3.0]() **Em andamento** 

## Requisitos do Projeto

#### Projeto - Sistema de Estacionamento

- Desafio de projeto: Para este desafio, foi preciso utilizar os conhecimentos adquiridos no módulo de fundamentos, da trilha .NET da DIO.

- Contexto: Na proposta desafio o desenvoledor foi contratado para construir um sistema para um estacionamento, que será usado para gerenciar os veículos estacionados e realizar suas operações, como por exemplo adicionar um veículo, remover um veículo (e exibir o valor cobrado durante o período) e listar os veículos.

- Proposta: Foi preciso construir uma classe chamada "Estacionamento", conforme o diagrama abaixo:

<img width="200" src="https://github.com/rhayssakramer/trilha-dotnet-desafio-fundamentos/blob/main/diagrama_classe_estacionamento.png">

#### A classe contém três variáveis, sendo:

- precoInicial: Tipo decimal. É o preço cobrado para deixar seu veículo estacionado.
- precoPorHora: Tipo decimal. É o preço por hora que o veículo permanecer estacionado.
- veiculos: É uma lista de string, representando uma coleção de veículos estacionados. Contém apenas a placa do veículo.

#### A classe contém três métodos, sendo:

- AdicionarVeiculo: Método responsável por receber uma placa digitada pelo usuário e guardar na variável veiculos.
- RemoverVeiculo: Método responsável por verificar se um determinado veículo está estacionado, e caso positivo, irá pedir a quantidade de horas que ele permaneceu no estacionamento. Após isso, realiza o seguinte cálculo: precoInicial * precoPorHora, exibindo para o usuário.
- ListarVeiculos: Lista todos os veículos presentes atualmente no estacionamento. Caso não haja nenhum, exibir a mensagem "Não há veículos estacionados".

#### Por último, deverá ser feito um menu interativo com as seguintes ações implementadas:
1. Cadastrar veículo
2. Remover veículo
3. Listar veículos
4. Encerrar

#### Solução
O código foi fornecido pela metade, e a função do desenvolvedor era dar continuidade obedecendo as regras descritas acima, para que no final, se tenha um programa funcional.

#### Especificações de conteúdo:
- Indique um nome para seu negócio.
- Sua composição de estacionamento (cadastrar, remover, listar e encerrar).
- O programa de conter classe e métodos.
- A saída deve exibir a placa do veículo removido e o valor a ser pago.

#### Especificações técnicas:
- Todos os dados são capturados pelo console (entrada do usuário).
- Exibir mensagens apropriadas a cada situação (você tem que interagir com o usuário).
- O usuário tem a opção de não escolher nada e encerrrar o sistema.
- Utilizar decimais e conversores nos itens.
- Utilizar estruturas como: `if / else`, `for`, `foreach` e `switch`

### Instruções de Uso

1. Clone ou baixe este repositório para a sua máquina local.

2. Certifique-se de ter o [Node.js](https://nodejs.org/en/download/current) e [.NET 8.0](https://dotnet.microsoft.com/pt-br/download) instalado em sua máquina.

3. Abra o terminal e navegue até o diretório raiz do projeto.

4. Para executar, utilize o comando:
```
dotnet run
```

### Créditos
Este projeto foi desenvolvido como parte de avaliação de desafio do Decola Tech Avanade 4ª Edição 2024, para avaliar o ensinado na bootcamp de fundamentos da linguagem de programação `C#`.

*Nota: Este projeto é apenas para fins educacionais e não possui nenhuma afiliação oficial com a franquia DIO ou Avanade ou suas empresas associadas.*

## Autora:
<table>
  <tr>
    <td>
      <img width="80px" align="center" src="https://github.com/rhayssakramer/rhayssakramer/blob/main/assets/images/logo.png"/>
    </td>
    <td align="left">
      <a href="https://github.com/rhayssakramer">
        <span><b>Rhayssa Kramer</b></span>
      </a>
      <br>
      <span>Desenvolvedora Full Stack</span>
    </td>
  </tr>
</table>

##
<div align="center">Feito por <a href="https://github.com/rhayssakramer">@devrhakramer</a>.</div>