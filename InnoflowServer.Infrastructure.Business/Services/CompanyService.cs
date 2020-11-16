using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Domain.Core.DTO;
using VideoGameStore.Domain.Core.Entities;
using VideoGameStore.Domain.Interface;
using VideoGameStore.Services.Interfaces;

namespace InnoflowServer.Infrastructure.Business.Services
{
    public class CompanyService : IService<CompanyDTO>
    {
        private IUnitOfWork db { get; set; }
        private IMapper _mapper;

        public CompanyService(IUnitOfWork uow, IMapper mapper)
        {
            _mapper = mapper;
            db = uow;
        }

        public IEnumerable<CompanyDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Company>, List<CompanyDTO>>(db.Companies.GetAll());
        }

        public bool Create(CompanyDTO companyDTO)
        {
            var company = db.Companies.Get(companyDTO.Id);

            if (company != null)
            {
                return false;
            }

            company = new Company
            {
                Name = companyDTO.Name,
                Location = companyDTO.Location
            };

            db.Companies.Create(company);
            db.Save();
            return true;
        }

        public CompanyDTO Get(int id)
        {
            var company = db.Companies.Get(id);

            if (company == null)
            {
                return null;
            }

            return _mapper.Map<Company, CompanyDTO>(db.Companies.Get(id));
        }

        public bool Update(CompanyDTO companyDTO)
        {
            var company = db.Companies.Get(companyDTO.Id);

            if (company == null)
            {
                return false;
            }

            company = new Company
            {
                Name = companyDTO.Name
            };

            db.Companies.Update(company);
            db.Save();
            return true;
        }

        public bool Delete(int id)
        {
            Company company = db.Companies.Get(id);

            if (company == null)
            {
                return false;

            }
            db.Companies.Delete(id);
            db.Save();
            return true;
        }
    }
}
