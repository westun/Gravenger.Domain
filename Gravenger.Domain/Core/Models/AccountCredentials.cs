namespace Gravenger.Domain.Core.Models
{
    public class AccountCredential
    {
        public int AccountCredentialID { get; set; }
        public int AccountID { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool Active { get; set; }
        public string Version { get; set; }
        
        public Account Account { get; set; }
    }
}
