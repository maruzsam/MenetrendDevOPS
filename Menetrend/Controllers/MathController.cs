using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MathController : ControllerBase
{
	// Endpoint az Euler-szám kiírására
	[HttpGet("euler")]
	public IActionResult GetEuler()
	{
		double euler = Math.E;
		return Ok(new { value = euler, description = "Euler-szám (e)" });
	}

	// Endpoint egy Fibonacci-sorozat generálására
	[HttpGet("fibonacci/{count}")]
	public IActionResult GetFibonacci(int count)
	{
		if (count <= 0)
		{
			return BadRequest("A számnak nagyobbnak kell lennie 0-nál.");
		}

		var sequence = GenerateFibonacci(count);
		return Ok(sequence);
	}

	// Endpoint egy véletlenszerû szám generálására
	[HttpGet("random")]
	public IActionResult GetRandomNumber()
	{
		var random = new Random();
		int number = random.Next(1, 100);
		return Ok(new { value = number, description = "Véletlenszerû szám (1-100 között)" });
	}

	// Fibonacci generálás segítõ metódus
	private List<int> GenerateFibonacci(int count)
	{
		var sequence = new List<int> { 0, 1 };
		while (sequence.Count < count)
		{
			sequence.Add(sequence[^1] + sequence[^2]);
		}
		return sequence.Take(count).ToList();
	}
}
