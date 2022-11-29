﻿using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Repository;
using NetAcademy.Repository.Interfaces;

namespace NetAcademy.Services;

public class StudentsService
{
    private IStudentsRepository repository;

    public StudentsService(IStudentsRepository repo)
    {
        repository = repo;
    }

    public async Task EnrollStudentToCourseAsync(long id, long courseId)
    {
        await repository.EnrollStudentToCourseAsync(id, courseId);
    }

    public async Task CreateNewStudentAsync(StudentDto dto)
    {
        await repository.CreateNewStudentAsync(dto);
    }

    public async Task UpdateStudentAsync(long id, StudentDto dto)
    {
        await repository.UpdateStudentAsync(id, dto);
    }

    public async Task<List<StudentDto>> GetAllStudentsAsync()
    {
        return await repository.GetAllStudentsAsync();
    }

    public async Task<StudentDto?> GetStudentAsync(long id)
    {
        return await repository.GetStudentAsync(id);
    }

    public async Task DeleteStudentAsync(long id)
    {
        await repository.DeleteStudentAsync(id);
    }

    public async Task CancelStudentFromCourseAsync(long id, long courseId)
    {
        await repository.CancelStudentFromCourseAsync(id, courseId);
    }

    // esercizi in più

    public async Task<StudentInfoDto> GetStudentCourseAsync(long id)
    {
        return await repository.GetStudentCourseAsync(id);
    }

    public async Task<StudentInfoDto> GetStudentCoursesAndTeachersAsync(long id)
    {
        return await repository.GetStudentCoursesAndTeachersAsync(id);
    }
}