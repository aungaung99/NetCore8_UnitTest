using FluentAssertions;

using Microsoft.AspNetCore.Mvc;

using NetCore8_UnitTest.APIs.Controllers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore8_UnitTest.APIs.Tests.Controllers
{
	public class AggregateControllerTest
	{
		private AggregateController _sut;
		public AggregateControllerTest()
		{
			_sut = new AggregateController();
		}

		[Theory]
		[InlineData(1, 2)]
		public void Sum_ShouldBeGreaterThanZero_WhereNatural(int a, int b)
		{
			var result = _sut.Sum(a, b);
			Assert.Equal(3, result);
			result.Should().NotBeNull();
			result.Should().BeAssignableTo<ActionResult<int>>();
			result.Result.Should().BeAssignableTo<OkObjectResult>();
		}
	}
}
