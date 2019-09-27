using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using VCAuthn.Models;

namespace VCAuthn.PresentationConfiguration
{
    public class PresentationRecord
    {
        [JsonProperty("id")] 
        public string Id { get; set; }
        
        [JsonProperty("subject_identifier")] 
        public string SubjectIdentifier { get; set; }

        // exists to convince EntityFramework to store config as a string
        private string _configuration;
        
        [JsonProperty("configuration")]
        [NotMapped]
        public PresentationRequestConfiguration Configuration
        {
            get => _configuration == null ? null : JsonConvert.DeserializeObject<PresentationRequestConfiguration>(_configuration);
            set => _configuration = JsonConvert.SerializeObject(value);
        }
    }
}