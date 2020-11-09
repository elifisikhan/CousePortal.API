using Portal.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Entities
{
    public class User:BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
    }
}
