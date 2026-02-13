using DataFormulaLibrary.Models.Cart;
using DataFormulaLibrary.Models.Shared.Properties;
using DataFormulaLibrary.Models.User;
using Microsoft.EntityFrameworkCore;

namespace DataFormulaLibrary.Data;

public class UserContext(DbContextOptions<UserContext> options) : DbContext(options)
{
    public DbSet<Cart> Carts { get; set; }
    public DbSet<WishList> WishLists { get; set; }
    public DbSet<WishListItem> WishListItems { get; set; }

    public const string PicturesTableName = "ProfilesPictures";
    public DbSet<Picture> ProfilesPictures => Set<Picture>(PicturesTableName);
    public DbSet<User> Users { get; set; }
    public DbSet<Models.User.MetaData> UsersMetaData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.SharedTypeEntity<Picture>(PicturesTableName);
        modelBuilder.Ignore<Picture>();
    }
}
