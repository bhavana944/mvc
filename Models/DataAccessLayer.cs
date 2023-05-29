using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Mvc;

namespace StudentDetails_MVC_.Models
{
    public class DataAccessLayer
    {
        //ForDisplay
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ToString());
        SqlCommand command = new SqlCommand();
        public List<StudentDetails> GetAllStudentDetails()
        {
            List<StudentDetails> studentDetails = new List<StudentDetails>();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SP_DisplayStudentdetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
           

            foreach (DataRow dataRow in dataTable.Rows)
            {
                studentDetails.Add(new StudentDetails()
                {
                    Id = Convert.ToInt32(dataRow["Id"].ToString()),
                    StudentName = dataRow["StudentName"].ToString(),
                    Gender = dataRow["Gender"].ToString(),
                    Standard = dataRow["Standard"].ToString(),
                    Section = dataRow["Section"].ToString(),
                    Hobbies = dataRow["Hobbies"].ToString(),
                    Subjects = dataRow["Subjects"].ToString(),
                    Marks1 = Convert.ToInt32(dataRow["Marks1"]),
                    Marks2 = Convert.ToInt32(dataRow["Marks2"]),
                    Marks3 = Convert.ToInt32(dataRow["Marks3"]),
                    Total = Convert.ToInt32(dataRow["Total"])

                }) ;
            }
            return studentDetails;
        }
        //For Insert And Update

        public void InsertAndUpdateStudentDetails(StudentDetails studentDetails)
        {
            connection.Open();
            var properties = studentDetails.GetType().GetProperties();
            command = new SqlCommand("SP_InsertAndUpdateStudentDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (var items in properties)
            {
                command.Parameters.AddWithValue(items.Name, items.GetValue(studentDetails));
            }
            command.ExecuteNonQuery();
            connection.Close();
        }

        
        //For Delete
        public void DeleteStudentDetails(int id)
        {
            connection.Open();
            command = new SqlCommand("SP_DeleteStudentDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            connection.Close();
        }
        //public StudentDetails GetAllStudentDetailsbyid(int id)
        //{
        //    StudentDetails studentDetails = new StudentDetails();
        //    SqlDataAdapter dataAdapter = new SqlDataAdapter("SP_DisplayStudentdetails",connection);
           
        //    DataTable dataTable = new DataTable();
        //    dataAdapter.Fill(dataTable);

        //    foreach (DataRow dataRow in dataTable.Rows)
        //    {

        //        studentDetails.Id = Convert.ToInt32(dataRow["Id"].ToString());
        //        studentDetails.StudentName = dataRow["StudentName"].ToString();
        //        studentDetails.Gender = dataRow["Gender"].ToString();
        //        studentDetails.Standard = dataRow["Standard"].ToString();
        //        studentDetails.Section = dataRow["Section"].ToString();
        //        studentDetails.Hobbies = dataRow["Hobbies"].ToString();
        //        string[] subjectslist = dataRow["Subjects"].ToString().Split(',');
        //        studentDetails.Subject = subjectslist.ToList();
        //        studentDetails.Marks1 = Convert.ToInt32(dataRow["Marks1"]);
        //        studentDetails.Marks2 = Convert.ToInt32(dataRow["Marks2"]);
        //        studentDetails.Marks3 = Convert.ToInt32(dataRow["Marks3"]);
        //        studentDetails.Total = Convert.ToInt32(dataRow["Total"]);

                
        //    }
        //    return studentDetails;
        //}
        //public List<Subjects> GetAllSubjects()
        //{
        //    List<SelectListItem> items = new List<SelectListItem>();
        //    List<Subjects> subjects = new List<Subjects>();
        //    command = new SqlCommand("select * from Subjects", connection);
        //    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
        //    DataTable dataTable = new DataTable();
        //   dataAdapter.Fill(dataTable);

        //    foreach (DataRow dataRow in dataTable.Rows)
        //    {
        //        subjects.Add(new Subjects()
        //        {
        //            Sid = Convert.ToInt32(dataRow["sid"].ToString()),
        //            Sname = dataRow["sname"].ToString(),

        //        });

        //    }

        //    return subjects;
        //}
        //public void GetSubjects()
        //{
        //    command = new SqlCommand("select * from Subjects",connection);
        //    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
        //    DataSet dataSet = new DataSet();
        //    dataAdapter.Fill(dataSet);

        //}


    }
}