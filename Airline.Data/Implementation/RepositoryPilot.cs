using Airline.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Airline.Data.Implementation
{
    public class RepositoryPilot : IRepositoryPilot
    {
        private AirlineContext context;
        public RepositoryPilot(AirlineContext context)
        {
            this.context = context;
        }
        public void Add(Pilot p)
        {
            context.Add(p);
        }

        public void Change(Pilot pilotNew)
        {
            context.Entry(pilotNew).State = EntityState.Modified;
        }

        public void Delete(int pilot_id)
        {
            Pilot p = context.Pilots.Find(pilot_id);
            context.Remove(p);
        }

        public Pilot FindById(int id)
        {
            Pilot p = context.Pilots.Find(id);
            return p;
        }

        public List<Pilot> GetAll()
        {
            List<Pilot> pList = context.Pilots.ToList();
            return pList;

        }
    }
}
