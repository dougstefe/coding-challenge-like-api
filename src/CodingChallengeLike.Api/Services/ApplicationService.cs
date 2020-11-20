using System;
using System.Threading.Tasks;
using AutoMapper;
using CodingChallengeLike.Api.ViewModels;
using CodingChallengeLike.Domain.Interfaces.Notifications;
using CodingChallengeLike.Domain.Interfaces.Services;
using CodingChallengeLike.Domain.Models;
using CodingChallengeLike.Domain.Models.Services;
using CodingChallengeLike.Api.Services.Interfaces;
using CodingChallengeLike.Domain.Interfaces.Repositories;

namespace CodingChallengeLike.Api.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly ISsoService _ssoService;
        private readonly IMapper _mapper;
        private readonly IDomainNotification _domainNotification;

        public ApplicationService(IApplicationRepository applicationRepository, ISsoService ssoService, IMapper mapper, IDomainNotification domainNotification)
        {
            _applicationRepository = applicationRepository;
            _ssoService = ssoService;
            _mapper = mapper;
            _domainNotification = domainNotification;
        }

        public async Task<ApplicationResponseViewModel> InsertAsync(ApplicationRequestViewModel applicationViewModel)
        {
            var applicationModel = _mapper.Map<ApplicationRequestModel>(applicationViewModel);
            var trackCode = Guid.NewGuid().ToString("N");
            var responseSso = await _ssoService.RegisterClient(new RegisterClientRequest(){
                ClientId = $"Like{trackCode}",
                GrantType = "client_credentials",
                Scopes = new string[1] {"like-api"}
            });
            if(responseSso is SsoError ssoError){
                _domainNotification.AddNotification("SsoError", ssoError.ErrorMessage);
                return null;
            }
            var registerClientResponse = responseSso as RegisterClientResponse;

            await _applicationRepository.InsertAsync(new ApplicationInsertDapper(){
                Id = trackCode,
                Secret = registerClientResponse.ClientSecret,
                Domains = applicationModel.Domains
            });

            return new ApplicationResponseViewModel(){
                TrackCode = trackCode
            };
        }

        public async Task<AuthenticationResponseViewModel> AuthenticationAsync(AuthenticationRequestViewModel authenticationRequestViewModel)
        {
            var authenticationRequestModel = _mapper.Map<AuthenticationRequestModel>(authenticationRequestViewModel);

            var repoResult = await _applicationRepository.SelectAsync(authenticationRequestModel.TrackCode);
            if(repoResult == null){
                _domainNotification.AddNotification("NotFound", "Application not found");
                return null;
            }
            var responseSso = await _ssoService.ConnectToken(new AuthenticationRequest(){
                ClientId = $"Like{repoResult.Id}",
                ClientSecret = repoResult.Secret,
                GrantType = "client_credentials",
                Scopes = new string[1] {"like-api"}
            });
            if(responseSso is SsoError ssoError){
                _domainNotification.AddNotification("SsoError", ssoError.ErrorMessage);
                return null;
            }
            var connectTokenResponse = responseSso as AuthenticationResponse;

            return _mapper.Map<AuthenticationResponseViewModel>(connectTokenResponse);

        }
    }
}