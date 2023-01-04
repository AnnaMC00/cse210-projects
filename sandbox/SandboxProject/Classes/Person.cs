using System;

namespace SandboxProject
{
    public class Person
    {
        private string _firstName = "";
        private string _lastName = "";

        public string GetFirstName()
        {
            return _firstName;
        }

        public string GetLastName()
        {
            return _lastName;
        }

        public void SetFirstName(string firstName)
        {
            _firstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            _lastName = lastName;
        }

        public string GetFullName()
        {
            return $"{_firstName} {_lastName}";
        }
    }
}