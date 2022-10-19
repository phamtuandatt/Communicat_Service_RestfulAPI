using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Data
{
    public class GradeMap
    {
        public GradeMap(EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey(t => t.MaLop);
            builder.Property(t => t.TenLop).IsRequired();
            builder.Property(t => t.SiSo).IsRequired();
        }
    }
}
