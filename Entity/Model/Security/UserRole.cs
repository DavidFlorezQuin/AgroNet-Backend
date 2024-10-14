namespace Entity.Model.Security
{
    public class UserRole : ABaseModel
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }    
        public int UserId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore] 
        public Users User { get; set; }

    }
}
