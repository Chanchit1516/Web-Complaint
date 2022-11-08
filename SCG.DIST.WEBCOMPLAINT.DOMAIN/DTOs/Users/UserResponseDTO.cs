namespace SCG.DIST.WEBCOMPLAINT.DOMAIN.DTOs.Users
{
    public class UserResponseDTO
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int BuId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }

    }
}
