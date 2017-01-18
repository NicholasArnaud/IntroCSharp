using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization_Practice
{
    class Student
    {
        private string mName;
        private int mAge;
        private string mID;
        Student() { }
        public Student(string name,int age,string id)
        {
            mName = name;
            mAge = age;
            id = mID;
        }
        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }
        public int Age
        {
            get
            {
                return mAge;
            }
            set { mAge = value; }
        }
        public string ID
        {
            get { return mID; }
            set { mID = value; }
        }



    }
}
