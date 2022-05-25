using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toki.Models;

namespace Toki.Services
{
    public interface IRatingService
    {
        public List<Rating> GetAllRatings();
        public Rating GetRating(int id);
        public void CreateRating(string name, int rating, string feedback);
        public void EditRating(int id, string name, int rating, string feedback);
        public void DeleteRanking(int id);
        //public IEnumerable<Rating> SearchInRankings(string query);
    }
}
