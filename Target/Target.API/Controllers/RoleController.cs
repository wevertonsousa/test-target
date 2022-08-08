using Microsoft.AspNetCore.Mvc;
using Target.Domain.Interfaces;

namespace Target.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var result = _roleRepository.GetList();
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public IActionResult Get([FromRoute]int Id)
        {
            var result = _roleRepository.GetById(Id);
            return Ok(result);
        }
    }
}
