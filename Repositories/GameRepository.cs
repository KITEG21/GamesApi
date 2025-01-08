using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gamesApi.Data;
using gamesApi.Dtos;
using gamesApi.Helpers;
using gamesApi.Interfaces;
using gamesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace gamesApi.Repositories
{
    //Repository for Game model's CRUD methods
    public class GameRepository : IGameRepository
    {
        private readonly AppDBContext _context;
        public GameRepository(AppDBContext context)
        {
            _context = context;
        }
        
        public async Task<List<Game>> GetAllAsync(QueryObject query)
        {
           var games = _context.Games.AsQueryable();

           if(!string.IsNullOrWhiteSpace(query.Developers))
           {
               games = _context.Games.Where(g => g.Developers.Contains(query.Developers));
           } 

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await games.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public Task<Game?> GetByIdAsync(int id)
        {
            return _context.Games.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Game> InsertGameAsync(GameDto gameInsert)
        {
            var newGame = new Game{
                Copies = gameInsert.Copies,
                Name = gameInsert.Name,
                Developers = gameInsert.Developers,
                Date = gameInsert.Date
            };
            
            _context.Games.Add(newGame);
            await _context.SaveChangesAsync();
            return newGame;
        }

        public async Task<Game?> UpdateGameAsync(int id, GameDto gameUpdate)
        {
            var game = await _context.Games.FirstOrDefaultAsync(x => x.Id == id);

            if(game == null)
            {
                return null;
            }

            game.Copies = gameUpdate.Copies;
            game.Name = gameUpdate.Name;
            game.Developers = gameUpdate.Developers;
            game.Date = gameUpdate.Date;

            await _context.SaveChangesAsync();
            return game;
        }
        public async Task<Game?> DeleteGameAsync(int id)
        {
            var game = await _context.Games.FirstOrDefaultAsync(x => x.Id == id);

            if(game == null)
            {
                return null;
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync(); 
            return game;

        }
    }
}