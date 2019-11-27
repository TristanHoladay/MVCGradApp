using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepo;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepo = companyRepository;
        }

        public IEnumerable<Company> GetAll()
        {
            IEnumerable<Company> companies = _companyRepo.GetAll();

            if(companies == null)
            {
                throw new ApplicationException("There are no companies to display.");
            }

            return companies;
        }

        public Company Get(int id)
        {
            Company company = _companyRepo.Get(id);

            if(company == null)
            {
                throw new ApplicationException("This company does not exist.");
            }

            return company;
        }

        public Company Add(Company newCompany)
        {
            Company company = _companyRepo.Add(newCompany);

            if(company == null)
            {
                throw new ApplicationException("This company already exists. You can make duplicates of the same company.");
            }

            return company;
        }

        public Company Update(Company updatedCompany)
        {
            Company company = _companyRepo.Update(updatedCompany);

            if(company == null)
            {
                throw new ApplicationException("The company you are trying to update does not exist.");
            }

            return company;
        }

        public void Delete(int id)
        {
            _companyRepo.Delete(id);
        }
    }
}
