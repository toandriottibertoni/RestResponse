using System.Collections.Generic;
using System.Linq;
using RestResponse;
namespace _01.Service
{
    public class Fruit
    {
        public string name {get; set;}
    }

    public class FruitsService
    {
        RestDataResponse restDataResponse = new RestDataResponse();
        private List<Fruit> fruitsList { get; set; } = new List<Fruit>();
        public FruitsService()
        {
            fruitsList.Add(new Fruit{ name = "Apple"});
            fruitsList.Add(new Fruit{ name = "Orange"});
            fruitsList.Add(new Fruit{ name = "Pineapple"});
            fruitsList.Add(new Fruit{ name = "Lemon"});
        }

        public List<Fruit> Filter(string fruitName)
        {
            return fruitsList.Where(p => p.name.Contains(fruitName)).ToList();
        }

        public RestStatusResponse FilterWithResponse(string fruitName)
        {
            List<Fruit> fruitList = new List<Fruit>();
            fruitList = this.fruitsList.Where(p => p.name.Contains(fruitName)).ToList();
            if(fruitList.Count > 0)
                return restDataResponse.OK_200(fruitList);
            else if(fruitList.Count == 0)
                return restDataResponse.NotFound_404();
            return null;
        }

        
    }
}