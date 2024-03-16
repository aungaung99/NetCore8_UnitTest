using AutoFixture;

using Microsoft.EntityFrameworkCore;

using Moq;

using NetCore8_UnitTest.APIs.Controllers;
using NetCore8_UnitTest.APIs.Data;
using NetCore8_UnitTest.APIs.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore8_UnitTest.APIs.Tests.Controllers
{
	public class StatesControllerTest
	{
		private readonly IFixture _fixture;
		private readonly Mock<NetCoreDemoDbContext> _dbMock;
		private readonly StatesController _sut;

		public StatesControllerTest()
		{
			_fixture = new Fixture();
			_dbMock = _fixture.Freeze<Mock<NetCoreDemoDbContext>>();
			_sut = new StatesController(_dbMock.Object);

		}

		[Fact]
		public async Task GetListAsync_ShoundReturnOkReponse_WhenDataFound()
		{
			// Arrage
			var states = _fixture.Create<IEnumerable<State>>();
			_dbMock.Setup(x => x.Streets.AsAsyncEnumerable()).ReturnsAsync(states);
			// Act

			// Assert
		}
	}
}
