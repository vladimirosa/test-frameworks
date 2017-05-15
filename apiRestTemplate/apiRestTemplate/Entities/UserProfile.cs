using testFrameworks.apiRest.Entities;

namespace apiRestTemplate.Entities
{
    public class UserProfile : IResource
    {
        public string Id { get; set; }
        public string Type { get; set; }
    }
}
