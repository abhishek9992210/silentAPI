using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using WebApiClient.Models;

namespace WebApiClient.Controllers
{
    public class EmployeeController : Controller
    {
        HttpClient client;
        public EmployeeController()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (hrm, cert, cetChain, policyErrors) => true;

            client = new HttpClient(handler);

        }
        public IActionResult Index()
        {

            client.BaseAddress = new Uri("http://localhost:5214/api/Employee/GetAllEmployees");

            string result =
            client.GetStringAsync(client.BaseAddress).Result;

            List<EmployeeModel> employees =
            JsonSerializer.Deserialize<List<EmployeeModel>>(result);

            return View(employees);   
        }


        public IActionResult Details(int id)
        {


            client.BaseAddress = new Uri("http://localhost:5214/api/Employee/GetById?id="+id);
   
            string result =
            client.GetStringAsync(client.BaseAddress).Result;

            EmployeeModel employees =  JsonSerializer.Deserialize<EmployeeModel>(result);

            return View(employees);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeModel employee)
        {

            client.BaseAddress = new Uri("http://localhost:5214/api/Employee/Create");
            string jsonEmployee = JsonSerializer.Serialize(employee);
         HttpResponseMessage response = client.PostAsync(client.BaseAddress, new StringContent(jsonEmployee, System.Text.Encoding.UTF8, "application/json")).Result;

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {

            client.BaseAddress = new Uri("http://localhost:5214/api/Employee/GetById?id=" + id);

            string result =
            client.GetStringAsync(client.BaseAddress).Result;

            EmployeeModel employees = JsonSerializer.Deserialize<EmployeeModel>(result);

            return View(employees);
        }

        [HttpPost]
        public IActionResult Update(EmployeeModel employee)
        {

            client.BaseAddress = new Uri("http://localhost:5214/api/Employee/Update?id="+employee.Id);
            string jsonEmployee = JsonSerializer.Serialize(employee);
            HttpResponseMessage response = client.PutAsync(client.BaseAddress, new StringContent(jsonEmployee, System.Text.Encoding.UTF8, "application/json")).Result;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {


            client.BaseAddress = new Uri("http://localhost:5214/api/Employee/GetById?id=" + id);

            string result =
            client.GetStringAsync(client.BaseAddress).Result;

            EmployeeModel employees = JsonSerializer.Deserialize<EmployeeModel>(result);

            return View(employees);

        }
        [HttpPost(Name ="Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            client.BaseAddress = new Uri("http://localhost:5214/api/Employee/Delete?id=" + id);

            HttpResponseMessage result =client.DeleteAsync(client.BaseAddress).Result;

            //EmployeeModel employees = JsonSerializer.Deserialize<EmployeeModel>(result);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));

        }

    }
}
