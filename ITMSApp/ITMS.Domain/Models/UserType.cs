using System;
using System.Collections.Generic;

namespace ITMS.Domain.Models
{
    public partial class UserType
    {
        public int Id { get; set; }

        public string TypeName { get; set; } = null!;

        public int? IsDelete { get; set; }

        public int CreateBy { get; set; }

        public int LastModifyBy { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? LastModifyDate { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}