﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Dto.Request.Department;
using VotingAPI.Application.Dto.Response.Department;
using VotingAPI.Application.Exceptions;
using VotingAPI.Application.Repositories.ModelRepos;
using VotingAPI.Domain.Entities;

namespace VotingAPI.Persistence.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentReadRepo _departmentReadRepo;
        private readonly IDepartmentWriteRepo _departmentWriteRepo;
        private readonly IMapper _mapper;
        public DepartmentService(
            IDepartmentReadRepo departmentReadRepo,
            IDepartmentWriteRepo departmentWriteRepo,
            IMapper mapper
            )
        {
            _departmentReadRepo = departmentReadRepo;
            _departmentWriteRepo = departmentWriteRepo;
            _mapper = mapper;
        }
        public List<GetDepartmentResponse> GetDepartmentList()
        {
            var department = _departmentReadRepo.GetAll().ToList();
            var response = _mapper.Map<List<GetDepartmentResponse>>(department);
            return response;
        }
        public async Task<bool> AddDepartmentAsync(AddDepartmentRequest addDepartmentRequest)
        {
            var departmentMapped = _mapper.Map<Department>(addDepartmentRequest);
            bool isAdded = await _departmentWriteRepo.AddAsync(departmentMapped);
            if (!isAdded)
                throw new DataNotAddedException();
            await _departmentWriteRepo.SaveChangesAsync();
            return isAdded;
        }

        public async Task<GetDepartmentResponse> GetDepartmentByIdAsync(int id)
        {
            var department = await _departmentReadRepo.GetByIdAsync(id);
            if (department == null)
                throw new DataNotFoundException(id);
            var response = _mapper.Map<GetDepartmentResponse>(department);
            return response;
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            bool isDeleted = await _departmentWriteRepo.RemoveByIdAsync(id);
            if(!isDeleted)
                throw new DataNotDeletedException();
            await _departmentWriteRepo.SaveChangesAsync();
            return isDeleted;
        }
    }
}