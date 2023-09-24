using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
	[ApiController]
	[Route("api/ApplicationForm")]
	public class ApplicationFormController : ControllerBase
	{
		private readonly CosmosDbContext _context;

		public ApplicationFormController(CosmosDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetApplicationForm(string id)
		{
			var application_form = await _context.applicationform.FindAsync(id);

			if (application_form == null)
			{
				return NotFound();
			}

			return Ok(application_form);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateApplicationForm(string id, [FromBody] ApplicationForm updatedApplicationForm)
		{
			if (updatedApplicationForm == null || id != updatedApplicationForm.Id)
			{
				return BadRequest("Invalid request data.");
			}
			var existingApplicationForm = await _context.applicationform.FindAsync(id);
			if (existingApplicationForm == null)
			{
				return NotFound();
			}
			existingApplicationForm.Description = updatedApplicationForm.Description;
			existingApplicationForm.Description = updatedApplicationForm.Description;

			_context.applicationform.Update(existingApplicationForm);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}