using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiVentaOnline.Context;
using ApiVentaOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiVentaOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductoController(AppDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(_context.producto.Include(p => p.usuario).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                var producto = _context.producto.Include(p => p.usuario).FirstOrDefault(item => item.id == id);
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("id", Name = "GetByIdProducto")]
        [HttpPost]
        public ActionResult Post([FromBody] Producto producto)
        {
            try
            {
                _context.producto.Add(producto);
                _context.SaveChanges();
                return CreatedAtRoute("GetByIdProducto", new { producto.id }, producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
