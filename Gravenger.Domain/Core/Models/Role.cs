using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Gravenger.Domain.Core.Models
{
    public class Role
    {
        public Role()
        {
            this.Accounts = new Collection<Account>();
        }

        public int RoleID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
