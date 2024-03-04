using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Service.DTO;

namespace Team.Service.Interface
{
    public interface ITeamService
    {
        Task Savecaptain(CreateTeamDTO teamdto);
        public Task<ResponseDTO> SavePlayers(CreateTeamDTO teamdto);

        public Task<ResponseDTO> SaveCaptain(CreateTeamDTO teamDTO);
    }
}
