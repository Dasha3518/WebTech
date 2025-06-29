using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Fedorova.Domain.Entities;
using Fedorova.UI.Data;

namespace Fedorova.UI.Areas.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly Fedorova.UI.Data.ApplicationDbContext _context;

        public DetailsModel(Fedorova.UI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Dish Dish { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dish = await _context.Dish.FirstOrDefaultAsync(m => m.Id == id);
            if (dish == null)
            {
                return NotFound();
            }
            else
            {
                Dish = dish;
            }
            return Page();
        }
    }
}
