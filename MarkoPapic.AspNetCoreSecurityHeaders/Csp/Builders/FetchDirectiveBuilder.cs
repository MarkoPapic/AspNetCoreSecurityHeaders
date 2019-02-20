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

		public FetchDirectiveBuilder AllowNone() {
			noneAllowed = true;
			return this;
		}

		public FetchDirectiveBuilder AllowSelf()
		{
            string item = "'self'";
            if (!sourcesAllowed.Contains(item))
                sourcesAllowed.Add(item);
            return this;
        }

		public FetchDirectiveBuilder AllowAny() {
            allAllowed = true;
			return this;
		}

		public FetchDirectiveBuilder AllowHosts(params string[] hosts)
		{
			foreach(string host in hosts)
                if (!sourcesAllowed.Contains(host))
                    sourcesAllowed.Add(host);
            return this;
        }

		public FetchDirectiveBuilder AllowSchemas(params string[] schemas)
		{
			foreach(string schema in schemas)
                if (!sourcesAllowed.Contains(schema))
                    sourcesAllowed.Add(schema);
            return this;
		}

		public FetchDirectiveBuilder AllowUnsafeInline() {
            unsafeInlineAllowed = true;
			return this;
		}

		public FetchDirectiveBuilder AllowUnsafeEval()
		{
			unsafeEvalAllowed = true;
			return this;
		}

		public FetchDirectiveBuilder AllowNonce(ICspNonceService nonceService)
		{

			if (nonceService == null)
				throw new ArgumentNullException(nameof(nonceService));
			string nonce = nonceService.GetNonce();
			string item = $"'nonce-{nonce}'";
			if (!noncesAllowed.Contains(item))
				noncesAllowed.Add(item);
			return this;
		}

		public FetchDirectiveBuilder AllowHash(string item)
		{
			if (!hashesAllowed.Contains(item))
                hashesAllowed.Add(item);
			return this;
		}

        public FetchDirectiveBuilder AllowHash(string algorithm, string hashedSource)
        {
            string item = $"{algorithm}-{hashedSource}";
            if (!hashesAllowed.Contains(item))
                hashesAllowed.Add(item);
            return this;
        }

		public FetchDirectiveBuilder WithStrictDynamic()
		{
            withStrictDynamic = true;
			return this;
		}

		public FetchDirectiveBuilder ReportSample()
		{
			reportSample = true;
			return this;
		}

		internal string Build()
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
					parts.Add("*");
				else if (sourcesAllowed.Count > 0)
					parts.AddRange(sourcesAllowed);
				if (reportSample)
					parts.Add("'report-sample'");
			}

			return string.Join(" ", parts);
		}
	}
}
