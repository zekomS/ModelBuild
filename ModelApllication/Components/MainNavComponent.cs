using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelApllication.ViewModels.Components;
using Microsoft.AspNetCore.Mvc;

namespace ModelApllication.Components
{
    [ViewComponent (Name = "MainNavigation")]
    public class MainNavComponent : ViewComponent
    {
        private IEnumerable<MainNavLinkVM> links { get; set; }

        public MainNavComponent()
        {
            links = new List<MainNavLinkVM>
            {
                new MainNavLinkVM{ Controller ="Home", Action = "Index", Text = "Home1"},
                new MainNavLinkVM{ Controller ="Home", Action = "About", Text = "About1"}
            };
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var navlinks = links;
            foreach (var nav in links)
            {
                if (this.RouteData.Values["controller"]?.ToString().ToLower() == nav.Controller.ToLower()
                    && this.RouteData.Values["action"]?.ToString().ToLower() == nav.Action.ToLower())
                {
                    nav.IsActive = true;
                }
            }

            return View(links);
        }
            
    }
}
