namespace AuctionApp.Service.Auth
{
    // класс с исключениями сервиса
    public static class ExpceptionAuthApi
    {
        public const string IncorrectData = "Логин или пароль были введены не верно";

        public const string NotFoundUser = "Пользователь не был найден";
    }
}
