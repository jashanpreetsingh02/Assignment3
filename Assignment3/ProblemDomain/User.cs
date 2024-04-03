using System;
using System.Collections.Generic;

namespace Assignment3
{
    [Serializable]
    public class User
    {
        
        public int Id { get; set; } 
        public string Name { get; set; } 
        public string Email { get; set; } 
        public string Password; 

        
        public User(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        
        public int getId()
        {
            return Id;
        }

        
        public string getName()
        {
            return Name;
        }

        
        public string getEmail()
        {
            return Email;
        }

        
        public bool isCorrectPassword(string password)
        {
            if (Password == null && password == null)
                return true;
            else if (Password == null || password == null)
                return false;
            else
                return Password.Equals(password);
        }

        
        public bool equals(Object obj)
        {
            if (!(obj is User))
                return false;

            User other = (User)obj;

           
            return Id == other.Id && Name.Equals(other.Name) && Email.Equals(other.Email);
        }
    }
}