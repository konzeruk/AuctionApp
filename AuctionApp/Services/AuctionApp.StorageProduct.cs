using AuctionApp.Service.Core.Models.DTO;
using AuctionApp.Service.Core.Models.DTO.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Diagnostics;

namespace AuctionApp.Services
{
    internal static partial class AuctionApp
    {
        public static class StorageProduct
        {
            private const string addressController = "api/StorageProduct";

            public static async Task<ResultModel<ProductModel>> AddProductAsync(int categoryId, ProductModel productModel)
            {
                try
                {
                    var request = $"addProduct/{categoryId}";

                    await httpClient._SendRequestAsync(new RequestModel()
                    {
                        BaseAddress = $"{baseAddress}/{addressController}",
                        Request = request,
                        _HttpMethod = HttpMethod.Post
                    }, productModel);

                    return new ResultModel<ProductModel>()
                    {
                        Value = null,
                        Status = StatusResult.OK
                    };
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);

                    return new ResultModel<ProductModel>()
                    {
                        Value = null,
                        Status = $"{StatusResult.ERROR}: Не удалось добавить новый продукт"
                    };
                }
            }

            public static async Task<ResultModel<ProductModel>> UpdataPriceProductAsync(int id, double price)
            {
                try
                {
                    var request = $"updataPriceProduct/{id}/{price}";

                    await httpClient._SendRequestAsync(new RequestModel()
                    {
                        BaseAddress = $"{baseAddress}/{addressController}",
                        Request = request,
                        _HttpMethod = HttpMethod.Post
                    });

                    return new ResultModel<ProductModel>()
                    {
                        Value = null,
                        Status = StatusResult.OK
                    };
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);

                    return new ResultModel<ProductModel>()
                    {
                        Value = null,
                        Status = $"{StatusResult.ERROR}: Не удалось поставить новую цену продукта"
                    };
                }
            }

            public static async Task<ResultModel<List<ProductModelResponse>>> GetAllProductAsync(int categoryId)
            {
                try
                {
                    var request = $"getAllProduct/{categoryId}";

                    var response = await httpClient.SendRequestAsync(new RequestModel()
                    {
                        BaseAddress = $"{baseAddress}/{addressController}",
                        Request = request,
                        _HttpMethod = HttpMethod.Get
                    });

                    return new ResultModel<List<ProductModelResponse>>()
                    {
                        Value = JsonConvert.DeserializeObject<List<ProductModelResponse>>(response, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" }),
                        Status = StatusResult.OK
                    };
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);

                    return new ResultModel<List<ProductModelResponse>>()
                    {
                        Value = null,
                        Status = $"{StatusResult.ERROR}: Продукты отсутствуют"
                    };
                }
            }

            public static async Task<ResultModel<List<CategoryModel>>> GetAllCategoryAsync()
            {
                try
                {
                    var request = "getAllCategory";

                    var response = await httpClient.SendRequestAsync(new RequestModel()
                    {
                        BaseAddress = $"{baseAddress}/{addressController}",
                        Request = request,
                        _HttpMethod = HttpMethod.Get
                    });

                    return new ResultModel<List<CategoryModel>>()
                    {
                        Value = JsonConvert.DeserializeObject<List<CategoryModel>>(response),
                        Status = StatusResult.OK
                    };
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);

                    return new ResultModel<List<CategoryModel>>()
                    {
                        Value = null,
                        Status = $"{StatusResult.ERROR}: Категории отсутствуют"
                    };
                }
            }
        }
    }
}
