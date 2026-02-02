using DataFormulaLibrary.Data;
using DataFormulaLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ServiceFormulaLibrary;

public class AddressService(AddressContext context)
{
    public async Task<Address?> GetAddressAsync(int addressId)
    {
        return await context.Addresses.AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == addressId);
    }

    public async Task<bool> DeleteAddressAsync(int addressId)
    {
        try
        {
            int affectedRows = await context.Addresses
                .Where(d => d.Id == addressId)
                .ExecuteDeleteAsync();
            return affectedRows > 0 && affectedRows < 2;
        }
        catch
        {
            //TODO: Add logging
            return false;
        }
    }

    public async Task<Address?> EditAddressAsync(Address Address)
    {
        context.Addresses.Update(Address);
        await context.SaveChangesAsync();
        return Address;
    }

    public async Task<int> CreateAddressAsync(Address Address)
    {
        context.Addresses.Add(Address);
        await context.SaveChangesAsync();
        return Address.Id;
    }
}