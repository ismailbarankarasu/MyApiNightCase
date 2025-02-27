namespace MyApiNightCase.WebApi.Dtos
{
    public class BookAddUpdateDto
    {
        public int BookId { get; set; }  
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
