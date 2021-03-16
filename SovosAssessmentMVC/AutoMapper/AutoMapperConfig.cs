using AutoMapper;
using DataAccess.Models;
using SovosAssessmentMVC.Models;
using System;
using Enum = SovosAssessmentMVC.Models.Enum;

namespace SovosAssessmentMVC.AutoMapper
{
    public class AutoMapperConfig
    {
        public static IMapper Mapper
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CaseModel, CaseViewModel>()
                        .ForMember(d => d.TypeEnum, opts => opts.MapFrom(s => (Enum.TypeEnum) s.Type))
                        .ForMember(d => d.StatusEnum, opts => opts.MapFrom(s => (Enum.StatusEnum) s.Status));
                    cfg.CreateMap<CaseViewModel, CaseModel>()
                        .ForMember(d => d.Type, opts => opts.MapFrom(s => (int?) s.TypeEnum == null ? null : (int?) s.TypeEnum))
                        .ForMember(d => d.Status, opts => opts.MapFrom(s => (int?) s.StatusEnum == null ? null : (int?) s.StatusEnum));
                }).CreateMapper();
            }
        }
    }
}