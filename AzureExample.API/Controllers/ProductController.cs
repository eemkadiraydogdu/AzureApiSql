using AzureExample.API.DB;
using AzureExample.API.Models;
using AzureExample.API.Repositories;
using AzureExample.API.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzureExample.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{

		private readonly IRepository<Product> _repository;
		private readonly IUnitOfWork _unitOfWork;

		public ProductController(IUnitOfWork unitOfWork, IRepository<Product> repository)
		{
			_unitOfWork = unitOfWork;
			_repository = repository;
		}

		[HttpPost]
		public async Task<IActionResult> Add(Product product) 
		{ 
			await _repository.AddAsync(product);
			await _unitOfWork.CommitAsync();
			return Ok();
		}
	}
}
