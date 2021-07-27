using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace chess_engine.tests
{
    [TestClass]
    

    public class POCTest
    {
        [TestMethod]
        public void TestMethod()
        {
            
            MyDerivedClass1 obj1 = new MyDerivedClass1();
            var obj2 = new MyDerivedClass2();
            var obj3 = new MyBaseClass();

            var list = new List<MyBaseClass>() { obj1,obj2,obj3};

            var name1 = list[0].WhatIsMyName();
            var name2 = list[1].WhatIsMyName();
            var name3 = list[2].WhatIsMyName();

            var ttt = ((MyDerivedClass1)list[0]).MethodOnlyForClass1();
        }
    }
    public class MyBaseClass
    {
        public string WhatIsMyName()
        {
            return MySpecialName();
        }
        public virtual string MySpecialName()
        {
            return "My base name";
        }
    }
    
    public class MyDerivedClass1 : MyBaseClass
    {
        public override string MySpecialName()
        {
            return "Special Name For Class 1";
        }

        public string MethodOnlyForClass1()
        {
            return "ok";
        }
    }

    public class MyDerivedClass2 : MyBaseClass
    {
        public override string MySpecialName()
        {
            return "Special Name For Class 2";
        }
    }
}
