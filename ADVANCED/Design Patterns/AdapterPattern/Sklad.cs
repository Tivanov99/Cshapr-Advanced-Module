using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterPattern
{
    public class Sklad
    {
        private List<string> components = new List<string>() { "procesor", "videoCard", "memory" };
        public bool ContainsAnyComponent(string component)
        {
            return component.Contains(component);
        }
    }
}
