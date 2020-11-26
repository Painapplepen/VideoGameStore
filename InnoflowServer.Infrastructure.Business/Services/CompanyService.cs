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

        public async Task<IEnumerable<CompanyDTO>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<Company>, List<CompanyDTO>>(await db.Companies.GetAllAsync());
        }

        public async Task<bool> CreateAsync(CompanyDTO companyDTO)
        {
            var company = await db.Companies.GetAsync(companyDTO.Id);

            if (company != null)
            {
                return false;
            }

            company = new Company
            {
                Name = companyDTO.Name,
                Location = companyDTO.Location
            };

            await db.Companies.CreateAsync(company);

            return true;
        }

        public async Task<CompanyDTO> GetAsync(int id)
        {
            var company = await db.Companies.GetAsync(id);

            if (company == null)
            {
                return null;
            }

            return _mapper.Map<Company, CompanyDTO>(await db.Companies.GetAsync(id));
        }

        public async Task<bool> UpdateAsync(CompanyDTO companyDTO)
        {
            var company = await db.Companies.GetAsync(companyDTO.Id);

            if (company == null)
            {
                return false;
            }

            company = new Company
            {
                Name = companyDTO.Name,
                Location = companyDTO.Location
            };

            await db.Companies.UpdateAsync(company);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var company = await db.Companies.GetAsync(id);

            if (company == null)
            {
                return false;
            }

            return await db.Companies.DeleteAsync(id);
        }
    }
}
