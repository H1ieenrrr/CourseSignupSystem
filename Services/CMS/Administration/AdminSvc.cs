using CourseSignupSystem.Interfaces;
using CourseSignupSystem.Models;
using CourseSignupSystem.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CourseSignupSystem.Services.CMS.Administration
{
    public class AdminSvc : IAdmin
    {
        protected DataContext _context;
        protected IEncode _enCode;

        public AdminSvc(DataContext context, IEncode encode)
        {
            _context = context;
            _enCode = encode;
        }

        public async Task<UserModel> GetUser(int id)
        {
            UserModel user = null;
            user = await _context.UserModels.FindAsync(id);
            return user;
        }


        #region Student
        public async Task<List<UserModel>> GetStudentAll()
        {
            var user = await _context.UserModels.Where(u => u.UserRole == 3).ToListAsync();
            return user;
        }

        public async Task<List<UserModel>> GetStudentId(ViewLogin viewLogin)
        {
            
            var user = await _context.UserModels.Where(u => u.UserStudentCode == viewLogin.UserStudentCode ||
               u.UserFisrtName == viewLogin.UserFisrtName || u.UserPhone == viewLogin.UserPhone || u.UserEmail == viewLogin.UserEmail).ToListAsync();
            return user;
        }

        public async Task<int> AddStudent(UserModel userModel, IFormFile file)
        {
            int ret = 0;
            try
            {
                userModel.UserBlock = false;
                userModel.UserPassword = _enCode.Encode(userModel.UserPassword);
                userModel.IsDelete = true;
                userModel.UserRole = 3;

                if (file != null)
                {
                    if (file.Length > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);

                        //var fileExtension = Path.GetExtension(fileName);
                        //var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                        var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                        fileName = DateTime.Now.Ticks + extension;

                        var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Image\\Students");

                        if (!Directory.Exists(pathBuilt))
                        {
                            Directory.CreateDirectory(pathBuilt);
                        }

                        var path = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Image\\Students", fileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        userModel.UserImg = fileName;
                    }
                }

                await _context.AddAsync(userModel);
                await _context.SaveChangesAsync();
                ret = userModel.UserId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> EditStudent(UserModel userModel, IFormFile file)
        {
            int ret = 0;
            try
            {
                UserModel user = null;
                user = await GetUser(userModel.UserId);

                user.UserSurname = userModel.UserSurname;
                user.UserFisrtName = userModel.UserFisrtName;
                user.UserBirthday = userModel.UserBirthday;
                user.UserEmail = userModel.UserEmail;
                user.UserAddress = userModel.UserAddress;
                user.UserParentName = userModel.UserParentName;
                user.UserClass = userModel.UserClass;
                user.UserPhone = userModel.UserPhone;
                user.UserPassword = _enCode.Encode(userModel.UserPassword);
                

                if (file != null)
                {
                    if (file.Length > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);

                        //var fileExtension = Path.GetExtension(fileName);
                        //var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                        var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                        fileName = DateTime.Now.Ticks + extension;

                        var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Image\\Students");

                        if (!Directory.Exists(pathBuilt))
                        {
                            Directory.CreateDirectory(pathBuilt);
                        }

                        var path = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Image\\Students", fileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        user.UserImg = fileName;
                    }
                }
                 _context.Update(user);
                await _context.SaveChangesAsync();
                ret = userModel.UserId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> DeleteStudent(int id)
        {
            int ret = 0;
            try
            {
                var user = await GetUser(id);
                _context.Remove(user);
                await _context.SaveChangesAsync();
                ret = user.UserId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        #endregion

        #region Teacher

        public async Task<List<UserModel>> GetTeacherAll()
        {
            var user = await _context.UserModels.Where(u => u.UserRole == 2).ToListAsync();
            return user;
        }

        public async Task<List<UserModel>> GetTeacherId(ViewLogin viewLogin)
        {
            var user = await _context.UserModels.Where(u => u.UserTeacherCode == viewLogin.UserTeacherCode ||
               u.UserFisrtName == viewLogin.UserFisrtName || u.UserPhone == viewLogin.UserPhone || u.UserEmail == viewLogin.UserEmail).ToListAsync();
            return user;
        }

        public async Task<int> AddTeacher(UserModel userModel, IFormFile file)
        {
            int ret = 0;
            try
            {
                userModel.UserBlock = false;
                userModel.UserPassword = _enCode.Encode(userModel.UserPassword);
                userModel.IsDelete = true;
                userModel.UserRole = 2;

                if (file != null)
                {
                    if (file.Length > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);

                        //var fileExtension = Path.GetExtension(fileName);
                        //var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                        var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                        fileName = DateTime.Now.Ticks + extension;

                        var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Image\\Teachers");

                        if (!Directory.Exists(pathBuilt))
                        {
                            Directory.CreateDirectory(pathBuilt);
                        }

                        var path = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Image\\Teachers", fileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        userModel.UserImg = fileName;
                    }
                }

                await _context.AddAsync(userModel);
                await _context.SaveChangesAsync();
                ret = userModel.UserId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> EditTeacher(UserModel userModel, IFormFile file)
        {
            int ret = 0;
            try
            {
                UserModel user = null;
                user = await GetUser(userModel.UserId);

                user.UserTaxCode = userModel.UserTaxCode;
                user.UserSurname = userModel.UserSurname;
                user.UserFisrtName = userModel.UserFisrtName;
                user.UserBirthday = userModel.UserBirthday;
                user.UserEmail = userModel.UserEmail;
                user.UserGender = userModel.UserGender;
                user.UserAddress = userModel.UserAddress;
               
                user.UserMainSubject = userModel.UserMainSubject;
                user.UserParttimeSubject = userModel.UserParttimeSubject;
                user.UserPhone = userModel.UserPhone;
                user.UserPassword = _enCode.Encode(userModel.UserPassword);


                if (file != null)
                {
                    if (file.Length > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);

                        //var fileExtension = Path.GetExtension(fileName);
                        //var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                        var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                        fileName = DateTime.Now.Ticks + extension;

                        var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Image\\Teachers");

                        if (!Directory.Exists(pathBuilt))
                        {
                            Directory.CreateDirectory(pathBuilt);
                        }

                        var path = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Image\\Teachers", fileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        user.UserImg = fileName;
                    }
                }
                _context.Update(user);
                await _context.SaveChangesAsync();
                ret = userModel.UserId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> DeleteTeacher(int id)
        {
            int ret = 0;
            try
            {
                var user = await GetUser(id);
                _context.Remove(user);
                await _context.SaveChangesAsync();
                ret = user.UserId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        #endregion

        #region Course (Khóa)

        public async Task<List<CourseModel>> GetCourse()
        {
            var list = await _context.CourseModels.ToListAsync();
            return list;
        }

        public async Task<List<CourseModel>> GetCourseId(CourseModel courseModel)
        {
            var course = await _context.CourseModels.Where(c => c.CourseCode == courseModel.CourseCode ||
                                    c.CourseName == courseModel.CourseName).ToListAsync();
            return course;
        }

        public async Task<CourseModel> GetCourseId(int id)
        {
            CourseModel course = null;
            course = await _context.CourseModels.FindAsync(id);
            return course;
        }

        public async Task<CourseModel> GetCourseString(string code)
        {
            CourseModel course = null;
            course = await _context.CourseModels.Where(c => c.CourseCode == code).FirstOrDefaultAsync();
            return course;
        }
        public async Task<int> CopyCourse(CourseModel courseModel)
        {
            int ret = 0;
            try
            {
                CourseModel course = null;
                course = await GetCourseString(courseModel.Course);

                await _context.AddAsync(courseModel);
                await _context.SaveChangesAsync();
                ret = courseModel.CourseId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> AddCourse(CourseModel courseModel)
        {
            int ret = 0;
            try
            {
                await _context.AddAsync(courseModel);
                await _context.SaveChangesAsync();
                ret = courseModel.CourseId;
            }
            catch(Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> EditCourse(CourseModel courseModel)
        {
            int ret = 0;
            try
            {
                CourseModel course = null;
                course = await GetCourseId(courseModel.CourseId);

                course.CourseCode = courseModel.CourseCode;
                course.CourseName = courseModel.CourseName;

                _context.Update(course);
                await _context.SaveChangesAsync();
                ret = courseModel.CourseId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> DeleteCourse(int id)
        {
            int ret = 0;
            try
            {
                var course = await GetCourseId(id);
                _context.Remove(course);
                await _context.SaveChangesAsync();
                ret = course.CourseId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        #endregion

        #region Department (Tổ Bộ Môn)

        public async Task<List<DepartmentModel>> GetDepartment()
        {
            var department = await _context.DepartmentModels.ToListAsync();
            return department;
        }

        public async Task<List<DepartmentModel>> GetDepartmentId(DepartmentModel departmentModel)
        {
            var department = await _context.DepartmentModels.Where(d => d.DepartmentName == departmentModel.DepartmentName).ToListAsync();
            return department;
        }

        public async Task<DepartmentModel> GetDepartmentId(int id)
        {
            DepartmentModel department = null;
            department = await _context.DepartmentModels.FindAsync(id);
            return department;
        }

        public async Task<int> AddDepartment(DepartmentModel departmentModel)
        {
            int ret = 0;
            try
            {
                await _context.AddAsync(departmentModel);
                await _context.SaveChangesAsync();
                ret = departmentModel.DepartmentId;
            }
            catch(Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> EditDepartment(DepartmentModel departmentModel)
        {
            int ret = 0;
            try
            {
                DepartmentModel depart = null;
                depart = await GetDepartmentId(departmentModel.DepartmentId);

                depart.DepartmentName = departmentModel.DepartmentName;

                 _context.Update(depart);
                await _context.SaveChangesAsync();
                ret = departmentModel.DepartmentId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> DeleteDepartment(int id)
        {
            int ret = 0;
            try
            {
                var depart = await GetDepartmentId(id);
                _context.Remove(depart);
                await _context.SaveChangesAsync();
                ret = depart.DepartmentId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        #endregion

    }

}
