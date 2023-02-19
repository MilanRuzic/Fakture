using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessLogic.Invoices.Models
{
    public class SearchInvoicesViewModel : IMapFrom<Invoice>
    {
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; } = null!;
        public string Partner { get; set; } = null!;
        public DateTime Date { get; set; }
        public decimal? AmountWithoutVat { get; set; }
        public decimal? Rebate { get; set; }
        public decimal? AmountWithoutVatrebate { get; set; }
        public decimal? AmountVat { get; set; }
        public decimal? Total { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Invoice, SearchInvoicesViewModel>()
                .ForMember(dest => dest.InvoiceId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AmountWithoutVat,
                opt=> opt.MapFrom(src=> src.InvoiceItems.Sum(item => item.AmountWithoutVat)))
                .ForMember(dest => dest.Rebate,
                opt => opt.MapFrom(src => src.InvoiceItems.Sum(item => item.Rebate)))
                .ForMember(dest => dest.AmountWithoutVatrebate,
                opt => opt.MapFrom(src => src.InvoiceItems.Sum(item => item.AmountWithoutVatrebate)))
                .ForMember(dest => dest.AmountVat,
                opt => opt.MapFrom(src => src.InvoiceItems.Sum(item => item.AmountVat)))
                .ForMember(dest => dest.Total,
                opt => opt.MapFrom(src => src.InvoiceItems.Sum(item => item.Total)));
        }
    }
}
