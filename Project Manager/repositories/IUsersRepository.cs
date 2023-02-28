using Project_Manager.models;

namespace Project_Manager.repositories 
{
    public interface IUsersRepository {

        Task<IEnumerable<Users>> GetAllUsers();

        Task<Users> GetUser(Guid id);

        Task<Users> AddUser(Users users);

        Task<Users> DeleteUser(Guid id);

        Task<Users> UpdateUsers(Guid id, Users users);


    }

}