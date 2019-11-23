using GradAppAPI.Core.Models;
using GradAppAPI.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        //Super Admin Access
        public IEnumerable<Company> GetAll()
        {
            IEnumerable<Company> companies = _dbContext.Companies.ToList();

            if (companies == null)
                return null;

            return _dbContext.Companies
                .Include(c => c.Tickets)
                .Include(c => c.Items)
                .ToList();
        }


        //Company Admin Access
        public Company Get(int id)
        {
            Company company = _dbContext.Companies.FirstOrDefault(c => c.Id == id);

            if (company == null)
                return null;

            return _dbContext.Companies
                .Include(c => c.Tickets)
                .Include(c => c.Items)
                .FirstOrDefault(c => c.Id == id);
        }

        public Company Add(Company newCompany)
        {
            Company company = _dbContext.Companies.FirstOrDefault(c => c.Id == newCompany.Id);

            if (company != null)
               return null;

            _dbContext.Companies.Add(newCompany);
            _dbContext.SaveChanges();

            return newCompany;
        }

        public Company Update(Company updatedCompany)
        {
            Company currentCompany = _dbContext.Companies.FirstOrDefault(c => c.Id == updatedCompany.Id);

            if (currentCompany == null)
                return null;

            _dbContext.Entry(currentCompany)
                .CurrentValues
                .SetValues(updatedCompany);
            _dbContext.Companies.Update(currentCompany);

            _dbContext.SaveChanges();

            return currentCompany;
        }

        public void Delete(int id)
        {
            Company delCompany = Get(id);

            if (delCompany == null) return;

            _dbContext.Companies.Remove(delCompany);
            _dbContext.SaveChanges();
        }

    }
}
