using _101_Controller.Models;
using Asp.NetCore6._0.ViewModel;
using AutoMapper;

namespace Asp.NetCore6._0.Mapping
{
    public class ViewModelMapping:Profile
    {
        public ViewModelMapping()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}
