using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Demo.Models;

namespace Demo.Controller;

[Microsoft.AspNetCore.Components.Route("api/[controller]")]
[ApiController]
public class FibonacciController : ControllerBase {
    public FibonacciController() {}

    [HttpPost("{n}")]
    public ActionResult<long> GetNthFibonacci(int n) {
        if (n < 0) {
            return BadRequest("Input 'n' must be greater than or equal to 0");
        }
        if (n == 0) {
            return 0;
        }
        if (n == 1) {
            return 1;
        }

        long a = 0;
        long b = 1;
        long result = 0;

        for (int i = 2; i <= n; i++) {
            result = a + b;
            a = b;
            b = result;
        }

        var response = new FibonacciResult() {
            NumericalOrder = n,
            Value = result
        };

        return Ok(response);
    }
}