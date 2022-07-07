﻿using NetAcademy.Domain.Models.DTOs;

namespace NetAcademy.Repositories.Interfaces;

public interface ICoursesRepository
{
    public Task CreateNewCourseAsync(CourseDto course);
    public Task DeleteCourseAsync(long id);
    public Task UpdateCourseAsync(long id, CourseDto dto);
    public Task<CourseDto> GetCourseAsync(long id);
    public Task<List<CourseDto>> GetAllCoursesAsync();
    public List<string> GetAllCoursesCategory();
    public List<CourseDto> GetCoursesByCategory(string category);
}