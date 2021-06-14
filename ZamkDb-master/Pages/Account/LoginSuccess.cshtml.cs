using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZamkDb.Models;

namespace ZamkDb.Pages.Account
{
    public class LoginSuccessModel : PageModel
    {
	    [BindProperty] public Participant Participant { get; set; } = new Participant();

	    
        public void OnGet()
        {
        }
    }
}
