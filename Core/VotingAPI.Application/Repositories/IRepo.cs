using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities.Common;

namespace VotingAPI.Application.Repositories
{
    public interface IRepo<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
