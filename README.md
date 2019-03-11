# MarkoPapic.AspNetCoreSecurityHeaders

[![Build Status](https://travis-ci.org/MarkoPapic/AspNetCoreSecurityHeaders.svg?branch=master)](https://travis-ci.org/MarkoPapic/AspNetCoreSecurityHeaders)

[![NuGet Version](https://img.shields.io/nuget/vpre/MarkoPapic.AspNetCoreSecurityHeaders.svg)](https://www.nuget.org/packages/MarkoPapic.AspNetCoreSecurityHeaders/)

A set of Asp.Net Core middlewares for adding security headers to ASP.NET Core web apps.

The library allows you to add the following HTTP security headers:

* `Content-Security-Policy`
* `Expect-CT`
* `Public-Key-Pins`
* `Referrer-Policy`
* `Strict-Transport-Security`
* `X-Content-Type-Options`
* `X-Frame-Options`
* `X-Permitted-Cross-Domain-Policies`
* `X-XSS-Protection`


## Installation

Visual Studio Package Manager Console:

```
Install-Package MarkoPapic.AspNetCoreSecurityHeaders -Version 0.1.0
```

dotnet CLI:

```
dotnet add package MarkoPapic.AspNetCoreSecurityHeaders --version 0.1.0
```


## Usage

You can add security headers by adding middlewares to your Asp.Net Core pipeline:

```cs
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
	app.UseXssProtection();
	//other middlewares
}
```


### Content-Security-Policy

You can add the `Content-Security-Policy` header using the `UseCsp` extension method:

```cs
app.UseCsp(x => {
	x.DefaultSources.AllowSelf();
	x.ScriptSources.AllowSelf().AllowHosts("https://example1.com", "https://example2.com");
	x.StyleSources.AllowHash("sha256", "Q0E0NTUyMzFGRTJFRUYyNkM1Mjg4ODJBREE0ODNDQTY2Mzc2OTYzQ0U2OUZDNEE5RjMyMDI0NzlGQjExNTgwMg==");
	x.FrameAncestors.AllowNone();
	x.PluginTypes.AllowMimeType("application/x-java-applet");
	x.AddReportingGroup(rg => {
		rg.Group = "examplegroup";
		rg.Endpoints.Add(new ReportGroupEndpoint("https://reportserver.com/report"));
		rg.IncludeSubdomains = true;
	});
});
```

The above example would result in the following HTTP headers being added to the HTTP response:
```
Content-Security-Policy: connect-src `self` https://example1.com https://example2.com; style-src sha256-Q0E0NTUyMzFGRTJFRUYyNkM1Mjg4ODJBREE0ODNDQTY2Mzc2OTYzQ0U2OUZDNEE5RjMyMDI0NzlGQjExNTgwMg==; plugin-types application/x-java-applet; frame-ancestors 'none'; report-to examplegroup

Report-To: {"group":"examplegroup","max_age":0,"include_subdomains":true,"endpoints":[{"url":"https://reportserver.com/report","priority":0,"weight":0}]}
```


#### connect-src Directive

You can set up the `connect-src` directive of the `Content-Security-Policy` header using the `ConnectSources` property of the `CspOptionsBuilder`:

```cs
app.UseCsp(x => {
	x.ConnectSources.AllowSelf().AllowHosts("https://example1.com", "https://example2.com");
});
```

You can use the following methods to set up the directive:

| Method  | Description |
| ------------- | ------------- |
| `AllowNone()`  | Sets the directive value to `none`.  |
| `AllowSelf()`  | Adds `self` to the directive value.  |
| `AllowAny()`  | Adds `*` to the directive value.  |
| `AllowHosts(params string[] hosts)`  | Adds host/s to the directive value.  |
| `AllowSchemas(params string[] schemas)`  | Adds schema/s to the directive value.  |
| `AllowUnsafeInline()`  | Adds `unsafe-inline` to the directive value.  |
| `AllowUnsafeEval()`  | Adds `unsafe-eval` to the directive value.  |
| `AllowNonce(ICspNonceService nonceService)`  | Adds the nonce (for specific inline scripts) to the directive value. You should provide the implementation of the `ICspNonceService` interface, that will be used to generate the nonce.  |
| `AllowHash(string item)`  | Adds the hash of the script or style to the directive value.  |
| `AllowHash(string algorithm, string hashedSource)`  | Adds the hash of the script or style to the directive value.  |
| `WithStrictDynamic()`  | Adds the `strict-dynamic` to the directive value.  |
| `ReportSample()`  | Adds the `report-sample` to the directive value.  |


#### default-src Directive

You can set up the `default-src` directive of the `Content-Security-Policy` header using the `DefaultSources` property of the `CspOptionsBuilder`. The setup is the same as for `connect-src` directive (and any other fetch directive).


#### font-src Directive

You can set up the `font-src` directive of the `Content-Security-Policy` header using the `FontSources` property of the `CspOptionsBuilder`. The setup is the same as for `connect-src` directive (and any other fetch directive).


#### frame-src Directive

You can set up the `frame-src` directive of the `Content-Security-Policy` header using the `FrameSources` property of the `CspOptionsBuilder`. The setup is the same as for `connect-src` directive (and any other fetch directive).


#### img-src Directive

You can set up the `img-src` directive of the `Content-Security-Policy` header using the `ImgSources` property of the `CspOptionsBuilder`. The setup is the same as for `connect-src` directive (and any other fetch directive).


#### manifest-src Directive

You can set up the `manifest-src` directive of the `Content-Security-Policy` header using the `ManifestSources` property of the `CspOptionsBuilder`. The setup is the same as for `connect-src` directive (and any other fetch directive).


#### media-src Directive

You can set up the `media-src` directive of the `Content-Security-Policy` header using the `MediaSources` property of the `CspOptionsBuilder`. The setup is the same as for `connect-src` directive (and any other fetch directive).


#### object-src Directive

You can set up the `object-src` directive of the `Content-Security-Policy` header using the `ObjectSources` property of the `CspOptionsBuilder`. The setup is the same as for `connect-src` directive (and any other fetch directive).


#### prefetch-src Directive

You can set up the `prefetch-src` directive of the `Content-Security-Policy` header using the `PrefetchSources` property of the `CspOptionsBuilder`. The setup is the same as for `connect-src` directive (and any other fetch directive).


#### script-src Directive

You can set up the `script-src` directive of the `Content-Security-Policy` header using the `ScriptSources` property of the `CspOptionsBuilder`. The setup is the same as for `connect-src` directive (and any other fetch directive).


#### style-src Directive

You can set up the `style-src` directive of the `Content-Security-Policy` header using the `StyleSources` property of the `CspOptionsBuilder`. The setup is the same as for `connect-src` directive (and any other fetch directive).


#### webrtc-src Directive

You can set up the `webrtc-src` directive of the `Content-Security-Policy` header using the `WebRtcSources` property of the `CspOptionsBuilder`. The setup is the same as for `connect-src` directive (and any other fetch directive).


#### worker-src Directive

You can set up the `worker-src` directive of the `Content-Security-Policy` header using the `WorkerSources` property of the `CspOptionsBuilder`. The setup is the same as for `connect-src` directive (and any other fetch directive).


#### base-uri Directive

You can set up the `base-uri` directive of the `Content-Security-Policy` header using the `BaseUri` property of the `CspOptionsBuilder`:

```cs
app.UseCsp(x => {
	x.BaseUri.AllowSelf().AllowHosts("https://example1.com", "https://example2.com");
});
```

You can use the following methods to set up the directive:

| Method  | Description |
| ------------- | ------------- |
| `AllowNone()`  | Sets the directive value to `none`.  |
| `AllowSelf()`  | Adds `self` to the directive value.  |
| `AllowAny()`  | Adds `*` to the directive value.  |
| `AllowHosts(params string[] hosts)`  | Adds host/s to the directive value.  |
| `AllowSchemas(params string[] schemas)`  | Adds schema/s to the directive value.  |
| `AllowUnsafeInline()`  | Adds `unsafe-inline` to the directive value.  |
| `AllowUnsafeEval()`  | Adds `unsafe-eval` to the directive value.  |
| `AllowNonce(ICspNonceService nonceService)`  | Adds the nonce (for specific inline scripts) to the directive value. You should provide the implementation of the `ICspNonceService` interface, that will be used to generate the nonce.  |
| `AllowHash(string item)`  | Adds the hash of the script or style to the directive value.  |
| `AllowHash(string algorithm, string hashedSource)`  | Adds the hash of the script or style to the directive value.  |
| `WithStrictDynamic()`  | Adds the `strict-dynamic` to the directive value.  |
| `ReportSample()`  | Adds the `report-sample` to the directive value.  |


#### plugin-types Directive

You can set up the `plugin-types` directive of the `Content-Security-Policy` header using the `PluginTypes` property of the `CspOptionsBuilder`:

```cs
app.UseCsp(x => {
	x.PluginTypes.AllowMimeType("application/x-java-applet");
});
```

You can use the following methods to set up the directive:

| Method  | Description |
| ------------- | ------------- |
| `AllowNone()`  | Sets the directive value to `none`.  |
| `AllowAny()`  | Sets the directive value to `*`.  |
| `AllowMimeType(string mimeType)`  | Adds the specified MIME type to the directive value.  |


#### sandbox Directive

You can set up the `sandbox` directive of the `Content-Security-Policy` header using the `Sandbox` property of the `CspOptionsBuilder`:

```cs
app.UseCsp(x => {
	x.Sandbox.AllowPopups();
});
```

You can use the following methods to set up the directive:

| Method  | Description |
| ------------- | ------------- |
| `AllowNone()`  | Sets the directive value to `none`.  |
| `AllowAny()`  | Sets the directive value to `*`.  |
| `AllowForms()`  | Adds `allow-forms` to the directive value.  |
| `AllowModals()`  | Adds `allow-modals` to the directive value.  |
| `AllowOrientationLock()`  | Adds `allow-orientation-lock` to the directive value.  |
| `AllowPointerLock()`  | Adds `allow-pointer-lock` to the directive value.  |
| `AllowPopups()`  | Adds `allow-popups` to the directive value.  |
| `AllowPopupsToEscapeSandbox()`  | Adds `allow-popups-to-escape-sandbox` to the directive value.  |
| `AllowPresentation()`  | Adds `allow-presentation` to the directive value.  |
| `AllowSameOrigin()`  | Adds `allow-same-origin` to the directive value.  |
| `AllowScripts()`  | Adds `allow-scripts` to the directive value.  |
| `AllowTopNavigation()`  | Adds `allow-top-navigation` to the directive value.  |


#### form-action Directive

You can set up the `form-action` directive of the `Content-Security-Policy` header using the `FormAction` property of the `CspOptionsBuilder`:

```cs
app.UseCsp(x => {
	x.FormAction.AllowSelf().AllowHosts("https://example1.com", "https://example2.com");
});
```

You can use the following methods to set up the directive:

| Method  | Description |
| ------------- | ------------- |
| `AllowNone()`  | Sets the directive value to `none`.  |
| `AllowSelf()`  | Adds `self` to the directive value.  |
| `AllowAny()`  | Adds `*` to the directive value.  |
| `AllowHosts(params string[] hosts)`  | Adds host/s to the directive value.  |
| `AllowSchemas(params string[] schemas)`  | Adds schema/s to the directive value.  |
| `AllowUnsafeInline()`  | Adds `unsafe-inline` to the directive value.  |
| `AllowUnsafeEval()`  | Adds `unsafe-eval` to the directive value.  |
| `AllowNonce(ICspNonceService nonceService)`  | Adds the nonce (for specific inline scripts) to the directive value. You should provide the implementation of the `ICspNonceService` interface, that will be used to generate the nonce.  |
| `AllowHash(string item)`  | Adds the hash of the script or style to the directive value.  |
| `AllowHash(string algorithm, string hashedSource)`  | Adds the hash of the script or style to the directive value.  |
| `WithStrictDynamic()`  | Adds the `strict-dynamic` to the directive value.  |
| `ReportSample()`  | Adds the `report-sample` to the directive value.  |


#### frame-ancestor Directive

You can set up the `frame-ancestor` directive of the `Content-Security-Policy` header using the `FrameAncestors` property of the `CspOptionsBuilder`:

```cs
app.UseCsp(x => {
	x.FrameAncestors.AllowSelf().AllowHosts("https://example1.com", "https://example2.com");
});
```

You can use the following methods to set up the directive:

| Method  | Description |
| ------------- | ------------- |
| `AllowNone()`  | Sets the directive value to `none`.  |
| `AllowSelf()`  | Adds `self` to the directive value.  |
| `AllowAny()`  | Adds `*` to the directive value.  |
| `AllowHosts(params string[] hosts)`  | Adds host/s to the directive value.  |
| `AllowSchemas(params string[] schemas)`  | Adds schema/s to the directive value.  |


#### block-all-mixed-content Directive

You can set up the `block-all-mixed-content` directive of the `Content-Security-Policy` header by calling the `BlockAllMixedContent()` method of the `CspOptionsBuilder`:

```cs
app.UseCsp(x => {
	x.BlockAllMixedContent();
});
```

This method will add the `block-all-mixed-content` directive to the `Content-Security-Policy` header.


#### require-sri-for Directive

You can add the `require-sri-for` directive to the `Content-Security-Policy` header using the `RequireSriFor` property of the `CspOptionsBuilder`:

```cs
app.UseCsp(x => {
	x.RequireSriFor.Script();
});
```

You can use the following methods to set up the directive:

| Method  | Description |
| ------------- | ------------- |
| `Script()`  | Sets the directive value to `script`.  |
| `Style()`  | Sets the directive value to `style`.  |
| `ScriptStyle()`  | Sets the directive value to `script style`.  |


#### upgrade-insecure-requests Directive

You can add the `upgrade-insecure-requests` directive to the 'Content-Security-Policy' header by calling the `UpgradeInsecureRequests()` method of the `CspOptionsBuilder`:

```cs
app.UseCsp(x => {
	x.UpgradeInsecureRequests();
});
```

This method will add the `upgrade-insecure-requests` directive to the `Content-Security-Policy` header.


#### report-to Directive

You can add the [reporting group](https://w3c.github.io/reporting/) for your Content Security Policy by calling the `AddReportingGroup(Action<ReportGroupOptions> optionsAction)` method of the `CspOptionsBuilder`:

```cs
app.UseCsp(x => {
	// ...
	x.AddReportingGroup(rg => {
		rg.Group = "examplegroup";
		rg.Endpoints.Add(new ReportGroupEndpoint("https://reportserver.com/report"));
		rg.IncludeSubdomains = true;
	});
});
```

This will add the appropriate `report-to` directive to the `Content-Security-Policy` header, as well as the `Report-To` header.


### Expect-CT

You can add the `Expect-CT` header using the `UseExpectCt` extension method:

```cs
app.UseExpectCt(x => x.SetMaxAge(TimeSpan.FromDays(1)).Enforce());
```

The above example would result in the following HTTP header being added to the HTTP response:

```
Expect-CT: enforce, max-age=86400
```


#### max-age Directive

You can set the `max-age` directive to the 'Expect-CT' header by calling the `SetMaxAge(TimeSpan maxAge)` method of the `ExpectCtOptionsBuilder`:

```cs
app.UseExpectCt(x => x.SetMaxAge(TimeSpan.FromDays(2)));
```

The default value for the `max-age` directive is 1 day.


#### enforce Directive

You can add the `enforce` directive to the 'Expect-CT' header by calling the `Enforce()` method of the `ExpectCtOptionsBuilder`:

```cs
app.UseExpectCt(x => x.Enforce());
```


#### report-uri Directive

You can add the `report-uri` directive to the 'Expect-CT' header by calling the `SetReportUri(string reportUri)` method of the `ExpectCtOptionsBuilder`:

```cs
app.UseExpectCt(x => x.SetReportUri("https://reportserver.com/uri"));
```


### Public-Key-Pins

You can add the `Public-Key-Pins` header using the `UseExpectCt` extension method:

```cs
app.UseHpkp(x => x.AddPins("VGhpcyBpcyBzb21lIFN1YmplY3QgUHVibGljIEtleSBJbmZvcm1hdGlvbiBmaW5nZXJwcmludC4=", "QW5kIGFub3RoZXIgU3ViamVjdCBQdWJsaWMgS2V5IEluZm9ybWF0aW9uIGZpbmdlcnByaW50Lg==")
				.SetMaxAge(TimeSpan.FromHours(3))
				.IncludeSubdomains());
```

The above example would result in the following HTTP header being added to the HTTP response:

```
Public-Key-Pins: pin-sha256="VGhpcyBpcyBzb21lIFN1YmplY3QgUHVibGljIEtleSBJbmZvcm1hdGlvbiBmaW5nZXJwcmludC4="; pin-sha256="QW5kIGFub3RoZXIgU3ViamVjdCBQdWJsaWMgS2V5IEluZm9ybWF0aW9uIGZpbmdlcnByaW50Lg=="; max-age=10800; includeSubDomains
```


#### Adding Pins

You can add pins to the `Public-Key-Pins` header by calling the `AddPins(params string[] pins)` method of the `HpkpOptionsBuilder`:

```cs
app.UseHpkp(x => x.AddPins("VGhpcyBpcyBzb21lIFN1YmplY3QgUHVibGljIEtleSBJbmZvcm1hdGlvbiBmaW5nZXJwcmludC4="));
```


#### max-age Directive

You can set the `max-age` directive to the `Public-Key-Pins` header by calling the `SetMaxAge(TimeSpan maxAge)` method of the `HpkpOptionsBuilder`:

```cs
app.UseHpkp(x => x.AddPins("VGhpcyBpcyBzb21lIFN1YmplY3QgUHVibGljIEtleSBJbmZvcm1hdGlvbiBmaW5nZXJwcmludC4=", "QW5kIGFub3RoZXIgU3ViamVjdCBQdWJsaWMgS2V5IEluZm9ybWF0aW9uIGZpbmdlcnByaW50Lg==")
				.SetMaxAge(TimeSpan.FromHours(3)));
```

The default value for the `max-age` directive is 5 hours.


#### includeSubDomains Directive

You can add the `includeSubDomains` directive to the `Public-Key-Pins` header by calling the `IncludeSubdomains()` method of the `HpkpOptionsBuilder`:

```cs
app.UseHpkp(x => x.AddPins("VGhpcyBpcyBzb21lIFN1YmplY3QgUHVibGljIEtleSBJbmZvcm1hdGlvbiBmaW5nZXJwcmludC4=", "QW5kIGFub3RoZXIgU3ViamVjdCBQdWJsaWMgS2V5IEluZm9ybWF0aW9uIGZpbmdlcnByaW50Lg==")
				.IncludeSubdomains());
```


#### report-to Directive

You can add the [reporting group](https://w3c.github.io/reporting/) for your Public Key Pinning Extension by calling the `AddReportingGroup(Action<ReportGroupOptions> optionsAction)` method of the `HpkpOptionsBuilder`:

```cs
app.UseHpkp(x => {
	// ...
	x.AddReportingGroup(rg => {
		rg.Group = "examplegroup";
		rg.Endpoints.Add(new ReportGroupEndpoint("https://reportserver.com/report"));
		rg.IncludeSubdomains = true;
	});
});
```

This will add the appropriate `report-to` directive to the `Public-Key-Pins` header, as well as the `Report-To` header.


### Referrer-Policy

You can add the `Referrer-Policy` header using the `UseReferrerPolicy` extension method:

```cs
app.UseReferrerPolicy(ReferrerPolicyOptions.SameOrigin);
```

The above example would result in the following HTTP header being added to the HTTP response:

```
Referrer-Policy: same-origin
```

The `ReferrerPolicyOptions` enum supports the following values:

| Value  | Description |
| ------------- | ------------- |
| `NoReferrerWhenDowngrade`  | Sets the directive value to `no-referrer-when-downgrade`.  |
| `NoReferrer`  | Sets the directive value to `no-referrer`.  |
| `Origin`  | Sets the directive value to `origin`.  |
| `OriginWhenCrossOrigin`  | Sets the directive value to `origin-when-cross-origin`.  |
| `SameOrigin`  | Sets the directive value to `same-origin`.  |
| `StrictOrigin`  | Sets the directive value to `strict-origin`.  |
| `StrictOriginWhenCrossOrigin`  | Sets the directive value to `strict-origin-when-cross-origin`.  |
| `UnsafeUrl`  | Sets the directive value to `unsafe-url`.  |


### Strict-Transport-Security

You can add the `Strict-Transport-Security` header using the `UseHsts` extension method:

```cs
app.UseHsts();
```

The above example would result in the following HTTP header being added to the HTTP response:

```
Strict-Transport-Security: max-age=2592000
```


#### max-age Directive

You can set the `max-age` directive to the `Strict-Transport-Security` header by setting the `MaxAge` property of the `HstsOptions`:

```cs
app.UseHsts(x => { x.MaxAge = TimeSpan.FromDays(20); });
```

The default value for the `max-age` directive is 30 days.


#### includeSubDomains Directive

You can add the `includeSubDomains` directive to the `Strict-Transport-Security` header by setting the `IncludeSubDomains` property of the `HstsOptions`:

```cs
app.UseHsts(x => { x.IncludeSubDomains = true; });
```


#### preload Directive

You can add the `preload` directive to the `Strict-Transport-Security` header by setting the `Preload` property of the `HstsOptions`:

```cs
app.UseHsts(x => { x.Preload = true; });
```


### X-Content-Type-Options

Documentation in progress.


### X-Frame-Options

Documentation in progress.


### X-Permitted-Cross-Domain-Policies

Documentation in progress.


### X-XSS-Protection

Documentation in progress.


## Building From Source

```
git clone https://github.com/MarkoPapic/AspNetCoreSecurityHeaders.git
cd AspNetCoreSecurityHeaders
dotnet restore
dotnet build ./MarkoPapic.AspNetCoreSecurityHeaders.sln
dotnet test ./MarkoPapic.AspNetCoreSecurityHeaders.UnitTests/
```


## License

[MIT License](https://github.com/MarkoPapic/AspNetCoreSecurityHeaders/blob/master/LICENSE.txt)