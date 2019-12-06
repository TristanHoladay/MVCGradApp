using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradAppAPI.APIModels
{
    public static class CompanyMappingExtensions
    {
        public static CompanyApiModel ToApiModel(this Company company)
        {
            return new CompanyApiModel
            {
                Id = company.Id,
                Name = company.Name,
                Status = company.Status
            };
        }

        public static Company ToDomainModel(this CompanyApiModel companyApiModel)
        {
            return new Company
            {
                Name = companyApiModel.Name,
                Status = companyApiModel.Status
            };
        }

        public static IEnumerable<CompanyApiModel> ToApiModels(this IEnumerable<Company> companies)
        {
            return companies.Select(c => c.ToApiModel());
        }

        public static IEnumerable<Company> ToDomainModels(this IEnumerable<CompanyApiModel> companies)
        {
            return companies.Select(c => c.ToDomainModel());
        }

    }
}
