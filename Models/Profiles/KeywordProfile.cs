using AutoMapper;
using Models.Models;
using Models.RawModels;

namespace Models.Profiles
{
    public class KeywordProfile: Profile
    {
        public KeywordProfile()
        {
            CreateMap<RawKeyword, Keyword>();
            CreateMap<Keyword, RawKeyword>();
        }
    }
}