using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RoverService.Data.Dto;
using System.Web;
using System.Web.Caching;
using CacheItemPriority = System.Web.Caching.CacheItemPriority;

namespace RoverService.Data.Repository
{
    public class Repository : IRepository<RoverDto>
    {
        #region constructors
        public Repository(){}
        #endregion

        #region methods
        public RoverDto GetById(object id)
        {
            if (id == null)
                return null;
            
            var roverId = (string) id;
            var roverData = HttpRuntime.Cache[roverId]?.ToString();

            try
            {
                return JsonConvert.DeserializeObject<RoverDto>(roverData);
            }
            catch (Exception e)
            {
                return null;
            }

            throw new NotImplementedException();
        }
        public void Set(RoverDto updatedDto)
        {
            if (HttpRuntime.Cache[updatedDto.RoverId] == null)
                HttpRuntime.Cache.Add(updatedDto.RoverId, updatedDto.ToString(), null, DateTime.MaxValue,
                    Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
            else HttpRuntime.Cache[updatedDto.RoverId] = updatedDto.ToString();
        }
    }
    #endregion
}
