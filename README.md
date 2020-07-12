POC de Worker Services com Dotnet Core 3
===================================================

## Instalação do serviço no windows

* Executar o CMD como Administrador.
* Executar o comando: sc.exe create NOME_DO_SERVICO binPath= "D:\Projetos\worker-service\bin\Debug\netcoreapp3.1\worker-service.exe"

## Desinstalar o serviço: 
* Executar o CMD como Administrador.
* sc delete NOME_DO_SERVICO

## Pacote necessário
* dotnet add package Microsoft.Extensions.Hosting.WindowsServices -v 3.1.3