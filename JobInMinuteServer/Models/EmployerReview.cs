namespace JobInMinuteServer.Models
{
    public class EmployerReview
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public virtual Employer Employer { get; set; } // מעסיק שנותן ביקורת
        public virtual Candidate Candidate { get; set; } // מועמד עליו ניתנת הביקורת
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
