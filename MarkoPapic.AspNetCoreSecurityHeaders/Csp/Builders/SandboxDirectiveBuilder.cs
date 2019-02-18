using System.Collections.Generic;

namespace MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders
{
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

        public SandboxDirectiveBuilder AllowModals()
        {
            modalsAllowed = true;
            return this;
        }

        public SandboxDirectiveBuilder AllowOrientationLock()
        {
            orientationLockAllowed = true;
            return this;
        }

        public SandboxDirectiveBuilder AllowPointerLock()
        {
            pointerLockAllowed = true;
            return this;
        }

        public SandboxDirectiveBuilder AllowPopups()
        {
            popupsAllowed = true;
            return this;
        }

        public SandboxDirectiveBuilder AllowPopupsToEscapeSandbox()
        {
            popupsAllowedToEscapeSandbox = true;
            return this;
        }

        public SandboxDirectiveBuilder AllowPresentation()
        {
            presentationAllowed = true;
            return this;
        }

        public SandboxDirectiveBuilder AllowSameOrigin()
        {
            sameOriginAllowed = true;
            return this;
        }

        public SandboxDirectiveBuilder AllowScripts()
        {
            scriptsAllowed = true;
            return this;
        }

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
                    parts.Add("allow-top-navigtion");
            }

            return string.Join(" ", parts);
        }
    }
}
