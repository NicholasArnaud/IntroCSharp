using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMAssessment
{
    delegate void CallBack();

    class Student
    {
        public Student()
        {
            onTalk = null;
        }

        CallBack onTalk;
        public void AddThingToSay(CallBack c)
        {
            onTalk += c;
        }
        public void Talk()
        {
            if (onTalk != null)
            onTalk.Invoke();
        }
    }
}
