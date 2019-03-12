using Bogus;
using demo.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Services
{
    public interface IKartService
    {

        KartItem Get(string vin);
        void Update(KartItem kart);
        void Add(KartItem kart);
        void Delete(string vin);
        KartResponse Get(KartResourceParameters kartSpecification);
    }

   
}
