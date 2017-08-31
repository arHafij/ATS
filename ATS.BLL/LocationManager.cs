using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.BLL.Contracts;
using ATS.DAL;
using ATS.Models;

namespace ATS.BLL
{
    public class LocationManager : ILocationManager
    {
        private LocationRepository _locationRepository = new LocationRepository();
        public bool Add(Location entity)
        {
            return _locationRepository.Add(entity);
        }

        public bool Add(ICollection<Location> entities)
        {
            throw new NotImplementedException();
        }

        public ICollection<Location> GetAll()
        {
            return _locationRepository.GetAll();
        }

        public Location GetById(long? id)
        {
            return _locationRepository.GetById(id);
        }

        public bool Remove(Location entity)
        {
            return _locationRepository.Remove(entity);
        }

        public bool Update(ICollection<Location> entities)
        {
            throw new NotImplementedException();
        }

        public bool Update(Location entity)
        {
            return _locationRepository.Update(entity);
        }
    }
}
