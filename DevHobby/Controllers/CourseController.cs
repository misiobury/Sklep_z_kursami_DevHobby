﻿using DevHobby.Models.Repositories;
using DevHobby.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DevHobby.Controllers
{
    public class CourseController : Controller
    {
        private ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public IActionResult List()
        {
            var courseListViewModel = new CourseListViewModel(
               _courseRepository.AllCourses,
               "Dev-hobby - najlepsze kursy!");
         
            return View(courseListViewModel);
        }

        public IActionResult Details(int id)
        {
            var course = _courseRepository.GetCourseById(id);

            if(course == null) { return NotFound(); }
            else
            {
                return View(course);
            }

           
        }
    }
}
