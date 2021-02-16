using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using gregslist.db;
using gregslist.Models;

namespace gregslist.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]

    public class CarsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            try
            {
                return Ok(FAKEDB.Cars);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Car> GetCarById(string id)
        {
           try
            {
                Car carToReturn = FAKEDB.Cars.Find(c => c.Id == id);
                return Ok(FAKEDB.Cars);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            } 
        }

        [HttpPost]

        public ActionResult<Car> Create([FromBody] Car newCar)
        {
            try
            {
               FAKEDB.Cars.Add(newCar);
               return Ok(newCar);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]

        public ActionResult<string> BuyCar(string id)
        {
            try
            {
                Car carToRemove = FAKEDB.Cars.Find(c => c.Id == id);
                if (FAKEDB.Cars.Remove(carToRemove))
                {
                    return Ok("You really just bought that?");
                };
                throw new System.Exception("Car does not exist");
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // [HttpPut("cars/{id}")]
        // public ActionResult<Car> Edit([FromBody] Car editCar)
        // {
        //     try
        //     {
        //        Car foundIt = FAKEDB.Cars.Find(c => c.Id == id);
        //        editCar.Make = editCar.Make != null ? editCar.Make : foundIt.Make;

        //        return Ok(newCar);
        //     }
        //     catch (System.Exception err)
        //     {
        //         return BadRequest(err.Message);
        //     }
        // }
    }
    
}