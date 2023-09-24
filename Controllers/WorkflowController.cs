using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
	internal class WorkflowController
	{
		private readonly CosmosDbContext _context;
		public WorkflowController(CosmosDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetWorkflow(string id)
		{
			var workflow = await _context.workflow.FindAsync(id);

			if (workflow == null)
			{
				return NotFoundResult();
			}

			return Ok(workflow);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateWorkflow(string id, [FromBody] Workflow updatedWorkflow)
		{
			if (updatedWorkflow == null || id != updatedWorkflow.Id)
			{
				return BadRequest("Invalid request data.");
			}
			var existingWorkflow = await _context.workflow.FindAsync(id);
			if (existingWorkflow == null)
			{
				return NotFound();
			}
			existingWorkflow.Stage_type = updatedWorkflow.Stage_type;
			existingWorkflow.Stage_type = updatedWorkflow.Stage_type;

			_context.workflow.Update(existingWorkflow);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
