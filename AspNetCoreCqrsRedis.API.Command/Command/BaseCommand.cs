using System;
using CQRSlite.Commands;

namespace AspNetCoreCqrsRedis.API.Command.Command
{
    public class BaseCommand : ICommand
    {
        public Guid Id { get; set; }
        public int ExpectedVersion { get; set; }
    }
}