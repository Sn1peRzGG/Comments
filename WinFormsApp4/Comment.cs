using System;

namespace WinFormsApp4
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public string FullName { get; set; }
        public string Message { get; set; }

        public Comment(int id, string text, int rating, string fullName, string message)
        {
            Id = id;
            Text = text;
            Rating = rating;
            FullName = fullName;
            Message = message;

            // Генерація випадкової кількості лайків і дизлайків від 0 до 1000
            Random rand = new Random();
            Likes = rand.Next(0, 1001);
            Dislikes = rand.Next(0, 1001);
            Id = rand.Next(0, 1000000);
            Message = message;
        }
    }
}
