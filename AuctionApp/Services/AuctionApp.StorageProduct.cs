using AuctionApp.Service.Core.Models.DTO;
using AuctionApp.Service.Core.Models.DTO.Responses;
using Azure;
using System.Diagnostics;
using System.Text.Json;

namespace AuctionApp.Services
{
    internal static partial class AuctionApp
    {
        public static class StorageProduct
        {
            private const string addressController = "api/StorageProduct";

            public static async Task<ResultModel<ProductModel>> AddProductAsync(ProductModel productModel)
            {
                try
                {
                    var request = "addProduct";

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

            public static async Task<ResultModel<ProductModel>> DeleteProductAsync(int id)
            {
                try
                {
                    var request = $"deleteProduct/{id}";

                    await httpClient._SendRequestAsync(new RequestModel()
                    {
                        BaseAddress = $"{baseAddress}/{addressController}",
                        Request = request,
                        _HttpMethod = HttpMethod.Delete
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
                        Status = $"{StatusResult.ERROR}: Не удалось удалить продукт"
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
                        Value = JsonSerializer.Deserialize<List<ProductModelResponse>>(response),
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
                        Value = JsonSerializer.Deserialize<List<CategoryModel>>(response),
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
