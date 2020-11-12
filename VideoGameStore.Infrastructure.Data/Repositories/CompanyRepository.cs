using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Core.Models;
using VideoGameStore.Domain.Interface;

namespace VideoGameStore.Infrastructure.Data.Repositories
{
    public class CompanyRepository : IRepository<Company>
    {
        private readonly ApplicationDbContext db;
        public CompanyRepository(ApplicationDbContext context)
        {
            db = context;
        }
        public IEnumerable<Company> GetAll()
        {
            return db.Companies;
        }
        public Company Get(int id)
        {
            return db.Companies.Find(id);
        }
        public void Create(Company company)
        {
            db.Companies.Add(company);
        }
        public void Update(Company company)
        {
            db.Companies.Update(company);
        }
        public void Delete(int id)
        {
            Company company = db.Companies.Find(id);
            if (company != null)
                db.Companies.Remove(company);
        }
    }
}
