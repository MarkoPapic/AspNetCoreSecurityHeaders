using MarkoPapic.AspNetCoreSecurityHeaders.Csp.Contracts;
using System;
using System.Collections.Generic;

namespace MarkoPapic.AspNetCoreSecurityHeaders.Csp.Builders
{
	/// <summary>
	/// Builder class for Content-Security-Policy header fetch directives.
	/// </summary>
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

		/// <summary>
		/// Sets the directive value to 'none'.
		/// </summary>
		public FetchDirectiveBuilder AllowNone() {
			noneAllowed = true;
			return this;
		}

		/// <summary>
		/// Adds 'self' to the directive value.
		/// </summary>
		public FetchDirectiveBuilder AllowSelf()
		{
            string item = "'self'";
            if (!sourcesAllowed.Contains(item))
                sourcesAllowed.Add(item);
            return this;
        }

		/// <summary>
		/// Adds * to the directive value.
		/// </summary>
		public FetchDirectiveBuilder AllowAny() {
            allAllowed = true;
			return this;
		}

		/// <summary>
		/// Adds host/s to the directive value.
		/// </summary>
		/// <param name="hosts">Host/s to be allowed.</param>
		public FetchDirectiveBuilder AllowHosts(params string[] hosts)
		{
			foreach(string host in hosts)
                if (!sourcesAllowed.Contains(host))
                    sourcesAllowed.Add(host);
            return this;
        }

		/// <summary>
		/// Adds schema/s to the directive value.
		/// </summary>
		/// <param name="schemas">Schema's to be allowed.</param>
		public FetchDirectiveBuilder AllowSchemas(params string[] schemas)
		{
			foreach(string schema in schemas)
                if (!sourcesAllowed.Contains(schema))
                    sourcesAllowed.Add(schema);
            return this;
		}

		/// <summary>
		/// Adds 'unsafe-inline' to the directive value.
		/// </summary>
		public FetchDirectiveBuilder AllowUnsafeInline() {
            unsafeInlineAllowed = true;
			return this;
		}

		/// <summary>
		/// Adds 'unsafe-eval' to the directive value.
		/// </summary>
		public FetchDirectiveBuilder AllowUnsafeEval()
		{
			unsafeEvalAllowed = true;
			return this;
		}

		/// <summary>
		/// Adds the nonce (for specific inline scripts) to the directive value.
		/// </summary>
		/// <param name="nonceService">Service for generating the nonce.</param>
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

		/// <summary>
		/// Adds the hash of the script or style to the directive value.
		/// </summary>
		/// <param name="item">Directive value in '<hash-algorithm>-<base64-value>' format.</param>
		public FetchDirectiveBuilder AllowHash(string item)
		{
			if (!hashesAllowed.Contains(item))
                hashesAllowed.Add(item);
			return this;
		}

		/// <summary>
		/// Adds the hash of the script or style to the directive value.
		/// </summary>
		/// <param name="algorithm">String representing the encryption algorithm used to chreate the hash.</param>
		/// <param name="hashedSource">Base64-encoded hash of the script or style.</param>
		public FetchDirectiveBuilder AllowHash(string algorithm, string hashedSource)
        {
            string item = $"{algorithm}-{hashedSource}";
            if (!hashesAllowed.Contains(item))
                hashesAllowed.Add(item);
            return this;
        }

		/// <summary>
		/// Adds the 'strict-dynamic' to the directive value.
		/// </summary>
		public FetchDirectiveBuilder WithStrictDynamic()
		{
            withStrictDynamic = true;
			return this;
		}

		/// <summary>
		/// Adds the 'report-sample' to the directive value.
		/// </summary>
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
