using CourseSignupSystem.Interfaces;
using CourseSignupSystem.Models;
using CourseSignupSystem.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseSignupSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin _adminSvc;
        public AdminController(IAdmin adminSvc)
        {
            _adminSvc = adminSvc;
        }

        #region Student

        [HttpGet]
        [Route("ListStudent")]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetAllStudent()
        {
            var getalluser = await _adminSvc.GetStudentAll();
            return getalluser;
        }

        [HttpGet]
        [Route("StudentId")]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetStudentId(ViewLogin viewLogin)
        {
            var getalluser = await _adminSvc.GetStudentId(viewLogin);
            return getalluser;
        }

        [HttpPost]
        [Route("AddStudent")]
        public async Task<ActionResult<int>> AddStudent([FromForm] UserModel userModel)
        {
            try
            {
                UserModel user = JsonConvert.DeserializeObject<UserModel>(userModel.User);

                int id = await _adminSvc.AddStudent(user, userModel.UploadImg);
                userModel.UserId = id;

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpPost]
        [Route("EditStudent")]
        public async Task<ActionResult<int>> EditStudent([FromForm]UserModel userModel)
        {
            try
            {
                UserModel user = JsonConvert.DeserializeObject<UserModel>(userModel.User);

                await _adminSvc.EditStudent(user, userModel.UploadImg);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public async Task<ActionResult<int>> DeleteStudent(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _adminSvc.DeleteStudent(id);

            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }

            return Ok(1);
        }
        #endregion

        #region Teacher


        [HttpGet]
        [Route("ListTeacher")]
        public async Task<ActionResult<IEnumerable<UserModel>>> ListTeacher()
        {
            var getalluser = await _adminSvc.GetTeacherAll();
            return getalluser;
        }

        [HttpGet]
        [Route("TeacherId")]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetTeacherId(ViewLogin viewLogin)
        {
            var getalluser = await _adminSvc.GetTeacherId(viewLogin);
            return getalluser;
        }

        [HttpPost]
        [Route("AddTeacher")]
        public async Task<ActionResult<int>> AddTeacher([FromForm] UserModel userModel)
        {
            try
            {
                UserModel user = JsonConvert.DeserializeObject<UserModel>(userModel.User);

                int id = await _adminSvc.AddTeacher(user, userModel.UploadImg);
                userModel.UserId = id;

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpPost]
        [Route("EditTeacher")]
        public async Task<ActionResult<int>> EditTeacher([FromForm] UserModel userModel)
        {
            try
            {
                UserModel user = JsonConvert.DeserializeObject<UserModel>(userModel.User);

                await _adminSvc.EditTeacher(user, userModel.UploadImg);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpDelete]
        [Route("DeleteTeacher/{id}")]
        public async Task<ActionResult<int>> DeleteTeacher(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _adminSvc.DeleteTeacher(id);

            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }

            return Ok(1);
        }
        #endregion

        #region Course

        [HttpGet]
        [Route("ListCourse")]
        public async Task<ActionResult<IEnumerable<CourseModel>>> GetAllCourse()
        {
            var list = await _adminSvc.GetCourse();
            return list;
        }

        [HttpGet]
        [Route("CourseId")]
        public async Task<ActionResult<IEnumerable<CourseModel>>> GetCourse(CourseModel courseModel)
        {
            var list = await _adminSvc.GetCourseId(courseModel);
            return list;
        }

        [HttpPost]
        [Route("AddCourse")]
        public async Task<ActionResult<int>> AddCourse(CourseModel courseModel)
        {
            try
            {
                var id = await _adminSvc.AddCourse(courseModel);
                courseModel.CourseId = id;
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpPost]
        [Route("EditCourse")]
        public async Task<ActionResult<int>> EditCourse(CourseModel courseModel)
        {
            try
            {
                await _adminSvc.EditCourse(courseModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpPost]
        [Route("CopyCourse")]
        public async Task<ActionResult<int>> CopyCourse(CourseModel courseModel)
        {
            try
            {
                var id = await _adminSvc.CopyCourse(courseModel);
                courseModel.CourseId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpDelete]
        [Route("DeleteCourse/{id}")]
        public async Task<ActionResult<int>> DeleteCourse(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _adminSvc.DeleteCourse(id);
            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }

            return Ok(1);
        }

        #endregion

        #region Department

        [HttpGet]
        [Route("ListDepartment")]
        public async Task<ActionResult<IEnumerable<DepartmentModel>>> ListAllDepartment()
        {
            var list = await _adminSvc.GetDepartment();
            return list;
        }

        [HttpGet]
        [Route("DepartmentId")]
        public async Task<ActionResult<IEnumerable<DepartmentModel>>> GetDepartmentId(DepartmentModel department)
        {
            var list = await _adminSvc.GetDepartmentId(department);
            return list;
        }

        [HttpPost]
        [Route("AddDepartment")]
        public async Task<ActionResult<int>> AddDepartment(DepartmentModel department)
        {
            try
            {
                var id = await _adminSvc.AddDepartment(department);
                department.DepartmentId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpPost]
        [Route("EditDepartment")]
        public async Task<ActionResult<int>> EditDepartment(DepartmentModel Department)
        {
            try
            {
                await _adminSvc.EditDepartment(Department);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpDelete]
        [Route("DeleteDepartment/{id}")]
        public async Task<ActionResult<int>> DeleteDepartment(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _adminSvc.DeleteDepartment(id);
            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }

            return Ok(1);
        }

        #endregion
    }
}
