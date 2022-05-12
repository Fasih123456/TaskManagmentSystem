using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using Microsoft.AspNetCore.Hosting;
using System.IO;
using TaskTrackingAPI.Models;

namespace TaskTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeTrackerController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TimeTrackerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from dbo.TimeTracker";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TaskManagmentAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        //This is the post method which will also us to add data to the database
        [HttpPost]
        public JsonResult Post(TimeTracker tt)
        {
            //Do not  write queries directly. Try to use stored procedures with parameters or entity framework
            string query = @"insert into dbo.TimeTracker
                (HoursCompleted, TotalHoursCompleted, DaysReduction, PerDay, Change)
                values 
                (
                '" + tt.WeekTracked + @"'
                ,'" + tt.HoursCompleted + @"'
                ,'" + tt.TotalHoursCompleted + @"'
				,'" + tt.DaysReduction + @"'
				,'" + tt.PerDay + @"'
				,'" + tt.Change + @"'
                )";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TaskManagmentAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("added sucessfully");
        }

        //This is the post method which will update data
        [HttpPut]
        public JsonResult Put(TimeTracker tt)
        {
            //Do not  write queries directly. Try to use stored procedures with parameters or entity framework
            string query = @"update dbo.TimeTracker set  
            WeekTracked = '" + tt.WeekTracked + @"'
            ,HoursCompleted = '" + tt.HoursCompleted + @"'
            ,TotalHoursCompleted = '" + tt.TotalHoursCompleted + @"'
            ,DaysReduction = '" + tt.DaysReduction + @"'
            ,PerDay = '" + tt.PerDay + @"'
            ,Change = '" + tt.Change + @"'
            where TaskId = " + tt.TimeTrackedId+ @"";


            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TaskManagmentAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated sucessfully");
        }

        //This is the post method which will delete data
        [HttpDelete("{id}")]//Since we will be writing the id in the use we need to add it here as a parameter
        public JsonResult Delete(int id)
        {
            //Do not  write queries directly. Try to use stored procedures with parameters or entity framework
            string query = @"delete from dbo.TimeTracker where TimeTrackerId = " + id + @"";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TaskManagmentAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted sucessfully");
        }
    }
}
