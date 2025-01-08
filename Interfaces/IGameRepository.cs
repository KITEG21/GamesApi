using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gamesApi.Dtos;
using gamesApi.Helpers;
using gamesApi.Models;

namespace gamesApi.Interfaces
{
    public interface IGameRepository
    {   
        // Interface for GameRepository(CRUD methods)
        public Task<List<Game>> GetAllAsync(QueryObject query);
        public Task<Game?> GetByIdAsync(int id);
        public Task<Game> InsertGameAsync(GameDto gameInsert);
        public Task<Game?> UpdateGameAsync(int id, GameDto gameUpdate);
        public Task<Game?> DeleteGameAsync(int id);

    }
}