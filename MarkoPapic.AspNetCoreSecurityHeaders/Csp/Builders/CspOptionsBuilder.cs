using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Options;
using System;
using System.Collections.Generic;

namespace MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders
{
    public class CspOptionsBuilder
    {
        private bool blockAllMixedContent;
        private bool upgrateInsecureRequests;
		private ReportGroupOptions reportingGroup;

		public CspOptionsBuilder()
        {
            ConnectSources = new FetchDirectiveBuilder();
            DefaultSources = new FetchDirectiveBuilder();
            FontSources = new FetchDirectiveBuilder();
            FrameSources = new FetchDirectiveBuilder();
            ImgSources = new FetchDirectiveBuilder();
            ManifestSources = new FetchDirectiveBuilder();
            MediaSources = new FetchDirectiveBuilder();
            ObjectSources = new FetchDirectiveBuilder();
            PrefetchSources = new FetchDirectiveBuilder();
            ScriptSources = new FetchDirectiveBuilder();
            StyleSources = new FetchDirectiveBuilder();
            WebRtcSources = new FetchDirectiveBuilder();
            WorkerSources = new FetchDirectiveBuilder();
            BaseUri = new BaseUriDirectiveBuilder();
            PluginTypes = new PluginTypesBuilder();
            Sandbox = new SandboxDirectiveBuilder();
            FormAction = new FormActionDirectiveBuilder();
            FrameAncestors = new FrameAncestorsDirectiveBuilder();
            RequireSriFor = new RequireSriForDirectiveBuilder();
        }

        public FetchDirectiveBuilder ConnectSources { get; }
        public FetchDirectiveBuilder DefaultSources { get; }
        public FetchDirectiveBuilder FontSources { get; }
        public FetchDirectiveBuilder FrameSources { get; }
        public FetchDirectiveBuilder ImgSources { get; }
        public FetchDirectiveBuilder ManifestSources { get; }
        public FetchDirectiveBuilder MediaSources { get; }
        public FetchDirectiveBuilder ObjectSources { get; }
        public FetchDirectiveBuilder PrefetchSources { get; }
        public FetchDirectiveBuilder ScriptSources { get; }
        public FetchDirectiveBuilder StyleSources { get; }
        public FetchDirectiveBuilder WebRtcSources { get; }
        public FetchDirectiveBuilder WorkerSources { get; }
        public BaseUriDirectiveBuilder BaseUri { get; }
        public PluginTypesBuilder PluginTypes { get; }
        public SandboxDirectiveBuilder Sandbox { get; }
        //TODO: disown-opener
        public FormActionDirectiveBuilder FormAction { get; }
        public FrameAncestorsDirectiveBuilder FrameAncestors { get; }
        //TODO: navigate-to
        //TODO: report-to
        public void BlockAllMixedContent() => blockAllMixedContent = true;
        public RequireSriForDirectiveBuilder RequireSriFor { get; }
        public void UpgradeInsecureRequests() => upgrateInsecureRequests = true;
		public void AddReportingGroup(Action<ReportGroupOptions> optionsAction)
		{
			var rg = new ReportGroupOptions();
			optionsAction(rg);
			reportingGroup = rg;
		}

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
            if (!string.IsNullOrEmpty(styleSourcesString))
                directives.Add($"style-src {styleSourcesString}");

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

			if (reportingGroup != null)
				directives.Add($"report-to {reportingGroup.Group}");

            CspOptions options = new CspOptions
            {
                Content = string.Join("; ", directives),
				ReportingGroup = reportingGroup
            };

            return options;
        }
    }
}
