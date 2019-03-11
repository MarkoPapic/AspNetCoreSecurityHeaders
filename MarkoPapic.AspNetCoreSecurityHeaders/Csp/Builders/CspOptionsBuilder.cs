using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Options;
using System;
using System.Collections.Generic;

namespace MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders
{
	/// <summary>
	/// Builder class for Content-Security-Policy header.
	/// </summary>
	public class CspOptionsBuilder
    {
        private bool blockAllMixedContent;
        private bool upgrateInsecureRequests;
		private ReportGroupOptions reportGroup;

		internal CspOptionsBuilder()
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

		/// <summary>
		/// Gets the builder for the 'connect-src' directive of the Content-Security-Policy header.
		/// </summary>
		/// <remarks>
		/// See: https://www.w3.org/TR/CSP/#directive-connect-src
		/// </remarks>
		public FetchDirectiveBuilder ConnectSources { get; }

		/// <summary>
		/// Gets the builder for the 'default-src' directive of the Content-Security-Policy header.
		/// </summary>
		/// <remarks>
		/// See: https://www.w3.org/TR/CSP/#directive-default-src
		/// </remarks>
		public FetchDirectiveBuilder DefaultSources { get; }

		/// <summary>
		/// Gets the builder for the 'font-src' directive of the Content-Security-Policy header.
		/// </summary>
		/// <remarks>
		/// See: https://www.w3.org/TR/CSP/#directive-font-src
		/// </remarks>
		public FetchDirectiveBuilder FontSources { get; }

		/// <summary>
		/// Gets the builder for the 'frame-src' directive of the Content-Security-Policy header.
		/// </summary>
		/// <remarks>
		/// See: https://www.w3.org/TR/CSP/#directive-frame-src
		/// </remarks>
		public FetchDirectiveBuilder FrameSources { get; }

		/// <summary>
		/// Gets the builder for the 'img-src' directive of the Content-Security-Policy header.
		/// </summary>
		/// <remarks>
		/// See: https://www.w3.org/TR/CSP/#directive-img-src
		/// </remarks>
		public FetchDirectiveBuilder ImgSources { get; }

		/// <summary>
		/// Gets the builder for the 'manifest-src' directive of the Content-Security-Policy header.
		/// </summary>
		/// <remarks>
		/// See: https://www.w3.org/TR/CSP/#directive-manifest-src
		/// </remarks>
		public FetchDirectiveBuilder ManifestSources { get; }

		/// <summary>
		/// Gets the builder for the 'media-src' directive of the Content-Security-Policy header.
		/// </summary>
		/// <remarks>
		/// See: https://www.w3.org/TR/CSP/#directive-media-src
		/// </remarks>
		public FetchDirectiveBuilder MediaSources { get; }

		/// <summary>
		/// Gets the builder for the 'object-src' directive of the Content-Security-Policy header.
		/// </summary>
		/// <remarks>
		/// See: https://www.w3.org/TR/CSP/#directive-object-src
		/// </remarks>
		public FetchDirectiveBuilder ObjectSources { get; }

		/// <summary>
		/// Gets the builder for the 'prefetch-src' directive of the Content-Security-Policy header.
		/// </summary>
		/// <remarks>
		/// See: https://www.w3.org/TR/CSP/#directive-prefetch-src
		/// </remarks>
		public FetchDirectiveBuilder PrefetchSources { get; }

		/// <summary>
		/// Gets the builder for the 'script-src' directive of the Content-Security-Policy header.
		/// </summary>
		/// <remarks>
		/// See: https://www.w3.org/TR/CSP/#directive-script-src
		/// </remarks>
		public FetchDirectiveBuilder ScriptSources { get; }

		/// <summary>
		/// Gets the builder for the 'style-src' directive of the Content-Security-Policy header.
		/// </summary>
		/// <remarks>
		/// See: https://www.w3.org/TR/CSP/#directive-style-src
		/// </remarks>
		public FetchDirectiveBuilder StyleSources { get; }

