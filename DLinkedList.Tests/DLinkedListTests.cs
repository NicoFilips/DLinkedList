using FluentAssertions;
using NUnit.Framework;

namespace DLinkedList.Tests;

[TestFixture]
public class DLinkedListTests
{
    private DLinkedList<int> _list;

    [SetUp]
    public void Setup() => _list = new DLinkedList<int>();

    [Test]
    public void AppendEnd_WhenListIsEmpty_ShouldSetFirstAndLastToTheSameNode()
    {
        // Arrange
        // Act
        _list.AppendEnd(10);

        // Assert
        _list.GetFirst().Data.Should().Be(10);
        _list.GetLast().Data.Should().Be(10);
    }

    [Test]
    public void AppendEnd_WhenListHasElements_ShouldAddNewNodeToTheEnd()
    {
        // Arrange
        _list.AppendEnd(10);
        _list.AppendEnd(20);

        // Act
        DLinkedListNode<int> lastNode = _list.GetLast();

        // Assert
        lastNode.Data.Should().Be(20);
        lastNode.Prev.Should().NotBeNull();
        lastNode.Prev?.Data.Should().Be(10);
    }

    [Test]
    public void AppendStart_WhenListIsEmpty_ShouldSetFirstAndLastToTheSameNode()
    {
        // Arrange
        // Act
        _list.AppendStart(10);

        // Assert
        _list.GetFirst().Data.Should().Be(10);
        _list.GetLast().Data.Should().Be(10);
    }

    [Test]
    public void AppendStart_WhenListHasElements_ShouldAddNewNodeToTheStart()
    {
        // Arrange
        _list.AppendEnd(20);
        _list.AppendStart(10);

        // Act
        DLinkedListNode<int> firstNode = _list.GetFirst();

        // Assert
        firstNode.Data.Should().Be(10);
        firstNode.Next.Should().NotBeNull();
        firstNode.Next?.Data.Should().Be(20);
    }

    [Test]
    public void PrintForward_WhenListHasElements_ShouldPrintNodesInCorrectOrder()
    {
        // Arrange
        _list.AppendEnd(10);
        _list.AppendEnd(20);
        _list.AppendEnd(30);

        // Act
        using var sw = new System.IO.StringWriter();
        Console.SetOut(sw);
        _list.PrintForward();
        string result = sw.ToString().Trim();

        // Assert
        result.Should().Be("10, 20, 30,");
    }

    [Test]
    public void PrintBackward_WhenListHasElements_ShouldPrintNodesInCorrectReverseOrder()
    {
        // Arrange
        _list.AppendEnd(10);
        _list.AppendEnd(20);
        _list.AppendEnd(30);

        // Act
        using var sw = new System.IO.StringWriter();
        Console.SetOut(sw);
        _list.PrintBackward();
        string result = sw.ToString().Trim();

        // Assert
        result.Should().Be("30, 20, 10,");
    }

    [Test]
    public void Delete_WhenNodeWithGivenDataExists_ShouldRemoveNodeFromList()
    {
        // Arrange
        _list.AppendEnd(10);
        _list.AppendEnd(20);
        _list.AppendEnd(30);

        // Act
        _list.Delete(20);

        // Assert
        _list.GetFirst().Data.Should().Be(10);
        _list.GetLast().Data.Should().Be(30);
        _list.GetFirst().Next?.Prev?.Data.Should().Be(10);
    }

    [Test]
    public void Delete_WhenMultipleNodesWithGivenDataExist_ShouldRemoveAllMatchingNodes()
    {
        // Arrange
        _list.AppendEnd(10);
        _list.AppendEnd(20);
        _list.AppendEnd(20);
        _list.AppendEnd(30);

        // Act
        _list.Delete(20);

        // Assert
        DLinkedListNode<int> firstNode = _list.GetFirst();
        firstNode.Data.Should().Be(10);
        _list.GetLast().Data.Should().Be(30);
        firstNode.Next?.Prev?.Data.Should().Be(10);
    }

    [Test]
    public void Delete_WhenDataNotFound_ShouldNotAlterTheList()
    {
        // Arrange
        _list.AppendEnd(10);
        _list.AppendEnd(20);
        _list.AppendEnd(30);

        // Act
        _list.Delete(40);

        // Assert
        _list.GetFirst().Data.Should().Be(10);
        _list.GetLast().Data.Should().Be(30);
    }
}
