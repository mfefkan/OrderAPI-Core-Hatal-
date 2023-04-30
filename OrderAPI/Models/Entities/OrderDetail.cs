namespace OrderAPI.Models.Entities
{
    public class OrderDetail:BaseEntity
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }

        //RelationalProperties

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }

    }
}
