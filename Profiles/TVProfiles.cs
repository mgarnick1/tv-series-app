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
                .ForMember(tv => tv.TVSeries, u => u.MapFrom(_ => _.TVSeries))
            ;

            CreateMap<TVSeries, TVSeriesViewModel>()
                .ForMember(tvm => tvm.NetworkLogoUrl, tv => tv.MapFrom(_ => _.NetworkLogo.LogoUrl))
                .ForMember(tvm => tvm.NetworkName, tv => tv.MapFrom(_ => _.NetworkLogo.NetworkName))
            ;
            CreateMap<TVSeriesViewModel, TVSeries>()
            ;

            CreateMap<NetworkLogo, NetworkLogoViewModel>()
            ;

             CreateMap<NetworkLogo, NetworkLogoViewModel>().ReverseMap()
            ;

            CreateMap<EpisodeDateTVShowsViewModel, TVSeriesViewModel>()
                .ForMember(tvm => tvm.Id, ep => ep.Ignore())
                .ForMember(tvm => tvm.Name, ep => ep.MapFrom(_ => _.name))
                .ForMember(tvm => tvm.Description, ep => ep.MapFrom(_ => _.permalink))
                .ForMember(tvm => tvm.ShowImage, ep => ep.MapFrom(_ => _.image_thumbnail_path))
                .ForMember(tvm => tvm.Rating, ep => ep.Ignore())
                .ForMember(tvm => tvm.Genre, ep => ep.Ignore())
                .ForMember(tvm => tvm.NetworkId, ep => ep.Ignore())
                .ForMember(tvm => tvm.NetworkLogoUrl, ep => ep.Ignore())
                .ForMember(tvm => tvm.UserId, ep => ep.Ignore())
                .ForMember(tvm => tvm.NetworkLogo, ep => ep.MapFrom(_ => _.NetworkLogo))
                .ForMember(tvm => tvm.NetworkName, ep => ep.MapFrom(_ => _.network))
            ;
        }
    }
}