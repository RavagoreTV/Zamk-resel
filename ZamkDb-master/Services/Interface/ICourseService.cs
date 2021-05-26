using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using ZamkDb.Models;

namespace ZamkDb.Services.Interface
{
	public interface ICourseService
	{
		Course GetCourse(int id);
		IEnumerable<Course> GetAllCourses();
		Course AddCourse(Course c);

		Course DeleteCourse(int id);

        Course EditCourse(Course c);

        IEnumerable <Course> FilterCourse(string criteria);
    }
}
