namespace ToastmasterScheduler.Domain
{
    public class Role : EntityBase
    {
        public string Description { get; set; }
        public int OrderIndex { get; set; }
    }
}