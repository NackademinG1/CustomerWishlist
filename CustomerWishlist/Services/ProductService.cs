using CustomerWishlist.Interfaces;
using CustomerWishlist.Models;
using Newtonsoft.Json;

namespace CustomerWishlist.Services;

public class ProductService : IProductService
{
    private static readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "wishlist.json");
    private readonly IFileService _fileService;
    private List<Product> _productList = new List<Product>();
    public ProductService(IFileService fileService)
    {
        _fileService = fileService;
    }
    public ResultResponse AddToWishlist(Product product)
    {
        try
        {
            _productList.Add(product);
            if (_productList.Any(p => p.Name == product.Name))
                return new ResultResponse { Success = true };

            _productList.Add(product);
            var json = JsonConvert.SerializeObject(_productList);
            var result = _fileService.SaveToFile("", json);
            if (result)
                return new ResultResponse { Success = true };

            return null!;
        }
        catch
        {
            return new ResultResponse { Success = false };
        }
    }
    public IEnumerable<Product> GetProducts()
    {
        return _productList;
    }
}

