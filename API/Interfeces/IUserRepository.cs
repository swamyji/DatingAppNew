using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfeces
{
    public interface IUserRepository
    {
         void Update(AppUser user);

         Task<bool> SaveAllAsync();
         Task<IEnumerable<AppUser>> GetUsersAsync();

         Task<AppUser> GetUserByIdAsync(int id);

         Task<AppUser> GetUserByNameAsync(string username);

         Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);

         Task<MemberDto> GetMemberAsync(string username);

         
    }
}