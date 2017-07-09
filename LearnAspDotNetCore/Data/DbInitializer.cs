using System;
using DatabaseObjects;
using LearnAspDotNetCore.Models;

namespace LearnAspDotNetCore.Data
{
    public static class DbInitializer
    {

        public static void Initialize(LearnAspDotNetCoreContext context)
        {
            context.Database.EnsureCreated();

            if (context.Test.Find(new object[] { (object)1 }) == null)
            {
                Test test = new Test();
                test.Title = "First";

                context.Test.Add(test);


                context.SaveChanges();
            }

            if (context.Person.Find(new object[] { (object)1 }) == null)
            {
                Person person = new Person();
                person.dob = new DateTime(1979, 5, 8);
                person.fName = "Oneal";
                person.lName = "Anguin";
                person.title = "Mr.";

                context.Person.Add(person);
                context.SaveChanges();
            }


        }

    }
}
