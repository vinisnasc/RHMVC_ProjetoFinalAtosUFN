# PROJETO FINAL ACADEMIA .NET 

## Gestão e controle de recursos humanos
Projeto de conclusão do curso Academia .Net, idealizado entre a parceria da Atos com a UFN e lecionado pelos professores Fabricio Londero e Ricardo Frohlich.
Meu objetivo é de criar um sistema de ERP(“Enterprise Resource Planning”) focado no controle de colaboradores, onde o administrador da empresa ou o funcionário de recursos humanos terá a possibilidade de:
- Criar e editar novos departamentos;
- Criar e editar novas funções, assim como, alterar salários, levando em conta de que, se existe funcionário ativo é impossível abaixar salário;
- Cadastrar novos funcionários e editar seus dados pessoais;
- Envio de e-mail para informar inicio de atividades laborais;
- Demissão de funcionários;
- Registro de férias;
- Registro de pagamentos;
- Registro de décimo terceiro;
- Exportação de dados de pagamentos para documento exterior a ser enviado ao financeiro.  
Obs.: Todos os calculos no momento estão sendo realizados sem encargos, para que em futuras melhorias, seja incluso sistema contábil, onde os profissionais deste setor informarão as taxas de descontos.

## Tecnologias Utilizadas:
- .NET 6.0;  
- Asp .Net MVC;  
- Microsoft SQL Server;  
- Entity Framework Core;  
- AutoMapper;  
- Refit;    
- Git.  

## UserStories: 

### ÉPICO: GD – GERENCIAMENTO DE DEPARTAMENTOS

GD1: Eu, como gerente de recursos humanos, necessito cadastrar novos departamentos
Critério de aceite: Necessário persistir no banco de dados as informações de nome de departamento e de subdepartamento. Obs.: Um nome de departamento e de subdepartamento não pode ter menos de 2 caracteres e mais de 50. Não pode ser cadastrado dois departamentos com o mesmo nome e mesmo subdepartamento.

GD2: Eu, como gerente de recursos humanos, necessito alterar nomes de departamentos devido a digitação errada ao cadastrar
Critério de aceite: Deixar a opção de realizar a alteração de nome de departamento e de subdepartamento, cumprindo as exigências do GD1.

GD3: Eu, como gerente de recursos humanos, necessito uma visualização de todos os departamentos cadastrados e da quantidade de funcionários nele existente.
Critério de aceite: Visualização de todos os departamentos em ordem de quantidade de funcionários cadastrados.

GD4: Eu, como gerente de recursos humanos, necessito uma visualização com os funcionários cadastrados em cada departamento.
Critério de aceite: Visualização de todos os funcionários ativos no departamento selecionado, informando número de registo, nome e função.

### ÉPICO: GF - GERENCIAMENTO DE FUNÇÕES

GF1: Eu, como gerente de recursos humanos, necessito cadastrar novas funções
Critério de aceite: Necessário persistir no banco de dados as informações de nome da função e o salário designado a ela. Obs.: Um nome de função não pode ter menos de 4 caracteres e mais de 50. Não pode ser cadastrado duas funções com o mesmo nome.

GF2: Eu, como gerente de recursos humanos, necessito alterar nomes de funções devido a digitação errada ao cadastrar
Critério de aceite: Deixar a opção de realizar a alteração somente do nome da função, cumprindo as exigências do GF1.

GF3: Eu, como gerente de recursos humanos, necessito a alteração de salário das funções
Critério de aceite: Deixar a opção de realizar a alteração de salário de uma função, levando em consideração que, se existe funcionário cadastrado com a função em questão, seja impossível realizar uma alteração abaixo do valor já existente.

GF4: Eu, como gerente de recursos humanos, necessito aumentar o salário de todos os funcionários, seja por bonificação ou por dissídio coletivo.
Critério de aceite: Realizar a alteração de salário de todas as funções registradas, aceitando somente aumento de valor, seja ele fixo, ou percentual.

