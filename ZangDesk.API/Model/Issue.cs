using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ZangDesk.API.Model
{
    public class Issue
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public IssueType IssueType { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Completed { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Priority
    {
        Low, Medium, High
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum IssueType
    {
        Feature, Bug
    }
}
