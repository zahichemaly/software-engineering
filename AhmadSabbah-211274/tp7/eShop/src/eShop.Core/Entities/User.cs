namespace eShop.Core.Entities
{
    public class User : BaseEntity
    {
        public User(): base()
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime LastActive { get; set; }
        public string Email { get; set; }

        public string FullName => FirstName + " " + LastName; 
    }
}
