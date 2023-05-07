using System;
using System.Collections.Generic;

namespace TrafficManagement.Models;

public partial class General
{
    public int Id { get; set; }

    public string? Direction { get; set; }

    public int? TimeIntervel { get; set; }
}
