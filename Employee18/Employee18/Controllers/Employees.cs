using Employee18.Data;
using Employee18.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee18.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Employees : Controller
    {
        private readonly EmployeeDB dbContext;
       

        public Employees(EmployeeDB dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetdetailsAsync()
        {
            return Ok(await dbContext.employees.ToListAsync());

        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult>Getdeatail([FromRoute] Guid id)
        {
            var employee = await dbContext.employees.FindAsync(id);

            if(employee == null)
            {
                return NotFound("id invalid");
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Adddetails(Addemployees addemplydata)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addemplydata.Name,
                Age = addemplydata.Age,
                Email_id = addemplydata.Email_id,
                address = addemplydata.address,
                phone = addemplydata.phone,

            };

            await dbContext.employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateDetails([FromRoute] Guid id, UpdateEmployee updateEmployee)
        {
            var employee= await dbContext.employees.FindAsync(id);

            if(employee != null)
            {
                employee.Name= updateEmployee.Name;
                employee.Age= updateEmployee.Age;
                employee.Email_id= updateEmployee.Email_id;
                employee.address= updateEmployee.address;
                employee.phone= updateEmployee.phone;

                await dbContext.SaveChangesAsync();

                return Ok(employee);
            }
            return NotFound();
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteDetail([FromRoute] Guid id)
        {
           var employee = await dbContext.employees.FindAsync(id);

            if(employee !=null)
            {
                dbContext.Remove(employee);
                await dbContext.SaveChangesAsync();
                return Ok(employee);
            }
            return NotFound();
        }
    }


}

