namespace Checlist.DTOs
{
    using AutoMapper;
    using Checlist.Models;
    using System.Collections.Generic;

    public class Mapper : Profile
    {
        public Mapper()
        {
            #region Action translator
            CreateMap<Action, Action>()
                .ForMember(destination => destination.Id, options => options.MapFrom(source => source.Id))
                .ForMember(destination => destination.Name, options => options.MapFrom(source => source.Name))
                .ForMember(destination => destination.Done, options => options.MapFrom(source => source.Done))
                .ForMember(destination => destination.Date, options => options.MapFrom(source => source.Date));
            #endregion
        }
    }
}
