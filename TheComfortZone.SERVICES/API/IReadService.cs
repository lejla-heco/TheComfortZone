﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheComfortZone.SERVICES.API
{
    public interface IReadService<T, TSearch> where T : class where TSearch : class
    {
        public IEnumerable<T> Get(TSearch search = null);
        public T GetById(int id);
    }
}