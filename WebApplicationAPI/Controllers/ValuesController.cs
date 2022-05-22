using Microsoft.AspNetCore.Mvc;


namespace WebApplicationAPI.Controllers
{
    public class ValuesController : ControllerBase
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        static List<string> strings = new List<string>()
        {
            "value0", "value1","value2","value3"
        };
        public IEnumerable<string> GET()
        {
            return strings;
        }
        public string GET(int id)
        {
            return strings[id];
        }
        public void POST([FromBody] string values)
        {
            strings.Add(values);
        }
        public void PUT(int id, [FromBody] string values)
        {
            strings[id] = values;
        }
        public void DELETE(int id)
        {
            strings.RemoveAt(id);
        }
    }
}
