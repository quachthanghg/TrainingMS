using Exam.Domain.SeedWork;
using MongoDB.Bson.Serialization.Attributes;

namespace Exam.Domain.AggregatesModel.CategoryAggregate
{
    public class Category : Entity
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("urlPath")]
        public string UrlPath { set; get; } //domain/exam-category-1/
    }
}
