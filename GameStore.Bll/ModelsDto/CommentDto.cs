namespace GameStore.Bll.ModelsDto
{
    public class CommentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Body { get; set; }

        public bool IsDeleted { get; set; }

        public int? ParentCommentId { get; set; }

        public CommentDto ParentComment { get; set; }

        public GameDto Game { get; set; }

    }
}
