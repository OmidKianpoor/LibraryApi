using AutoMapper;
using LibraryApi.DbContexts;
using LibraryApi.Dtos;
using LibraryApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class OrdersController:ControllerBase
    {
        private readonly LibraryDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(LibraryDbContext context,IMapper mapper,ILogger<OrdersController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        // POST: api/orders
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (dto.Items == null || dto.Items.Count == 0)
                return BadRequest("Order must contain at least one item.");

            var bookIds = dto.Items.Select(i => i.BookId).Distinct().ToList();
            var books = await _context.Books.Where(b => bookIds.Contains(b.Id)).ToListAsync();

            if (books.Count != bookIds.Count)
                return BadRequest("One or more BookIds are invalid.");

            using var tx = await _context.Database.BeginTransactionAsync();

            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.UtcNow
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync(); // نیاز به order.UserId برای FK آیتم‌ها

            int total = 0;

            foreach (var itemDto in dto.Items)
            {
                var book = books.First(b => b.Id == itemDto.BookId);

                // UnitPrice را از Book.Price می‌گیریم (Book.Price از نوع int است)
                int unitPrice = book.Price;

                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    BookId = itemDto.BookId,
                    Quantity = itemDto.Quantity,
                    UnitPrice = unitPrice
                };

                _context.OrderItems.Add(orderItem);
                total += unitPrice * itemDto.Quantity;
            }

            order.TotalPrice = total;
            await _context.SaveChangesAsync();
            await tx.CommitAsync();

            // بارگذاری مجدد برای بازگشت DTO
            var orderWithItems = await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == order.Id);

            var orderDto = _mapper.Map<OrderDto>(orderWithItems);
            orderDto.Items = orderWithItems.Items.Select(i => new OrderItemDto
            {
                Id = i.Id,
                BookId = i.BookId,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice
            }).ToList();

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, orderDto);
        }

        // GET: api/orders/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return NotFound();

            var dto = _mapper.Map<OrderDto>(order);
            dto.Items = order.Items.Select(i => new OrderItemDto
            {
                Id = i.Id,
                BookId = i.BookId,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice
            }).ToList();

            return Ok(dto);
        }

        // GET: api/orders
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _context.Orders
                .Include(o => o.Items)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            var dtos = _mapper.Map<List<OrderDto>>(orders);
            for (int i = 0; i < orders.Count; i++)
            {
                dtos[i].Items = orders[i].Items.Select(it => new OrderItemDto
                {
                    Id = it.Id,
                    BookId = it.BookId,
                    Quantity = it.Quantity,
                    UnitPrice = it.UnitPrice
                }).ToList();
            }

            return Ok(dtos);
        }

        // DELETE: api/orders/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

    

