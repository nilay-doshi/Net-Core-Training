using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Repo.Models;

namespace Team.Repo.Interface
{
    public interface ITeamRepository
    {
        Task<string> checkCaptaincount();
        Task<string> checkPlayercount();
        Task<List<UserRegistration>> SavePlayers(string[] playersEmail);
        Task<UserRegistration?> SaveCaptain(string captainEmail);



    }
}
