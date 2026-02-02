using DataFormulaLibrary.Data;
using DataFormulaLibrary.Models.Shared.Properties;
using Microsoft.EntityFrameworkCore;

namespace ServiceFormulaLibrary;

public class PictureService(DataContext context)
{
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
    public async Task<int> SavePictureAsync(Stream inputPicture, string extention, byte displayOrder, string tableName)
    {
        byte[] binary;
        if (inputPicture.CanSeek)
        {
            // PRO TIP: Use AllocateUninitializedArray to skip filling the array with zeros (CPU saver for large files)
            // Ensure the length is safely cast to int (max 2GB)
            //int length = (int)(inputPicture.Length - inputPicture.Position);
            //binary = GC.AllocateUninitializedArray<byte>(length);

            binary = new byte[inputPicture.Length - inputPicture.Position];
            await inputPicture.ReadExactlyAsync(binary);
        }
        else
        {
            using MemoryStream memoryStream = new();
            await inputPicture.CopyToAsync(memoryStream);
            binary = memoryStream.ToArray();
        }

        Picture picture = new() { Extention = extention, Binary = binary, DisplayOrder = displayOrder };

        context.Set<Picture>(tableName).Add(picture);
        await context.SaveChangesAsync();
        context.Entry(picture).State = EntityState.Detached;
        return picture.Id;
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
}