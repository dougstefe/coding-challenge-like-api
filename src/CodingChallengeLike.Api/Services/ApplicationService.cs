using System;
using System.Threading.Tasks;
using AutoMapper;
using CodingChallengeLike.Api.ViewModels;
using CodingChallengeLike.Domain.Models;
using CodingChallengLike.Api.Services.Interfaces;
using CodingChallengLike.Domain.Interfaces.Repositories;

namespace CodingChallengeLike.Api.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;

        public ApplicationService(IApplicationRepository applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
        }

        public async Task<ApplicationResponseViewModel> InsertAsync(ApplicationRequestViewModel applicationViewModel)
        {
            var applicationModel = _mapper.Map<ApplicationRequestModel>(applicationViewModel);
            var applicationInsertDapper = new ApplicationInsertDapper(){
                    Id = Guid.NewGuid().ToString("N"),
                    Domains = applicationModel.Domains
                };
            await _applicationRepository.InsertAsync(applicationInsertDapper);
            return new ApplicationResponseViewModel(){
                TrackCode = applicationInsertDapper.Id,
                Domains = applicationModel.Domains
            };
        }
    }
}