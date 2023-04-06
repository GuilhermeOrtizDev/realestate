﻿using DevIO.Business.DTOs;
using DevIO.Business.Repositorys;
using DevIO.Data.Context;
using DevIO.Data.Repository;

namespace DevIO.Data.Repositorys
{
    public class CityRepository : Repository<CityDTO>, ICityRepository
    {
        public CityRepository(RealEstateDbContext context) : base(context)
        {

        }
    }
}
