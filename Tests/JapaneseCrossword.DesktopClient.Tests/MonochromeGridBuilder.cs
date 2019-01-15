using Xunit;

namespace JapaneseCrossword.DesktopClient.Tests
{
    public class MonochromeGridBuilderTests
    {
        private MonochromeGridBuilder _gridBuilder;

        public MonochromeGridBuilderTests()
        {
            var gridSlot = new Grid();
            _gridBuilder = new MonochromeGridBuilder();
        }

        [Fact]
        public void GenerateCellsDataTest()
        {
            _gridBuilder.GenerateCellData();
            Assert.NotNull(_gridBuilder.GridData);
        }

        [Fact]
        public void FillCellsTest()
        {
            _gridBuilder.GenerateCellData();
            _gridBuilder.FillCells();
        }

        [Fact]
        public void ClearTest()
        {
            _gridBuilder.GenerateCellData();
            _gridBuilder.FillCells();
            _gridBuilder.Clear();
        }
    }
}
