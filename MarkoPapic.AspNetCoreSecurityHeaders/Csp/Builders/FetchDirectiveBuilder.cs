using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Contracts;
using System;
using System.Collections.Generic;

namespace MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders
{
	public class FetchDirectiveBuilder
	{
		protected bool noneAllowed;
		protected bool allAllowed;
		protected readonly ICollection<string> sourcesAllowed;
		protected bool unsafeEvalAllowed;
		protected bool unsafeInlineAllowed;
		protected bool withStrictDynamic;
		protected readonly ICollection<string> noncesAllowed;
		protected readonly ICollection<string> hashesAllowed;
		protected bool reportSample;

		public FetchDirectiveBuilder()
		{
			sourcesAllowed = new List<string>();
			noncesAllowed = new List<string>();
			hashesAllowed = new List<string>();
		}

		public FetchDirectiveBuilder Allow(string source) {
			FetchDirectiveBuilder result = this;
			if (source == "none" || source == "'none'")
				result = AllowNone();
			else if (source == "'*'")
				result = AllowNone();
			else if (!noneAllowed && !allAllowed)
				if (!sourcesAllowed.Contains(source))
					sourcesAllowed.Add(source);
			return result;
		}

		public FetchDirectiveBuilder AllowNone() {
			noneAllowed = true;
			allAllowed = false;
			unsafeEvalAllowed = false;
			unsafeInlineAllowed = false;
			sourcesAllowed.Clear();
			noncesAllowed.Clear();
			hashesAllowed.Clear();
			return this;
		}

		public FetchDirectiveBuilder AllowSelf()
		{
			return Allow("'self'");
		}

		public FetchDirectiveBuilder AllowAny() {
			if (!noneAllowed)
			{
				allAllowed = true;
				sourcesAllowed.Clear();
			}
			return this;
		}

		public FetchDirectiveBuilder AllowHosts(params string[] hosts)
		{
			string hostsMerged = string.Join(" ", hosts);
			return Allow(hostsMerged);
		}

		public FetchDirectiveBuilder AllowSchemas(params string[] schemas)
		{
			string schemasMerged = string.Join(" ", schemas);
			return Allow(schemasMerged);
		}

		public FetchDirectiveBuilder AllowUnsafeInline() {
			if (!noneAllowed)
				unsafeInlineAllowed = true;
			return this;
		}

		public FetchDirectiveBuilder AllowUnsafeEval()
		{
			if (!noneAllowed)
				unsafeEvalAllowed = true;
			return this;
		}

		public FetchDirectiveBuilder AllowNonce(ICspNonceService nonceService)
		{

			if (nonceService == null)
				throw new ArgumentNullException(nameof(nonceService));
			if (!noneAllowed)
			{
				string nonce = nonceService.GetNonce();
				string item = $"'nonce-{nonce}'";
				if (!noncesAllowed.Contains(item))
					noncesAllowed.Add(item);
			}
			return this;
		}

		public FetchDirectiveBuilder AllowHash(string item)
		{
			if (!noneAllowed)
				if (!hashesAllowed.Contains(item))
					hashesAllowed.Add(item);
			return this;
		}

		public FetchDirectiveBuilder AllowHash(string algorithm, string hashedSource)
		{
			if (!noneAllowed)
			{
				string item = $"{algorithm}-{hashedSource}";
				if (!hashesAllowed.Contains(item))
					hashesAllowed.Add(item);
			}
			return this;
		}

		public FetchDirectiveBuilder WithStrictDynamic()
		{
			if (!noneAllowed)
				withStrictDynamic = true;
			return this;
		}

		public FetchDirectiveBuilder ReportSample()
		{
			reportSample = true;
			return this;
		}

		public string Build()
		{
			List<string> parts = new List<string>();

			if (noneAllowed)
			{
				parts.Add("'none'");
			}
			else
			{
				if (unsafeEvalAllowed)
					parts.Add("'unsafe-eval'");
				if (unsafeInlineAllowed)
					parts.Add("'unsafe-inline'");
				if (withStrictDynamic)
					parts.Add("'strict-dynamic'");
				if (noncesAllowed.Count > 0)
					parts.AddRange(noncesAllowed);
				if (hashesAllowed.Count > 0)
					parts.AddRange(hashesAllowed);
				if (allAllowed)
					parts.Add("'*'");
				else if (sourcesAllowed.Count > 0)
					parts.AddRange(sourcesAllowed);
				if (reportSample)
					parts.Add("'report-sample'");
			}

			return string.Join(" ", parts);
		}
	}
}
