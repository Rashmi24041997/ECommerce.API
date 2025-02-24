using Microsoft.EntityFrameworkCore;
using Products.DAL.Data;
using Products.DAL.Entities;
using Products.DAL.RepositoryContracts;
using System.Linq;
using System.Linq.Expressions;

namespace Products.DAL.Repository;
public class ProductRepository : IProductsRepository
{
    private readonly ApplicationDbContext dbContext;

    public ProductRepository(ApplicationDbContext DbContext)
    {
        dbContext = DbContext;
    }

    public async Task<Product?> AddProduct(Product product)
    {
        dbContext.Add(product);
        await dbContext.SaveChangesAsync();
        return product;
    }

    public async Task<bool> DeleteProduct(Guid productId)
    {
        Product? product = dbContext.Products.FirstOrDefault(product => product.ProductID.Equals(productId));
        if (product != null)
        {
            dbContext.Remove(product);
            int res = await dbContext.SaveChangesAsync();
            return res != 0;
        }
        return false;
    }

    public async Task<IEnumerable<Product?>> GetProductsByCondition(Func<Product, bool> conditionExpression)
    {
        var product = dbContext.Products.Where(conditionExpression).ToList();
        return product;
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await dbContext.Products.ToListAsync();
    }

    public async Task<Product?> UpdateProduct(Product product)
    {
        Product? existingProduct = await dbContext.Products.FirstOrDefaultAsync(p => p.ProductID.Equals(product.ProductID));
        if (existingProduct != null)
        {
            dbContext.Entry(existingProduct).CurrentValues.SetValues(product);
            await dbContext.SaveChangesAsync();
            return existingProduct;
        }
        return null;
    }
}
