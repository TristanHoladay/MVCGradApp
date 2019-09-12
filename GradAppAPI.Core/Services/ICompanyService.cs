using GradAppAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradAppAPI.Core.Services
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetAll();

        Company Get(int id);

        Company Add(Company newCompany);

        Company Update(Company updatedCompany);

        void Delete(int id);
    }
}
