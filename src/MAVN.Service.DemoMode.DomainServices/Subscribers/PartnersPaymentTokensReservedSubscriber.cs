﻿using System.Threading.Tasks;
using Lykke.Common.Log;
using MAVN.Service.DemoMode.Domain.Services;
using MAVN.Service.PartnersPayments.Contract;

namespace MAVN.Service.DemoMode.DomainServices.Subscribers
{
    public class PartnersPaymentTokensReservedSubscriber : RabbitSubscriber<PartnersPaymentTokensReservedEvent>
    {
        private readonly IDemoModeService _demoModeService;

        public PartnersPaymentTokensReservedSubscriber(
            string connectionString,
            string exchangeName,
            IDemoModeService demoModeService,
            ILogFactory logFactory)
            : base(connectionString, exchangeName, logFactory)
        {
            _demoModeService = demoModeService;
        }

        public override async Task<(bool isSuccessful, string errorMessage)> ProcessMessageAsync(PartnersPaymentTokensReservedEvent message)
        {
            await _demoModeService.ProcessPartnersPaymentTokensReservedAsync(message);

            return (true, string.Empty);
        }
    }
}
