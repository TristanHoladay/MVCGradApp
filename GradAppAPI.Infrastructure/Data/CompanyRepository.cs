using GradAppAPI.Core.Models;
using GradAppAPI.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Infrastructure.Data
{
    public class CompanyRepository : ICompanyRepository 
    {
        private readonly AppDbContext _dbContext;

        public CompanyRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Company> GetAll()
        {

        }

        public Company Get(int id)
        {

        }

        public Company Add(Company newCompany)
        {

        }

        public Company Update(Company updatedCompany)
        {

        }

        void Delete(int id)
        {

        }

    }
}
