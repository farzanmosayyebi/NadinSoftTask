﻿namespace NadinSoftTask.Core.Models;
public class Product : EntityBase
{
    public string Name { get; set; } = default!;
    public DateTime ProduceDate { get; set; }
    public string ManufacturerEmail { get; set; } = default!;
    public string ManufacturerPhone { get; set;} = default!;
    public bool IsAvailable { get; set; }

    // to do: add User

}
