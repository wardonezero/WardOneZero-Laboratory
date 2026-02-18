using DataFormulaLibrary.Data;
using DataFormulaLibrary.Models.Attribute;
using DataFormulaLibrary.Models.Product;
using DataFormulaLibrary.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ServiceFormulaLibrary;

public class ProductService(CatalogContext context, AttributeContext attributeContext) : DbContext
{
    public async Task<bool> AddOrRemoveProductAttributeAsync(int productId, int attributeId, bool remove = false)
    {
        Inventory? inventory = await context.Set<Inventory>()
            .FirstOrDefaultAsync(i => i.Id == productId);

        if (inventory is not null)
        {
            if (!inventory.AttributesValuesIds.Contains(attributeId) && !remove)
                inventory.AttributesValuesIds.Add(attributeId);
            if (inventory.AttributesValuesIds.Contains(attributeId) && remove)
                inventory.AttributesValuesIds.Remove(attributeId);
            context.Entry(inventory).Property(i => i.AttributesValuesIds).IsModified = true;
            await context.SaveChangesAsync();
            context.Entry(inventory).State = EntityState.Detached;
            return true;
        }
        else
            return false;
    }

    private async Task<List<ItemIdNameViewModel>> GetAttributesItemsAsync(List<int> ids)
    {
        return await attributeContext.Attributes.AsNoTracking()
            .Where(a => ids.Contains(a.Id))
            .Select(a => new ItemIdNameViewModel { Name = a.Name, Id = a.Id })
            .ToListAsync();
    }

    public async Task<Dictionary<string, AttributeValue>> GetProductAttributesValuesAsync(int productId, bool isSpecification)
    {
        Dictionary<string, AttributeValue> attributeValuesDictionary;
        List<AttributeValue> attributesValues;
        List<ItemIdNameViewModel> attributesItems;
        List<int> attributesValuesIds = await context.ProductsInventories.AsNoTracking()
            .Where(pi => pi.Id == productId)
            .Select(pi => pi.AttributesValuesIds)
            .FirstOrDefaultAsync() ?? [];

        if (attributesValuesIds.Count == 0) return [];

        attributesValues = await attributeContext.AttributeValues.AsNoTracking()
            .Where(av => attributesValuesIds.Contains(av.Id) && av.IsSelectable == !isSpecification).ToListAsync();

        if (attributesValues.Count == 0) return [];

        attributesItems = await GetAttributesItemsAsync([.. attributesValues.Select(av => av.AttributeId)]);

        attributeValuesDictionary = attributesValues
            .Join(attributesItems,
                av => av.AttributeId,
                ai => ai.Id,
                (av, ai) => new { ai.Name, AttributeValue = av })
            .ToDictionary(x => x.Name, x => x.AttributeValue);

        return attributeValuesDictionary;
    }

    public async Task<ProductFormViewModel?> GetProductForEdit(int productId)
    {
        return await (from p in context.Products.AsNoTracking()
                      join c in context.ProductsConfigurations.AsNoTracking() on p.Id equals c.Id
                      join i in context.ProductsInventories.AsNoTracking() on p.Id equals i.Id
                      join m in context.ProductsMetaDatas.AsNoTracking() on p.Id equals m.Id
                      join d in context.Departments.AsNoTracking() on m.DepartmentId equals d.Id into dGroup
                      from department in dGroup.DefaultIfEmpty()
                      join cat in context.Categories.AsNoTracking() on m.CategoryId equals cat.Id into catGroup
                      from category in catGroup.DefaultIfEmpty()
                      join s in context.Subcategories.AsNoTracking() on m.SubcategoryId equals s.Id into sGroup
                      from subcategory in sGroup.DefaultIfEmpty()
                      join b in context.Brands.AsNoTracking() on m.BrandId equals b.Id into bGroup
                      from brand in bGroup.DefaultIfEmpty()
                      where p.Id == productId
                      select new ProductFormViewModel(c, i, m, p)
                      {
                          Department = department != null ? department.Name : string.Empty,
                          Category = category != null ? category.Name : string.Empty,
                          Subcategory = subcategory != null ? subcategory.Name : string.Empty,
                          Brand = brand != null ? brand.Name : string.Empty
                      }).FirstOrDefaultAsync();
    }

    public async Task<List<ProductTableViewModel>> GetProductTablePagedAsync(int page = 1, byte size = 20)
    {
        return await (from p in context.Products.AsNoTracking()
                      join m in context.ProductsMetaDatas.AsNoTracking() on p.Id equals m.Id
                      join i in context.ProductsInventories.AsNoTracking() on p.Id equals i.Id
                      orderby p.Id
                      select new ProductTableViewModel
                      {
                          Id = p.Id,
                          Name = p.Name,
                          Price = p.Price,
                          InStock = i.InStock,
                          Published = m.Status == DataFormulaLibrary.Enums.ProductStatuses.Published
                      }).Skip((page - 1) * size).Take(size).ToListAsync();
    }
}