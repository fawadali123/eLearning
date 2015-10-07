using Learning.Data;
using Learning.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Learning.Web.Controllers
{
    public class CoursesController : BaseApiController
    {
        public List<Course> Get()
        {
            ILearningRepository repository = new LearningRepository(new LearningContext());

            return repository.GetAllCourses().ToList();
        }

        public HttpResponseMessage GetCourse(int id)
        {
            try
            {
                var course = TheRepository.GetCourse(id);
                if (course != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, TheModelFactory.Create(course));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
            
        }
    }
}
