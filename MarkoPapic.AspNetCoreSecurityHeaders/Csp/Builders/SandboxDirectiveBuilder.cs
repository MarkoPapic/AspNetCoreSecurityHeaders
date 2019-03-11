using System.Collections.Generic;

namespace MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders
{
	/// <summary>
	/// Builder class for Content-Security-Policy header sandbox directive.
	/// </summary>
	public class SandboxDirectiveBuilder
	{
		private bool noneAllowed;
        private bool allAllowed;
        private bool formsAllowed;
        private bool modalsAllowed;
        private bool orientationLockAllowed;
        private bool pointerLockAllowed;
        private bool popupsAllowed;
        private bool popupsAllowedToEscapeSandbox;
        private bool presentationAllowed;
        private bool sameOriginAllowed;
        private bool scriptsAllowed;
        private bool topNavigationAllowed;

		/// <summary>
		/// Sets the directive value to 'none'.
		/// </summary>
		public SandboxDirectiveBuilder AllowNone()
		{
			noneAllowed = true;
			return this;
		}

		/// <summary>
		/// Adds * to the directive value.
		/// </summary>
		public SandboxDirectiveBuilder AllowAny()
		{
			allAllowed = true;
			return this;
		}

		/// <summary>
		/// Adds 'allow-forms' to the directive value.
		/// </summary>
		public SandboxDirectiveBuilder AllowForms()
		{
			formsAllowed = true;
			return this;
		}

		/// <summary>
		/// Adds 'allow-modals' to the directive value.
		/// </summary>
		public SandboxDirectiveBuilder AllowModals()
        {
            modalsAllowed = true;
            return this;
        }

		/// <summary>
		/// Adds 'allow-orientation-lock' to the directive value.
		/// </summary>
		public SandboxDirectiveBuilder AllowOrientationLock()
        {
            orientationLockAllowed = true;
            return this;
        }

		/// <summary>
		/// Adds 'allow-pointer-lock' to the directive value.
		/// </summary>
		public SandboxDirectiveBuilder AllowPointerLock()
        {
            pointerLockAllowed = true;
            return this;
        }

		/// <summary>
		/// Adds 'allow-popups' to the directive value.
		/// </summary>
		public SandboxDirectiveBuilder AllowPopups()
        {
            popupsAllowed = true;
            return this;
        }

		/// <summary>
		/// Adds 'allow-popups-to-escape-sandbox' to the directive value.
		/// </summary>
		public SandboxDirectiveBuilder AllowPopupsToEscapeSandbox()
        {
            popupsAllowedToEscapeSandbox = true;
            return this;
        }

		/// <summary>
		/// Adds 'allow-presentation' to the directive value.
		/// </summary>
		public SandboxDirectiveBuilder AllowPresentation()
        {
            presentationAllowed = true;
            return this;
        }

		/// <summary>
		/// Adds 'allow-same-origin' to the directive value.
		/// </summary>
		public SandboxDirectiveBuilder AllowSameOrigin()
        {
            sameOriginAllowed = true;
            return this;
        }

		/// <summary>
		/// Adds 'allow-scripts' to the directive value.
		/// </summary>
		public SandboxDirectiveBuilder AllowScripts()
        {
            scriptsAllowed = true;
            return this;
        }

		/// <summary>
		/// Adds 'allow-top-navigation' to the directive value.
		/// </summary>
		public SandboxDirectiveBuilder AllowTopNavigation()
        {
            topNavigationAllowed = true;
            return this;
        }

        internal string Build()
        {
            List<string> parts = new List<string>();

            if (noneAllowed)
                parts.Add("'none'");
            else if (allAllowed)
                parts.Add("'*'");
            else
            {
                if (formsAllowed)
                    parts.Add("allow-forms");
                if (modalsAllowed)
                    parts.Add("allow-modals");
                if (orientationLockAllowed)
                    parts.Add("allow-orientation-lock");
                if (pointerLockAllowed)
                    parts.Add("allow-pointer-lock");
                if (popupsAllowed)
                    parts.Add("allow-popups");
                if (popupsAllowedToEscapeSandbox)
                    parts.Add("allow-popups-to-escape-sandbox");
                if (presentationAllowed)
                    parts.Add("allow-presentation");
                if (sameOriginAllowed)
                    parts.Add("allow-same-origin");
                if (scriptsAllowed)
                    parts.Add("allow-scripts");
                if (topNavigationAllowed)
                    parts.Add("allow-top-navigation");
            }

            return string.Join(" ", parts);
        }
    }
}
