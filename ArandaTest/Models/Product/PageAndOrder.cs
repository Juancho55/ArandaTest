namespace Models.Product
{
    public class PageAndOrder
    {
        public int PageCurrent {  get; set; }
        public int PageSize {  get; set; }
        public bool? OrderByName { get; set; }
        public bool? OrderByCategory { get; set; }
    }
}
