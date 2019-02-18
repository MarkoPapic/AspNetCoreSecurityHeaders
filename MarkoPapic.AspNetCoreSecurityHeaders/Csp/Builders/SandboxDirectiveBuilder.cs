using System.Collections.Generic;

namespace MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders
{
	public class SandboxDirectiveBuilder
	{
		protected bool noneAllowed;
		protected bool allAllowed;
		protected bool formsAllowed;

		public SandboxDirectiveBuilder AllowNone()
		{
			noneAllowed = true;
			return this;
		}

		public SandboxDirectiveBuilder AllowAny()
		{
			allAllowed = true;
			return this;
		}

		public SandboxDirectiveBuilder AllowForms()
		{
			formsAllowed = true;
			return this;
		}
	}
}
