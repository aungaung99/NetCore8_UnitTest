using AutoFixture;

using FluentAssertions;

using Microsoft.AspNetCore.Mvc;

using Moq;

using NetCore8_UnitTest.APIs.Controllers;
using NetCore8_UnitTest.APIs.Entities;
using NetCore8_UnitTest.APIs.Interfaces;

namespace NetCore8_UnitTest.APIs.Tests.Controllers
{
	public class StatesControllerTest
	{
		private readonly IFixture _fixture;
		private readonly Mock<IRepositoryWrapper> _repoMock;
		private readonly StatesController _sut;

		public StatesControllerTest()
		{
			_fixture = new Fixture();
			_repoMock = _fixture.Freeze<Mock<IRepositoryWrapper>>();
			_sut = new StatesController(_repoMock.Object);

		}

		[Fact]
		public async Task GetListAsync_ShoundReturnOkResponse_WhenDataFound()
		{
			// Arrage
			IReadOnlyList<State> states = _fixture.Create<IReadOnlyList<State>>();
			_ = _repoMock.Setup(x => x.States.GetAsync()).ReturnsAsync(states);

			// Act
			ActionResult<IReadOnlyList<State>?> result = await _sut.GetListAsync();

			// Assert
			Assert.NotNull(result);
			_ = result.Should().NotBeNull();
			_ = result.Should().BeAssignableTo<ActionResult<IReadOnlyList<State>>?>();
			_ = result.Result.Should().BeAssignableTo<OkObjectResult>();
			_repoMock.Verify(x => x.States.GetAsync(), Times.Once());
		}

		[Fact]
		public async Task GetListAsync_ShouldReturnNotFoundResponse_WhenNotFound()
		{
			// Arrage
			IReadOnlyList<State>? states = null;
			_ = _repoMock.Setup(x => x.States.GetAsync()).ReturnsAsync(states);

			// Act
			ActionResult<IReadOnlyList<State>?> result = await _sut.GetListAsync();

			// Assert
			_ = result.Should().NotBeNull();
			_ = result.Result.Should().BeAssignableTo<NotFoundResult>();
			_repoMock.Verify(x => x.States.GetAsync(), Times.Once);
		}

		[Fact]
		public async Task GetByIdAsync_ShouldReturnOkResponse_WhenValidInput()
		{
			// Arrange
			State states = _fixture.Create<State>();
			int id = _fixture.Create<int>();
			_ = _repoMock.Setup(x => x.States.GetByIdAsync(id)).ReturnsAsync(states);

			// Act
			ActionResult<State?> result = await _sut.GetByIdAsync(id);

			// Assert
			_ = result.Should().NotBeNull();
			_ = result.Should().BeAssignableTo<ActionResult<State?>>();
			result.Result.Should().BeAssignableTo<OkObjectResult>();
			result.Result.As<OkObjectResult>().Value
				.Should()
				.NotBeNull()
				.And.BeOfType(states.GetType());
			_repoMock.Verify(x => x.States.GetByIdAsync(id), Times.Once);
		}

		[Fact]
		public async Task GetByIdAsync_ShouldReturnNotFoundResponse_WhereNoDataFound()
		{
			// Arrange
			State? state = null;
			var id = _fixture.Create<int>();
			_repoMock.Setup(x => x.States.GetByIdAsync(id)).ReturnsAsync(state);

			// Act
			var result = await _sut.GetByIdAsync(id);

			// Assert
			result.Should().NotBeNull();
			result.Result.Should().BeAssignableTo<NotFoundObjectResult>();
			_repoMock.Verify(x => x.States.GetByIdAsync(id), Times.Once);
		}
	}
}
