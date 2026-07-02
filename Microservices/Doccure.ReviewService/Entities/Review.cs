using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Doccure.ReviewService.Entities
{
    public class Review
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ReviewId { get; set; }

        // Referanslar
        public string DoctorId { get; set; }
        public string UserId { get; set; }

        // Kullanıcı bilgisi (denormalize)
        public string UserName { get; set; }
        public string UserImageUrl { get; set; }

        // Yorum içeriği
        public string Comment { get; set; }
        public int Rating { get; set; }
        public bool Recommended { get; set; }
        public int LikeCount { get; set; }

        // Metadata
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
       
    }
}