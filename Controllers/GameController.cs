using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using gamesApi.Data;
using gamesApi.Dtos;
using gamesApi.Helpers;
using gamesApi.Interfaces;
using gamesApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace gamesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepo;

        public GameController(AppDBContext context, IGameRepository gameRepo)
        {
            _gameRepo = gameRepo;
        }

        [HttpGet("GetGames")]
        [Authorize]
        public async Task<IActionResult> GetAllGames([FromQuery]QueryObject query)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
        
            var games = await _gameRepo.GetAllAsync(query);
            return Ok(games);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame(int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var game = await _gameRepo.GetByIdAsync(id);
            if(game == null)
            {
                return NotFound("The game required doesn't exist");
            }
            return Ok(game);
        }

        [HttpPost("InsertGame")]
        public async Task<IActionResult> PostGame(GameDto gameInsert)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var newGame = await _gameRepo.InsertGameAsync(gameInsert);
            return Ok(newGame);
        }

        [HttpPut("UpdateGame{id}")]
        public async Task<IActionResult> PutGames(int id, GameDto gameUpdate)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var game = await _gameRepo.UpdateGameAsync(id, gameUpdate);
            return Ok(game);
        }
 
        [HttpDelete("DeleteGame{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {   
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var game = await _gameRepo.DeleteGameAsync(id);
            return Ok("The game has been deleted");
        }
        
    }    
}