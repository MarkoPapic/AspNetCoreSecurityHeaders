using System.Collections.Generic;

namespace MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders
{
    public class FrameAncestorsDirectiveBuilder
    {
        protected bool noneAllowed;
        protected bool allAllowed;
        protected readonly ICollection<string> sourcesAllowed;

        public FrameAncestorsDirectiveBuilder()
        {
            sourcesAllowed = new List<string>();
        }

        public FrameAncestorsDirectiveBuilder AllowNone()
        {
            noneAllowed = true;
            return this;
        }

        public FrameAncestorsDirectiveBuilder AllowSelf()
        {
            string item = "'self'";
            if (!sourcesAllowed.Contains(item))
                sourcesAllowed.Add(item);
            return this;
        }

        public FrameAncestorsDirectiveBuilder AllowAny()
        {
            allAllowed = true;
            return this;
        }

        public FrameAncestorsDirectiveBuilder AllowHosts(params string[] hosts)
        {
            foreach (string host in hosts)
                if (!sourcesAllowed.Contains(host))
                    sourcesAllowed.Add(host);
            return this;
        }

        public FrameAncestorsDirectiveBuilder AllowSchemas(params string[] schemas)
        {
            foreach (string schema in schemas)
                if (!sourcesAllowed.Contains(schema))
                    sourcesAllowed.Add(schema);
            return this;
        }

        internal string Build()
        {
            List<string> parts = new List<string>();

            if (noneAllowed)
                parts.Add("'none'");
            else if(allAllowed)
                    parts.Add("'*'");
            else if (sourcesAllowed.Count > 0)
                parts.AddRange(sourcesAllowed);

            return string.Join(" ", parts);
        }
    }
}
