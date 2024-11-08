using CustomerWishlist.Models;

namespace CustomerWishlist.Interfaces;

public interface IProductService
{
    public ResultResponse AddToWishlist(Product product);
    public IEnumerable<Product> GetProducts();
}
