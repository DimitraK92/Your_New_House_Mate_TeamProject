namespace YNHM.Entities.TestResources
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Answer { get; set; }

        //Navigation Properties

        public int? TestId { get; set; }
        public virtual Test Test { get; set; }
    }

}
