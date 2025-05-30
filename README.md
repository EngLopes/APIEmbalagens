# APIEmbalagens

API REST para gerenciamento de embalagens, feita em .NET 8 e usando SQL Server via Docker.

## Itens necessários

1. [.NET 8](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)  
2. [Docker Desktop](https://www.docker.com/products/docker-desktop/)

## Como rodar
1. Execute o Docker Desktop
2. Clone o projeto:

Abra o CMD ou PowerShell no diretório que preferir e execute os comandos abaixo:

```bash
git clone https://github.com/EngLopes/APIEmbalagens.git
cd APIEmbalagens
docker-compose up --build
```

3. Acessar API:
Abra no navegador o endereço:
http://localhost:5000/swagger



## Outras informações
- Verifique os containers ativos no docker para validar se estão rodando normalmente com o comando no CMD ou PowerShell
  ```bash
  docker ps
  ```
- Para rodar os testes unitários localmente, execute o comando na raiz do projeto de testes
  ```bash
  dotnet test
  ```
- O projeto APIEmbalagens deve estar compilado antes de executar os testes.

- A API está configurada para acessar pela porta 80, então, caso queira testar fora do docker, execute  a API no Visual Studio ou  IDE de preferencia e acesse o link http://localhost:80/swagger


