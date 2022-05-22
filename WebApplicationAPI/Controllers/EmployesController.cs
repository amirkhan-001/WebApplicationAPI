using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployesController : ControllerBase
    {
        //private static List<EmployesDetail> empList = new List<EmployesDetail>
        //{
        //    new EmployesDetail{
        //        Id = 1,
        //        Name = "Amir",
        //        Department = "Angular",
        //        salary = 6000
        //    },
        //    new EmployesDetail{
        //        Id = 2,
        //        Name = "Sufiyan",
        //        Department = "Power BI",
        //        salary = 6000
        //    }
        //};
        private readonly DataContext dataContext;

        public EmployesController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<EmployesDetail>>> GET()
        {
            return Ok(await this.dataContext.Employes.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<EmployesDetail>>> GET(int id)
        {
            //var emp = empList.Find(x => x.Id == id);
            var emp = await this.dataContext.Employes.FindAsync(id);
            if (emp == null)
                return BadRequest("Employe Not Found");
            return Ok(emp);
        }
        [HttpPost]
        public async Task<ActionResult<List<EmployesDetail>>> addEmploye (EmployesDetail employe)
        {
            //empList.Add(employe);
            //return Ok(empList);
            this.dataContext.Employes.Add(employe);
            await this.dataContext.SaveChangesAsync();
            return Ok(await this.dataContext.Employes.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<EmployesDetail>>> updateEmploye(EmployesDetail request)
        {
            //var emp = empList.Find(x => x.Id == request.Id);
            //if (emp == null)
            //    return BadRequest("Employe Not Found");
            //emp.Name = request.Name;
            //emp.Department = request.Department;
            //emp.salary = request.salary;
            //return Ok(empList);
            var dbEmp = await this.dataContext.Employes.FindAsync(request.Id);
            if (dbEmp == null)
                return BadRequest("Employe Not Found");
            dbEmp.Name = request.Name;
            dbEmp.Department = request.Department;
            dbEmp.salary = request.salary;
            await this.dataContext.SaveChangesAsync();
            return Ok(await this.dataContext.Employes.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<EmployesDetail>>> Delete(int id)
        {
            //var emp = empList.Find(x => x.Id == id);
            //if (emp == null)
            //    return BadRequest("Employe Not Found");
            //empList.Remove(emp);
            //return Ok(empList);
            var dbEmp = await this.dataContext.Employes.FindAsync(id);
            if (dbEmp == null)
                return BadRequest("Employe Not Found");
            this.dataContext.Employes.Remove(dbEmp);
            await this.dataContext.SaveChangesAsync();
            return Ok(await this.dataContext.Employes.ToListAsync());
        }
    }
}
