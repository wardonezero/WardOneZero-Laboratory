using DataFormulaLibrary.Enums;

namespace DataFormulaLibrary.Models.Product.Properties;

public class Dimention
{
    public int Id { get; set; } = 0;

    public float Length { get; set; } = 0f;

    public float Width { get; set; } = 0f;

    public float Height { get; set; } = 0f;

    public int MeasurementUnitId { get; set; } = 0;

    public override string ToString()
    {
        if (Length > 0f && Width > 0f && Height > 0f)
            return $"{Length}x{Width}x{Height}";
        if (Length > 0f && Width > 0f && Height <= 0f)
            return $"{Length}x{Width}";

        return string.Empty;
    }
}