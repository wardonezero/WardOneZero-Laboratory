using DataFormulaLibrary.Data;
using DataFormulaLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ServiceFormulaLibrary;

public class CatalogService(CatalogContext context)
{
    //Departments
    public async Task<Department?> GetDepartmentAsync(int departmentId)
    {
        return await context.Departments.AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == departmentId);
    }

    public async Task<bool> DeleteDepartmentAsync(int departmentId)
    {
        try
        {
            int affectedRows = await context.Departments
                .Where(d => d.Id == departmentId)
                .ExecuteDeleteAsync();
            return affectedRows > 0 && affectedRows < 2;
        }
        catch
        {
            //TODO: Add logging
            return false;
        }
    }

    public async Task<Department?> EditDepartmentAsync(Department department)
    {
        context.Departments.Update(department);
        await context.SaveChangesAsync();
        return department;
    }

    public async Task<int> CreateDepartmentAsync(Department department)
    {
        context.Departments.Add(department);
        await context.SaveChangesAsync();
        return department.Id;
    }

    //Categories
    public async Task<Category?> GetCategoryAsync(int categoryId)
    {
        return await context.Categories.AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == categoryId);
    }

    public async Task<bool> DeleteCategoryAsync(int categoryId)
    {
        try
        {
            int affectedRows = await context.Categories
                .Where(d => d.Id == categoryId)
                .ExecuteDeleteAsync();
            return affectedRows > 0 && affectedRows < 2;
        }
        catch
        {
            //TODO: Add logging
            return false;
        }
    }

    public async Task<Category?> EditCategoryAsync(Category category)
    {
        context.Categories.Update(category);
        await context.SaveChangesAsync();
        return category;
    }

    public async Task<int> CreateCategoryAsync(Category category)
    {
        context.Categories.Add(category);
        await context.SaveChangesAsync();
        return category.Id;
    }

    //Subcategories
    public async Task<Department?> GetSubcategoryAsync(int subcategoryId)
    {
        return await context.Departments.AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == subcategoryId);
    }

    public async Task<bool> DeleteSubcategoryAsync(int subcategoryId)
    {
        try
        {
            int affectedRows = await context.Subcategories
                .Where(d => d.Id == subcategoryId)
                .ExecuteDeleteAsync();
            return affectedRows > 0 && affectedRows < 2;
        }
        catch
        {
            //TODO: Add logging
            return false;
        }
    }

    public async Task<Subcategory?> EditSubcategoryAsync(Subcategory subcategory)
    {
        context.Subcategories.Update(subcategory);
        await context.SaveChangesAsync();
        return subcategory;
    }

    public async Task<int> CreateSubcategoryAsync(Subcategory subcategory)
    {
        context.Subcategories.Add(subcategory);
        await context.SaveChangesAsync();
        return subcategory.Id;
    }

    //Brands
    public async Task<Brand?> GetBrandAsync(int brandId)
    {
        return await context.Brands.AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == brandId);
    }

    public async Task<bool> DeleteBrandAsync(int brandId)
    {
        try
        {
            int affectedRows = await context.Brands
                .Where(d => d.Id == brandId)
                .ExecuteDeleteAsync();
            return affectedRows > 0 && affectedRows < 2;
        }
        catch
        {
            //TODO: Add logging
            return false;
        }
    }

    public async Task<Brand?> EditBrandAsync(Brand brand)
    {
        context.Brands.Update(brand);
        await context.SaveChangesAsync();
        return brand;
    }

    public async Task<int> CreateBrandAsync(Brand brand)
    {
        context.Brands.Add(brand);
        await context.SaveChangesAsync();
        return brand.Id;
    }

    //Warehouses
    public async Task<Warehouse?> GetWarehouseAsync(int warehouseId)
    {
        return await context.Warehouses.AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == warehouseId);
    }

    public async Task<bool> DeleteWarehouseAsync(int warehouseId)
    {
        try
        {
            int affectedRows = await context.Warehouses
                .Where(d => d.Id == warehouseId)
                .ExecuteDeleteAsync();
            return affectedRows > 0 && affectedRows < 2;
        }
        catch
        {
            //TODO: Add logging
            return false;
        }
    }

    public async Task<Warehouse?> EditWarehouseAsync(Warehouse warehouse)
    {
        context.Warehouses.Update(warehouse);
        await context.SaveChangesAsync();
        return warehouse;
    }

    public async Task<int> CreateWarehouseAsync(Warehouse warehouse)
    {
        context.Warehouses.Add(warehouse);
        await context.SaveChangesAsync();
        return warehouse.Id;
    }
}