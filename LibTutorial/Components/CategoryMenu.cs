using Application.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibTutorial.Components {
    public class CategoryMenu : BaseComponent {
        public CategoryMenu(IMediator mediator) : base(mediator) {
        }

        public async Task<IViewComponentResult> InvokeAsync() {
            var categories = await Mediator.Send(new GetCategoryQuery());
            return View(categories);
        }
    }
}
