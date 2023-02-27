using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project_Manager.dbcontext;
using Project_Manager.models;
using Project_Manager.repositories;

namespace Project_Manager.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : Controller
    {
        private readonly IUsersRepository usersRepository;

        private readonly IMapper mapper;

        public UsersController(IUsersRepository usersRepository, IMapper mapper)
        {
            this.usersRepository = usersRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("getallusers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await usersRepository.GetAllUsers();
            var usersDTO = mapper.Map<List<models.dtos.Users>>(result);

            if (usersDTO == null)
            {
                return NotFound();
            }
            return Ok(result);

        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetUser")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await usersRepository.GetUser(id);
            var response = mapper.Map<models.dtos.Users>(user);

            if (response == null)
            {

                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Users>> AddUser(models.dtos.AddUsersRequest addUsersRequest)
        {
   
            var newUser = new Users()
            {
                userName = addUsersRequest.userName,
                role= addUsersRequest.role,
                emailId= addUsersRequest.emailId,
                password= addUsersRequest.password,
                reporterOfIssues= addUsersRequest.reporterOfIssues,
                assignedIssues = addUsersRequest.assignedIssues


            };

            newUser = await usersRepository.AddUser(newUser);

            var usersDTO = new models.dtos.Users() 
            {
                userId = newUser.userId,
                userName = newUser.userName,
                role= newUser.role,
                emailId= newUser.emailId,
                password= newUser.password,
                reporterOfIssues= newUser.reporterOfIssues,
                assignedIssues = newUser.assignedIssues

            };

            // return CreatedAtAction(nameof(GetUser), new {projectId = newUser.userId}, usersDTO);
            return Ok(usersDTO);
            

        }


    }

}