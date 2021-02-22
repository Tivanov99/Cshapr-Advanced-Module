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
            IsTheSame = false;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }
        public bool IsTheSame { get; set; }

        public int CompareTo(Person other)
        {
            int result = 1;
            if (other != null)
            {
                result = this.Name.CompareTo(other.Name);
            }
            if (result == 0)
            {
                if (this.Age.CompareTo(other.Age) == 0)
                {
                    IsTheSame = true;
                }
                else
                {
                    return this.Age.CompareTo(other.Age);
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
