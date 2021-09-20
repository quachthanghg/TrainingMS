using Exam.Domain.SeedWork;
using MongoDB.Bson.Serialization.Attributes;

namespace Exam.Domain.AggregatesModel.CategoryAggregate
{
    [BsonIgnoreExtraElements]
    public class Category : Entity, IAggregateRoot
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("urlPath")]
        public string UrlPath { set; get; } //domain/exam-category-1/
        public Category(string id, string name, string urlPath) => (Id, Name, UrlPath) = (id, name, urlPath);
    }
}
