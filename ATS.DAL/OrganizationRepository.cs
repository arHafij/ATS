using ATS.DAL.Contracts;
using ATS.DAL.Database;
using ATS.Models;

namespace ATS.DAL
{
    public class OrganizationRepository:BaseRepository<Organization>,IOrganizationRepository
    {
        public OrganizationRepository() : base(new AssetTrackingSystemContext())
        {

        }

    }
}