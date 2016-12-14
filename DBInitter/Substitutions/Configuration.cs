using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DBInitter.Substitutions
{
    [DataContract]
    internal class Configuration
    {
        [DataMember(IsRequired = false, Name = "checkVersion")]
        public bool CheckVersion { get; protected set; } = true;

        [DataMember(Name = "commit")]
        public bool Commit { get; protected set; } = false;

        [DataMember(Name = "knownHosts", IsRequired = false)]
        public ISet<string> KnownHosts { get; protected set; } = new HashSet<string>();

        [DataMember(Name = "knownPaths")]
        public ISet<string> KnownPaths { get; protected set; } = new HashSet<string>();

        /// <summary>
        /// The replacements where the key is the string to be replaced and the value is its replacement
        /// </summary>
        [DataMember(Name = "substitutions")]
        public IDictionary<string, string> Replacements { get; set; }
    }
}