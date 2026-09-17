using System;

namespace Session_09_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 1 - Primary Constructor & Records

            Patient patient01 = new Patient(1, "Ahmed Ali", "01011111111", "Diabetes");
            Patient patient02 = new Patient(1, "Ahmed Ali", "01011111111", "Diabetes");

            Console.WriteLine(patient01.ToString());

            Console.WriteLine(patient01.GetHashCode());
            Console.WriteLine(patient02.GetHashCode());
            // the hash codes are different, because Patient is a class
            // (reference type), so GetHashCode() by default is based on
            // the object's identity (memory reference), not its data,
            // even though patient01 and patient02 hold the same values.

            Console.WriteLine(patient01.Equals(patient02));
            // False, for the same reason: Equals() by default (inherited
            // from object) compares references, not the actual field
            // values, unless it's overridden.

            patient01 = patient02;
            Console.WriteLine(patient01.Equals(patient02));
            // True now, because patient01 and patient02 point to the
            // exact same object in memory after the assignment.

            Console.WriteLine("----------------------------------");

            PatientDto dto01 = new PatientDto(1, "Ahmed Ali", "01011111111");
            PatientDto dto02 = new PatientDto(1, "Ahmed Ali", "01011111111");

            Console.WriteLine(dto01.GetHashCode());
            Console.WriteLine(dto02.GetHashCode());
            // the hash codes ARE equal here, because records generate
            // value-based GetHashCode()/Equals() automatically, based on
            // the values of their properties, not their memory address.

            Console.WriteLine(dto01.Equals(dto02));
            // True, records compare by value out of the box.

            // difference between Patient (class) and PatientDto (record):
            // a class uses reference equality by default, while a record
            // uses value equality by default (records were made for
            // immutable data-holder types like DTOs).

            Console.WriteLine("----------------------------------");

            PatientDto mappedDto = PatientMapper.MapFromModelToDto(patient01);
            Console.WriteLine(mappedDto);

            #endregion

            Console.WriteLine("----------------------------------");

            #region Part 2 - Singleton

            AppLogger logger01 = AppLogger.GetLogger();
            AppLogger logger02 = AppLogger.GetLogger();
            AppLogger logger03 = AppLogger.GetLogger();
            AppLogger logger04 = AppLogger.GetLogger();

            Console.WriteLine(logger01.GetHashCode());
            Console.WriteLine(logger02.GetHashCode());
            Console.WriteLine(logger03.GetHashCode());
            Console.WriteLine(logger04.GetHashCode());
            // all four hash codes are identical, because GetLogger() only
            // creates a new AppLogger the first time it's called; every
            // call after that returns that same instance (that's the
            // whole point of the Singleton pattern).

            #endregion

            Console.WriteLine("----------------------------------");

            #region Part 3 - var & dynamic

            Patient p1 = new(2, "Mona Samir", "01022222222", "Asthma");

            var p2 = new Patient(3, "Omar Khaled", "01033333333", "None");

            dynamic p3;
            p3 = new Patient(4, "Sara Hany", "01044444444", "Allergy");
            Console.WriteLine(p3);

            // var is resolved at COMPILE time: the compiler figures out
            // the actual type (Patient here) from the right-hand side and
            // locks it in, so type checking still works normally.
            // dynamic is resolved at RUNTIME: the compiler skips type
            // checking completely on a dynamic variable, so type errors
            // only show up while the program is running, not while
            // compiling.

            #endregion

            Console.WriteLine("----------------------------------");

            #region Part 4 - Anonymous Types

            var doctor01 = new
            {
                Name = "Sara",
                Specialty = "Cardiology",
                ExperienceYears = 8,
                Salary = 25_000
            };

            var doctor02 = new
            {
                Name = "Sara",
                Specialty = "Cardiology",
                ExperienceYears = 8,
                Salary = 25_000
            };

            Console.WriteLine(doctor01.Name);
            Console.WriteLine(doctor01.Specialty);

            Console.WriteLine(doctor01.GetHashCode());
            Console.WriteLine(doctor02.GetHashCode());

            Console.WriteLine(doctor01.GetType());

            Console.WriteLine(doctor01.Equals(doctor02));

            Console.WriteLine(doctor01.ToString());

            // anonymous types behave like records here: two anonymous
            // objects with the same property names/values/order are
            // equal and share the same hash code, because the compiler
            // generates value-based Equals()/GetHashCode() for them too.
            // that's different from a normal class, which compares by
            // reference unless Equals()/GetHashCode() are overridden.

            #endregion

            Console.WriteLine("----------------------------------");

            #region Part 5 - Extension Methods

            Console.WriteLine("Stethoscope".IsShorterThan(5));
            Console.WriteLine("Ab".Repeat(4));

            #endregion
        }
    }
}
