using System;
using System.Collections.Generic;
using System.Text;

namespace DataFormulaLibrary.Models.Product;

public class Inventory
{
    public int ProductId { get; set; }

    public List<int> ColorsIds { get; set; } = [];
    public List<int> DimentionsIds { get; set; } = [];
    public List<int> PicturesIds { get; set; } = [];
    public List<int> SizesIds { get; set; } = [];
}