using System.Text;

namespace Academy.Models
{
    public class DemoResource : Resource
    {
        public DemoResource(string name, string url)
            : base(name, url)
        {
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"     - Type: Demo");
            return base.ToString() + builder.ToString().TrimEnd();
        }
    }
}
