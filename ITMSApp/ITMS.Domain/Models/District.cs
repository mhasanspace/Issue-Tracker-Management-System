using System;
using System.Collections.Generic;

namespace ITMS.Domain.Models
{
    public partial class District
    {
        public int Id { get; set; }

        public int? DivisionId { get; set; }

        public string DistrictName { get; set; } = null!;

        public int CreateBy { get; set; }

        public int LastModifyBy { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? LastModifyDate { get; set; }

        public virtual Division? Division { get; set; }

        public virtual ICollection<Thana> Thanas { get; set; } = new List<Thana>();
    }
}