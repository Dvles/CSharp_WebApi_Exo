using BLL.Entities;
using webapi.Models;

namespace webapi.Mappers
{
	public static class Mappers
	{
		public static UserDTO ToDTO(this User user) { 
		
		if (user is null) throw new ArgumentNullException(nameof(user));
			return new UserDTO
			{
				User_Id = user.User_Id,
				First_Name = user.First_Name,
				Last_Name = user.Last_Name,
				Email = user.Email,
				CreatedAt = user.CreatedAt,
				IsDisable = user.IsDisabled
			};
		
		}

		public static User ToBLL(this UserPostDTO dto)
		{
			if (dto == null)
				throw new ArgumentNullException(nameof(dto), "DTO cannot be null");

			return new User
			{
				First_Name = dto.First_Name,
				Last_Name = dto.Last_Name,
				Email = dto.Email,
				Password = dto.Password,
				CreatedAt = DateTime.UtcNow
			};
		}

	}
}
