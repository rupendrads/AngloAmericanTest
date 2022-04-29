namespace Rupendra.Assignment.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AccountTypeId { get; set; }
        public int Balance { get; set; }
        public string Address { get; set; }
    }
}
