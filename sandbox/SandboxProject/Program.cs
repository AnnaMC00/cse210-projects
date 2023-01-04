using System;

namespace SandboxProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            person1.SetFirstName("Ana");
            person1.SetLastName("Casariego");
            Console.WriteLine(person1.GetFullName());

            Person person2 = new Person();
            person2.SetFirstName("Hoshi");
            person2.SetLastName("Kwon");
            Console.WriteLine(person2.GetFullName());

            ChurchMember churchMember = new ChurchMember();
            churchMember.SetFirstName("Candy");
            churchMember.SetLastName("Chalco");
            churchMember.SetCalling("MMJJ");
            Console.WriteLine(churchMember.GetFullName());
            Console.WriteLine(churchMember.GetCalling());

            ChurchMember churchMember1 = new ChurchMember();
            churchMember1.SetFirstName("Piero");
            churchMember1.SetLastName("Casariego");
            churchMember1.SetCalling("HHJJ");
            Console.WriteLine(churchMember1.GetFullName());
            Console.WriteLine(churchMember1.GetCalling());


        }
    }
}
