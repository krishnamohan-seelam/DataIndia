namespace DataIndia.Models
{
    public class District
    {
        public int  Id { get; set; }
        public int DistrictCode { get; set; }
        public int  StateId { get; set; }
        public string Name { get; set; }
        
        public virtual State State { get; set; }
    }


}
