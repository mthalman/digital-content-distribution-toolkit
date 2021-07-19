﻿using AutoMapper;
using blendnet.common.dto.Incentive;

namespace blendnet.incentive.api.Model
{
    public class IncentiveMappingProfile : Profile
    {
        public IncentiveMappingProfile()
        {
            CreateMap<IncentivePlan, IncentivePlanDto>();
            CreateMap<IncentivePlanDto, IncentivePlan>();
            CreateMap<PlanDetail, PlanDetailDto>();
            CreateMap<PlanDetailDto, PlanDetail>();
        }
    }
}