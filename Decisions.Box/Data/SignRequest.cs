using System.Runtime.Serialization;
using DecisionsFramework.Design.ConfigurationStorage.Attributes;

namespace Decisions.Box.Data;

[DataContract]
[Writable]
public class SignRequest
{
    [DataMember]
    [WritableValue]
    public string Id { get; set; } = string.Empty;
    
    [DataMember]
    [WritableValue]
    public string SignerEmail { get; set; } = string.Empty;
    
    [DataMember]
    [WritableValue]
    public string Status { get; set; } = string.Empty;
}