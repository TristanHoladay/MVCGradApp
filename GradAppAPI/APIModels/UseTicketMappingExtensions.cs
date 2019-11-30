using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradAppAPI.APIModels
{
    public static class UseTicketMappingExtensions
    {
        public static UseTicketApiModel ToApiModel(this UseTicket useTicket)
        {
            return new UseTicketApiModel
            {
                Id = useTicket.Id,
                TISNumber = useTicket.TISNumber,
                Date = useTicket.Date,
                Notes = useTicket.Notes,
                companyId = useTicket.CompanyId,
                Company = useTicket.Company != null
                    ? useTicket.Company.Name
                    : null,
                userId = useTicket.userId,
                User = useTicket.User != null
                    ? useTicket.User.FullName
                    : null,
                Items = useTicket.UsedItems
            };
        }

        public static UseTicket ToDomainModel(this UseTicketApiModel useTicket)
        {
            return new UseTicket
            {
                Id = useTicket.Id,
                TISNumber = useTicket.TISNumber,
                Date = useTicket.Date,
                Notes = useTicket.Notes,
                userId = useTicket.userId,
                CompanyId = useTicket.companyId
            };
        }

        public static IEnumerable<UseTicketApiModel> ToApiModels(this IEnumerable<UseTicket> useTickets)
        {
            return useTickets.Select(ut => ut.ToApiModel());
        }

        public static IEnumerable<UseTicket> ToDomainModels(this IEnumerable<UseTicketApiModel> useTickets)
        {
            return useTickets.Select(ut => ut.ToDomainModel());
        }
    }
}
