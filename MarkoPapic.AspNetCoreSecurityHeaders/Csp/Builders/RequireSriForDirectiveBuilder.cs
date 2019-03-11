using System;
namespace MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders
{
	/// <summary>
	/// Builder class for Content-Security-Policy header require-sri-for directive.
	/// </summary>
	public class RequireSriForDirectiveBuilder
    {
        private string value;

		/// <summary>
		/// Sets the directive value to 'script'.
		/// </summary>
        public void Script()
        {
            value = "script";
        }

		/// <summary>
		/// Sets the directive value to 'style'.
		/// </summary>
        public void Style()
        {
            value = "style";
        }

		/// <summary>
		/// Sets the directive value to 'script style.'
		/// </summary>
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
