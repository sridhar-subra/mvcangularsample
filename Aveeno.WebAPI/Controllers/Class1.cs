using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aveeno.WebAPI.Controllers
{
    public class Class1 :class2
    {

        public override  void DoWork()
        {
            
            throw new NotImplementedException();
        }
        public new void DoWork1()
        {
        }
    }
    public abstract class class2
    {
      
        public abstract void DoWork();
        public void DoWork1()
        {
            Console.Write("dowork1");
        }

        public  void DoWork2()
        {
            Console.Write("dowork2");
        }
    }
}