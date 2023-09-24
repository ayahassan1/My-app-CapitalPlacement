using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
	internal class PreviewController
	{
		private readonly CosmosDbContext _context;
		public PreviewController(CosmosDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetPreview(string id)
		{
			var preview = await _context.Preview.FindAsync(id);

			if (preview == null)
			{
				return NotFoundResult();
			}

			return Ok(preview);
		}
	}
}
