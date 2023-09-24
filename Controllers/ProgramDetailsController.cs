using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
	internal class ProgramDetailsController
	{
		private readonly CosmosDbContext _context;
		public ProgramDetailsController(CosmosDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		[HttpPost]
		public async Task<IActionResult> CreateProgramDetails([FromBody] ProgramDetails programdetails)
		{
			if (programdetails == null)
			{
				return BadRequest("Programdetails data is invalid.");
			}

			_context.programdetails.Add(programdetails);
			await _context.SaveChangesAsync();

			return CreatedAtAction("Get programdetails", new { id = programdetails.Id }, programdetails);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProgramDetails(string id)
		{
			var preview = await _context.Preview.FindAsync(id);

			if (preview == null)
			{
				return NotFoundResult();
			}

			return Ok(preview);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateProgramDetails(string id, [FromBody] ProgramDetails updatedProgramDetails)
		{
			if (updatedProgramDetails == null || id != updatedProgramDetails.Id)
			{
				return BadRequest("Invalid request data.");
			}
			var existingProgramDetails = await _context.programdetails.FindAsync(id);
			if (existingProgramDetails == null)
			{
				return NotFound();
			}
			existingProgramDetails.Summary = updatedProgramDetails.Summary;
			existingProgramDetails.Summary = updatedProgramDetails.Summary;

			_context.programdetails.Update(existingProgramDetails);
			await _context.SaveChangesAsync();

			return NoContent();
		}

	}
}
