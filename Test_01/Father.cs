
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Test_01
{
    public class Father
    {
        private string _name;
        public Father(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
            // set { _name = value; }
        }

        public string getName()
        {
            return _name;
        }

        public void setName(string name)
        {
            _name = name;
        }

        public string Name2;
        public string Name3
        {
            get
            {
                if (_name.StartsWith("1"))
                {
                    return _name;
                }
                else
                {
                    return _name + "1111111";
                }
            }
            set { }
        }
    }
}
