using System.Collections.Generic;
using System.Linq;
using RestResponse;
namespace _01.Service
{
    public class Fruit
    {
        public string name {get; set;}
        public int id {get; set;}
    }

    public class FruitsService
    {
        RestDataResponse restDataResponse = new RestDataResponse();
        private List<Fruit> fruitsList { get; set; } = new List<Fruit>();
        public FruitsService()
        {
            fruitsList.Add(new Fruit{ name = "Apple", id = 1});
            fruitsList.Add(new Fruit{ name = "Orange", id = 2});
            fruitsList.Add(new Fruit{ name = "Pineapple", id = 3});
            fruitsList.Add(new Fruit{ name = "Lemon", id = 4});
        }

        public List<Fruit> Filter(string fruitName)
        {
            return fruitsList.Where(p => p.name.Contains(fruitName)).ToList();
        }

        public RestStatusResponse<List<Fruit>> FilterWithResponse(string fruitName)
        {
            List<Fruit> fruitList = new List<Fruit>();
            fruitList = this.fruitsList.Where(p => p.name.Contains(fruitName)).ToList();
            if(fruitList.Count > 0)
                return restDataResponse.Ok200<List<Fruit>>(fruitList);
            else if(fruitList.Count == 0)
                return restDataResponse.NotFound404<List<Fruit>>(null);
            return null;
        }

        public RestStatusResponse<List<Fruit>> FilterWithResponseList(string fruitName)
        {
            return restDataResponse.RestStatusWithList<Fruit>(this.fruitsList.Where(p => p.name.Contains(fruitName)).ToList());
        }

        public RestStatusResponse<Fruit> FilterWithResponseObject(int id)
        {
            return restDataResponse.RestStatusWithObject<Fruit>(this.fruitsList.Where(p => p.id == id).FirstOrDefault<Fruit>());
        }
        
    }
}