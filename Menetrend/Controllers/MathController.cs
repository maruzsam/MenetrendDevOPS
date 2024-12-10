using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MathController : ControllerBase
{
	// Endpoint az Euler-sz�m ki�r�s�ra
	[HttpGet("euler")]
	public IActionResult GetEuler()
	{
		double euler = Math.E;
		return Ok(new { value = euler, description = "Euler-sz�m (e)" });
	}

	// Endpoint egy Fibonacci-sorozat gener�l�s�ra
	[HttpGet("fibonacci/{count}")]
	public IActionResult GetFibonacci(int count)
	{
		if (count <= 0)
		{
			return BadRequest("A sz�mnak nagyobbnak kell lennie 0-n�l.");
		}

		var sequence = GenerateFibonacci(count);
		return Ok(sequence);
	}

	// Endpoint egy v�letlenszer� sz�m gener�l�s�ra
	[HttpGet("random")]
	public IActionResult GetRandomNumber()
	{
		var random = new Random();
		int number = random.Next(1, 100);
		return Ok(new { value = number, description = "V�letlenszer� sz�m (1-100 k�z�tt)" });
	}

	// Fibonacci gener�l�s seg�t� met�dus
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
