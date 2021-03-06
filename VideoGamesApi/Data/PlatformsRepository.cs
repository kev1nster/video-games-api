﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGamesApi.Models;

namespace VideoGamesApi.Data
{
    public class PlatformsRepository : IBaseRepository<Platform>
    {
        private readonly VideoGamesContext _videoGamesContext;

        public PlatformsRepository(VideoGamesContext videoGamesContext)
        {
            _videoGamesContext = videoGamesContext;
        }
        
        public void Add(Platform item)
        {
            _videoGamesContext.Add(item);
            _videoGamesContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var platform = Get(id);

            if (platform == null)
                throw new Exception();

            _videoGamesContext.Remove(platform);
            _videoGamesContext.SaveChanges();
        }
        
        public IEnumerable<Platform> Get()
        {
            return _videoGamesContext.Platforms.ToList();
        }

        public Platform Get(int id)
        {
            return _videoGamesContext.Platforms.Where(p => p.Id == id).SingleOrDefault();
        }
        
        public void Update(Platform item)
        {
            _videoGamesContext.Update(item);
            _videoGamesContext.SaveChanges();
        }
    }
}
