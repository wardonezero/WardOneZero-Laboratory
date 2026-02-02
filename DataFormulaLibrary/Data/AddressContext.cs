using DataFormulaLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataFormulaLibrary.Data;

public class AddressContext(DbContextOptions<AddressContext> options) : DbContext(options)
{
    public DbSet<Address> Addresses { get; set; }
}