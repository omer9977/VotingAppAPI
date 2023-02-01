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
        Task<Result> UploadCandidateImageAsync(int candidateId, IFormFileCollection files);
        //public async Task<List<>> AddCandidateList();
        Task<Result> AddCandidateAsync(AddCandidateRequest addCandidateRequest);
        Task<Result> GetCandidateByIdAsync(int id);
        Result GetCandidateList();
        Task<Result> GetCandidateImage(int candidateId);
        Task<Result> DeleteCandidateProfilePhotoAsync(int candidateId);
    }
}
