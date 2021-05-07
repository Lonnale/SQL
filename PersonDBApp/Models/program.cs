using PersonDBApp.Data;
using PersonDBApp.Views;
using System;
using System.Linq;

namespace PersonDBApp
{
    class Program
    {
        //static private readonly PersonTestDBContext context = new PersonTestDBContext();
        // _personView.PrintAllPeople();

        static private readonly IPersonView _personView = new PersonView();
        static void Main(string[] args)
        {
            string choice = null;

            do
            {
                choice = UserInterface();

                switch (choice.ToUpper())
                {
                    case "C":
                        _personView.CreatePerson();
                        break;
                    case "R":
                        _personView.PrintAllPeople();
                        break;
                    case "u":
                        _personView.UpdatePerson();
                        break;
                    case "D":
                        _personView.DeletePerson();
                        break;
                    case "R1":
                        _personView.PrintSinglePerson();
                        break;
                    case "R2":
                        _personView.PrintByCity();
                        break;


                }
                Console.WriteLine("Paine enteriä jatkaaksesi...");
                Console.ReadLine();
            }
            while (choice.ToUpper() != "X");

        }

        static string UserInterface()
        {
            Console.WriteLine("Tietokannan käsittelymerkki");
            Console.WriteLine("[C] - lisää uusi henklilö");
            Console.WriteLine("[R] - Tulosta kaikki henkilöt");
            Console.WriteLine("[U] - Päivitä henkilön tietoja");
            Console.WriteLine("[D] - Poista henkilön tiedot");
            Console.WriteLine("[R1] - Tulosta yksi henkilö");
            Console.WriteLine("[R2] - Tulosta kaupungin kaikki henkilöt");
            Console.WriteLine("[X] - Lopeta ohjelman suoritus");
            

            return Console.ReadLine();
        }



       // static void PrintAllPeople()
      //  {
           // var people = context.People.ToList();

           // foreach(var p in people)
          //  {
           //     Console.WriteLine($"Etunimi: {p.FirstName}, Sukunimi: {p.LastName}");
         //   }

      //  }


    }
}
