using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseSignupSystem.Models
{
    public enum Gender
    {
        [Display(Name = "Nam")]
        Nam = 1,
        [Display(Name = "Nữ")]
        Nu = 2
    }

    [Table("User")]
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "Họ")]
        [StringLength(20)]
        public string UserSurname { get; set; }

        [Display(Name = "Tên Đệm và Tên")]
        [StringLength(30)]
        public string UserFisrtName { get; set; }

        [Display(Name = "Mã Giảng Viên")]
        [StringLength(20)]
        public string UserTeacherCode { get; set; }

        [Display(Name = "Mã Số Thuế")]
        [StringLength(20)]
        public string UserTaxCode { get; set; }

        [Display(Name = "Mã Học Viên")]
        [StringLength(20)]
        public string UserStudentCode { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        [Column(TypeName = "varchar(15)"), MaxLength(15)]
        [DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})[-. ]?([0-9]{4})[-. ]?([0-9]{3})$", ErrorMessage = "Số Điện Thoại Không Hợp Lệ")]
        public string UserPhone { get; set; }

        [Display(Name = "Địa Chỉ")]
        [StringLength(200)]
        public string UserAddress { get; set; }

        
        [Display(Name = "Giới Tính")]
        public Gender UserGender { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime UserBirthday { get; set; }

        [Display(Name = "Tên Phụ Huynh")]
        [StringLength(200)]
        public string UserParentName { get; set; }

        [Display(Name = "Hình Ảnh Đại Diện")]
        [Column(TypeName = "varchar(200)"), MaxLength(100)]
        public string UserImg { get; set; }

        [Display(Name = "Lớp Học")]
        [StringLength(20)]
        public string UserClass { get; set; }

        [Display(Name = "Môn Dạy Chính")]
        [StringLength(200)]
        public string UserMainSubject { get; set; }

        [Display(Name = "Môn Kiêm Nhiệm")]
        [StringLength(200)]
        public string UserParttimeSubject { get; set; }

        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("UserPassword", ErrorMessage = "Mật khẩu không khớp")]
        [NotMapped]
        public string UserCofirmPassword { get; set; }

        [ForeignKey("roleModel")]
        public int UserRole { get; set; }

        public bool UserBlock { get; set; }

        public bool IsDelete { get; set; }

        public RoleModel roleModel { get; set; }

        public virtual ClassModel classModel { get; set; }
    }
}
