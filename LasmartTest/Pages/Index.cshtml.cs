﻿using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LasmartTest.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        private readonly ILogger<IndexModel> _logger;
    }
}