namespace PjA2Tp3.Models
{
    public class VagaTag
    {
        public int VagaId { get; set; } 
        public Vaga Vaga { get; set; }  

        public int TagId { get; set; }  
        public Tag Tag { get; set; }
    }
}
