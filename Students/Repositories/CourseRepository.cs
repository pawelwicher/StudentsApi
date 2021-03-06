﻿using System.Collections.Generic;
using Students.DataAccess;
using Students.Model;
using Students.Repositories.Interfaces;

namespace Students.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        public IEnumerable<Course> GetAll()
        {
            return FakeDb.GetAllCourses();
        }
    }
}