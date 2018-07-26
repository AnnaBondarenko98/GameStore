namespace GameStore.Models
{
    public class CommentVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Body { get; set; }

        public  CommentVm ParentComment { get; set; }

        public  GameVm Game { get; set; }
    }
}