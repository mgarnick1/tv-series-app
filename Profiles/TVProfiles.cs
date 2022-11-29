using System;
using AutoMapper;
using tv_series_app.Models;
using tv_series_app.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace tv_series_app.Profiles
{
    public class TVProfiles : Profile
    {
        public TVProfiles()
        {

            CreateMap<UserViewModel, User>()
                .ForMember(u => u.UserName, uvm => uvm.MapFrom(_ => _.Email))
            ;
            CreateMap<User, UserViewModel>()
            ;

            CreateMap<User, UserTVSeriesModel>()
            ;
        }
    }
}