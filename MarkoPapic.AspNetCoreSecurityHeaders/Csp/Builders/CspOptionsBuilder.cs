using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Options;
using System.Collections.Generic;

namespace MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders
{
    public class CspOptionsBuilder
	{
        private bool blockAllMixedContent;
        private bool upgrateInsecureRequests;

		public FetchDirectiveBuilder ConnectSources => new FetchDirectiveBuilder();
		public FetchDirectiveBuilder DefaultSources => new FetchDirectiveBuilder();
		public FetchDirectiveBuilder FontSources => new FetchDirectiveBuilder();
		public FetchDirectiveBuilder FrameSources => new FetchDirectiveBuilder();
		public FetchDirectiveBuilder ImgSources => new FetchDirectiveBuilder();
		public FetchDirectiveBuilder ManifestSources => new FetchDirectiveBuilder();
		public FetchDirectiveBuilder MediaSources => new FetchDirectiveBuilder();
		public FetchDirectiveBuilder ObjectSources => new FetchDirectiveBuilder();
		public FetchDirectiveBuilder PrefetchSources => new FetchDirectiveBuilder();
		public FetchDirectiveBuilder ScriptSources => new FetchDirectiveBuilder();
		public FetchDirectiveBuilder StyleSources => new FetchDirectiveBuilder();
		public FetchDirectiveBuilder WebRtcSources => new FetchDirectiveBuilder();
		public FetchDirectiveBuilder WorkerSources => new FetchDirectiveBuilder();
		public BaseUriDirectiveBuilder BaseUri => new BaseUriDirectiveBuilder();
		public PluginTypesBuilder PluginTypes => new PluginTypesBuilder();
        public SandboxDirectiveBuilder Sandbox => new SandboxDirectiveBuilder();
        //TODO: disown-opener
        public FormActionDirectiveBuilder FormAction => new FormActionDirectiveBuilder();
        public FrameAncestorsDirectiveBuilder FrameAncestors => new FrameAncestorsDirectiveBuilder();
        //TODO: navigate-to
        //TODO: report-to
        public void BlockAllMixedContent() => blockAllMixedContent = true;
        public RequireSriForDirectiveBuilder RequireSriFor => new RequireSriForDirectiveBuilder();
        public void UpgradeInsecureRequests() => upgrateInsecureRequests = true;


        internal CspOptions Build()
		{
            List<string> directives = new List<string>();

			string connectSourcesString = ConnectSources.Build();
			if (!string.IsNullOrEmpty(connectSourcesString))
				directives.Add($"connect-src {connectSourcesString}");

			string defaultResourcesString = DefaultSources.Build();
			if (!string.IsNullOrEmpty(defaultResourcesString))
				directives.Add($"default-src {defaultResourcesString}");

			string fontSourcesString = FontSources.Build();
			if (!string.IsNullOrEmpty(fontSourcesString))
				directives.Add($"font-src {fontSourcesString}");

			string frameSourcesString = FrameSources.Build();
			if (!string.IsNullOrEmpty(frameSourcesString))
				directives.Add($"frame-src {frameSourcesString}");

			string imgSourcesString = ImgSources.Build();
			if (!string.IsNullOrEmpty(imgSourcesString))
				directives.Add($"img-src {imgSourcesString}");

			string manifestSourcesString = ManifestSources.Build();
			if (!string.IsNullOrEmpty(manifestSourcesString))
				directives.Add($"manifest-src {manifestSourcesString}");

			string mediaSourcesString = MediaSources.Build();
			if (!string.IsNullOrEmpty(mediaSourcesString))
				directives.Add($"media-src {mediaSourcesString}");

			string objectSourcesString = ObjectSources.Build();
			if (!string.IsNullOrEmpty(objectSourcesString))
				directives.Add($"object-src {objectSourcesString}");

			string prefetchSourcesString = PrefetchSources.Build();
			if (!string.IsNullOrEmpty(prefetchSourcesString))
				directives.Add($"prefetch-src {prefetchSourcesString}");

			string scriptSourcesString = ScriptSources.Build();
			if (!string.IsNullOrEmpty(scriptSourcesString))
				directives.Add($"script-src {scriptSourcesString}");

			string styleSourcesString = StyleSources.Build();
			if (!string.IsNullOrEmpty(scriptSourcesString))
				directives.Add($"script-src {scriptSourcesString}");

			string webrtcSourcesString = WebRtcSources.Build();
			if (!string.IsNullOrEmpty(webrtcSourcesString))
				directives.Add($"webrtc-src {webrtcSourcesString}");

			string workerSourcesString = WorkerSources.Build();
			if (!string.IsNullOrEmpty(workerSourcesString))
				directives.Add($"worker-src {workerSourcesString}");

			string baseUriString = BaseUri.Build();
			if (!string.IsNullOrEmpty(baseUriString))
				directives.Add($"base-uri {baseUriString}");

			string pluginTypesString = PluginTypes.Build();
			if (!string.IsNullOrEmpty(pluginTypesString))
				directives.Add($"plugin-types {pluginTypesString}");

            string sanboxOptionsString = Sandbox.Build();
            if (!string.IsNullOrEmpty(sanboxOptionsString))
                directives.Add($"sandbox {sanboxOptionsString}");

            string formActionString = FormAction.Build();
            if (!string.IsNullOrEmpty(formActionString))
                directives.Add($"form-action {formActionString}");

            string frameAncestors = FrameAncestors.Build();
            if (!string.IsNullOrEmpty(frameAncestors))
                directives.Add($"frame-ancestors {frameAncestors}");

            if (upgrateInsecureRequests)
                directives.Add("upgrade-insecure-requests");

            if (blockAllMixedContent)
                directives.Add("block-all-mixed-content");

            string requireSriForString = RequireSriFor.Build();
            if (!string.IsNullOrEmpty(requireSriForString))
                directives.Add($"require-sri-for {requireSriForString}");

            CspOptions options = new CspOptions {
                Content = string.Join("; ", directives)
			};

			return options;
		}
	}
}
