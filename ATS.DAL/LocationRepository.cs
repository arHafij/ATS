using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.DAL.Contracts;
using ATS.DAL.Database;
using ATS.Models;

namespace ATS.DAL
{
    public class LocationRepository:BaseRepository<Location>,ILocationRepository
    {
        public LocationRepository() : base(new AssetTrackingSystemContext())
        {

        }
    }
}
