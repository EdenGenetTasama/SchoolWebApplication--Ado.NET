using SchoolWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolWebApplication.Controllers.api
{

    public class TeacherController : ApiController
    {
        static string connectionString = "Data Source=DESKTOP-0MT6QTG;Initial Catalog=SchoolDataBasa;Integrated Security=True;Pooling=False";
        List<Teacher> teachers = new List<Teacher>();
        // GET: api/Teacher
        public IHttpActionResult Get()
        {
            try
            {
                using (SqlConnection dataConnection = new SqlConnection(connectionString))
                {
                    dataConnection.Open();
                    string query = "SELECT * FROM Teacher";
                    SqlCommand sqlCommand = new SqlCommand(query, dataConnection);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {

                            teachers.Add(new Teacher(sqlDataReader.GetInt32(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2), sqlDataReader.GetInt32(3), sqlDataReader.GetDateTime(4)));


                        }
                    }
                    return Ok(new { teachers });
                }
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Teacher/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (SqlConnection dataContect = new SqlConnection(connectionString))
                {
                    dataContect.Open();
                    string query = $@"SELECT * FROM Teacher WHERE Id ={id}";
                    SqlCommand sqlCommand = new SqlCommand(query, dataContect);
                    SqlDataReader getIdInfo = sqlCommand.ExecuteReader();
                    if (getIdInfo.HasRows)
                    {
                        while (getIdInfo.Read())
                        {

                            Teacher objectId = new Teacher(getIdInfo.GetInt32(0), getIdInfo.GetString(1), getIdInfo.GetString(2), getIdInfo.GetInt32(3), getIdInfo.GetDateTime(4));
                            return Ok(objectId);
                        }
                    }
                    return Ok("Failed");

                }

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Teacher
        public IHttpActionResult Post([FromBody] Teacher teacher)
        {
            try
            {
                using (SqlConnection dataContect = new SqlConnection(connectionString))
                {
                    dataContect.Open();
                    string query = $@"INSERT INTO Teacher(firstName , lastName , payment , birthDay) VALUES('{teacher.Name}','{teacher.LastName}',{teacher.Payment},'{teacher.Birthday}')";
                    SqlCommand sqlCommand = new SqlCommand(query, dataContect);
                    sqlCommand.ExecuteNonQuery();
                    dataContect.Close();

                    return Ok("ADDED");


                }


            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Teacher/5
        public IHttpActionResult Put(int id, [FromBody] Teacher Teacher)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = $@"UPDATE Teacher
                                      SET firstName = '{Teacher.Name}' , lastName = '{Teacher.LastName}' , payment = {Teacher.Payment} , birthDay ='{Teacher.Birthday}'
                                       WHERE Id={id}";

                    SqlCommand sqlCommand = new SqlCommand(updateQuery, connection);
                    sqlCommand.ExecuteNonQuery();
                    connection.Close();
                }

                return Ok("UPDATED");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Teacher/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string deleteQuery = $@"DELETE FROM Teacher WHERE Id={id}";
                    SqlCommand sqlCommand = new SqlCommand(deleteQuery, connection);
                    sqlCommand.ExecuteNonQuery();

                }
                return Ok("DELETE");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
