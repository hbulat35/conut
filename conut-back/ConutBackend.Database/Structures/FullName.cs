using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConutBackend.Database.Structures
{
    public class FullName
    {
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }

        public FullName(string surName, string firstName, string? lastName = null)
        {
            SurName = surName;
            FirstName = firstName;
            LastName = lastName;
        }
        
        public string GetFullNameString()
        {
            return $"{SurName} {FirstName} {LastName}";
        }

        public static readonly Expression<Func<FullName, string>> GetFullNameStringExpression =
            (fullName) => fullName.SurName + " " + fullName.FirstName + " " + fullName.LastName;
    }
}
