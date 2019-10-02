using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Domain.Entities; 
using Application.ModelsDto.ActivoDto_Agreggate_Root;

namespace Application.ModelsDto
{
    public class AutoMapperMappingProfile : Profile
    {
        public AutoMapperMappingProfile()
        { 
            CreateMap<ActivoDto, Activo>();
            CreateMap<Activo, ActivoDto>();
            CreateMap<DocumentacionActivoDTO, DocumentacionActivo>();
            CreateMap<DocumentacionActivo, DocumentacionActivoDTO>();
            CreateMap<ListadoInspeccion, ListadoInspeccionDTO>();
            CreateMap<ListadoInspeccionDTO, ListadoInspeccion>();
            CreateMap<ItemControl, ItemControlDTO>();
            CreateMap<ItemControlDTO, ItemControl>();
            CreateMap<Inspeccion, InspeccionDTO>();
            CreateMap<InspeccionDTO, Inspeccion>();
            CreateMap<InspeccionEstado, InspeccionEstadoDTO>();
            CreateMap<InspeccionEstadoDTO, InspeccionEstado>();
            CreateMap<Inspeccion_ItemControl_ValoresDTO, Inspeccion_ItemControl_Valores>();
            CreateMap<Inspeccion_ItemControl_Valores, Inspeccion_ItemControl_ValoresDTO>(); 
            CreateMap<TipoActivo, TipoActivoDTO>();
            CreateMap<TipoActivoDTO, TipoActivo>();

        }
    }
}
