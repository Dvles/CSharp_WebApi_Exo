using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;

namespace webapi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private static List<Student> _list = new List<Student>
		{
			new Student(){
				Student_Id = 1, First_Name = "Charifa", Last_Name  = "Zhinef" },
			new Student(){ 
				Student_Id = 2, First_Name = "Khaoula", Last_Name  = "Ayra" },
			new Student(){
				Student_Id = 3, First_Name = "Mélusine", Last_Name  = "Khaoula" },
			new Student(){
				Student_Id = 4, First_Name = "Dorothée", Last_Name  = "Valentyn" },
			new Student(){
				Student_Id = 5, First_Name = "Jenny", Last_Name  = "Fernandez Garcia" },
			new Student(){
				Student_Id = 6, First_Name = "Marwa", Last_Name  = "Khaoula" },
			new Student(){
				Student_Id = 7, First_Name = "Anaïs", Last_Name  = "Aerts" },
			new Student(){
				Student_Id = 8, First_Name = "Emilie", Last_Name  = "Blanckaerts" },
			new Student(){
				Student_Id = 9, First_Name = "Amalia", Last_Name  = "Langlet Tessaro" },
			new Student(){
				Student_Id = 10, First_Name = "Leslie", Last_Name  = "Habimana" },
			new Student(){
				Student_Id = 11, First_Name = "Jessica", Last_Name  = "Conrad" },
			new Student(){
				Student_Id = 12, First_Name = "Debby", Last_Name  = "Clerckx" },

		};
		
		[HttpGet("")]
		public ActionResult<List<Student>> Get()
		{
			List<Student> model = _list;
			return Ok(model);
		}

		[HttpGet("{id}")]
		[ProducesResponseType<Student>(200)]
		[ProducesResponseType<Student>(404)]
		public ActionResult<List<Student>> Get(int id)
		{
			Student model = _list.Where (st => st.Student_Id == id).SingleOrDefault();
			if (model is not null)
			{
				return Ok(model);

			}
			// return NotFound();
			return StatusCode(404);
		}

		[HttpPost]
		[ProducesResponseType<Student>(201)]
		public IActionResult Post(Student student)
		{
			try 
			{
				int id = _list.Max(st => st.Student_Id) + 1;
				student.Student_Id = id;
				_list.Add(student);
				return CreatedAtAction(nameof(Get), new { id }, student);

			} 
			catch(Exception)
			{
				return StatusCode(415);
			}
		}

		[HttpPut("{id}")]
		[ProducesResponseType<Student>(201)]
		[ProducesResponseType(415)]
		public IActionResult Put(int id, Student student)
		{
			try{

				Student model = _list.Where(st => st.Student_Id == id).SingleOrDefault();
				if (model is null) throw new ArgumentOutOfRangeException(nameof(id));
				model.First_Name = student.First_Name;
				model.Last_Name = student.Last_Name;
				return CreatedAtAction(nameof(Get), new { id }, model);

			} catch (ArgumentOutOfRangeException)
			{
				return NotFound();
			}
			catch (ArgumentException)
			{
				return StatusCode(415); // incorrect mediatype return
			}

		}

		[HttpDelete("{id}")]
		[ProducesResponseType(204)]
		public IActionResult Delete(int id)
		{
			try
			{
				Student model = _list.Where(st => st.Student_Id == id).SingleOrDefault();
				if (model is null) throw new ArgumentOutOfRangeException(nameof(id));
				_list.Remove(model);
				return NoContent();
			}
			catch (ArgumentOutOfRangeException)
			{
				return NotFound();
			}
		}
	}
}
