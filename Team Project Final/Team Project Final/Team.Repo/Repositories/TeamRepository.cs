using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Repo.Interface;
using Team.Repo.Models;

namespace Team.Repo.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly TeamDBContext _dbContext;
        public TeamRepository(TeamDBContext dbcontext)
        {
           _dbContext = dbcontext;
        }

        public async Task<string> checkCaptaincount()
        {
            var Checkcaptaincount = await _dbContext.Registration
                                       .CountAsync(u => u.FlagRole == 2);
            return Checkcaptaincount.ToString();

        }

        public async Task<string> checkPlayercount()
        {
            var Checkplayerscount = await _dbContext.Registration
                                       .CountAsync(u => u.FlagRole == 1);
            return Checkplayerscount.ToString();
        }
        public async Task<List<UserRegistration>> SavePlayers(string[] playersEmail)
        {
            var users = _dbContext.Registration
                               .Where(u => playersEmail.Contains(u.Email) && u.FlagRole == 0)
                               .ToList();

            foreach (var user in users)
            {
                user.FlagRole = 1;
            }
            _dbContext.SaveChanges();
            foreach (var user in users)
            {
                user.Password = null;
            }
            return users;
        }
        public async Task<UserRegistration?> SaveCaptain(string captainEmail)
        {
            try
            {
                var makeCaptain = _dbContext.Registration
                          .FirstOrDefault(u => u.Email == captainEmail && u.FlagRole == 1);
                if (makeCaptain != null)
                {
                    makeCaptain.FlagRole = 2;
                    _dbContext.SaveChanges();
                    makeCaptain.Password = null;
                }

                return makeCaptain;
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                throw new NotImplementedException(errorMessage);
            }
        }




    }
}
