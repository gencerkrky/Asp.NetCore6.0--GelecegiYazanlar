using Asp.NetCore6._0.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Turkcell.Models;

namespace Asp.NetCore6._0.Views.Shared.ViewComponents
{
    public class VisitorViewComponent:ViewComponent
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public VisitorViewComponent(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var visitor = _context.Visitors.ToList();

            var visitorViewModel = _mapper.Map<List<VisitorViewModel>>(visitor);

            ViewBag.visitorViewModels = visitorViewModel;
            return View();
        }

    }
}
