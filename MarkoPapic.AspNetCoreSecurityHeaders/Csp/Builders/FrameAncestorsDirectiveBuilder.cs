using System.Collections.Generic;

namespace MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders
{
	/// <summary>
	/// Builder class for Content-Security-Policy header frame-ancestor directive.
	/// </summary>
	public class FrameAncestorsDirectiveBuilder
    {
        protected bool noneAllowed;
        protected bool allAllowed;
        protected readonly ICollection<string> sourcesAllowed;

        public FrameAncestorsDirectiveBuilder()
        {
            sourcesAllowed = new List<string>();
        }

		/// <summary>
		/// Sets the directive value to 'none'.
		/// </summary>
		public FrameAncestorsDirectiveBuilder AllowNone()
        {
            noneAllowed = true;
            return this;
        }

		/// <summary>
		/// Adds 'self' to the directive value.
		/// </summary>
		public FrameAncestorsDirectiveBuilder AllowSelf()
        {
            string item = "'self'";
            if (!sourcesAllowed.Contains(item))
                sourcesAllowed.Add(item);
            return this;
        }

		/// <summary>
		/// Adds * to the directive value.
		/// </summary>
		public FrameAncestorsDirectiveBuilder AllowAny()
        {
            allAllowed = true;
            return this;
        }

		/// <summary>
		/// Adds the host/s to the directive value.
		/// </summary>
		/// <param name="hosts">Host/s to be allowed.</param>
		public FrameAncestorsDirectiveBuilder AllowHosts(params string[] hosts)
        {
            foreach (string host in hosts)
                if (!sourcesAllowed.Contains(host))
                    sourcesAllowed.Add(host);
            return this;
        }

		/// <summary>
		/// Adds the schema's to the directive value.
		/// </summary>
		/// <param name="schemas">Schema's to be allowed.</param>
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
                    parts.Add("*");
            else if (sourcesAllowed.Count > 0)
                parts.AddRange(sourcesAllowed);

            return string.Join(" ", parts);
        }
    }
}
