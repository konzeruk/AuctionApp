// создание всех бд и их заполнение

using AuctionApp.Service.Core.ContextDB;
using AuctionApp.Service.Core.Models.Entities;

int idP5,
    idP2,
    idAdmin,
    idUser1;

using (var db = new ApplicationContextAuth(true))
{
    var admin = new AuthEntity()
    {
        Login = "admin",
        Password = "admin"
    };

    var user1 = new AuthEntity()
    {
        Login = "user1",
        Password = "user1"
    };

    db.Auth.Add(admin);
    db.Auth.Add(user1);

    db.SaveChanges();

    idAdmin = db.Auth
        .Where(x => x.Login == "admin")
        .FirstOrDefault()!
        .Id;

    idUser1 = db.Auth
        .Where(x => x.Login == "user1")
        .FirstOrDefault()!
        .Id;
}

using (var db = new ApplicationContextProduct(true))
{
    var category1 = new CategoryEntity() { Name = "Автомобили" };
    var category2 = new CategoryEntity() { Name = "Драгоценности" };
    var category3 = new CategoryEntity() { Name = "Недвижимость" };

    db.Category.Add(category1);
    db.Category.Add(category2);
    db.Category.Add(category3);

    db.SaveChanges();

    var c1 = db.Category
        .Where(x => x.Name == "Автомобили")
        .FirstOrDefault();

    var p1 = new ProductEntity()
    {
        Name = "BMW",
        Price = 5000000,
        DateEnd = new DateTime(2024, 3, 27),
        Category = c1!,
        CategoryId = c1!.Id
    };

    var p2 = new ProductEntity()
    {
        Name = "Kia",
        Price = 1000000,
        DateEnd = new DateTime(2024, 3, 23),
        Category = c1!,
        CategoryId = c1!.Id
    };
    
    db.Product.Add(p1);
    db.Product.Add(p2);

    db.SaveChanges();

    idP2 = db.Product
        .Where(x => x.Name == "Kia")
        .FirstOrDefault()!
        .Id;

    var c2 = db.Category
        .Where(x => x.Name == "Драгоценности")
        .FirstOrDefault();

    var p3 = new ProductEntity()
    {
        Name = "Кольцо",
        Price = 500000,
        DateEnd = new DateTime(2024, 4, 27),
        Category = c2!,
        CategoryId = c2!.Id
    };

    var p4 = new ProductEntity()
    {
        Name = "Kia",
        Price = 300000,
        DateEnd = new DateTime(2024, 4, 23),
        Category = c2!,
        CategoryId = c2!.Id
    };

    db.Product.Add(p3);
    db.Product.Add(p4);

    db.SaveChanges();

    var c3 = db.Category
        .Where(x => x.Name == "Недвижимость")
        .FirstOrDefault();

    var p5 = new ProductEntity()
    {
        Name = "Загородный дом",
        Price = 7900000,
        DateEnd = new DateTime(2024, 3, 21),
        Category = c3!,
        CategoryId = c3!.Id
    };

    var p6 = new ProductEntity()
    {
        Name = "Остров",
        Price = 60000000,
        DateEnd = new DateTime(2024, 10, 21),
        Category = c3!,
        CategoryId = c3!.Id
    };

    db.Product.Add(p5);
    db.Product.Add(p6);

    db.SaveChanges();

   idP5 = db.Product
        .Where(x => x.Name == "Загородный дом")
        .FirstOrDefault()!
        .Id;
}

using (var db = new ApplicationContextBargaining(true))
{
    var b1 = new BargainingEntity()
    {
        Price = 80000456,
        ProductId = idP5,
        UserId = idAdmin
    };

    var b2 = new BargainingEntity()
    {
        Price = 1200000,
        ProductId = idP2,
        UserId = idUser1
    };

    db.Bargaining.Add(b1);
    db.Bargaining.Add(b2);

    db.SaveChanges();
}