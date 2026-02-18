using System;
using System.Collections.Generic;
using System.Text;

namespace DataFormulaLibrary.Enums;

public enum ShippingStatuses
{
    ShippingNotRequired = 0,
    NotYetShipped = 10,
    PartiallyShipped = 20,
    Shipped = 30,
    Delivered = 40
}