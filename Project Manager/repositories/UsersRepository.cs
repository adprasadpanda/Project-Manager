using Microsoft.EntityFrameworkCore;
using Project_Manager.dbcontext;
using Project_Manager.models;

namespace Project_Manager.repositories
{
    public class UsersRepository : IUsersRepository
    {

        public readonly ProjectsContext projectsContext;

        public UsersRepository(ProjectsContext projectsContext)
        {
            this.projectsContext = projectsContext;
            
        }

        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            return await projectsContext.Users.ToListAsync();
        }

        public async Task<Users> GetUser(Guid userId)
        {
            var user = await projectsContext.Users.FirstOrDefaultAsync(x => x.userId == userId);
            return user;
        }

        public async Task<Users> AddUser(Users users)
        {
            users.userId = new Guid();
            await projectsContext.AddAsync(users);
            await projectsContext.SaveChangesAsync();

            return users;
        }

    }

}