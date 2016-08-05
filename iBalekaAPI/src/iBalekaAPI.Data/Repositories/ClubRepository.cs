﻿using iBalekaAPI.Data.Infastructure;
using iBalekaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBalekaAPI.Data.Repositories
{
    public interface IClubRepository : IRepository<Club>
    {
        Club GetClubByID(int id);
    }
    public class ClubRepository : RepositoryBase<Club>, IClubRepository
    {
        public ClubRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Club GetClubByID(int id)
        {
            return DbContext.Club.Where(m => m.ClubId == id && m.Deleted == false).FirstOrDefault();
        }
        public override IEnumerable<Club> GetAll()
        {
            return DbContext.Club.Where(a => a.Deleted == false).ToList();
        }
        public override void Delete(Club entity)
        {
            entity.Deleted = true;
            Update(entity);
        }
    }
}
