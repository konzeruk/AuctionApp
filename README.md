Для запуска нужно:
1) В проекте AuctionApp.Service.Core изменить в файле config.json строки подключения. (пример строки: "Server=[BRUNGILDA\\SQLEXPRESS];Database=Auth;Integrated Security=True;TrustServerCertificate=True;", в скобках [] то, что нужно изменить)
2) Отдельно запустить TestApp, после этого будут созданы заполненые бд. 
3) В проекте AuctionApp.Service.Core изменить в файле config.json строки подключения Docker_<имя бд> (пример строки: "Server=host.docker.internal,[1433];Database=Auth;User Id=[test1];Password=[test1];TrustServerCertificate=True;").
   Для этого нужно в SQL Server создать пользователя и дать ему права на созданые бд и вставить в строки (пример выше) имя и пароль этого пользователя.
   Порт сервера SQL можно найти в SQL Server 2022 Configuration Manager:
   
   ![image](https://github.com/konzeruk/AuctionApp/assets/36711359/36041f55-da25-47ba-ae90-edf4a892a2e8)
   
   Открыть TCP/IP:
   
   ![image](https://github.com/konzeruk/AuctionApp/assets/36711359/a68cdb19-3d29-4652-8d5f-bb82f822c600)
   
   Там будет указан порт TCP.
4) В PowerShell в VS прописать и запустить по очереди:
   docker build -t service-auth -f ServiceApiAuth_Dockerfile .
   docker build -t service-storage-product -f ServiceApiStorageProduct_Dockerfile .
   docker build -t service-bargaining -f ServiceApiBargaining_Dockerfile .
   docker build -t service-infrastructur -f ServiceApiInfrastructur_Dockerfile .
5) В Docker Desktop в build будет такое:
   
   ![image](https://github.com/konzeruk/AuctionApp/assets/36711359/3bb61e48-bc6d-4e95-80db-99f928e9c159)
   
   В вкладке Image будет:
   
   ![image](https://github.com/konzeruk/AuctionApp/assets/36711359/ed75f0ec-7516-4228-8bd7-d4a376d84c9c)
   
   Нужно нажать для каждого на run:
   
   ![image](https://github.com/konzeruk/AuctionApp/assets/36711359/3b02c13c-e4e4-4ccc-a5b2-4c8bbac309fe)
   
   Нужно указать название и порт (порт такой же какой там и указан)
   
   ![image](https://github.com/konzeruk/AuctionApp/assets/36711359/84e6b6f1-8d92-47ca-93e9-08b5f29a16c9)
   
   В итоге не надо будет запускать ничего, оно всё будет автоматом работать на фоне.  
6) Запустить проект AuctionApp.

Во всех проектах есть README, в которах всякое описано, где что лежит и нюансы некоторых алгоритмах.
