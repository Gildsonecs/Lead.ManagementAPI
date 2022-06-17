using AutoMapper;
using Lead.Management.Application.Interfaces;
using Lead.Management.Domain.Entities;
using Lead.Management.Domain.Models;
using Lead.Management.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Lead.Management.Application
{
    public class InvitedApplication : IInvitedApplication
    {
        private readonly IInvitedRepository _invitedRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public InvitedApplication(IInvitedRepository invitedRepository, IMapper mapper, IEmailSender emailSender)
        {
            _invitedRepository = invitedRepository;
            _mapper = mapper;
            _emailSender = emailSender;
        }

        public async Task CreateInvited(InviteCreateModel model) 
        {
            var entity = _mapper.Map<Contacts>(model);
            await _invitedRepository.AddAsync(entity);
        }

        public async Task ChangeAccept(InvitedModel model)  
        {
            if (model.Price > 500)
            {
                float discountedValue = model.Price - (model.Price * (float)0.1);
                await _emailSender.SendEmailAsync("vendas@test.com", discountedValue );
            }

            var entity = _mapper.Map<Contacts>(model);
            await _invitedRepository.ChangeAcceptAsync(entity);
        }

        public async Task ChangeDecline(Guid id) => await _invitedRepository.ChangeDeclineAsync(id);
    }
}
