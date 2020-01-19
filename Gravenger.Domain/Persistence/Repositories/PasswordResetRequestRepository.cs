﻿using Gravenger.Domain.Core.Models;
using Gravenger.Domain.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Gravenger.Domain.Persistence.Repositories
{
    public class PasswordResetRequestRepository : IPasswordResetRequestRepository
    {
        private readonly GravengerContext context;

        public PasswordResetRequestRepository(GravengerContext context)
        {
            this.context = context;
        }
        
        public PasswordResetRequest GetByIDAndToken(int passwordResetRequestID, string token)
        {
            return this.context.PasswordResetRequests
                .FirstOrDefault(prr => prr.PasswordResetRequestID == passwordResetRequestID && prr.Token == token);
        }

        public IEnumerable<PasswordResetRequest> GetAllRevocableTokens(int accountID)
        {
            return this.context.PasswordResetRequests
                .Where(prr => prr.AccountID == accountID && !prr.Used)
                .ToList();
        }
        
        public void Add(PasswordResetRequest passwordResetRequest)
        {
            this.context.PasswordResetRequests.Add(passwordResetRequest);
        }
    }
}
