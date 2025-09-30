/* 
Uppgift 3 - programmering i C# .NET
Ramona Reinholdz
*/

using System;

namespace guestbook
{
    class Program
    {
        static void Main(string[] args)
        {
            Guestbook guestbook = new Guestbook();  //instans av klassen Guestbook
            int i = 0;  //variabel för index av inlägg

            while (true)    //loop för meny
            {
                Console.Clear();    //rensar konsoll när menyn visas
                Console.WriteLine("G Ä S T B O K\n\n");
                Console.WriteLine("1. Skriv i gästboken");  //menyval för att lägga till inlägg
                Console.WriteLine("2. Ta bort inlägg\n");   //menyval för att ta bort inlägg
                Console.WriteLine("X. Avsluta\n");  //menyval för att avsluta programmet

                i = 0;
                foreach (Post post in guestbook.GetPosts()) //loopar igenom alla inlägg
                {
                    Console.WriteLine($"[{i++}] {post.Owner} - {post.PostText}");   //utskrift av inlägg med index
                }

                int input = (int)Console.ReadKey(true).Key; //läser tangenttryck
                switch (input)  //switch-sats för menyval
                {
                    case '1':   //1 = lägga till inlägg
                        Console.CursorVisible = true;
                        Console.Write("Ange ditt namn: ");
                        string? owner = Console.ReadLine();
                        Console.Write("Ange ditt meddelande: ");
                        string? postText = Console.ReadLine();

                        try
                        {
                            guestbook.AddPost(owner, postText); //lägger till inlägg
                            Console.WriteLine("Inlägg tillagt! Tryck på valfri tangent för att fortsätta...");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Fel: Namn och meddelande måste fyllas i. Tryck på valfri tangent för att fortsätta...");
                            Console.ReadKey();
                        }

                        Console.ReadKey();
                        break;

                    case '2':   //2 = ta bort inlägg
                        Console.CursorVisible = true;
                        Console.Write("Ange index att radera: ");
                        string? indexInput = Console.ReadLine();    //läser in index på inlägg att radera

                        if (String.IsNullOrEmpty(indexInput))   //kontroll om index är tomt
                        {
                            Console.WriteLine("Fel: Index måste fyllas i.\n Tryck på valfri tangent för att fortsätta...");
                        }
                        else
                        {
                            try
                            {
                                guestbook.RemovePost(Convert.ToInt32(indexInput));  //försöker radera inlägg med angivet index
                                Console.WriteLine("Inlägget är raderat! Tryck på valfri tangent för att fortsätta...");
                            }
                            catch (Exception)
                            {
                                //om index är ogiltigt
                                Console.WriteLine("Fel: Välj ett befintligt inläggs index för att radera det.\n Tryck på valfri tangent för att fortsätta...");
                                Console.ReadKey();
                            }
                        }
                        Console.ReadKey();
                        break;

                    case 'X':   //X = avsluta program
                        return;

                    default:    //ogiltigt tangentval
                        Console.WriteLine("Ogiltigt val. Tryck på valfri tangent för att fortsätta...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}