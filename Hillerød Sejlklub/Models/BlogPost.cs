namespace Hillerød_Sejlklub.Models
{
    public class BlogPost
    {
        #region Properties
        private static int _nextId = 1;
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;

        #endregion

        #region Constructor
        public BlogPost()
        {
            Id = _nextId++;
        }
        public BlogPost(string title, string content, DateTime publishedDate, string author, string imagePath)
        {
            Id = _nextId++;
            Title = title;
            Content = content;
            PublishedDate = publishedDate;
            Author = author;
            ImagePath = imagePath;
        }
        #endregion
    
    #region Methods
    public override string ToString()
    {
        return
            $"BlogPost ID: {Id}\n" +
            $"Title: {Title}\n" +
            $"Content: {Content}\n" +
            $"Published Date: {PublishedDate}\n" +
            $"Author: {Author}\n";
    }
        #endregion
    }
}
