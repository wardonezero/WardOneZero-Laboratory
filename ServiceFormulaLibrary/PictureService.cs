using DataFormulaLibrary.Models.Product;
using DataFormulaLibrary.Models.Shared.Properties;
using Microsoft.EntityFrameworkCore;

namespace ServiceFormulaLibrary;

/// <summary>
/// Provides functionality for saving and retrieving picture data in a database using a specified Entity Framework Core
/// context.
/// </summary>
/// <remarks>This service enables asynchronous operations for storing and accessing pictures in a database table
/// of your choice. It is designed to work with any Entity Framework Core <see cref="DbContext"/> implementation. The
/// service does not track retrieved entities, making it suitable for scenarios where read-only access is
/// required.</remarks>
/// <typeparam name="TContext">The type of the database context to use for data access. Must derive from <see cref="DbContext"/>.</typeparam>
/// <param name="context">The database context instance used to perform operations on the picture data. Cannot be null.</param>
public class PictureService<TContext>(TContext context) where TContext : DbContext
{
    public async Task<bool> AddOrRemoveProductPictureAsync(int productId, int pictureId, bool remove = false)
    {
        Inventory? inventory = await context.Set<Inventory>()
            .FirstOrDefaultAsync(i => i.Id == productId);

        if (inventory is not null)
        {
            if (!inventory.PicturesIds.Contains(pictureId) && !remove)
                inventory.PicturesIds.Add(pictureId);
            if (inventory.PicturesIds.Contains(pictureId) && remove)
                inventory.PicturesIds.Remove(pictureId);
            context.Entry(inventory).Property(i => i.PicturesIds).IsModified = true;
            await context.SaveChangesAsync();
            context.Entry(inventory).State = EntityState.Detached;
            return true;
        }
        else
            return false;
    }

    public async Task<List<Picture>> GetProductPicturesAsync(int productId, string tableName)
    {
        List<int>? pictureIds = await context.Set<Inventory>().AsNoTracking()
            .Where(i => i.Id == productId)
            .Select(i => i.PicturesIds).FirstOrDefaultAsync();
        return pictureIds is null ? []
            : await GetPicturesAsync(pictureIds, tableName);
    }

    /// <summary>
    /// Asynchronously retrieves a list of pictures from the specified table that match the provided identifiers.
    /// </summary>
    /// <remarks>The query is executed without tracking the returned entities, which can improve performance
    /// when the entities are not modified.</remarks>
    /// <param name="ids">An enumerable collection of picture identifiers to retrieve. Must not be empty.</param>
    /// <param name="tableName">The name of the database table from which to retrieve the pictures. This value must correspond to a valid table
    /// in the database context.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="Picture"/>
    /// objects that match the specified identifiers. The list is empty if no matching pictures are found.</returns>
    public async Task<List<Picture>> GetPicturesAsync(List<int> ids, string tableName)
    {
        List<Picture> pictures;
        pictures = await context.Set<Picture>(tableName)
            .AsNoTracking()
            .Where(p => ids.Contains(p.Id))
            .OrderBy(p => p.DisplayOrder)
            .ToListAsync();
        return pictures;
    }

    /// <summary>
    /// Asynchronously retrieves a picture with the specified identifier from the given database table.
    /// </summary>
    /// <remarks>The returned picture is not tracked by the context. This method is suitable for read-only
    /// scenarios.</remarks>
    /// <param name="pictureId">The unique identifier of the picture to retrieve.</param>
    /// <param name="tableName">The name of the database table containing the picture. Cannot be null or empty.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="Picture"/> if found;
    /// otherwise, <see langword="null"/>.</returns>
    public async Task<Picture?> GetPictureAsync(int pictureId, string tableName)
    {
        return await context.Set<Picture>(tableName).AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == pictureId);
    }

    public async Task<bool> DeletePictureAsync(int pictureId, string tableName)
    {
        try
        {
            int affectedRows = await context.Set<Picture>(tableName)
                .Where(p => p.Id == pictureId).ExecuteDeleteAsync();
            return affectedRows > 0 && affectedRows < 2; ;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Asynchronously saves a picture to the specified database table and returns the unique identifier of the saved
    /// picture.
    /// </summary>
    /// <param name="inputPicture">A stream containing the picture data to be saved. The stream must be readable and positioned at the start of the
    /// picture data.</param>
    /// <param name="extention">The file extension of the picture (for example, ".jpg" or ".png"). Cannot be null or empty.</param>
    /// <param name="displayOrder">The display order value to associate with the picture. Determines the position of the picture in ordered lists.</param>
    /// <param name="tableName">The name of the database table in which to store the picture. Cannot be null or empty.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the unique identifier of the saved
    /// picture.</returns>
    public async Task<int> SavePictureAsync(Stream inputPicture, string extention, byte displayOrder, string title, string alt, string tableName)
    {
        byte[] binary;
        if (inputPicture.CanSeek)
        {
            // PRO TIP: Use AllocateUninitializedArray to skip filling the array with zeros (CPU saver for large files)
            // Ensure the length is safely cast to int (max 2GB)
            int length = (int)(inputPicture.Length - inputPicture.Position);
            binary = GC.AllocateUninitializedArray<byte>(length);

            //binary = new byte[inputPicture.Length - inputPicture.Position];
            await inputPicture.ReadExactlyAsync(binary);
        }
        else
        {
            using MemoryStream memoryStream = new();
            await inputPicture.CopyToAsync(memoryStream);
            binary = memoryStream.ToArray();
        }

        Picture picture = new() { Extention = extention, Binary = binary, DisplayOrder = displayOrder, Title = title, Alt = alt };

        context.Set<Picture>(tableName).Add(picture);
        await context.SaveChangesAsync();
        context.Entry(picture).State = EntityState.Detached;
        return picture.Id;
    }
}