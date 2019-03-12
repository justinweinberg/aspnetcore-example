using Bogus;
using demo.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Services.Fakes
{
    public class FakeKartService : IKartService
    {
        private static List<KartItem> _fakeKarts;

        static FakeKartService()
        {
            _fakeKarts = FakeCartGenerator.Generate(500);
        }

        public void Add(KartItem kart)
        {
            _fakeKarts.Add(kart);
        }

        public KartItem Get(string vin)
        {
            return (from kart in _fakeKarts
                    where kart.VIN == vin
                    select kart).FirstOrDefault();

        }

        public KartResponse Get(KartResourceParameters kartSpecification)
        {
          
            var matchingKarts = from k in _fakeKarts
                                where k.Equals(kartSpecification)
                                select k;

            int results = Math.Min(matchingKarts.Count(), kartSpecification.Size);

            return new KartResponse
            {
                Size = results,
                Start = kartSpecification.Start,
                TotalHits = matchingKarts.Count(),
                Hits = matchingKarts.Skip(kartSpecification.Start).Take(results).ToList()
            };

        }

        public void Delete(string vin)
        {
            throw new NotImplementedException("Not implemented");
        }

        public void Update(KartItem kart)
        {
            throw new NotImplementedException("Not implemented");
        }
    }
}
