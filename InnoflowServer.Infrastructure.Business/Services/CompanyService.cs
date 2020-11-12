using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Core.Models;
using VideoGameStore.Domain.Interface;
using VideoGameStore.Services.Interfaces;

namespace InnoflowServer.Infrastructure.Business.Services
{
    public class CompanyService : IService<Company>
    {
        private readonly IRepository<Company> companies;
        public CompanyService(IRepository<Company> companyRepository)
        {
            companies = companyRepository;
        }
        public IEnumerable<Company> GetAll()
        {
            return companies.GetAll();
        }
        public bool Create(Company company)
        {
            companies.Create(company);
            return true;
        }
        public Company Get(int id)
        {
            return companies.Get(id);
        }
        public bool Update(Company company)
        {
            companies.Update(company);
            return true;
        }
        public bool Delete(int id)
        {
            companies.Delete(id);
            return true;
        }
    }
}
