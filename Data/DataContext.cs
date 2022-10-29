using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


public class TVSeriesContext : DbContext
{
    public TVSeriesContext(DbContextOptions<TVSeriesContext> options) : base(options)
    {

    }
}
