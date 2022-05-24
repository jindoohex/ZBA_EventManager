using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerLib.model
{
    public class User
    {
        public enum UserStateType { Admin, RegUser };

        private int _userId;
        private string _firstName;
        private string _lastName;
        private string _phone;
        private string _email;
        private string _password;
        private UserStateType _userState;

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        [Required]
        [MinLength(3, ErrorMessage = "Firstname must be at least 3 characters long")]
        public string FirstName
        {
            get { return _firstName; }
            set {
                CheckFirstName(value);
                _firstName = value; }
        }

        private void CheckFirstName(string firstname)
        {
            if (string.IsNullOrEmpty(firstname))
            {
                throw new ArgumentNullException("Firstname must not be empty");
            }
           
            if (firstname.Length < 3)
            {
                throw new ArgumentException("firstName must be at least 3 character long");
            }
        }

        [Required]
        [MinLength(3, ErrorMessage = "Lastname must be at least 3 characters long")]
        public string LastName
        {
            get { return _lastName; }
            set {
                CheckLastName(value);
                _lastName = value; }
        }

        private void CheckLastName(string lastname)
        {
            if (string.IsNullOrEmpty(lastname))
            {
                throw new ArgumentNullException("Lastname must not be empty");
            }

            if (lastname.Length < 3)
            {
                throw new ArgumentException("Lastname must be at least 3 character long");
            }

        }

        [Required]
        [MinLength(8, ErrorMessage = "Phone must be at least 8 characters long")]
        [MaxLength(8)]
        public string Phone
        {
            get { return _phone; }
            set {
                CheckPhone(value);
                _phone = value; }
        }

        private void CheckPhone(string phone)
        {

            if (string.IsNullOrEmpty(phone))
            {
                throw new ArgumentNullException("Phone must not be empty");
            }
            
            if (phone.Length < 8)
            {
                throw new ArgumentOutOfRangeException("Phone must be 8 Chars long");
            }

            if (phone.Length > 8)
            {
                throw new ArgumentOutOfRangeException("Phone must be 8 Chars long");
            }
        }

        //validering med at der skal være noget før @ og noget efter @.
        [Required]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$", ErrorMessage = "Email must be with a @ like xxxx@xxx.com")]
        [EmailAddress]
        public string Email
        {
            get { return _email; }
            set {
                CheckEmail(value);
                _email = value; }
        }

        private void CheckEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("Email must not be empty");
            }

        }

        [Required]
        [MinLength(4, ErrorMessage = "Password must be at least 4 but not more than 8 characters long")]
        [MaxLength(8)]
        public string Password
        {
            get { return _password; }
            set {
                CheckPassword(value);
                _password = value; }
        }

        private void CheckPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("Password must not be empty");
            }

            if (password.Length < 4)
            {
                throw new ArgumentException("Password must be at least 4 character long");
            }
        }

        public UserStateType UserState
        {
            get { return _userState; }
            set { _userState = value; }
        }

        public User()
        {
        }

        public User(int userId, string firstName, string lastName, string phone, string email, string password, UserStateType userState)
        {
            _userId = userId;
            _firstName = firstName;
            _lastName = lastName;
            _phone = phone;
            _email = email;
            _password = password;
            _userState = userState;
        }

        public override string ToString()
        {
            return $"{nameof(UserId)}: {UserId}, {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}, {nameof(Phone)}: {Phone}, {nameof(Email)}: {Email}, {nameof(Password)}: {Password}, {nameof(UserState)}: {UserState}";
        }
    }
}
