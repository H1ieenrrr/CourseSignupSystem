﻿using CourseSignupSystem.Interfaces;
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

        #region Role

        [HttpPost]
        [Route("AddRole")]
        public async Task<ActionResult<int>> AddRole(RoleModel roleModel)
        {
            try
            {
                var id = await _adminSvc.AddRole(roleModel);
                roleModel.RoleId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }
        #endregion

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

        #region Subject 

        [HttpGet]
        [Route("ListSubject")]
        public async Task<ActionResult<IEnumerable<SubjectModel>>> ListSubject()
        {
            var list = await _adminSvc.GetSubject();
            return list;
        }

        [HttpGet]
        [Route("ListSubjectAll")]
        public async Task<ActionResult<IEnumerable<SubjectModel>>> ListAllSubject()
        {
            var list = await _adminSvc.GetSubjectAll();
            return list;
        }

        [HttpGet]
        [Route("SubjectId")]
        public async Task<ActionResult<IEnumerable<SubjectModel>>> ListSubjectId(SubjectModel subjectModel)
        {
            var list = await _adminSvc.GetSubjectId(subjectModel);
            return list;
        }

        [HttpPost]
        [Route("AddSubject")]
        public async Task<ActionResult<int>> AddSubject(SubjectModel subjectModel)
        {
            try
            {
                var id = await _adminSvc.AddSubject(subjectModel);
                subjectModel.SubjectId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpPost]
        [Route("EditSubject")]
        public async Task<ActionResult<int>> EditSubject(SubjectModel subjectModel)
        {
            try
            {
                 await _adminSvc.EditSubject(subjectModel);               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpDelete]
        [Route("DeleteSubject/{id}")]
        public async Task<ActionResult<int>> DeleteSubject(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _adminSvc.DeleteSubject(id);
            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }

            return Ok(1);
        }

        #endregion

        #region ScoreType (Loại Điểm)

        [HttpGet]
        [Route("ListScoreType")]
        public async Task<ActionResult<IEnumerable<ScoreTypeModel>>> ListAllScoreType()
        {
            var list = await _adminSvc.GetScoreType();
            return list;
        }

        [HttpPost]
        [Route("AddScoreType")]
        public async Task<ActionResult<int>> AddScoreType(ScoreTypeModel scoreTypeModel)
        {
            try
            {
                var id = await _adminSvc.AddScoreType(scoreTypeModel);
                scoreTypeModel.ScoreTypeId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpPost]
        [Route("EditScoreType")]
        public async Task<ActionResult<int>> EditScoreType(ScoreTypeModel scoreTypeModel)
        {
            try
            {
                await _adminSvc.EditScoreType(scoreTypeModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpDelete]
        [Route("DeleteScoreType/{id}")]
        public async Task<ActionResult<int>> DeleteScoreType(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _adminSvc.DeleteScoreType(id);
            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }

            return Ok(1);
        }

        #endregion

        #region Score (Điểm)

        [HttpGet]
        [Route("ListScore")]
        public async Task<ActionResult<IEnumerable<ScoreModel>>> ListAllScore()
        {
            var list = await _adminSvc.GetScore();
            return list;
        }

        [HttpGet]
        [Route("ListScoreAll")]
        public async Task<ActionResult<IEnumerable<ScoreModel>>> ListScoreAll()
        {
            var list = await _adminSvc.GetScoreAll();
            return list;
        }

        [HttpGet]
        [Route("ScoreId")]
        public async Task<ActionResult<IEnumerable<ScoreModel>>> ScoreId(ScoreModel scoreModel)
        {
            var list = await _adminSvc.GetScoreId(scoreModel);
            return list;
        }

        [HttpPost]
        [Route("AddScore")]
        public async Task<ActionResult<int>>  AddScore(ScoreModel scoreModel)
        {
            try
            {
                int id = await _adminSvc.AddScore(scoreModel);
                scoreModel.ScoreId = id;
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpPost]
        [Route("EditScore")]
        public async Task<ActionResult<int>> EditScore(ScoreModel scoreModel)
        {
            try
            {
                int id = await _adminSvc.EditScore(scoreModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpDelete]
        [Route("DeleteScore/{id}")]
        public async Task<ActionResult<int>> DeleteScore(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _adminSvc.DeleteScore(id);
            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }

            return Ok(1);
        }

        #endregion

        #region Class (Lớp Học)

        [HttpGet]
        [Route("ListClass")]
        public async Task<ActionResult<IEnumerable<ClassModel>>> ListClass()
        {
            var list = await _adminSvc.GetClass();
            return list;
        }

        [HttpGet]
        [Route("ListClassStudent")]
        public async Task<ActionResult<IEnumerable<UserModel>>> ListClassStudent(ClassModel classModel)
        {
            var list = await _adminSvc.GetClassStudent(classModel);
            return list;
        }

        [HttpGet]
        [Route("ClassId")]
        public async Task<ActionResult<IEnumerable<ClassModel>>> ClassId(ClassModel classModel)
        {
            var list = await _adminSvc.GetClassId(classModel);
            return list;
        }

        [HttpPost]
        [Route("AddClass")]
        public async Task<ActionResult<int>> AddClass(ClassModel classModel)
        {
            try
            {
                var id = await _adminSvc.AddClass(classModel);
                classModel.ClassId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpPost]
        [Route("EditClass")]
        public async Task<ActionResult<int>> EditClass(ClassModel classModel)
        {
            try
            {
                await _adminSvc.EditClass(classModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpDelete]
        [Route("DeleteClass/{id}")]
        public async Task<ActionResult<int>> DeleteClass(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _adminSvc.DeleteClass(id);
            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }

            return Ok(1);
        }

        #endregion

        #region ScoreDetail (Bảng Điểm)

        [HttpGet]
        [Route("ListScoreDetail")]
        public async Task<ActionResult<IEnumerable<ScoreDetail>>> ListScoreDetail()
        {
            var list = await _adminSvc.GetScoreDetail();
            return list;
        }

        [HttpGet]
        [Route("ScoreDetailId")]
        public async Task<ActionResult<IEnumerable<ScoreDetail>>> ScoreDetailId(ScoreDetail scoreDetail)
        {
            var list = await _adminSvc.ScoreDetailId(scoreDetail);
            return list;
        }

        [HttpPost]
        [Route("AddScoreDetail")]
        public async Task<ActionResult<int>> AddScoreDetai(ViewScore viewScore)
        {
            try
            {
                await _adminSvc.AddScoreDetail(viewScore);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpPost]
        [Route("EditScoreDetail")]
        public async Task<ActionResult<int>> EditScoreDetail(ViewScore viewScore)
        {
            try
            {
                await _adminSvc.EditScoreDetail(viewScore);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }
        #endregion

        #region Receipts (học phí)
        [HttpGet]
        [Route("ListReceipts")]
        public async Task<ActionResult<IEnumerable<ReceiptsModel>>> ListReceipts()
        {
            var list = await _adminSvc.GetReceipts();
            return list;
        }

        [HttpPost]
        [Route("AddReceipts")]
        public async Task<ActionResult<int>> AddReceipts(ReceiptsModel receiptsModel)
        {
            try
            {
               int id =  await  _adminSvc.AddReceipts(receiptsModel);
                receiptsModel.ReceiptsId = id;
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }
        #endregion

        #region Schedule ( Lịch Dạy)

        [HttpGet]
        [Route("ListSchedule")]
        public async Task<ActionResult<IEnumerable<ScheduleModel>>> ListSchedule()
        {
            var list = await _adminSvc.GetSchedule();
            return list;
        }

        [HttpGet]
        [Route("ScheduleId")]
        public async Task<ActionResult<IEnumerable<ScheduleModel>>> ScheduleId(ScheduleModel scheduleModel)
        {
            var list = await _adminSvc.ScheduleId(scheduleModel);
            return list;
        }

        [HttpPost]
        [Route("AddSchedule")]
        public async Task<ActionResult<int>> AddSchedule(ScheduleModel scheduleModel)
        {
            try
            {
                int id = await _adminSvc.AddSchedule(scheduleModel);
                scheduleModel.ScheduleId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpPost]
        [Route("EditSchedule")]
        public async Task<ActionResult<int>> EditSchedule(ScheduleModel scheduleModel)
        {
            try
            {
                await _adminSvc.EditSchedule(scheduleModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpDelete]
        [Route("DeleteSchedule/{id}")]
        public async Task<ActionResult<int>> DeleteSchedule(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _adminSvc.DeleteSchedule(id);
            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }

            return Ok(1);
        }
        #endregion

        #region Schedule (Ngày Nghỉ)
        [HttpGet]
        [Route("ListScheduleHoliDay")]
        public async Task<ActionResult<IEnumerable<ScheduleHoliday>>> ListScheduleHoliday()
        {
            var list = await _adminSvc.GetScheduleHoliday();
            return list;
        }

        [HttpGet]
        [Route("ScheduleHolidayId")]
        public async Task<ActionResult<IEnumerable<ScheduleHoliday>>> ScheduleHolidayId(ScheduleHoliday scheduleHoliday)
        {
            var list = await _adminSvc.ScheduleHolidayId(scheduleHoliday);
            return list;
        }

        [HttpPost]
        [Route("AddScheduleHoliday")]
        public async Task<ActionResult<int>> AddScheduleHoliday(ScheduleHoliday scheduleHoliday)
        {
            try
            {
                int id = await _adminSvc.AddScheduleHoliday(scheduleHoliday);
                scheduleHoliday.ScheduleHolidayId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpPost]
        [Route("EditScheduleHoliday")]
        public async Task<ActionResult<int>> EditScheduleHoliday(ScheduleHoliday scheduleHoliday)
        {
            try
            {
                await _adminSvc.EditScheduleHoliday(scheduleHoliday);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpDelete]
        [Route("DeleteScheduleHoliday/{id}")]
        public async Task<ActionResult<int>> DeleteScheduleHoliday(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _adminSvc.DeleteScheduleHoliday(id);
            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }

            return Ok(1);
        }
        #endregion

        #region Schedule (Học Sinh)

        [HttpGet]
        [Route("ScheduleStudentId")]
        public async Task<ActionResult<IEnumerable<ScheduleStudent>>> ScheduleStudentId(ScheduleStudent scheduleStudent)
        {
            var list = await _adminSvc.GetScheduleStudent(scheduleStudent);
            return list;
        }

        [HttpPost]
        [Route("AddScheduleStudent")]
        public async Task<ActionResult<int>> AddScheduleStudent(ScheduleStudent scheduleStudent)
        {
            try
            {
                int id = await _adminSvc.AddScheduleStudent(scheduleStudent);
                scheduleStudent.ScheduleStudentId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        #endregion
    }

}
