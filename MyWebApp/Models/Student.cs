using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Models
{
	public class Student
	{
		public int Id { get; set; }//Mã sinh viên
		[Required(ErrorMessage = "Họ tên bắt buộc phải được nhập")]
		[StringLength(100, MinimumLength = 4, ErrorMessage = "Họ tên từ {2} đến {1} ký tự")]
		public string? Name { get; set; } //Họ tên
		[Required(ErrorMessage = "Email bắt buộc phải được nhập")]
		[RegularExpression(@"^[\w-\.]+@gmail\.com$",
	 ErrorMessage = "Email phải có đuôi gmail.com")]
		public string? Email { get; set; } //Email
		[StringLength(100, MinimumLength = 8)]
		[Required(ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường, chữ số và ký tự đặc biệt")]
		[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
	 ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường, chữ số và ký tự đặc biệt")]
		public string? Password { get; set; }//Mật khẩu
		[Required(ErrorMessage = "Branch bắt buộc phải được nhập")]
		public Branch? Branch { get; set; }//Ngành học
		[Required(ErrorMessage = "Gender bắt buộc phải được nhập")]
		public Gender? Gender { get; set; }//Giới tính
		public bool IsRegular { get; set; }//Hệ: true-chính quy, false-phi chính quy
		[DataType(DataType.MultilineText)]
		[Required(ErrorMessage = "Địa chỉ bắt buộc phải được nhập")]
		public string? Address { get; set; }//Địa chỉ

		[Range(typeof(DateTime), "01/01/1963", "12/31/2005",
			ErrorMessage = "Ngày sinh phải trong khoảng {1} đến {2}")]
		[DataType(DataType.Date)]
/*		[Required(ErrorMessage = "Ngày sinh bắt buộc phải được nhập  ")]*/
		public DateTime DateOfBorth { get; set; }//Ngày sinh
		//[Required(ErrorMessage = "Điểm bắt buộc phải được nhập")]
		//[Range(0.0, 10.0, ErrorMessage = "Điểm từ {1} đến {2}")]
		//public float? Diem { get; set; }
	}
}
