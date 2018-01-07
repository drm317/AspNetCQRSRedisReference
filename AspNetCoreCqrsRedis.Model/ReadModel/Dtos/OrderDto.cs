using System;

namespace AspNetCoreCqrsRedis.Model.ReadModel.Repository
{
    public class OrderDto
    {
        public Guid Id;
        public string Description;
        public int CurrentCount;
        public int Version;

        public OrderDto(Guid id, string description, int currentCount, int version)
        {
            Id = id;
            Description = description;
            CurrentCount = currentCount;
            Version = version;
        }
    }
}