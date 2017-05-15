using testFrameworks.apiRest.Entities;

namespace apiRestTemplate.Entities
{
    class User: IResource
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public UserProfile UserProfile { get; set; }

    }
}
