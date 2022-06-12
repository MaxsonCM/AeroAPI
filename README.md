Aplicação desenvolvidade em Asp.Net Core 2.1 apartir do Visual Studio 2017, utilizando o code first para criar o banco de dados.

## Instruções

* Baixe o projeto

* Verifique se todas as dependencias do NuGet estão instaladas exe.: EF (EntityFramework), etc.

* [Para o banco de dados utilizei o Docker para criar um container instanciando o Microsoft SQL Server.](#configurando-o-docker)

* [Crie o banco de dados e configure a conexão com o banco de dados.](#configurando-a-conexão-com-mssql)

* Execute o projeto.

* [Testando os end points.](#testando-os-endpoints)

---

### Configurando o Docker

Com o Docker instalado abra o powershell e execute os comandos abaixo:

Para baixar a imagem do mssql:

		docker pull mcr.microsoft.com/mssql/server:2019-latest

Para iniciar o container:

		docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=<YourStrong@Passw0rd>" -p 1433:1433 --name sql1 --hostname sql1 -d mcr.microsoft.com/mssql/server:2019-latest

O usuário padrão é o sa e a senha pode ser definida alterando o parâmetro SA_PASSWORD para qualquer ou valor.

Caso ainda tenha alguma duvida visite o site para [mais detalhes em clique aqui](https://docs.microsoft.com/pt-br/sql/linux/quickstart-install-connect-docker?view=sql-server-ver16&pivots=cs1-bash)

---

### Configurando a conexão com MSSQL:

Edite o arquivo appsettings.json para alterar as configurações de coneção.

Exstem duas string de conexão já estão pré configuradas (AeroAPI_Docker e AeroAPI_local):

A string AeroAPI_Docker para caso utilise o Docker para precisar instalar o servidor em sua maquina.
A string AeroAPI_local para caso possua uma instância instada do MSSQL.

Para criar o banco de dados utilize o *Console do Gerenciador de Pacotes* e execute o comando abaixo:

		update-database

Caso não possua o *Console do Gerenciador de Pacotes* aberto, é possível abri-lo no menu *Exibir > Outras Janelas > Console do Gerenciador de Pacotes*

---

### Testando os EndPoints

Para testar foi utilizado o programa [insomnia](https://insomnia.rest/download).

Importe o arquivo *Insomnia_AeroAPI.json* para ter todos os endpoints prontos para executar.

