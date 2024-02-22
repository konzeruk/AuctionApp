using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionApp.Service.Core.Exceptions
{
    public interface IExceptionApi
    {
        public ApiError IncorrectData();
        public ApiError ErrorDatabase();
        public ApiError NotFoundEntry();
    }
}
