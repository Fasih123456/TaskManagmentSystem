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
    public class TaskClassController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TaskClassController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from dbo.Task";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("TaskManagmentAppCon");
            SqlDataReader myReader;
            using(SqlConnection myCon=new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using(SqlCommand myCommand = new SqlCommand(query, myCon))
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
        public JsonResult Post(TaskClass task)
        {
            //Do not  write queries directly. Try to use stored procedures with parameters or entity framework
            string query = @"insert into dbo.Task
                (TaskDate,Day,Course,TaskName,TimeRequired,TimeNotSpent,TaskStatus)
                values 
                (
                '" + task.TaskDate + @"'
                ,'" + task.Day + @"'
                ,'" + task.Course + @"'
				,'" + task.TaskName + @"'
				,'" + task.TimeRequired + @"'
				,'" + task.TimeNotSpent + @"'
                ,'" + task.TaskStatus + @"'
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
        public JsonResult Put(TaskClass task)
        {
            //Do not  write queries directly. Try to use stored procedures with parameters or entity framework
            string query = @"update dbo.Task set  
            TaskName = '" + task.TaskName + @"'
            ,Day = '" + task.Day + @"'
            ,Course = '" + task.Course + @"'
            ,TimeRequired = '" + task.TimeRequired + @"'
            ,TimeNotSpent = '" + task.TimeNotSpent + @"'
            ,TaskStatus = '" + task.TaskStatus + @"'
            where TaskId = " + task.TaskId + @"";

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
            string query = @"delete from dbo.Task where TaskId = " + id + @"";
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
