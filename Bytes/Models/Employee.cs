using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bytes.Models
{
    public class Employee
    {
        private int employeeID;
        private string username;
        private string password;
        private string firstName;
        private string lastName;
        private string phoneNumber;

        [Key]
        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        [Required(ErrorMessage = "Please provide user name")]
        [RegularExpression(".+\\@.+\\..+",
        ErrorMessage = "Please enter a valid username")]
        [StringLength(25)]
        [Display(Name = "User Name")]
        [EmailAddress]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        [Required(ErrorMessage = "Please provide user password")]
        [StringLength(25)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        [Required(ErrorMessage = "Please enter first name")]
        [StringLength(25)]
        [Display(Name = "First Name")]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        [Required(ErrorMessage = "Please enter last name")]
        [StringLength(25)]
        [Display(Name = "Last Name")]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        [Required(ErrorMessage = "Please provide phone number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
         
    }
}