using Project_Manager.models;

namespace Project_Manager.repositories 
{
    public interface IUsersRepository {

        Task<IEnumerable<Users>> GetAllUsers();

        Task<Users> GetUser(Guid id);

        Task<Users> AddUser(Users users);


    }

}