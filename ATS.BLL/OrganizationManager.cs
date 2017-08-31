using System;
using System.Collections.Generic;
using ATS.DAL;
using ATS.BLL.Contracts;
using ATS.Models;

namespace ATS.BLL
{
    public class OrganizationManager:IOrganizationManager
    {
        private OrganizationRepository _organizationRepository = new OrganizationRepository();

        public bool Add(Organization organization)
        {
            return _organizationRepository.Add(organization);
        }

        public bool Add(ICollection<Organization> entities)
        {
            throw new NotImplementedException();
        }

        public ICollection<Organization> GetAll()
        {
            return _organizationRepository.GetAll();
        }

        public Organization GetById(long? id)
        {
            return _organizationRepository.GetById(id);
        }

        public bool Remove(Organization entity)
        {
            return _organizationRepository.Remove(entity);
        }

        public bool Update(Organization organization)
        {
            return _organizationRepository.Update(organization);
        }

        public bool Update(ICollection<Organization> entities)
        {
            throw new NotImplementedException();
        }
    }
}