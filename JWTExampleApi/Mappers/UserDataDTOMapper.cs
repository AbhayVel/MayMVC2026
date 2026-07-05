using JWTExampleApi.DTOs;
using JWTExampleApi.Entitties;

namespace JWTExampleApi.Mappers
{
    public static class UserDataDTOMapper
    {

        public static UserDTO MapToDTO(this UserData userData)
        {
            if (userData == null)
                return null;
            return new UserDTO
            {
                Id = userData.Id,
                UserName = userData.UserName,
                Password = userData.Password,
                RoleName = userData.Role?.RoleName // Assuming Role is not null
            };
        }

        // Map from UserDTO to UserData
        public static UserData MapToEntity(UserDTO userDTO)
        {
            if (userDTO == null)
                return null;
            return new UserData
            {
                Id = userDTO.Id,
                UserName = userDTO.UserName,
                Password = userDTO.Password,

                 // Assuming you want to create a new Role entity
            };
        }


        // Map from UserDTO to UserData with existing Role
        public static UserData MapToEntityWithRole(UserDTO userDTO, Role role)
        {
            if (userDTO == null || role == null)
                return null;
            return new UserData
            {
                Id = userDTO.Id,
                UserName = userDTO.UserName,
                Password = userDTO.Password,
                RoleID = role.Id,
                Role = role
            };
        }


        //    Map from UserDTO to UserData with Existing UserData and Role
        public static UserData MapToEntityWithExistingUser(UserDTO userDTO, UserData existingUser, Role role)
        {
            if (userDTO == null || existingUser == null || role == null)
                return null;
            existingUser.UserName = userDTO.UserName;
            existingUser.Password = userDTO.Password;
            existingUser.RoleID = role.Id;
            existingUser.Role = role;
            return existingUser;
        }

    }
}
