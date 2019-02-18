using System;
namespace MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders
{
    public class RequireSriForDirectiveBuilder
    {
        private string value;

        public void Script()
        {
            value = "script";
        }

        public void Style()
        {
            value = "style";
        }

        public void ScriptStyle()
        {
            value = "script style";
        }

        internal string Build()
        {
            return value;
        }
    }
}
