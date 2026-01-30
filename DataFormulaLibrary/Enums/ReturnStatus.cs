using System;
using System.Collections.Generic;
using System.Text;

namespace DataFormulaLibrary.Enums;

public enum ReturnStatus
{
    Pending = 0,
    Received = 10,
    Approved = 20,
    Refounded = 30,
    Rejected = 40,
    Canceled = 50
}
