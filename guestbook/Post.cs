/* 
Uppgift 3 - programmering i C# .NET
Ramona Reinholdz
*/

namespace guestbook
{
    public class Post
    {
        /*
        strukturen på inlägg i gästboken där värderna kan hämtas/skrivas ut (get) och sättas/skapas (set)
        */
        public string? Owner { get; set; }      //ägaren
        public string? PostText { get; set; }       //inlägget

    }

}