using AutoMapper;

namespace EcommerceMicroServices.Api.Checkout.Common.ObjectMapProfiles
{
    public class CheckoutMapProfile :Profile
    {
        public CheckoutMapProfile()
        {
            CreateMap<Data.Entities.Checkout, Models.CheckoutModel>().ReverseMap();
        }
    }
}
