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

        public async Task<Users?> DeleteUser(Guid userId)
        {
            var user = await projectsContext.Users.FirstOrDefaultAsync(x => x.userId == userId);
        

            if(user == null){
                return null;
            }
            else {
                
                projectsContext.Users.Remove(user);
                await projectsContext.SaveChangesAsync();

                return user;
            }
        }

        public async Task<Users> UpdateUsers(Guid userId, Users newUser)
        {
            var user = await projectsContext.Users.FirstOrDefaultAsync(x => x.userId == userId);

            if(user == null){
                return user;
            }

            user.userName = newUser.userName;
            user.role = newUser.role;
            user.emailId = newUser.emailId;
            user.password = newUser.password;
            user.assignedIssues = newUser.assignedIssues;
            user.reporterOfIssues = newUser.reporterOfIssues;

            return user;


        }
    }

}