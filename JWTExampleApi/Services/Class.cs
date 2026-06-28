using JWTExampleApi.DTOs;
using JWTExampleApi.Entitties;
using JWTExampleApi.Mappers;
using JWTExampleApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JWTExampleApi.Services
{
    public class UserService
    {

        public BaseRepository USerRepository { get; set; }
        public UserService([FromKeyedServices("user")]BaseRepository _uSerRepository) {
            USerRepository = _uSerRepository;
        }


        public List<UserDTO> GetAllUsers()
        {
            //var users = USerRepository.GetAll<UserData>(null, x=>x.Role)
            //    .Select(x=> UserDataDTOMapper.MapToDTO(x)).ToList();

            var users = USerRepository.GetAll<UserData>(null, x => x.Role)
            .Select(x => x.MapToDTO()).ToList();

            return users;
        }


    }
}
