using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Options;
using System.Text;

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
			StringBuilder sb = new StringBuilder();

			string connectSourcesString = ConnectSources.Build();
			if (!string.IsNullOrEmpty(connectSourcesString))
				sb.Append($"connect-src {connectSourcesString}");

			string defaultResourcesString = DefaultSources.Build();
			if (!string.IsNullOrEmpty(defaultResourcesString))
				sb.Append($"default-src {defaultResourcesString}");

			string fontSourcesString = FontSources.Build();
			if (!string.IsNullOrEmpty(fontSourcesString))
				sb.Append($"font-src {fontSourcesString}");

			string frameSourcesString = FrameSources.Build();
			if (!string.IsNullOrEmpty(frameSourcesString))
				sb.Append($"frame-src {frameSourcesString}");

			string imgSourcesString = ImgSources.Build();
			if (!string.IsNullOrEmpty(imgSourcesString))
				sb.Append($"img-src {imgSourcesString}");

			string manifestSourcesString = ManifestSources.Build();
			if (!string.IsNullOrEmpty(manifestSourcesString))
				sb.Append($"manifest-src {manifestSourcesString}");

			string mediaSourcesString = MediaSources.Build();
			if (!string.IsNullOrEmpty(mediaSourcesString))
				sb.Append($"media-src {mediaSourcesString}");

			string objectSourcesString = ObjectSources.Build();
			if (!string.IsNullOrEmpty(objectSourcesString))
				sb.Append($"object-src {objectSourcesString}");

			string prefetchSourcesString = PrefetchSources.Build();
			if (!string.IsNullOrEmpty(prefetchSourcesString))
				sb.Append($"prefetch-src {prefetchSourcesString}");

			string scriptSourcesString = ScriptSources.Build();
			if (!string.IsNullOrEmpty(scriptSourcesString))
				sb.Append($"script-src {scriptSourcesString}");

			string styleSourcesString = StyleSources.Build();
			if (!string.IsNullOrEmpty(scriptSourcesString))
				sb.Append($"script-src {scriptSourcesString}");

			string webrtcSourcesString = WebRtcSources.Build();
			if (!string.IsNullOrEmpty(webrtcSourcesString))
				sb.Append($"webrtc-src {webrtcSourcesString}");

			string workerSourcesString = WorkerSources.Build();
			if (!string.IsNullOrEmpty(workerSourcesString))
				sb.Append($"worker-src {workerSourcesString}");

			string baseUriString = BaseUri.Build();
			if (!string.IsNullOrEmpty(baseUriString))
				sb.Append($"base-uri {baseUriString}");

			string pluginTypesString = PluginTypes.Build();
			if (!string.IsNullOrEmpty(pluginTypesString))
				sb.Append($"plugin-types {pluginTypesString}");

            string sanboxOptionsString = Sandbox.Build();
            if (!string.IsNullOrEmpty(sanboxOptionsString))
                sb.Append($"sandbox {sanboxOptionsString}");

            string formActionString = FormAction.Build();
            if (!string.IsNullOrEmpty(formActionString))
                sb.Append($"form-action {formActionString}");

            string frameAncestors = FrameAncestors.Build();
            if (!string.IsNullOrEmpty(frameAncestors))
                sb.Append($"frame-ancestors {frameAncestors}");

            if (upgrateInsecureRequests)
                sb.Append("upgrade-insecure-requests");

            if (blockAllMixedContent)
                sb.Append("block-all-mixed-content");

            string requireSriForString = RequireSriFor.Build();
            if (!string.IsNullOrEmpty(requireSriForString))
                sb.Append($"require-sri-for {requireSriForString}");

            CspOptions options = new CspOptions {
				Content = sb.ToString()
			};

			return options;
		}
	}
}
