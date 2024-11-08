using CustomerWishlist.Interfaces;
using CustomerWishlist.Models;
using CustomerWishlist.Services;
using Moq;

namespace CustomerWishlist.Tests;

public class ProductServices_Tests
{
    [Fact]
    public void AddToWishlist_ShouldAddProductToWishlist_AndReturnSuccess()
    {
        Mock<IFileService> fileServiceMock = new Mock<IFileService>();
        fileServiceMock.Setup(x => x.SaveToFile(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

        ProductService productService = new ProductService(fileServiceMock.Object);
        Product product = new Product { Name = "Enesco Wizard World of Harry Potter Dumbledore with Fawkes Figurine, 25 cm", Price = "Currently out of stock" };

        var result = productService.AddToWishlist(product);
        var productList = productService.GetProducts();

        Assert.True(result.Success);
        Assert.Single(productList);
    }
}
