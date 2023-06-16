using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Decisions.Box.Api.Data
{
    [DataContract]
    [Writable]
    public class BoxTask : BoxEntity
    {
        public const string FieldDueAt = "due_at";
        public const string FieldItem = "item";
        public const string FieldAction = "action";
        public const string FieldMessage = "message";
        public const string FieldIsCompleted = "is_completed";
        public const string FieldCreatedBy = "created_by";
        public const string FieldTaskAssignmentCollection = "task_assignment_collection";
        public const string FieldCompletionRule = "completion_rule";

        [JsonProperty(PropertyName = FieldDueAt)]
        public virtual string DueAt { get; private set; }

        [JsonProperty(PropertyName = FieldItem)]
        public virtual BoxItem Item { get; private set; }

        [JsonProperty(PropertyName = FieldAction)]
        public virtual string Action { get; private set; }

        [JsonProperty(PropertyName = FieldMessage)]
        public virtual string Message { get; private set; }

        [JsonProperty(PropertyName = FieldIsCompleted)]
        public virtual bool IsCompleted { get; private set; }

        [JsonProperty(PropertyName = FieldCreatedBy)]
        public virtual BoxUser CreatedBy { get; private set; }

        [JsonProperty(PropertyName = FieldTaskAssignmentCollection)]
        public virtual BoxCollection<BoxTaskAssignment> TaskAssignments { get; private set; }

        [JsonProperty(PropertyName = FieldCompletionRule)]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual BoxCompletionRule CompletionRule { get; private set; }
    }
}