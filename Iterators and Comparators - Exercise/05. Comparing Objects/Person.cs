using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Exercise
{
    public class Person : IComparable<Person>
    {
        public Person(params string[] input)
        {
            Name = input[0];
            Age = int.Parse(input[1]);
            Town = input[2];
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo([AllowNull] Person other)
        {
            int result = 1;
            if (other != null)
            {
                result = this.Name.CompareTo(other.Name);
            }
            if (result == 0)
            {
                return this.Age.CompareTo(other.Age);
                if (result == 0)
                {
                    return this.Town.CompareTo(other.Town);
                }
            }
            return result;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
