using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestBoard.Pages
{
    public class TawoolyModel
    {
        private readonly ILogger<TawoolyModel> _logger;

        public TawoolyModel(ILogger<TawoolyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}