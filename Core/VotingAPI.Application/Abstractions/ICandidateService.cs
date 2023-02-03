using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Dto.Request.Candidate;
using VotingAPI.Application.Dto.Response;
using VotingAPI.Application.Dto.Response.Candidate;
using VotingAPI.Application.Dto.Response.ProfilePhoto;

namespace VotingAPI.Application.Abstractions
{
    public interface ICandidateService
    {
        Task<bool> UploadCandidateImageAsync(int candidateId, IFormFileCollection files); // daha sonrasında bool kaldır
        //public async Task<List<>> AddCandidateList();
        Task<bool> AddCandidateAsync(AddCandidateRequest addCandidateRequest);
        Task<GetCandidateResponse> GetCandidateByIdAsync(int id);
        List<GetCandidateResponse> GetCandidateList();
        Task<GetProfilePhotoResponse> GetCandidateImageAsync(int candidateId);
        Task<bool> DeleteCandidateProfilePhotoAsync(int candidateId);
    }
}
