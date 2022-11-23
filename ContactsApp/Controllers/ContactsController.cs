using ContactsApp.Domain.Models;
using ContactsApp.Domain.Services;
using ContactsApp.Requests.Contacts;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactsService _service;

        public ContactsController(ContactsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _service.GetAll() ?? Array.Empty<Contact>();
        }

        [HttpPost]
        public async Task<int> Create([FromBody] ContactViewModel viewModel)
        {
            return await _service.Create(viewModel.ToModel());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ContactViewModel viewModel)
        {
            var model = viewModel.ToModel();
            model.Id = id;

            var result = await _service.Update(model);

            return result ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);

            return result ? Ok() : NotFound();
        }
    }
}
