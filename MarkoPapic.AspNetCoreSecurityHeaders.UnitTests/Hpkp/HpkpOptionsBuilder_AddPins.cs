using MarkoPapic.AspNetCoreSecurityHeaders.Hpkp;
using Xunit;

namespace MarkoPapic.AspNetCoreSecurityHeaders.UnitTests.Hpkp
{
	public class HpkpOptionsBuilder_AddPins
	{
		[Fact]
		public void Called_PinsAdded()
		{
			//Arrange
			HpkpOptionsBuilder builder = new HpkpOptionsBuilder();
			string pin1 = "==somepinvalue";
			string pin2 = "==somepinvalue2";

			//Act
			builder.AddPins(pin1, pin2);

			//Assert
			HpkpOptions result = builder.Build();
			Assert.Equal(2, result.Pins.Count);
			Assert.Contains($"pin-sha256=\"{pin1}\"", result.Pins);
			Assert.Contains($"pin-sha256=\"{pin2}\"", result.Pins);
		}

		[Fact]
		public void DuplicatePinsAdded_DuplicatesOmitted()
		{
			//Arrange
			HpkpOptionsBuilder builder = new HpkpOptionsBuilder();
			string pin1 = "==somepinvalue";
			string pin2 = "==somepinvalue2";
			string pin3 = "==somepinvalue2";

			//Act
			builder.AddPins(pin1, pin2, pin3);

			//Assert
			HpkpOptions result = builder.Build();
			Assert.Equal(2, result.Pins.Count);
			Assert.Contains($"pin-sha256=\"{pin1}\"", result.Pins);
			Assert.Contains($"pin-sha256=\"{pin2}\"", result.Pins);
		}
	}
}
