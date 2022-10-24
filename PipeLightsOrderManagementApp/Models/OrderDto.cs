namespace PipeLightsOrderManagementApp.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Lamp { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Channel { get; set; }
        public string Characteristics { get; set; }
    }
}
