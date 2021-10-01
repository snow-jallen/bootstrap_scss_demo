using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        [BindProperty]
        public SignUp UserSignupInfo { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
                return RedirectToPage();
            return Page();
        }
    }

    public class SignUp
    {
        [Required]
        public string Name { get; set; }
        [Range(1,10,ErrorMessage ="Please bring at least 1 bag, but no more than 10."), Display(Name="Bags of Chips")]
        public int BagsOfChips { get; set; }
        [EmailAddress, Display(Name="Email Address")]
        public string Email { get; set; }
        [Display(Name ="Sign up by")][DataType(DataType.Date)]
        public DateTime DueDate { get; set; } = DateTime.Today;
    }
}
