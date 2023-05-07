using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Forecast
{
    public class Location : BaseEntity
    {
        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }

    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
        }
    }

}
