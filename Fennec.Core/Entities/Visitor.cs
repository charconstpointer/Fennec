namespace Fennec.Core.Entities
{
    public class Visitor
    {
        public Visitor(string ipAddress)
        {
            IpAddress = ipAddress;
        }

        public string IpAddress { get; }
    }
}