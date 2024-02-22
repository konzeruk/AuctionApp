using AuctionApp.Service.Core.Exceptions;

namespace AuctionApp.Service.Auth
{
    public class ExpceptionAuthApi:IExceptionApi
    {
        public ApiError ErrorDatabase()=>
            new ApiError() { Code = ErrorCode.ErrorDatabase, Message = "Ошибка базы данных" };

        public ApiError IncorrectData() =>
            new ApiError() { Code = ErrorCode.IncorrectData, Message = "Логин или пароль были введены не верно" };

        public ApiError NotFoundEntry() =>
            new ApiError() { Code = ErrorCode.NotFoundEntry, Message = "Пользователь не был найден" };
    }
}
