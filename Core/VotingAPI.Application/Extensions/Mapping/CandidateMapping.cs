using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Dto.General;
using VotingAPI.Application.Dto.Request.Candidate;
using VotingAPI.Application.Dto.Response.Candidate;
using VotingAPI.Application.Repositories.ModelRepos;

namespace VotingAPI.Application.Extensions.Mapping
{
    public static class CandidateMapping
    {
        public static async Task<GetCandidateResponse> ToGetCandidateResponseAsync(this CandidateDto candidateDto, IUserReadRepo userReadRepo)
        {
            var user = await userReadRepo.GetByIdAsync(candidateDto.UserId);
            var getCandidateResponse = new GetCandidateResponse()
            {
                ApproveStatus = (short)candidateDto.ApproveStatus,
                Description = candidateDto.Description,
                FirstName = user.Name,
                LastName = user.LastName,
                UserName = user.UserName,
            };

            return getCandidateResponse;
        }

        public static async Task<GetCandidateListResponse> ToGetCandidateListResponseAsync(this List<CandidateDto> candidatesDto, IUserReadRepo userReadRepo)
        {
            var getCandidateListResponse = new List<GetCandidateResponse>();
            var userIds = new HashSet<int>(candidatesDto.Select(u => u.UserId));
            var users = await userReadRepo.GetWhere(x => userIds.Contains(x.Id)).ToListAsync();

            foreach (var candidateDto in candidatesDto)
            {
                var user = users.FirstOrDefault(u => u.Id == candidateDto.UserId);
                var getCandidateResponse = new GetCandidateResponse()
                {
                    ApproveStatus = (short)candidateDto.ApproveStatus,
                    Description = candidateDto.Description,
                    FirstName = user?.Name ?? "",
                    LastName = user?.LastName ?? "",
                    UserName = user?.UserName ?? "",
                };
                getCandidateListResponse.Add(getCandidateResponse);
            }

            return new GetCandidateListResponse() { CandidateList = getCandidateListResponse };
        }

        public static async Task<GetCandidateListResponse> ToGetCandidateListResponseAsync(this CandidateFilterRequest filter, ICandidateReadRepo candidateReadRepo, IUserReadRepo userReadRepo)
        {
            var getCandidateListResponse = new List<GetCandidateResponse>();
            //var userIds = new HashSet<int>(candidatesDto.Select(u => u.UserId));
            var candidates = await candidateReadRepo.GetWhere(c => c.Id == filter.Id && c.ApproveStatus == filter.ApproveStatus && c.ElectionId == filter.ElectionId).ToListAsync();

            if (!string.IsNullOrEmpty(filter.UserName))
            {
                var user = await userReadRepo.GetSingleAsync(x => x.UserName == filter.UserName);
                var candidate = candidates.FirstOrDefault(c => c.UserId == user.Id);
                var getCandidateResponse = new GetCandidateResponse()
                {
                    ApproveStatus = (short)candidate.ApproveStatus,
                    Description = candidate?.Description ?? "",
                    FirstName = user?.Name ?? "",
                    LastName = user?.LastName ?? "",
                    UserName = user?.UserName ?? "",
                };
                return new GetCandidateListResponse() { CandidateList = { getCandidateResponse } };
            }

            //foreach (var candidate in candidates)
            //{
            //    var users = userReadRepo.GetWhere(x => );
            //    var userDb = users.FirstOrDefault(u => u.Id == candidateDto.UserId);
            //    var getCandidateResponse = new GetCandidateResponse()
            //    {
            //        ApproveStatus = (short)candidateDto.ApproveStatus,
            //        Description = candidateDto.Description,
            //        FirstName = user?.Name ?? "",
            //        LastName = user?.LastName ?? "",
            //        UserName = user?.UserName ?? "",
            //    };
            //    getCandidateListResponse.Add(getCandidateResponse);
            //}

            return new GetCandidateListResponse() { CandidateList = getCandidateListResponse };
        }
    }
}
