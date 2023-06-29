using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment1V1.Areas.Identity.Data;
using Assignment1V1.Models;
using Microsoft.AspNetCore.Identity;

namespace Assignment1V1.Controllers
{
    public class UserProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserProductsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager= userManager;
        }

        // GET: UserProducts
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin"))
            {
                var applicationDbContext = _context.UserProducts.Include(u => u.Course).Include(u => u.User).OrderBy(x => x.Course.Name);
                return View(await applicationDbContext.ToListAsync());
            }
            else
            {
                var applicationDbContext = _context.UserProducts.Where(x => x.UserId == _userManager.GetUserId(User)).Include(u => u.Course).Include(u => u.User).OrderBy(x => x.Course.Name);
                return View(await applicationDbContext.ToListAsync());
            }
           
        }
        public async Task<IActionResult> Apply(int? courseId) 
        {
            UserProducts userProducts = new UserProducts();

            userProducts.CourseId = courseId;
            userProducts.UserId = _userManager.GetUserId(User);

            _context.UserProducts.Add(userProducts);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string? userId, int? courseId)
        {
            var userProduct = _context.UserProducts.Where(x => x.UserId == userId && x.CourseId == courseId).FirstOrDefault();

            if(userProduct == null) return RedirectToAction(nameof(Index));

            _context.UserProducts.Remove(userProduct);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
