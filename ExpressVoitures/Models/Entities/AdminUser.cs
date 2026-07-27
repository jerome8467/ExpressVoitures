namespace ExpressVoitures.Models.Entities
{
    public class AdminUser
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public AdminUserRole Role { get; set; } = AdminUserRole.Standby;

    }

}
