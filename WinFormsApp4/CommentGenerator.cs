using System;
using System.Xml.Linq;

namespace WinFormsApp4
{
    public class CommentGenerator
    {
        public static List<Comment> CreateComments(int count)
        {
            List<Comment> comments = new List<Comment>();
            Random rand = new Random();
            string[] firstNames = new string[10] { "John", "Mary", "Alexander", "Anna", "William", "Eva", "Michael", "Olivia", "James", "Sophia" };
            string[] lastNames = new string[10] { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor" };
            string[] messages = new string[10]
            {
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                "A stitch in time saves nine.",
                "Actions speak louder than words.",
                "Don't count your chickens before they're hatched.",
                "The early bird catches the worm.",
                "Where there's smoke, there's fire."
            };

            for (int i = 0; i < count; i++)
            {
                string randomFirstName = firstNames[rand.Next(firstNames.Length)];
                string randomLastName = lastNames[rand.Next(lastNames.Length)];
                string fullName = $"{randomFirstName} {randomLastName}";
                string message = messages[rand.Next(messages.Length)];

                comments.Add(new Comment(i, $"Comment_{i}", rand.Next(0, 100), fullName, message));
            }

            return comments;
        }
    }
}