GF5: Eu, como gerente de recursos humanos, necessito uma visualização de todas as funções cadastradas e da quantidade de funcionários a elas resignadas.
Critério de aceite: Visualização de todas as funções e seus salários, em ordem de quantidade de funcionários cadastrados.

GF6: Eu, como gerente de recursos humanos, necessito uma visualização com os funcionários cadastrados em cada função.
Critério de aceite: Visualização de todos os funcionários ativos no departamento selecionado, informando número de registo, nome e departamento.

### ÉPICO: CC - CADASTRO DE COLABORADORES

CC1: Eu, como gerente de recursos humanos, necessito acesso a cadastro de funcionários.
Critério de aceite: Necessário persistir no banco de dados as informações de dados pessoais do funcionário (Nome, Nome Social, CPF, RG, Data de nascimento, E-mail, Endereço (Cep, número de residência e complemento), Conta bancaria(Código do Banco, Agencia e número da conta)), e seus dados empresariais (número de registro – gerado automático, data de admissão, função e departamento).	
Observação: Não deve ser possível cadastrar o mesmo funcionário duas vezes caso exista um registro ativo.

CC2: Eu, como gerente de recursos humanos, solicito que, ao cadastrar um funcionário, ele seja comunicado sobre sua admissão.
Critério de aceite: Enviar e-mail ao funcionário que foi cadastrado informando sua data de admissão.

CC3: Eu, como gerente de recursos humanos, necessito alterar os dados dos funcionários.
Critério de aceite: Necessário realizar a alteração de todos os dados do funcionário, exceto a data de admissão no caso dela ser posterior a data da alteração e do número de registro.

CC4: Eu, como gerente de recursos humanos, necessito demitir um funcionário.
Critério de aceite: Informar a data de demissão, e ao demitir, gerar documento para ser enviado ao setor de financeiro para pagamento. O documento deverá conter:	
- Data de demissão;	
- Data de pagamento (10 dias após a data de demissão);	
- Valor do salário (salário / 30 x quantidade de dias trabalhados no mês da demissão);
- Valor do 13º (salário / 12 * quantidade de meses devidos-para mais informações ver GP2);	
- Valor das férias (salário / 12 * quantidade de meses devidos-para mais informações ver GP3);
- Valor do 1/3 de férias (Valor das férias / 3);

### GP – GERENCIADOR DE PAGAMENTOS

GP1: Eu, como gerente de recursos humanos, necessito gerar a folha de pagamento, informando a data de pagamento.
Critério de aceite: Gerar documento que será enviado ao setor de financeiro, contendo nome do funcionário, seus dados bancários, e o valor que será pago a ele. O valor deverá ser calculado da seguinte forma: (salário / 30 * número de dias trabalhados no mês anterior ao do dia de pagamento).	

GP2: Eu, como gerente de recursos humanos, necessito gerar o pagamento de 13º.
Critério de aceite: Gerar documento que será enviado ao setor de financeiro, contendo nome do funcionário, seus dados bancários, e o valor que será pago a ele. O Valor deverá ser calculado da seguinte forma:	
- Meses devidos: o funcionário terá direito a um mês caso ele trabalhe 15 dias no mês em questão.
- Cálculo: (salário / 12 * Meses devidos).	
Obs.: Deve poder ser gerado até duas vezes para cada funcionário, sendo que, na primeira, será calculado como devido todos os meses até dezembro do mês selecionado, dividido por dois, e na segunda, só poderá ser gerado no mês de dezembro e o valor será o valor restante que não foi pago na primeira parcela.	

GP3: Eu, como gerente de recursos humanos, necessito gerar o pagamento individual de férias.
Critério de aceite: Gerar documento que será enviado ao setor de financeiro, contendo nome do funcionário, seus dados bancários, e o valor que será pago a ele. Somente poderá ser realizado caso o funcionário selecionado tenha completado um ano de empresa e tenha 12 meses pendentes. O valor deve ser realizado da seguinte forma:	
- Salário + Salário / 3.
