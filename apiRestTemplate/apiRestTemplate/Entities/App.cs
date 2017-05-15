using testFrameworks.apiRest.Entities;

namespace apiRestTemplate.Entities
{
    public class App : IResource
    {
        public string Id { get; set; }
        public string name { get; set; }
    }
}
