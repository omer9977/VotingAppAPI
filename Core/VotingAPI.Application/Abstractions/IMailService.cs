using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Dto.Request.Mail;

namespace VotingAPI.Application.Abstractions
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);

    }
}