using INF272DB1StudentFiles2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace INF272DB1StudentFiles2022.Controllers
{
    public class HomeController : Controller
    {
        private DataService dataService = DataService.getDataService();
        SqlConnection myConnection = new SqlConnection(("Data Source=.;Initial Catalog TouristSites;Integrated Security=True"));

        //complete the missing code and adjust given code where necessary
        public ActionResult Index()
        { //to display a list of records currently in the database in the Index view
            List<string> DBdata = new List<string>();
            try
            {
                SqlCommand mysqlCommand = new SqlCommand("SELECT * FROM TouristSites", myConnection); //add DB 
                myConnection.Open();
                SqlDataReader myReader = mysqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        mysqlCommand.Add(myReader[""]);
                    }
            }
            catch(Exception err)
            {
                ViewBag.Message = "Error" + err.Message;
            }
            finally
            {
                myConnection.Close();
            }
            return View(DBdata);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            //To display the chosen record in the update view
            
            return View(id);
        }

        [HttpPost]
        public ActionResult Update(DestinationModel someDest)
        {//to return the updated record to the Index view and update it in the database
            dataService.updateDest();
            return View(someDest);
        }

        [HttpGet]
        public ActionResult Add()
        {//to open the Add view
            return View();
        }

        [HttpPost]
        public ActionResult Add(DestinationModel someDest)
        {//to add a new record to the database and display it on the Index view
            DataService.createDest();
            return View(someDest);

        }

        public ActionResult Delete(int id)
        {//to delete the chosen record from the database and show it on the Index view
            DataService.deleteDest();
            return View(id);
        }
    }

}