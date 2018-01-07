using System;
using CQRSlite.Commands;

namespace AspNetCoreCqrsRedis.Model.WriteModel.Commands
{
    public class CreateOrder : ICommand
    {
        public string Description;
	    
        public CreateOrder(Guid id, string description)
        {
            Id = id;
            Description = description;
        }

        public Guid Id { get; set; }
        
        public int ExpectedVersion { get; set; }
    }
}