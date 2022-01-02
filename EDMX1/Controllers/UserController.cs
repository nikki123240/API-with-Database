using EDMX1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EDMXdata.Controllers
{
    public class UserController : ApiController
    {

        //Get Fulldata
       public IHttpActionResult GetData()
        {
            using(UsersEntities Dc = new UsersEntities())
            {
                //Method 1
                //List<student> result = Dc.student.ToList();
                //return Ok(result);


                //method 2 using linq query

                List<student> result1 = (from t in Dc.student
                                         select t ).ToList();
                return Ok(result1);

            }
        }

        //Get data by Id

        //[HttpGet]
        //public IHttpActionResult getid(int id)
        //{
        //    using (UsersEntities Dc = new UsersEntities())
        //    {
        //        student students = Dc.student.Where(x => x.Id == id).FirstOrDefault();
        //        return Ok(students);
        //    }
        //}

        //Get data by name

        [HttpGet]
        public IHttpActionResult getName(string Name)
        {
            using (UsersEntities Dc = new UsersEntities())
            {
                student students1 = Dc.student.Where(a=>a.Name == Name).FirstOrDefault();
                return Ok(students1); 
            }
        }

        //Delete data by Id

        [HttpGet]
        public IHttpActionResult deleteid(string name)
        {
            using (UsersEntities Dc = new UsersEntities())
            {
                student students2 = Dc.student.Where(w=>w.Name == name).FirstOrDefault();
                Dc.student.Remove(students2);
                Dc.SaveChanges();
                return Ok(Dc.student);

                List<student> result1 = (from t in Dc.student
                                         select t).ToList();
                return Ok(result1);
            }
        }

        //Add Data by prameters

        [HttpGet]
        public IHttpActionResult AddData(string Name,string Gender,string Domain)
        {
            using (UsersEntities Dc = new UsersEntities())
            {
               var add =  Dc.student.Add(new student { Name = Name, Gender = Gender, Domain = Domain });
                Dc.student.Add(add);
                Dc.SaveChanges();

                List<student> result1 = (from t in Dc.student
                                         select t).ToList();
                return Ok(result1);

            }
        }

        //Add data using postman //added data using class parameter 

        public IHttpActionResult postdata(student stud)
        {
            using (UsersEntities Dc = new UsersEntities())
            {
                var add1 = Dc.student.Add(new student()
                {
                    Name = stud.Name,
                    Gender = stud.Gender,
                    Domain = stud.Domain,

                });
                Dc.student.Add(add1);
                Dc.SaveChanges();

                List<student> result1 = (from t in Dc.student
                                         select t).ToList();
                return Ok(result1);
            }
        }
        
    }
}
