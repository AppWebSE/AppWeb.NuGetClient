using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace AppWeb.NuGetClient.Models
{    
    [Serializable()]
    [XmlRoot("package")]
    public class NuGetPackageManifestRoot
    {
        [XmlElement("metadata")]
        public NuGetPackageManifest Manifest { get; set; }
    }

    [Serializable()]
    public class NuGetPackageManifest
    {
        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("version")]
        public string Version { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("authors")]
        public string Authors { get; set; }

        [XmlElement("owners")]
        public string Owners { get; set; }

        [XmlElement("licenseUrl")]
        public string LicenseUrl { get; set; }

        [XmlElement("projectUrl")]
        public string ProjectUrl { get; set; }

        [XmlElement("iconUrl")]
        public string IconUrl { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("releaseNotes")]
        public string ReleaseNotes { get; set; }

        [XmlElement("tags")]
        public string Tags { get; set; }

        [XmlElement("repository")]
        public Repository Repository { get; set; }

        [XmlArray("dependencies")]
        [XmlArrayItem("group", typeof(DependencyGroup))]
        public DependencyGroup[] Dependencies {get;set;}

        // todo: dependencies?
        // todo: iconUrl?
    }

    [Serializable()]
    public class Repository
    {
        [XmlAttribute("url")]
        public string Url { get; set; }
    }
    
    [Serializable()]
    public class DependencyGroup
    {
        [XmlAttribute("targetFramework")]
        public string TargetFramework { get; set; }

        [XmlElement("dependency")]
        public Dependency Dependency { get; set; }
    }

    [Serializable()]
    public class Dependency
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlAttribute("exclude")]
        public string Exclude { get; set; }
    }
}
