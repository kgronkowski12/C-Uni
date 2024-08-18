namespace RPNTest;

[TestFixture]
public class RpnTest {
    private Rpn _sut;
    [SetUp]
    public void Setup() {
        _sut = new Rpn();
    }
    [Test]
    public void CheckIfTestWorks() {
        Assert.Pass();
    }

    [Test]
    public void CheckIfCanCreateSut() {
        Assert.That(_sut, Is.Not.Null);
    }

    [Test]
    public void SingleDigitOneInputOneReturn() {
        var result = _sut.EvalRpn("D1");

        Assert.That(result, Is.EqualTo(1));

    }
    [Test]
    public void SingleDigitOtherThenOneInputNumberReturn() {
        var result = _sut.EvalRpn("D2");

        Assert.That(result, Is.EqualTo(2));

    }
    [Test]
    public void TwoDigitsNumberInputNumberReturn() {
        var result = _sut.EvalRpn("D12");

        Assert.That(result, Is.EqualTo(12));

    }
    [Test]
    public void TwoNumbersGivenWithoutOperator_ThrowsExcepton() {
        Assert.Throws<InvalidOperationException>(() => _sut.EvalRpn("D1 D2"));

    }
    [Test]
    public void OperatorPlus_AddingTwoNumbers_ReturnCorrectResult() {
        var result = _sut.EvalRpn("D1 D2 +");

        Assert.That(result, Is.EqualTo(3));
    }
    [Test]
    public void OperatorTimes_AddingTwoNumbers_ReturnCorrectResult() {
        var result = _sut.EvalRpn("D2 D2 *");

        Assert.That(result, Is.EqualTo(4));
    }
    [Test]
    public void OperatorMinus_SubstractingTwoNumbers_ReturnCorrectResult() {
        var result = _sut.EvalRpn("D1 D2 -");

        Assert.That(result, Is.EqualTo(1));
    }
    [Test]
    public void ComplexExpression() {
        var result = _sut.EvalRpn("D15 D7 D1 D1 + - / D3 * D2 D1 D1 + + -");

        Assert.That(result, Is.EqualTo(4));
    }
    [Test]
    public void DivisionTest()
    {
        var result = _sut.EvalRpn("D2 D6 /");

        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void DivideByZero()
    {
        Assert.Throws<InvalidOperationException>(() => _sut.EvalRpn("D0 D5 /"));
    }

    [Test]
    public void FactorialTest()
    {
        var result = _sut.EvalRpn("D5 !");

        Assert.That(result, Is.EqualTo(120));
    }

    [Test]
    public void AbsoluteValTest()
    {
        var result = _sut.EvalRpn("D-5 |");

        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void AbsoluteValTest2()
    {
        var result = _sut.EvalRpn("D7 |");

        Assert.That(result, Is.EqualTo(7));
    }

    [Test]
    public void BinaryTest()
    {
        var result = _sut.EvalRpn("B101 B1 +");

        Assert.That(result, Is.EqualTo(6));
    }
    [Test]
    public void BinaryTest2()
    {
        var result = _sut.EvalRpn("B101 B101 +");

        Assert.That(result, Is.EqualTo(10));
    }
    [Test]
    public void HexTest()
    {
        var result = _sut.EvalRpn("#AB");

        Assert.That(result, Is.EqualTo(171));
    }
    [Test]
    public void MixedTest()
    {
        var result = _sut.EvalRpn("#BA D13 +");

        Assert.That(result, Is.EqualTo(199));
    }
    [Test]
    public void NoNumberType()
    {
        Assert.Throws<InvalidOperationException>(() => _sut.EvalRpn("15"));
    }
}