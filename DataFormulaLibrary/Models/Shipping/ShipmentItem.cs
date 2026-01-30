using System;
using System.Collections.Generic;
using System.Text;

namespace DataFormulaLibrary.Models.Shipping;

public class ShipmentItem
{
	public int Id { get; set; } = 0;
	public int ShipmentId { get; set; } = 0;
	public int OrderItemId { get; set; } = 0;
	public byte Quantity { get; set; } = 0;
	public float Weight { get; set; } = 0f;
	public int WarehouseId { get; set; } = 0;
}
