namespace JobInMinuteServer.Models
{
    public class CandidateJobReview
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public virtual Candidate Candidate { get; set; } // מועמד שנותן ביקורת
        public virtual Job Job { get; set; } // עבודה שעליה ניתנת הביקורת
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
