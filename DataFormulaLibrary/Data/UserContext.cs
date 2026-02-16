using DataFormulaLibrary.Models.Cart;
using DataFormulaLibrary.Models.Shared.Properties;
using DataFormulaLibrary.Models.User;
using Microsoft.EntityFrameworkCore;

namespace DataFormulaLibrary.Data;

public class UserContext(DbContextOptions<UserContext> options) : DbContext(options)
{
    public const string ProfilesPicturesTableName = "ProfilesPictures";

    public DbSet<Cart> Carts { get; set; }
    public DbSet<WishList> WishLists { get; set; }
    public DbSet<WishListItem> WishListItems { get; set; }
    public DbSet<Picture> ProfilesPictures => Set<Picture>(ProfilesPicturesTableName);
    public DbSet<User> Users { get; set; }
    public DbSet<Models.User.MetaData> UsersMetaData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.SharedTypeEntity<Picture>(ProfilesPicturesTableName, entity =>
        {
            entity.HasKey(p => p.Id);
            entity.ToTable(ProfilesPicturesTableName);
        });
    }
}