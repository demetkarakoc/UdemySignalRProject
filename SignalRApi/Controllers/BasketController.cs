using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BasketController : ControllerBase
	{
		private readonly IBasketService _basketService;
		private readonly IMapper _mapper;

		public BasketController(IBasketService basketService, IMapper mapper)
		{
			_basketService = basketService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetBasketByMenuTableID(int id)
		{
			var values= _basketService.TGetBasketByMenuTableNumber(id);
			return Ok(values);
		}

		[HttpGet("BasketListByMenuTableWithProductName")]
		public IActionResult BasketListByMenuTableWithProductName(int id)
		{
			using var context = new SignalRContext();
			var values = context.Baskets.Include(x => x.Product).Where(y => y.MenuTableID == id).Select(z => new ResultBasketListWithProducts
			{
				BasketID = z.BasketID,
				Count = z.Count,
				MenuTableID = z.MenuTableID,
				Price = z.Price,
				ProductId= z.ProductId,
				TotalPrice = z.TotalPrice,
				ProductName=z.Product.ProductName
			}).ToList();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateBasket(CreateBasketDto createBasketDto)
		{
			using var context = new SignalRContext();
			_basketService.TAdd(new Basket()
			{
				Count = 1,
				Price=context.Products.Where(x=>x.ProductId==createBasketDto.ProductId).Select(y=>y.Price).FirstOrDefault(),
				TotalPrice=0,
				ProductId = createBasketDto.ProductId,
				MenuTableID=createBasketDto.MenuTableID	
			});
			return Ok();

		}

		[HttpDelete("{id}")]
		public IActionResult DeleteBasket(int id)
		{
			var value = _basketService.TGetByID(id);
			_basketService.TDelete(value);
			return Ok("Sepetteki Seçilen Ürün silindi");
		}

	}
}
