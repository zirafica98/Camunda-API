using System.Runtime.Serialization;

namespace Camunda_api.Models
{

    [Serializable]
    [DataContract]
    public class ProcessDefinition
    {
        [DataMember(Name = "ID")]
        public string ID { get; set; }

        [DataMember(Name = "Key")]
        public string Key { get; set; }

        [DataMember(Name = "Category")]
        public string Category { get; set; }

        [DataMember(Name = "Description")]
        public object Description { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Version")]
        public int Version { get; set; }

        [DataMember(Name = "Resource")]
        public string Resource { get; set; }

        [DataMember(Name = "DeploymentId")]
        public string DeploymentID { get; set; }

        [DataMember(Name = "Diagram")]
        public object Diagram { get; set; }

        [DataMember(Name = "Suspended")]
        public bool Suspended { get; set; }

        [DataMember(Name = "TenantId")]
        public object TenantID { get; set; }

        [DataMember(Name = "VersionTag")]
        public string VersionTag { get; set; }

        [DataMember(Name = "HistoryTimeToLive")]
        public int HistoryTimeToLive { get; set; }

        [DataMember(Name = "StartableInTasklist")]
        public bool StartableInTasklist { get; set; }
    }

}
