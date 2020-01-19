using Gravenger.Domain.Core.Models;
using System.Collections.Generic;

namespace Gravenger.Domain.Core.Dto
{
    public class AccountDTO
    {
        public int AccountID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string ProfileImageFileName { get; set; }
        public string ProfileImageFullPath { get; set; }
        public virtual IEnumerable<AccountDTO> Followers { get; set; }
        public virtual IEnumerable<AccountDTO> Followees { get; set; }
        public virtual IEnumerable<PostcardDTO> Postcards { get; set; }
    }
}
