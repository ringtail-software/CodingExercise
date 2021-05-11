using Microsoft.AspNetCore.Mvc;
using CodingExercise.Data;

namespace CodingExercise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserInvestmentController : ControllerBase
    {
        //The default get returns the list of investments for a user.  I think this is appropriate, since the controller is just for user investments.  There is only one user in this
        //exercise, but there should also be an identifier for the user as an argument to the get method.
        [HttpGet]
        public IActionResult Get()
        {
            //This is where we could also add any verification necessary.  E.g. API key, user permissions, etc.
            return Ok(CodingExerciseDataAccess.GetUserInvestments());
        }


        [HttpGet("[action]/{id}")]
        public ActionResult Detail(int id)
        {
            var detail = CodingExerciseDataAccess.GetInvestmentDetail(id);

            //Returning 404 if not found, but a different response could be sent if it's more appropriate
            if (detail == null)
            {
                return NotFound();
            }
            return Ok(detail);
        }
    }
}
