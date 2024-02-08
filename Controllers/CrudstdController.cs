using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stdapi.Models;

namespace stdapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudstdController : ControllerBase
    {
        public readonly DatabaseContext _context;

        public CrudstdController(DatabaseContext context)
        {
            _context = context;
        }

        [Route("GetAllData")]
        [HttpGet]
        public ActionResult<IEnumerable<Studentsdata>> GetAllData()
        {
            var res = (from s in _context.Studentsdata select s).ToList();
            return res;
        }

        [Route("GetDataByName")]
        [HttpGet]
        public IEnumerable<Studentsdata> GetDataByName(string Name)
        {
            
            var result = from s in _context.Studentsdata where s.Name == Name select s;
            return result;
        }

        [Route("GetDataById")]
        [HttpGet]
        public IEnumerable<Studentsdata> GetDataById(int Id)
        {

            var result = from s in _context.Studentsdata where s.Id == Id select s;
            return result;
        }

        [Route("LoginData")]
        [HttpGet]
        public IEnumerable<Studentsdata> LoginData(string EmaiId, string password)
        {
            var res1 = from s in _context.Studentsdata where s.EmailID == EmaiId && s.Password == password select s;
            return res1;
        }

        [Route("InsetStd")]
        [HttpPost]
        public ActionResult<Studentsdata> InsetStd(Studentsdata obj)
        {
            if(obj == null)
            {
                return BadRequest();
            }
            else
            {
                _context.Add(obj);
                _context.SaveChanges();
                return CreatedAtAction("GetAllData", new { Id = obj.Id, obj });
            }
        }

        [HttpPut]
        [Route("Update")]
        public bool Update(Studentsdata obj)
        {

            if(obj.Id == null)
            {
                return false;
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _context.Entry(obj).State = EntityState.Modified;
                    _context.SaveChanges();
                    return true;
                }
            }
            return true;
        }

        [HttpDelete]
        [Route("Delete")]
        public int Delete(int Id)
        {
            if(Id  == 0)
            {
                return 0;
            }
            else
            {
                var res = _context.Studentsdata.Find(Id);
                _context.Remove(res);
                _context.SaveChanges();
                return 1;
            }
        }

    }
}
