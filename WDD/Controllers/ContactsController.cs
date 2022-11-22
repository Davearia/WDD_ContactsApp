using Microsoft.AspNetCore.Mvc;
using WDD.Data.Entities;
using WDD.Data.Repositories.Abstract;

namespace WDD.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{

		private readonly ILogger<ContactsController> _logger;		
		private readonly IGenericRepository<Contact> _repository;
		private readonly IContactsRepository _contactsRepository;
		
		public ContactsController(ILogger<ContactsController> logger,	
			IGenericRepository<Contact> repository,
			IContactsRepository contactsRepository)
		{
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));			
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
			_contactsRepository = contactsRepository ?? throw new ArgumentNullException(nameof(contactsRepository));
		}
		
		[HttpGet]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		public ActionResult<IEnumerable<Contact>> GetAllContacts()
		{
			try
			{
				return Ok( _repository.GetAll());
			}
			catch (Exception ex)
			{
				_logger.LogError($"GetAllContacts failed: {ex}");
				return BadRequest("GetAllContacts failed");
			}			
		}				
	
		[HttpGet("{lastName}")]		
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		public ActionResult<IEnumerable<Contact>> GetContactByLastName(string lastName)
		{
			try
			{
				return Ok(_contactsRepository.GetContactsByLastName(lastName));
			}
			catch (Exception ex)
			{
				_logger.LogError($"GetContactByLastName failed: {ex}");
				return BadRequest("GetContactByLastName failed");
			}
		}

		[HttpPost]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		public IActionResult CreateContact([FromBody] Contact contact)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					_logger.LogError("Contact model not valid");
					return BadRequest("Contact model not valid");
				}

				contact.Id = null;

				_repository.Insert(contact);
				_repository.Save();

				return Created($"/api/contact/{contact.Id}", contact);
			}
			catch (Exception ex)
			{
				_logger.LogError($"CreateContact failed: {ex}");
				return BadRequest("CreateContact failed");
			}			
		}
		
		[HttpPut("{id}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		public IActionResult UpdateContact(int id, [FromBody] Contact contact)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					_logger.LogError("Contact model not valid");
					return BadRequest("Contact model not valid");
				}

				contact.Id = id;
				_repository.Update(contact);
				_repository.Save();

				return Ok("Contact successfully updated");
			}
			catch (Exception ex)
			{
				_logger.LogError($"UpdateContact failed: {ex}");
				return BadRequest("UpdateContact failed");
			}			
		}
	
		[HttpDelete("{id}")]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		public IActionResult DeleteContact(int id)
		{
			try
			{
				_repository.Delete(id);
				_repository.Save();

				return Ok("Contact successfully deleted");
			}
			catch (Exception ex)
			{
				_logger.LogError($"DeleteContact failed: {ex}");
				return BadRequest("DeleteContact failed");
			}			
		}
	}
}
