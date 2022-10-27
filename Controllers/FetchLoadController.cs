using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using recruiting_takehome.Models;

namespace recruiting_takehome.Controllers
{

    [ApiController]
    [Route("api/robots/closest")]
    public class FetchLoadController : ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();
        private static string source = "";
        private static string robo_main = "https://60c8ed887dafc90017ffbd56.mockapi.io/robots";
        private static string robo_mirr =  "https://svtrobotics.free.beeceptor.com/robots";
        private readonly ILogger<FetchLoadController> _logger;

        public FetchLoadController(ILogger<FetchLoadController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<Robot>> Get()
        {
            var robots = await GetRobotsAsync();
            return robots;
        }

        [HttpPost]
        public async Task<Result> GetRobot(Load load)
        {            
            var result = new List<Result>();
            var robots = await GetRobotsAsync();
            if (robots == null) {
                result.Add(new Result(null, null, null, "Both endpoints unavailable."));
                return result[0];
            }
            Console.Write("robots source: ");
            Console.WriteLine(source);
            foreach (var robot in robots)
            {
                var dist = Math.Sqrt(
                    Math.Pow((load.X - robot.X), 2) + Math.Pow((load.Y - robot.Y), 2));
                result.Add(new Result(robot.RobotId, robot.BatteryLevel, dist, null));
            }
            var res = FilterRobots(result);
            return res[0];
        }

        private List<Result> FilterRobots(List<Result> results) {
            Result result;
            List<Result> res = new List<Result>();
            results = results.OrderBy(r=>r.DistanceToGoal).ToList();
            Boolean underTen = false;
            foreach (var r in results) {
                if (r.DistanceToGoal <= 10.0 && r.BatteryLevel > 0) {
                    res.Add(r);
                    underTen = true;
                } else if(!underTen && r.DistanceToGoal > 10.0 && res.Count == 0 && r.BatteryLevel > 0) {
                    r.DistanceToGoal = (double)Math.Round((decimal)r.DistanceToGoal, 2);
                    res.Add(r);
                    return res;
                } 
            }
            if (res.Count > 0) {
                var max = res.MaxBy(r => r.BatteryLevel);
                max.DistanceToGoal = (double)Math.Round((decimal)max.DistanceToGoal, 2);
                res.Clear();
                res.Add(max);
                return res;
            }
            res.Add(new Result(null, null, null, "All robots are out of battery"));
            return res;
        }
        private static async Task<List<Robot>> GetRobotsAsync()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            try {
                source = robo_main;
                var streamTask = client.GetStreamAsync(source);
                return await JsonSerializer.DeserializeAsync<List<Robot>>(await streamTask);
            } catch {
                try {
                    source =  robo_mirr;
                    var streamTask = client.GetStreamAsync(source);
                    return await JsonSerializer.DeserializeAsync<List<Robot>>(await streamTask);
                } catch {
                    source = "both endpoints failed";
                    return null;
                }
            }
        }
    }
}