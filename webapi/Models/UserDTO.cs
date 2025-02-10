using BLL.Entities;

namespace webapi.Models
{
	public class UserDTO
	{
		public Guid User_Id { get; set; }
		public string First_Name { get; set; }
		public string Last_Name { get; set; }
		public string Email { get; set; }
		public DateTime CreatedAt { get; set; }

		public bool IsDisable { get; set; } 


	}
}
