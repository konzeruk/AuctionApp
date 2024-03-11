Для запуска нужно:
1) В проекте AuctionApp.Service.Core изменить в файле config.json. (пример строки: "Server=[BRUNGILDA\\SQLEXPRESS];Database=Auth;Integrated Security=True;TrustServerCertificate=True;", в скобках [] то, что нужно изменить)
2) Отдельно запустить TestApp, после этого будут созданы заполненые бд.
3) Запустить без отладки проекты: AuctionApp.Service.Auth, AuctionApp.Service.StorageProduct, AuctionApp.Service.Bargaining, AuctionApp.Service.Infrastructur.
4) Запустить проект AuctionApp.

Во всех проектах есть README, в которах всякое описано, где что лежит и нюансы некоторых алгоритмах.
