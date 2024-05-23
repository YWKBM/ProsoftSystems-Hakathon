using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace AuthService.Mappings;

public class WebMapping : Profile
{
    public WebMapping() 
    {
        // SignUp
        CreateMap<Controllers.DTO.SignUp.Request, AuthLogic.Features.Auth.SignUp.Request>();

        CreateMap<AuthLogic.Features.Auth.SignUp.Result, Controllers.DTO.SignUp.Response>();


        // SignIn
        CreateMap<Controllers.DTO.SignIn.Request, AuthLogic.Features.Auth.SignIn.Request>();

        CreateMap<AuthLogic.Features.Auth.SignIn.Result, Controllers.DTO.SignIn.Response>();
    }

}