/* 
Uppgift 3 - programmering i C# .NET
Ramona Reinholdz
*/

using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace guestbook
{
    /*
    En klass för att hantera gästboken.
    Inläggen lagras i en JSON-fil och kan läggas till, tas bort och hämtas.
    */
    public class Guestbook
    {
        private string filePath = @"guestbook.json";    //filnamnet för gästbokens sparad inlägg i JSON-format

        private List<Post> posts = new List<Post>();    //lista med inlägg

        public Guestbook()
        {
            if (File.Exists(filePath) == true)  //om JSON-filen finns läses existerande inlägg in
            {
                string jsonString = File.ReadAllText(filePath);
                posts = JsonSerializer.Deserialize<List<Post>>(jsonString)!;    //deserialiserar JSON-strängen
            }
        }

        //lägger till inlägg i gästboken med ägare och inläggs-text
        public Post AddPost(string? owner, string? postText)
        {
            //skapar nytt inlägg (hämtar från Post.cs), sätter ägare och inläggs-text
            Post newPost = new Post();
            newPost.Owner = owner;
            newPost.PostText = postText;

            if (string.IsNullOrEmpty(owner) || string.IsNullOrEmpty(postText))  //kontrollerar att ägare och inlägg inte är tomma
            {
                throw new ArgumentOutOfRangeException("Ägare och inlägg måste fyllas.");
            }
            else
            {
                posts.Add(newPost); //lägger till inlägget i listan
                marshal();  //sparar inlägg till JSON-filen
                return newPost;
            }
        }

        //raderar inlägg
        public int RemovePost(int index)
        {
            if (index < 0 || index >= posts.Count)  //kontrollerar att index är giltigt
            {
                throw new ArgumentException("Ogiltigt index.");
            }

            posts.RemoveAt(index);  //tar bort valt inlägget från listan
            marshal();  //sparar ändring till JSON-filen
            return index;
        }

        //hämtar alla inlägg i gästboken
        public List<Post> GetPosts()
        {
            if (posts.Count == 0)   //kontrollerar om listan är tom
            {
                Console.WriteLine("Gästboken är tom.");
            }
            return posts;   //returnerar listan med inlägg
        }

        //sparar inlägg i JSON-filen
        private void marshal()
        {
            var jsonString = JsonSerializer.Serialize(posts);   //serialiserar listan till en JSON-sträng
            File.WriteAllText(filePath, jsonString);    //skriver JSON-strängen till filen
        }

    }
}