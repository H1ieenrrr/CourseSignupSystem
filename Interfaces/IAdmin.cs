using CourseSignupSystem.Models;
using CourseSignupSystem.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseSignupSystem.Interfaces
{
    public interface IAdmin 
    {
        #region Student
        Task<List<UserModel>> GetStudentAll();
        Task<List<UserModel>> GetStudentId(ViewLogin viewLogin);
        Task<int> AddStudent(UserModel userModel, IFormFile file);
        Task<int> EditStudent(UserModel userModel, IFormFile file);
        Task<int> DeleteStudent(int id);
        #endregion

        #region Teacher
        Task<int> AddTeacher(UserModel userModel, IFormFile file);
        Task<int> EditTeacher(UserModel userModel, IFormFile file);
        Task<List<UserModel>> GetTeacherAll();
        Task<List<UserModel>> GetTeacherId(ViewLogin viewLogin);
        Task<int> DeleteTeacher(int id);

        #endregion

        #region Course

        Task<List<CourseModel>> GetCourse();
        Task<List<CourseModel>> GetCourseId(CourseModel courseModel);
        Task<int> CopyCourse(CourseModel courseModel);
        Task<int> AddCourse(CourseModel courseModel);
        Task<int> EditCourse(CourseModel courseModel);
        Task<int> DeleteCourse(int id);

        #endregion

        #region Department
        Task<List<DepartmentModel>> GetDepartment();
        Task<List<DepartmentModel>> GetDepartmentId(DepartmentModel departmentModel);
        Task<int> AddDepartment(DepartmentModel departmentModel);
        Task<int> EditDepartment(DepartmentModel departmentModel);
        Task<int> DeleteDepartment(int id);
        #endregion
    }
}