		/// <summary>
		/// Gets the builder for the 'webrtc-src' directive of the Content-Security-Policy header.
		/// </summary>
		public FetchDirectiveBuilder WebRtcSources { get; }

		/// <summary>
		/// Gets the builder for the 'worker-src' directive of the Content-Security-Policy header.
		/// </summary>
		/// <remarks>
		/// See: https://www.w3.org/TR/CSP/#directive-worker-src
		/// </remarks>
		public FetchDirectiveBuilder WorkerSources { get; }

		/// <summary>
		/// Gets the builder for the 'base-uri' directive of the Content-Security-Policy header.
		/// </summary>
		/// <remarks>
		/// See: https://www.w3.org/TR/CSP/#directive-base-uri
		/// </remarks>
		public BaseUriDirectiveBuilder BaseUri { get; }

		/// <summary>
		/// Gets the builder for the 'plugin-types' directive of the Content-Security-Policy header.
		/// </summary>
		/// <remarks>
		/// See: https://www.w3.org/TR/CSP/#directive-plugin-types
		/// </remarks>
		public PluginTypesBuilder PluginTypes { get; }

		/// <summary>
		/// Gets the builder for the 'sandbox' directive of the Content-Security-Policy header.
		/// </summary>
		/// <remarks>
		/// See: https://www.w3.org/TR/CSP/#directive-sandbox
		/// </remarks>
		public SandboxDirectiveBuilder Sandbox { get; }

		//TODO: disown-opener
		/// <summary>
		/// Gets the builder for the 'form-action' directive of the Content-Security-Policy header.
		/// </summary>
		/// <remarks>
		/// See: https://www.w3.org/TR/CSP/#directive-form-action
		/// </remarks>
		public FormActionDirectiveBuilder FormAction { get; }

		/// <summary>
		/// Gets the builder for the 'frame-ancestors' directive of the Content-Security-Policy header.
		/// </summary>
		/// <remarks>
		/// See: https://www.w3.org/TR/CSP/#directive-frame-ancestors
		/// </remarks>
		public FrameAncestorsDirectiveBuilder FrameAncestors { get; }

		//TODO: navigate-to
		/// <summary>
		/// Adds the 'block-all-mixed-content' directive of the Content-Security-Policy header.
		/// </summary>
		/// <remarks>
		/// See: https://www.w3.org/TR/mixed-content/
		/// </remarks>
		public void BlockAllMixedContent() => blockAllMixedContent = true;

		/// <summary>
		/// Gets the builder for the 'require-sri-for' directive of the Content-Security-Policy header.
		/// </summary>
		/// <remarks>
		/// See: https://www.w3.org/TR/SRI/
		/// </remarks>
		public RequireSriForDirectiveBuilder RequireSriFor { get; }

		/// <summary>
		/// Adds the 'upgrade-insecure-requests' directive of the Content-Security-Policy header.
		/// </summary>
		/// <remarks>
		/// See: https://www.w3.org/TR/CSP/#biblio-upgrade-insecure-requests
		/// </remarks>
		public void UpgradeInsecureRequests() => upgrateInsecureRequests = true;

		/// <summary>
		/// Adds the Report-To header.
		/// </summary>
		/// <param name="optionsAction">A delegate used for setting up the <see cref="ReportGroupOptions"/></param>
		/// <remarks>
		/// See: https://www.w3.org/TR/CSP/#directive-report-to
		/// See: https://w3c.github.io/reporting/#group
		/// </remarks>
		public void AddReportingGroup(Action<ReportGroupOptions> optionsAction)
		{
			ReportGroupOptions rg = new ReportGroupOptions();
			optionsAction(rg);
			reportGroup = rg;
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

			if (reportGroup != null)
				directives.Add($"report-to {reportGroup.Group}");

            CspOptions options = new CspOptions
            {
                Content = string.Join("; ", directives),
				ReportingGroup = reportGroup
            };

            return options;
        }
    }
}
