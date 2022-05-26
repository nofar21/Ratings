using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Toki.Models;

namespace Toki.Services
{
    public class RatingService : IRatingService
    {
        private static List<Rating> rateList = new List<Rating>();
        public List<Rating> GetAllRatings()
        {
            return rateList;
        }
        public Rating GetRating(int id)
        {
            return rateList.Find(x => x.Id == id);
        }
        public void EditRating(int id, string name, int rating, string feedback)
        {
            Rating rate = GetRating(id);
            rate.NameOfRater = name;
            rate.RateNumber = rating;
            rate.Feedback = feedback;
        }
        public void CreateRating(string name, int rating, string feedback)
        {
            int getNextId;
            if (rateList.Count == 0)
            {
                getNextId = 1;
            }
            else
            {
                getNextId = rateList.Max(x => x.Id) + 1;
            }
            rateList.Add(new Rating() { Id = getNextId, NameOfRater = name,
                RateNumber = rating, Feedback = feedback, Time = DateTime.Now });
        }
        public void DeleteRanking(int id)
        {
            rateList.Remove(GetRating(id));
        }
    }
}
