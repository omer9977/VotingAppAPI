using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Dto.Request.Candidate;
using VotingAPI.Application.Dto.Request.File;
using VotingAPI.Application.Dto.Response;
using VotingAPI.Application.Dto.Response.Candidate;
using VotingAPI.Application.Dto.Response.ProfilePhoto;
using VotingAPI.Application.Dto.Response.User;

namespace VotingAPI.Application.Abstractions
{
    public interface ICandidateService
    {
        //public async Task<List<>> AddCandidateList();
        Task<TokenResponse> AddCandidateAsync(AddCandidateRequest addCandidateRequest);
        Task<GetCandidateResponse> GetCandidateByIdAsync(int id);
        Task<GetCandidateListResponse> GetCandidateListAsync();
        Task<TokenResponse> WithdrawCandidateAsync(string userName);
        //Task<GetFileResponse> GetCandidateFileAsync(int candidateId, short fileTypeId);
        //Task<bool> UploadCandidateFileAsync(AddCandidateFileRequest addFileRequest); // daha sonrasında bool kaldır
        //Task<bool> DeleteCandidateFileAsync(int candidateId, short fileTypeId);
    }
}
